namespace SimpleSolution
{
    public class InputStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            return InputHelper.ReadPosition();
        }
    }
}