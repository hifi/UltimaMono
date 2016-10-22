/***************************************************************************
 *   InputEventKeyboard.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 *   
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using UltimaXNA.Core.Windows;

namespace UltimaXNA.Core.Input
{
    public class InputEventKeyboard : InputEvent
    {
        public KeyboardEvent EventType
        {
            get;
            private set;
        }

        public char KeyChar
        {
            get;
            private set;
        } = '\0';

        public void OverrideKeyChar(char newChar)
        {
            KeyChar = newChar;
        }

        public bool IsChar
        {
            get { return KeyChar != '\0'; }
        }

        public override string ToString()
        {
            return EventType.ToString() + " " + KeyChar;
        }

        public WinKeys KeyCode
        {
            get;
            private set;
        }

        public int KeyCodeInt
        {
            get { return (int)KeyCode; }
        }

        public InputEventKeyboard(KeyboardEvent eventType, WinKeys keyCode, int modifiers)
            : base((WinKeys)modifiers)
        {
            EventType = eventType;
            KeyCode = keyCode;
        }
    }
}
