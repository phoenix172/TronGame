namespace SimpleSolution
{
    public interface IPlayerStrategy
    {
        Position PlayTurn(TurnContext context);
    }

    public class TurnContext
    {
        public TurnContext(Board board, Position ourPosition, Position opponentPosition)
        {
            Board = board;
            OurPosition = ourPosition;
            OpponentPosition = opponentPosition;
        }

        public Board Board { get; }
        public Position OurPosition { get; }
        public Position OpponentPosition { get; }
    }
}