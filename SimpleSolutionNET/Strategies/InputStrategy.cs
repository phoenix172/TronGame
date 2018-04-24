using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    public class InputStrategy : IPlayerStrategy
    {
        public Position PlayTurn(TurnContext context)
        {
            return InputHelper.ReadPosition();
        }
    }
}