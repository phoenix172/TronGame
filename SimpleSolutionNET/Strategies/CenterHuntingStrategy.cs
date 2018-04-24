using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    class CenterHuntingStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            var center = context.Board.GetCenterPosition();

            int vectorX = 0;
            int vectorY = 0;

            if (center.X - context.OurPosition.X > 0)
                vectorX = 1;
            else
                vectorX = -1;

            if (center.Y - context.OurPosition.Y > 0)
                vectorY = 1;
            else
                vectorY = -1;

            Position lastValidPosition = context.OurPosition;
            foreach (var vector in MoveVectors.All)
            {
                var newPosition = context.OurPosition.Move(vector);
                if (!context.Board.IsValidPosition(newPosition)) continue;

                lastValidPosition = newPosition;

                if (newPosition == center)
                    return newPosition;
            }

            foreach (var vector in MoveVectors.All)
            {
                var newPosition = context.OurPosition.Move(vector);
                if (!context.Board.IsValidPosition(newPosition)) continue;

                lastValidPosition = newPosition;

                if (vector.X == vectorX)
                    return newPosition;
                if (vector.Y == vectorY)
                    return newPosition;
            }

            if (lastValidPosition == context.OurPosition)
                throw new InvalidOperationException("No valid moves");
            return lastValidPosition;
        }
    }
}
