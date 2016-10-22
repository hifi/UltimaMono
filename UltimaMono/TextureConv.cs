using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace UltimaMono
{
    public static class TextureConv
    {
        public static int[] Bgra5551ToArgb32(int w, int h, ushort[] inputData)
        {
            var outputData = new int[w * h];

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    ushort p = inputData[y * w + x];

                    int b = (p & 0x1F) << 3;
                    int g = ((p >> 5) & 0x1F) << 3;
                    int r = ((p >> 10) & 0x1F) << 3;
                    int a = ((p >> 15) > 0 ? 0xFF : 0) << 3;

                    outputData[y * w + x] = (a << 24) | (b << 16) | (g << 8) | r;
                }
            }

            return outputData;
        }
    }
}
