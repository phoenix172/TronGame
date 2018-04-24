using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    class RandomStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            Random random = new Random();
            var validMoves = GetValidMoves(context).ToList();
            if(!validMoves.Any()) throw new InvalidOperationException("No moves");
            int moveIndex = random.Next(0, validMoves.Count);
            return validMoves[moveIndex];
        }

        private IEnumerable<Position> GetValidMoves(TurnContext context)
        {
            foreach (var vector in MoveVectors.All)
            {
                var newPosition = context.OurPosition.Move(vector);
                if (!context.Board.IsValidPosition(newPosition)) continue;
                yield return newPosition;
            }
        }
    }
}
