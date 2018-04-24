using System;

namespace SimpleSolution
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public bool IsValid(int boardSize) => X >= 1 && X <= boardSize && Y >= 1 && Y <= boardSize;

        public Position Move(Position moveVector) => new Position(X + moveVector.X, Y + moveVector.Y);

        public override string ToString()
        {
            return $"{{X: {X}, Y: {Y}}}";
        }
    }
}