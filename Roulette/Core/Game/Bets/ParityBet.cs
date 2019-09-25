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
    public class ParityBet : Bet
    {
        public Parity Parity { get; }

        public ParityBet(double amount, Parity parity) : base(amount, 1)
        {
            Parity = parity;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;

            if ((Parity == Parity.Even && pocket.IsEven() == 1) || (Parity == Parity.Odd && pocket.IsEven() == 0))
            {
                winnings += Amount * 2;
            }

            return winnings;
        }
    }
}
