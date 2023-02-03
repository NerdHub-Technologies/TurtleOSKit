/* Random.cs
 * ---------------
 * Project: TurtleKit-Beta
 * Organization: 32bit Restoration Project
 * Developers:
 *      WinMister332 <cemberley@nerdhub.net>
 * License: MIT <license.txt>
 * ---------------
 * Copyright (c) 32bit Restoration Project 2022, All Rights Reserved.
 */

using Cosmos.System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using TurtleOSKit.Utilities;

using RTC = Cosmos.HAL.RTC;

namespace TurtleOSKit.Core
{
    public sealed class RNG
    {
        public static RNG INSTANCE = new RNG();

        private Random r;

        RNG()
        {
            var hour = RTC.Hour;
            var minute = RTC.Minute;
            var second = RTC.Second;
            var year = RTC.Year;
            var month = RTC.Month;
            var day = RTC.DayOfTheMonth;

            var now = new DateTime(year, month, day, hour, minute, second).Ticks;
            var _1970 = new DateTime(1970, 01, 01, 12, 00, 00).Ticks;

            var ticks = (int)Math.Abs(now - _1970);
            r = new Random(ticks);
        }

        public int NextInt(int min = 0, int max = -1)
        {
            if (min > max || min == max)
            {
                min = 0;
                max = int.MaxValue;
            }
            return r.Next(min, max);
        }

        public byte NextByte(bool includeSymbols = false, bool includeExtendedASCII = false)
        {
            List<byte> byteTable = new List<byte>();
            byteTable.AddRange(GenerateAlphaNumericalASCII());
            if (includeSymbols)
                byteTable.AddRange(GenerateASCIISymbols());
            if (includeExtendedASCII)
                byteTable.AddRange(GenerateExtendedASCII());
            return NextByte(byteTable.ToArray());
        }

        public byte NextByte(byte[] byteTable)
        {
            var i = NextInt(0, byteTable.Length - 1);
            return byteTable[i];
        }

        public byte[] GenerateBytes(int length, bool includeSymbols = false, bool includeExtendedASCII = false)
        {
            byte[] b = new byte[length];
            for (int i = 0; i < b.Length; i++)
                b[i] = NextByte(includeSymbols, includeExtendedASCII);
            return b;
        }

        public byte[] GenerateBytes(int length, in byte[] byteTable)
        {
            byte[] b = new byte[length];
            for (int i = 0; i < b.Length; i++)
                b[i] = NextByte(byteTable);
            return b;
        }

        public Guid NextGuid() => Guid.NewGuid();

        internal byte[] GenerateAlphaNumericalASCII()
        {
            List<byte> b = new List<byte>();
            for (int i = 0; i < 127; i++)
            {
                if ((i >= 48 && i <= 57) || (i >= 65 && i <= 90) || (i >= 97 && i <= 122))
                    b.Add((byte)i);
                else continue;
            }
            return b.ToArray();
        }

        internal byte[] GenerateASCIISymbols()
        {
            List<byte> b = new List<byte>();
            for (int i = 0; i < 127; i++)
            {
                if ((i >= 32 && i <= 47) || (i >= 58 && i <= 64) || (i >= 91 && i <= 96))
                    b.Add((byte)i);
                else continue;
            }
            return b.ToArray();
        }

        internal byte[] GenerateExtendedASCII()
        {
            List<byte> b = new List<byte>();
            for (int i = 128; i < 255; i++)
                b.Add((byte)i);
            return b.ToArray();
        }

        /// <summary>
        /// Generates a list of bytes that can be used to generate psuedo-hex strings.
        /// </summary>
        /// <returns></returns>
        internal byte[] GenerateHexBytes()
        {
            List<char> c = new List<char>() 
            { 
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F'
            };
            return c.ToArray().GetBytes();
        }
    }
}
