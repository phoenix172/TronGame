namespace SimpleSolutionNET.GameEngine
{
    public class GameState
    {
        private readonly int _boardSize;

        public GameState(int boardSize, Position playerPosition, Position opponentPosition)
        {
            _boardSize = boardSize;
            Board = new Board(_boardSize);
            PlayerPosition = playerPosition;
            OpponentPosition = opponentPosition;
        }

        public GameState(GameState state)
        {
            _boardSize = state._boardSize;
            Board = state.Board;
            PlayerPosition = state.PlayerPosition;
            OpponentPosition = state.OpponentPosition;
        }
        
        public Board Board { get; }
        public Position PlayerPosition { get; set; }
        public Position OpponentPosition { get; set; }

        public Player? Winner { get; set; }
        public bool IsGameOver => Winner != null;
        public bool GameStarted { get; set; }
    }
}