/***************************************************************************
 *   InputManager.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region usings
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using UltimaXNA.Core.Windows;
using Microsoft.Xna.Framework.Input;
#endregion

namespace UltimaXNA.Core.Input
{
    public class InputManager
    {
        private double m_LastMouseMove;
        private double m_LastUpdateTime;

        private MouseState m_MouseState;
        private List<InputEventMouse> m_MouseEvents;

        private KeyboardState m_KeyboardState;
        private List<InputEventKeyboard> m_KeyboardEvents;

        public InputManager(IntPtr handle)
        {
            m_MouseState = Mouse.GetState();
            m_MouseEvents = new List<InputEventMouse>();

            m_KeyboardState = Keyboard.GetState();
            m_KeyboardEvents = new List<InputEventKeyboard>();
        }

        public void Dispose()
        {
        }

        public bool IsCtrlDown
        {
            get
            {
                return false;
            }
        }

        public bool IsShiftDown
        {
            get
            {
                return false;
            }
        }

        public int MouseStationaryTimeMS
        {
            get { return (int)(m_LastUpdateTime - m_LastMouseMove); }
        }

        public Point MousePosition
        {
            get
            {
                return new Point(m_MouseState.X, m_MouseState.Y);
            }
        }

        public bool IsKeyDown(WinKeys key)
        {
            return false;
        }

        public List<InputEventKeyboard> GetKeyboardEvents()
        {
            var events = new List<InputEventKeyboard>();

            foreach (var e in m_KeyboardEvents)
            {
                if (!e.Handled)
                    events.Add(e);
            }

            return events;
        }

        public List<InputEventMouse> GetMouseEvents()
        {
            var events = new List<InputEventMouse>();

            foreach (var e in m_MouseEvents)
            {
                if (!e.Handled)
                    events.Add(e);
            }

            return events;
        }

        private static WinKeys TranslateToWinKey(Keys xnaKey)
        {
            return WinKeys.None;
        }

        private static Keys TranslateToXNAKey(WinKeys winKey)
        {
            return Keys.None;
        }

        public void Update(double totalTime, double frameTime)
        {
            m_MouseEvents.Clear();
            m_KeyboardEvents.Clear();

            var mouseState = Mouse.GetState();
            var keyState = Keyboard.GetState();

            if (mouseState.X != m_MouseState.X || mouseState.Y != m_MouseState.Y)
            {
                m_LastMouseMove = totalTime;
            }

            if (mouseState.LeftButton != m_MouseState.LeftButton)
            {
                var buttonState = mouseState.LeftButton == ButtonState.Pressed ? MouseEvent.Down : MouseEvent.Up;
                m_MouseEvents.Add(new InputEventMouse(buttonState, WinMouseButtons.Left, 0, m_MouseState.X, m_MouseState.Y, 0, 0));
            }

            if (mouseState.RightButton != m_MouseState.RightButton)
            {
                var buttonState = mouseState.RightButton == ButtonState.Pressed ? MouseEvent.Down : MouseEvent.Up;
                m_MouseEvents.Add(new InputEventMouse(buttonState, WinMouseButtons.Right, 0, m_MouseState.X, m_MouseState.Y, 0, 0));
            }

            if (mouseState.MiddleButton != m_MouseState.RightButton)
            {
                var buttonState = mouseState.MiddleButton == ButtonState.Pressed ? MouseEvent.Down : MouseEvent.Up;
                m_MouseEvents.Add(new InputEventMouse(buttonState, WinMouseButtons.Middle, 0, m_MouseState.X, m_MouseState.Y, 0, 0));
            }

            var oldKeys = new List<Keys>(m_KeyboardState.GetPressedKeys());
            var newKeys = new List<Keys>(keyState.GetPressedKeys());

            foreach (var k in oldKeys)
            {
                if (!newKeys.Contains(k))
                {
                    m_KeyboardEvents.Add(new InputEventKeyboard(KeyboardEvent.Up, TranslateToWinKey(k), 0x11001, 0));

                    var press = new InputEventKeyboard(KeyboardEvent.Press, TranslateToWinKey(k), 0x11001, 0);
                    press.OverrideKeyChar(TranslateToWinKey(k));
                    m_KeyboardEvents.Add(press);
                }
            }

            foreach (var k in newKeys)
            {
                if (!oldKeys.Contains(k))
                {
                    m_KeyboardEvents.Add(new InputEventKeyboard(KeyboardEvent.Down, TranslateToWinKey(k), 0x11001, 0));
                }
            }

            m_MouseState = mouseState;
            m_KeyboardState = keyState;
            m_LastUpdateTime = totalTime;
        }

        public bool HandleKeyboardEvent(KeyboardEvent type, WinKeys key, bool shift, bool alt, bool ctrl)
        {
            foreach (InputEventKeyboard e in m_KeyboardEvents)
            {
                if (e.Handled)
                    continue;

                if (e.EventType == type &&
                   e.KeyCode == key &&
                   e.Shift == shift &&
                   e.Alt == alt &&
                   e.Control == ctrl)
                {
                    e.Handled = true;
                    return true;
                }
            }

            return false;
        }

        public bool HandleMouseEvent(MouseEvent type, MouseButton mb)
        {
            foreach (InputEventMouse e in m_MouseEvents)
            {
                if (e.Handled)
                    continue;

                if (e.EventType == type && e.Button == mb)
                {
                    e.Handled = true;
                    return true;
                }
            }

            return false;
        }
    }
}