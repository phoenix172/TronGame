using System;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    public class DummyStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            foreach (var vector in MoveVectors.All)
            {
                var newPosition = context.OurPosition.Move(vector);
                if (context.Board.IsValidPosition(newPosition))
                    return newPosition;
            }
            throw new InvalidOperationException("No valid moves");
        }
    }
}