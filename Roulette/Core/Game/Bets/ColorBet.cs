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
    public class ColorBet : Bet
    {
        public PocketColor PocketColor { get; set; }

        public ColorBet(double amount, PocketColor pocketColor) : base(amount, 1)
        {
            PocketColor = pocketColor;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;

            if (pocket.Color == PocketColor)
            {
                winnings += Amount * 2;
            }

            return winnings;
        }
    }
}
