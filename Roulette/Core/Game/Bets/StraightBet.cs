using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class StraightBet : Bet
    {
        private readonly int _number;

        public StraightBet(double amount, int number) : base(amount, 35)
        {
            if (number < -1 || number > 36)
            {
                throw new ArgumentException("Not a valid number (-1-36)");
            }

            _number = number;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;

            if (_number == pocket.Number)
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }
    }
}
