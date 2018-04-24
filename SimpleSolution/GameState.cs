using System;
using System.ComponentModel;

namespace SimpleSolution
{
    public class GameState
    {
        private readonly int _boardSize;

        public GameState(int boardSize, Position playerPosition, Position opponentPosition)
        {
            _boardSize = boardSize;
            Board = new Board(_boardSize);
            PlayerPosition = playerPosition;
            OpponentPosition = opponentPosition;
        }

        public GameState(GameState state)
        {
            _boardSize = state._boardSize;
            Board = state.Board;
            PlayerPosition = state.PlayerPosition;
            OpponentPosition = state.OpponentPosition;
        }
        
        public Board Board { get; }
        public Position PlayerPosition { get; set; }
        public Position OpponentPosition { get; set; }

        public Player? Winner { get; set; }
        public bool IsGameOver => Winner != null;
        public bool GameStarted { get; set; }
    }

    public class Board
    {
        private readonly int _size;
        private readonly int[,] _board;

        public Board(int size)
        {
            _size = size;
            _board = new int[size, size];
        }

        public void Mark(Player player, Position position)
        {
            ThrowIfInvalidPosition(position);
            _board[position.Y - 1, position.X - 1] = (int)player;
        }

        private void ThrowIfInvalidPosition(Position position)
        {
            if (!position.IsValid(_size))
            {
                throw new ArgumentOutOfRangeException(nameof(position),
                    $"Position {position} is invalid for board size {_size}");
            }
            var newSquare = GetSquare(position);
            if (newSquare != 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(position), $"Invalid turn. Position {position} is already taken by player {newSquare}");
            }
        }

        public bool IsValidPosition(Position position) => position.IsValid(_size)
                                                          && GetSquare(position) == 0;

        public int GetSquare(Position position) => _board[position.Y - 1, position.X - 1];

        public void Print()
        {
            Console.WriteLine("Current Board:");
            int rowLength = _board.GetLength(0);
            int colLength = _board.GetLength(1);

            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    Console.Write(string.Format("{0} ", _board[j, i]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.WriteLine("-------------");
        }
    }
}