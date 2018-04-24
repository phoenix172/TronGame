using System;

namespace SimpleSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = InputHelper.ReadInt();
            var p = InputHelper.ReadInt();

            var playerPosition = InputHelper.ReadPosition();
            var opponentPosition = InputHelper.ReadPosition();

            IPlayerStrategy ourStrategy = new DummyStrategy();
            IPlayerStrategy opponentStrategy = new InputStrategy();

            ourStrategy = new PrintStrategyDecorator("Us", ourStrategy);
#if DEBUG
            opponentStrategy = new PrintStrategyDecorator("Them", opponentStrategy);
#endif

            GameSettings settings = new GameSettings(n, (Player)p,
                ourStrategy, opponentStrategy);

            TronGame game = new TronGame(settings);
            game.Start(playerPosition, opponentPosition);

#if DEBUG
            game.GameOver += (s, e) => Console.WriteLine($"Winner: Player {(int)e}");
            game.Board.Print();
#endif

            while (!game.State.IsGameOver)
            {
                game.PlayTurn();
#if DEBUG
                game.Board.Print();
#endif
            }

#if DEBUG
            while (true)
            {
                Console.ReadLine();
            }
#endif
        }
    }
}
