using SimpleSolutionNET.Strategies;

namespace SimpleSolutionNET.GameEngine
{
    public class GameSettings
    {
        public GameSettings(int boardSize, Player firstPlayer,
            IPlayerStrategy playerStrategy, IPlayerStrategy opponentStrategy)
        {
            BoardSize = boardSize;
            FirstPlayer = firstPlayer;
            PlayerStrategy = playerStrategy;
            OpponentStrategy = opponentStrategy;
        }

        public int BoardSize { get; }
        public Player FirstPlayer { get; }

        public IPlayerStrategy PlayerStrategy { get; set; }
        public IPlayerStrategy OpponentStrategy { get; set; }
    }
}