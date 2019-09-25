using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public class FiveNumbersBet : Bet
    {
        public FiveNumbersBet(double amount) : base(amount, 6)
        {
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (IsCorrect(pocket.Number))
            {
                winnings += Amount + Amount * WinningsMultiplier;
            }

            return winnings;
        }

        private static bool IsCorrect(int nr)
        {
            bool correct = false;
            for (int i = -1; i <= 3; i++)
            {
                if (i == nr)
                {
                    correct = true;
                    break;
                }
            }

            return correct;
        }
    }
}
