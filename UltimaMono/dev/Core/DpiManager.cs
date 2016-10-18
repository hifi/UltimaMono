/***************************************************************************
 *   DpiManager.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 * 
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;

namespace UltimaXNA.Core
{
    internal static class DpiManager
    {
        public static Vector2 GetSystemDpiScalar()
        {
            return new Vector2(1.0f, 1.0f);
        }
    }
}