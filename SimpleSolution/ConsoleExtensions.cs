using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSolution
{
    static class InputHelper
    {
        public static Position ReadPosition()
        {
            var x = ReadInt();
            var y = ReadInt();
            return new Position(x, y);
        }

        public static int ReadInt() => int.Parse(Console.ReadLine());
    }
}
