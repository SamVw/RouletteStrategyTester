using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Bets
{
    public abstract class Bet
    {
        public double Amount { get; set; }

        public int WinningsMultiplier { get; set; }

        protected Bet(double amount, int winningsMultiplier)
        {
            Amount = amount;
            WinningsMultiplier = winningsMultiplier;
        }

        public abstract double CalculateWinnings(Pocket pocket);
    }
}
