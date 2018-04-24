using System.Collections.Generic;

namespace SimpleSolutionNET.GameEngine
{
    public static class MoveVectors
    {
        static readonly Position[] _moveVectors = new[]
        {
            new Position(-1, 0), //Up
            new Position(1, 0), //Down
            new Position(0, -1), //Left
            new Position(0, 1) //Right
        };

        public static readonly Position Up;
        public static readonly Position Down;
        public static readonly Position Left;
        public static readonly Position Right;

        static MoveVectors()
        {
            Up = _moveVectors[0];
            Down = _moveVectors[1];
            Left = _moveVectors[2];
            Right = _moveVectors[3];
        }

        public static IEnumerable<Position> All
        {
            get
            {
                yield return Up;
                yield return Down;
                yield return Left;
                yield return Right;
            }
        }
    }
}
