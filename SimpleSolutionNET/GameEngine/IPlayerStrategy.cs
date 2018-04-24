namespace SimpleSolutionNET.GameEngine
{
    public interface IPlayerStrategy
    {
        Position PlayTurn(TurnContext context);
    }

    public class TurnContext
    {
        public TurnContext(Board board, Player player,
            Position ourPosition, Position opponentPosition, bool isPlayerFirst)
        {
            Board = board;
            OurPosition = ourPosition;
            OpponentPosition = opponentPosition;
            Player = player;
            IsPlayerFirst = isPlayerFirst;
        }

        public Board Board { get; }
        public Position OurPosition { get; }
        public Position OpponentPosition { get; }
        public Player Player { get; }
        public bool IsPlayerFirst { get; }
    }
}