using System;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET
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

        public static void LoopInput()
        {
#if DEBUG
            while (true)
            {
                Console.ReadLine();
            }
#endif
        }
    }
}
