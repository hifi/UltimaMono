/***************************************************************************
 *   NativeMethods.cs
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
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;
#endregion

namespace UltimaXNA.Core.Windows
{
    class NativeMethods
    {
        // this is used for resource loading, god knows why
        internal static unsafe void ReadBuffer(SafeFileHandle ptr, void* buffer, int length)
        {
            var stream = new FileStream(ptr, FileAccess.Read);

            byte[] data = new byte[length];
            stream.Read(data, 0, length);

            Marshal.Copy(data, 0, (IntPtr)buffer, length);
        }
    }
}
