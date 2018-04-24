using System;
using SimpleSolutionNET.GameEngine;
using SimpleSolutionNET.Strategies;

namespace SimpleSolutionNET
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = InitGameSettings();
            var game = BeginGame(settings);

            while (!game.State.IsGameOver)
            {
                PlayTurn(game);
            }

            InputHelper.LoopInput();
        }

        private static void PlayTurn(TronGame game)
        {
            game.PlayTurn();
#if DEBUG
            game.Board.Print();
#endif
        }

        private static TronGame BeginGame(GameSettings settings)
        {
            var playerPosition = InputHelper.ReadPosition();
            var opponentPosition = InputHelper.ReadPosition();

            TronGame game = new TronGame(settings);
            game.Start(playerPosition, opponentPosition);

#if DEBUG
            game.GameOver += (s, e) => Console.WriteLine($"Winner: Player {(int)e}");
            game.Board.Print();
#endif

            return game;
        }

        private static GameSettings InitGameSettings()
        {
            var n = InputHelper.ReadInt();
            var p = InputHelper.ReadInt();

            IPlayerStrategy ourStrategy = new WinningStrategy();
            IPlayerStrategy opponentStrategy = new InputStrategy();

            ourStrategy = new PrintStrategyDecorator("Us", ourStrategy);
#if DEBUG
            opponentStrategy = new PrintStrategyDecorator("Them", opponentStrategy);
#endif

            GameSettings settings = new GameSettings(n, (Player) p,
                ourStrategy, opponentStrategy);
            return settings;
        }
    }
}
