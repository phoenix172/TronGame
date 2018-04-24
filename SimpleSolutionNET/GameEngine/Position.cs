namespace SimpleSolutionNET.GameEngine
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
            return $"{{X: {Y}, Y: {X}}}";
        }

        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Position && Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }
    }
}