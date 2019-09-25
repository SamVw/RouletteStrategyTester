using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Bets;
using Roulette.Core.Interfaces;

namespace Roulette.Core.Game
{
    public class LimitedRoulette : RouletteGame
    {
        private readonly int _maxBid;
        private const int TableLimitMultiplier = 100;

        public LimitedRoulette(IWheel wheel, ITableLoader tableLoader, int maxBid) : base(wheel, tableLoader)
        {
            _maxBid = maxBid;
        }

        public override double PlaceBetAndSpin(Bet b)
        {
            var tableLimit = _maxBid * TableLimitMultiplier;
            if (b.Amount > tableLimit)
            {
                b.Amount = tableLimit + 0.0;
            }

            return base.PlaceBetAndSpin(b);
        }
    }
}
