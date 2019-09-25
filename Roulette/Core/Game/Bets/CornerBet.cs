using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class CornerBet : Bet
    {
        private readonly int _leftTopCornerNr;

        public CornerBet(double amount, int leftTopCornerNr) : base(amount, 8)
        {
            if (leftTopCornerNr >= 34 || Pocket.ColumnOfPocket(leftTopCornerNr) == 3)
            {
                throw new ArgumentException("Invalid left top corner value");
            }

            _leftTopCornerNr = leftTopCornerNr;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (pocket.Number == _leftTopCornerNr
                || pocket.Number == _leftTopCornerNr + 1
                || pocket.Number == _leftTopCornerNr + 3
                || pocket.Number == _leftTopCornerNr + 4)
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }
    }
}
