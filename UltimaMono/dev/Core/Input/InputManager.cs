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
        private UltimaMono.Keymap m_Keymap;
        private int m_Modifiers;

        public InputManager(IntPtr handle)
        {
            m_MouseState = Mouse.GetState();
            m_MouseEvents = new List<InputEventMouse>();

            m_KeyboardState = Keyboard.GetState();
            m_KeyboardEvents = new List<InputEventKeyboard>();
            m_Keymap = new UltimaMono.Keymap();
            m_Modifiers = 0;
        }

        public void Dispose()
        {
        }

        public bool IsCtrlDown
        {
            get
            {
                return (m_Modifiers & (int)WinKeys.Control) > 0;
            }
        }

        public bool IsShiftDown
        {
            get
            {
                return (m_Modifiers & (int)WinKeys.Shift) > 0;
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
            return m_KeyboardState.IsKeyDown(TranslateToXNAKey(key));
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
            switch (xnaKey)
            {
                case Keys.Back:                 return WinKeys.Back;
                case Keys.Tab:                  return WinKeys.Tab;
                case Keys.Enter:                return WinKeys.Enter;
                case Keys.CapsLock:             return WinKeys.CapsLock;
                case Keys.Escape:               return WinKeys.Escape;
                case Keys.Space:                return WinKeys.Space;
                case Keys.PageUp:               return WinKeys.PageUp;
                case Keys.PageDown:             return WinKeys.PageDown;
                case Keys.End:                  return WinKeys.End;
                case Keys.Home:                 return WinKeys.Home;
                case Keys.Left:                 return WinKeys.Left;
                case Keys.Up:                   return WinKeys.Up;
                case Keys.Right:                return WinKeys.Right;
                case Keys.Down:                 return WinKeys.Down;
                case Keys.Select:               return WinKeys.Select;
                case Keys.Print:                return WinKeys.Print;
                case Keys.Execute:              return WinKeys.Execute;
                case Keys.PrintScreen:          return WinKeys.PrintScreen;

                case Keys.D0:                   return WinKeys.D0;
                case Keys.D1:                   return WinKeys.D1;
                case Keys.D2:                   return WinKeys.D2;
                case Keys.D3:                   return WinKeys.D3;
                case Keys.D4:                   return WinKeys.D4;
                case Keys.D5:                   return WinKeys.D5;
                case Keys.D6:                   return WinKeys.D6;
                case Keys.D7:                   return WinKeys.D7;
                case Keys.D8:                   return WinKeys.D8;
                case Keys.D9:                   return WinKeys.D9;

                case Keys.A:                    return WinKeys.A;
                case Keys.B:                    return WinKeys.B;
                case Keys.C:                    return WinKeys.C;
                case Keys.D:                    return WinKeys.D;
                case Keys.E:                    return WinKeys.E;
                case Keys.F:                    return WinKeys.F;
                case Keys.G:                    return WinKeys.G;
                case Keys.H:                    return WinKeys.H;
                case Keys.I:                    return WinKeys.I;
                case Keys.J:                    return WinKeys.J;
                case Keys.K:                    return WinKeys.K;
                case Keys.L:                    return WinKeys.L;
                case Keys.M:                    return WinKeys.M;
                case Keys.N:                    return WinKeys.N;
                case Keys.O:                    return WinKeys.O;
                case Keys.P:                    return WinKeys.P;
                case Keys.Q:                    return WinKeys.Q;
                case Keys.R:                    return WinKeys.R;
                case Keys.S:                    return WinKeys.S;
                case Keys.T:                    return WinKeys.T;
                case Keys.U:                    return WinKeys.U;
                case Keys.V:                    return WinKeys.V;
                case Keys.W:                    return WinKeys.W;
                case Keys.X:                    return WinKeys.X;
                case Keys.Y:                    return WinKeys.Y;
                case Keys.Z:                    return WinKeys.Z;

                case Keys.LaunchApplication1:   return WinKeys.None;
                default:
                    return WinKeys.None;
            }
        }

        private char TranslateToPrintableChar(Keys xnaKey, KeyboardState state)
        {
            var shifted = state.IsKeyDown(Keys.LeftShift) ||
                          state.IsKeyDown(Keys.RightShift);

            return m_Keymap.GetChar(xnaKey, shifted);
        }

        private static Keys TranslateToXNAKey(WinKeys winKey)
        {
            switch (winKey)
            {
                case WinKeys.Up:    return Keys.Up;
                case WinKeys.Right: return Keys.Right;
                case WinKeys.Left:  return Keys.Left;
                case WinKeys.Down:  return Keys.Down;
                default:            return Keys.None;
            }
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
            m_Modifiers = 0;

            if (keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift))
                m_Modifiers |= (int)WinKeys.Shift;

            if (keyState.IsKeyDown(Keys.LeftAlt) || keyState.IsKeyDown(Keys.RightAlt))
                m_Modifiers |= (int)WinKeys.Alt;

            if (keyState.IsKeyDown(Keys.LeftControl) || keyState.IsKeyDown(Keys.RightControl))
                m_Modifiers |= (int)WinKeys.Control;

            foreach (var k in oldKeys)
            {
                if (!newKeys.Contains(k))
                {
                    m_KeyboardEvents.Add(new InputEventKeyboard(KeyboardEvent.Up, TranslateToWinKey(k), m_Modifiers));
                }
            }

            foreach (var k in newKeys)
            {
                if (!oldKeys.Contains(k))
                {
                    m_KeyboardEvents.Add(new InputEventKeyboard(KeyboardEvent.Down, TranslateToWinKey(k), m_Modifiers));
                    var press = new InputEventKeyboard(KeyboardEvent.Press, TranslateToWinKey(k), m_Modifiers);
                    press.OverrideKeyChar(TranslateToPrintableChar(k, keyState));
                    m_KeyboardEvents.Add(press);
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