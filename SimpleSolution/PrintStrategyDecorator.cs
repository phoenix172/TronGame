using System;

namespace SimpleSolution
{
    public class PrintStrategyDecorator : IPlayerStrategy
    {
        private readonly string _player;
        private readonly IPlayerStrategy _strategy;

        public PrintStrategyDecorator(string player, IPlayerStrategy strategy)
        {
            _player = player;
            _strategy = strategy;
        }
        public Position PlayTurn(TurnContext context)
        {
            var newPosition = _strategy.PlayTurn(context);
#if DEBUG
            Console.WriteLine($"Player {_player} turn:");
#endif
            Console.WriteLine(newPosition.X);
            Console.WriteLine(newPosition.Y);
#if DEBUG
            Console.WriteLine("------");
#endif
            return newPosition;
        }
    }
}