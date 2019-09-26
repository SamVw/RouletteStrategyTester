using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game;
using Roulette.Infrastructure.Loaders;

namespace Roulette.Core.Factories
{
    public class RouletteGameFactory
    {
        public static RouletteGame Create(int? minBet, int? maxBet)
        {
            var wheel = new Wheel();
            var loader = new TxtTableLoader();

            if (minBet == null && maxBet == null)
            {
                return new RouletteGame(wheel, loader);
            }
            else
            {
                var game = new LimitedRoulette(wheel, loader);
                game.SetLimits((int)minBet, (int)maxBet);
                return game;
            }
        }
    }
}
