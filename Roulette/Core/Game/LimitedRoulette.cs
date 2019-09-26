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
        private int _minBid;
        private int _maxBid;

        public LimitedRoulette(IWheel wheel, ITableLoader tableLoader) : base(wheel, tableLoader)
        {
        }

        public override double PlaceBetAndSpin(Bet b)
        {
            if (b.Amount > _maxBid)
            {
                throw new ArgumentException("max reached");
            }
            if (b.Amount < _minBid)
            {
                throw new ArgumentException("min reached");
            }

            return base.PlaceBetAndSpin(b);
        }

        public void SetLimits(int minBid, int maxBid)
        {
            _minBid = minBid;
            _maxBid = maxBid;
        }
    }
}
