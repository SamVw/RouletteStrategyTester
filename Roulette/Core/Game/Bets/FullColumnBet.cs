using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class FullColumnBet : Bet
    {
        private readonly int _column;

        public FullColumnBet(double amount, int column) : base(amount, 2)
        {
            if (column < 1 && column > 3)
            {
                throw new ArgumentException("Row value not between 1 and 3");
            }

            _column = column;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (CheckIfColumnWasGuessed(_column, Pocket.ColumnOfPocket(pocket.Number)))
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }

        private static bool CheckIfColumnWasGuessed(int column, int pocketColumn)
        {
            if (column == pocketColumn)
            {
                return true;
            }

            return false;
        }
    }
}
