using System;

namespace SimpleSolution
{
    public class TronGame
    {
        public TronGame(GameSettings settings)
        {
            Settings = settings;
            NextPlayer = settings.FirstPlayer;
        }

        public Board Board => State.Board;
        public GameState State { get; private set; }
        public Player NextPlayer { get; set; }
        public GameSettings Settings { get; }

        public void Start(Position playerPosition, Position opponentPosition)
        {
            State = new GameState(Settings.BoardSize,
                playerPosition, opponentPosition);
            Board.Mark(Player.Player, State.PlayerPosition);
            Board.Mark(Player.Opponent, State.OpponentPosition);

            State.Winner = null;
            State.GameStarted = true;
        }

        public void PlayTurn()
        {
            if(State.IsGameOver)
                throw new InvalidOperationException("No more turns. Game over!");

            if(!State.GameStarted)
                throw new InvalidOperationException("Game is not started");

            var currentPosition = GetPlayerPosition(NextPlayer);
            var opponent = GetOpponent(NextPlayer);
            var opponentPosition = GetPlayerPosition(opponent);
            var strategy = GetPlayerStrategy(NextPlayer);

            var newPosition = strategy.PlayTurn(new TurnContext(State.Board, currentPosition, opponentPosition));

            Board.Mark(NextPlayer, newPosition);
            SetPlayerPosition(NextPlayer,newPosition);
            NextPlayer = opponent;
            

            CheckWin();
        }

        private void CheckWin()
        {
            State.Winner = GetGameWinner();
            if (State.Winner.HasValue)
            {
                GameOver?.Invoke(this, State.Winner.Value);
                State.GameStarted = false;
            }
        }

        private Player? GetGameWinner()
        {
            Position currentPosition = GetPlayerPosition(NextPlayer);
            foreach (var vector in MoveVectors.All)
            {
                var newPosition = currentPosition.Move(vector);
                if (State.Board.IsValidPosition(newPosition))
                    return null;
            }
            return GetOpponent(NextPlayer);
        }

        private Player GetOpponent(Player player) => player == Player.Player ? Player.Opponent : Player.Player;

        private Position GetPlayerPosition(Player player) => player == Player.Player ? State.PlayerPosition : State.OpponentPosition;

        private void SetPlayerPosition(Player player, Position newPosition)
        {
            if (player == Player.Player)
                State.PlayerPosition = newPosition;
            else
                State.OpponentPosition = newPosition;
        }

        private IPlayerStrategy GetPlayerStrategy(Player player) =>
            player == Player.Player ? Settings.PlayerStrategy : Settings.OpponentStrategy;

        public event EventHandler<Player> GameOver;
    }
}