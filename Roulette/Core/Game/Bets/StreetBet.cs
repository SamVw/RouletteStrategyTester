using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class StreetBet : Bet
    {
        private readonly int _startNrOfRow;

        public StreetBet(double amount, int startNrOfRow) : base(amount, 11)
        {
            if (Pocket.ColumnOfPocket(startNrOfRow) != 1)
            {
                throw new ArgumentException("Not a valid start of a row");
            }

            _startNrOfRow = startNrOfRow;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (pocket.Number >= _startNrOfRow && pocket.Number <= _startNrOfRow + 2)
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }
    }
}
