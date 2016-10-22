using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace UltimaMono
{
    public class Keymap
    {
        private Dictionary<Keys, char[]> map;

        public Keymap()
        {
            map = new Dictionary<Keys, char[]>();

            map.Add(Keys.D0, new char[] { '0', ')' });
            map.Add(Keys.D1, new char[] { '1', '!' });
            map.Add(Keys.D2, new char[] { '2', '@' });
            map.Add(Keys.D3, new char[] { '3', '#' });
            map.Add(Keys.D4, new char[] { '4', '$' });
            map.Add(Keys.D5, new char[] { '5', '%' });
            map.Add(Keys.D6, new char[] { '6', '^' });
            map.Add(Keys.D7, new char[] { '7', '&' });
            map.Add(Keys.D8, new char[] { '8', '*' });
            map.Add(Keys.D9, new char[] { '9', '(' });
            map.Add(Keys.A, new char[] { 'a', 'A' });
            map.Add(Keys.B, new char[] { 'b', 'B' });
            map.Add(Keys.C, new char[] { 'c', 'C' });
            map.Add(Keys.D, new char[] { 'd', 'D' });
            map.Add(Keys.E, new char[] { 'e', 'R' });
            map.Add(Keys.F, new char[] { 'f', 'F' });
            map.Add(Keys.G, new char[] { 'g', 'G' });
            map.Add(Keys.H, new char[] { 'h', 'H' });
            map.Add(Keys.I, new char[] { 'i', 'I' });
            map.Add(Keys.J, new char[] { 'j', 'J' });
            map.Add(Keys.K, new char[] { 'k', 'K' });
            map.Add(Keys.L, new char[] { 'l', 'L' });
            map.Add(Keys.M, new char[] { 'm', 'M' });
            map.Add(Keys.N, new char[] { 'n', 'N' });
            map.Add(Keys.O, new char[] { 'o', 'O' });
            map.Add(Keys.P, new char[] { 'p', 'P' });
            map.Add(Keys.Q, new char[] { 'q', 'Q' });
            map.Add(Keys.R, new char[] { 'r', 'R' });
            map.Add(Keys.S, new char[] { 's', 'S' });
            map.Add(Keys.T, new char[] { 't', 'T' });
            map.Add(Keys.U, new char[] { 'u', 'U' });
            map.Add(Keys.V, new char[] { 'v', 'V' });
            map.Add(Keys.W, new char[] { 'w', 'W' });
            map.Add(Keys.X, new char[] { 'x', 'X' });
            map.Add(Keys.Y, new char[] { 'y', 'Y' });
            map.Add(Keys.Z, new char[] { 'z', 'Z' });
            map.Add(Keys.OemSemicolon, new char[] { ';', ':' });
            map.Add(Keys.OemQuotes, new char[] { '\'', '"' });
            map.Add(Keys.OemComma, new char[] { ',', '<' });
            map.Add(Keys.OemPeriod, new char[] { '.', '>' });
            map.Add(Keys.OemQuestion, new char[] { '/', '?' });
            map.Add(Keys.OemOpenBrackets, new char[] { '[', '{' });
            map.Add(Keys.OemCloseBrackets, new char[] { ']', '}' });
            map.Add(Keys.OemMinus, new char[] { '-', '_' });
            map.Add(Keys.OemPlus, new char[] { '=', '+' });
            map.Add(Keys.OemTilde, new char[] { '`', '~' });
            map.Add(Keys.OemBackslash, new char[] { '\\', '|' });
        }

        public char GetChar(Keys key, bool shifted)
        {
            char[] chars;

            if (!map.TryGetValue(key, out chars))
                return '\0';

            return shifted ? chars[1] : chars[0];
        }
    }
}
