using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    public class MinimaxStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            var result = ScanSquare(context.OurPosition, context.Board, context.Player);
            return result.position;
        }

        private static (int depth, Position position) ScanSquare(Position position, Board board, Player player, int depth = 0)
        {
            (int depth, Position position) bestMove = (depth, position);
            foreach (var moveVector in MoveVectors.All)
            {
                var newPosition = position.Move(moveVector);
                if (board.IsValidPosition(newPosition))
                {
                    board.Mark(player, newPosition);
                    (int depth, Position position) result = ScanSquare(newPosition, board, player, depth + 1);
                    if (result.depth > bestMove.depth)
                    {
                        bestMove.depth = result.depth;
                        bestMove.position = newPosition;
                    }
                    board.Unmark(newPosition);
                }
            }
            return bestMove;
        }
    }
}
