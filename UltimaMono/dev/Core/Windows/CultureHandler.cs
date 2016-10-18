/***************************************************************************
 *   CultureHandler.cs
 *   Copyright (c) 2015 UltimaXNA Development Team
 *   
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System.Text;
using UltimaXNA.Core.Diagnostics.Tracing;

namespace UltimaXNA.Core.Windows
{
    static class CultureHandler
    {
        public static void InvalidateEncoder()
        {
        }

        public static char TranslateChar(char inputChar)
        {
            return inputChar;
        }
    }
}
