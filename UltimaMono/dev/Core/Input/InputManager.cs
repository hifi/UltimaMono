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

        public InputManager(IntPtr handle)
        {
            m_MouseEvents = new List<InputEventMouse>();
            m_MouseState = new MouseState();
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
            return new List<InputEventKeyboard>();
        }

        public List<InputEventMouse> GetMouseEvents()
        {
            return new List<InputEventMouse>(m_MouseEvents);
        }

        public void Update(double totalTime, double frameTime)
        {
            m_MouseEvents.Clear();

            var mouseState = Mouse.GetState();

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

            m_MouseState = Mouse.GetState();
            m_LastUpdateTime = totalTime;
        }

        public bool HandleKeyboardEvent(KeyboardEvent type, WinKeys key, bool shift, bool alt, bool ctrl)
        {
            return false;
        }

        public bool HandleMouseEvent(MouseEvent type, MouseButton mb)
        {
            return false;
        }
    }
}