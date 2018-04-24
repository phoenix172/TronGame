using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSolutionNET.GameEngine;

namespace SimpleSolutionNET.Strategies
{
    class WinningStrategy : IPlayerStrategy
    {
        private bool _centerReached, _randomPlayed;
        private IPlayerStrategy _random, _minimax, _centerHunting;

        public WinningStrategy()
        {
            _random = new RandomStrategy();
            _minimax = new MinimaxStrategy();
            _centerHunting = new CenterHuntingStrategy();
        }

        public Position PlayTurn(TurnContext context)
        {
            try
            {
                var center = context.Board.GetCenterPosition();
                if (context.IsPlayerFirst)
                {
                    if (context.OurPosition == center || context.Board.GetSquare(center) != 0)
                        _centerReached = true;
                    if (_centerReached)
                        return _minimax.PlayTurn(context);
                    if (context.OurPosition != center)
                        return _centerHunting.PlayTurn(context);
                }
                else
                {
                    if (context.OurPosition == center || context.Board.GetSquare(center) != 0)
                        _centerReached = true;
                    if (_centerReached)
                    {
                        if (!_randomPlayed)
                        {
                            _randomPlayed = true;
                            return _random.PlayTurn(context);
                        }
                        return _minimax.PlayTurn(context);
                    }
                    if (context.OurPosition != center)
                        return _centerHunting.PlayTurn(context);
                }
#if DEBUG
                throw new InvalidOperationException("No moves");
#endif
                return _random.PlayTurn(context);
            }
            catch
            {
                return _random.PlayTurn(context);
            }
        }
    }
}
