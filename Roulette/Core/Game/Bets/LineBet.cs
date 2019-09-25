using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class LineBet : Bet
    {
        private readonly int _startNrOfLine;

        public LineBet(double amount, int startNrOfLine) : base(amount, 5)
        {
            if (Pocket.ColumnOfPocket(startNrOfLine) != 1 && startNrOfLine < 34)
            {
                throw new ArgumentException("Value is not a start of a line");
            }

            _startNrOfLine = startNrOfLine;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;

            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            if (_startNrOfLine + 5 <= pocket.Number + 5 && _startNrOfLine >= pocket.Number)
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }
    }
}
