using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;
using Roulette.Core.Models;

namespace Roulette.Core.Game.Bets
{
    public class SplitBet : Bet
    {
        private readonly AdjacentPair _pair;

        public SplitBet(double amount, AdjacentPair pair) : base(amount, 17)
        {
            if (!(pair.Number1 == pair.Number2 - 3
                 || pair.Number1 == pair.Number2 - 1
                 || pair.Number1 == pair.Number2 + 1
                 || pair.Number1 == pair.Number2 + 3))
            {
                throw new ArgumentException("Provided pair is not adjacent");
            }

            _pair = pair;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (pocket.Number == _pair.Number1 || pocket.Number == _pair.Number2)
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }
    }
}
