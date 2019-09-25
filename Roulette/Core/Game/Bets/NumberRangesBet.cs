using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class NumberRangesBet : Bet
    {
        private readonly int _range;

        public NumberRangesBet(double amount, int range) : base(amount, 2)
        {
            if (!new [] {1, 2, 3}.Contains(range))
            {
                throw new ArgumentException("Only 1,2,3 are allowed");
            }

            _range = range;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (CheckIfGuessedCorrectly(_range, pocket.Number))
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }

        private static bool CheckIfGuessedCorrectly(int rangeNr, int spinResult)
        {
            if (spinResult <= 12 * rangeNr && spinResult >= (12 * rangeNr) - 11)
            {
                return true;
            }

            return false;
        }
    }
}
