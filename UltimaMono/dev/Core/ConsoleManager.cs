/***************************************************************************
 *   ConsoleManager.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 * 
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
#region usings
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using UltimaXNA.Core.Diagnostics.Tracing;
#endregion

namespace UltimaXNA.Core
{
    internal static class ConsoleManager
    {
        public static bool HasConsole
        {
            get { return true; }
        }

        public static void PushColor(ConsoleColor color)
        {
        }

        public static ConsoleColor PopColor()
        {
            return Console.ForegroundColor;
        }

        public static void Show()
        {
        }

        public static void Hide()
        {
        }

        public static void Toggle()
        {
        }
    }
}