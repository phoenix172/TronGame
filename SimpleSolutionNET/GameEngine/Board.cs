using System;

namespace SimpleSolutionNET.GameEngine
{
    public class Board
    {
        public int Size { get; }
        public int[,] Cells { get; private set; }

        public Board(int size)
        {
            Size = size;
            Cells = new int[size, size];
        }

        public void Mark(Player player, Position position)
        {
            ThrowIfInvalidPosition(position);
            Cells[position.Y - 1, position.X - 1] = (int)player;
        }

        public void Unmark(Position position)
        {
            if (position.IsValid(Size))
            {
                Cells[position.Y - 1, position.X - 1] = 0;
            }
        }

        private void ThrowIfInvalidPosition(Position position)
        {
            if (!position.IsValid(Size))
            {
                throw new ArgumentOutOfRangeException(nameof(position),
                    $"Position {position} is invalid for board size {Size}");
            }
            var newSquare = GetSquare(position);
            if (newSquare != 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(position), $"Invalid turn. Position {position} is already taken by player {newSquare}");
            }
        }

        public bool IsValidPosition(Position position) => position.IsValid(Size)
                                                          && GetSquare(position) == 0;



        public Position GetCenterPosition()
        {
            int center = Size / 2 + 1;
            return new Position(center, center);
        }

        public int GetSquare(Position position) => Cells[position.Y - 1, position.X - 1];

        public Board CloneBoard()
        {
            Board board = new Board(Size);
            Array.Copy(Cells, board.Cells, Cells.Length);
            return board;
        }

        public void Print()
        {
            Console.WriteLine("--------------");
            int rowLength = Cells.GetLength(0);
            int colLength = Cells.GetLength(1);

            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write($"{Cells[j, i]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
        }
    }
}