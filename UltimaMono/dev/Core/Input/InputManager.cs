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
#endregion

namespace UltimaXNA.Core.Input
{
    public class InputManager
    {
        public InputManager(IntPtr handle)
        {
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
            get { return 0; }
        }

        public Point MousePosition
        {
            get
            {
                return new Point();
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
            return new List<InputEventMouse>();
        }

        public void Update(double totalTime, double frameTime)
        {
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