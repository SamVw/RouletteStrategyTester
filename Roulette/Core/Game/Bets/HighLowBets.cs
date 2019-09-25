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
    public class HighLowBets : Bet
    {
        private readonly HighLow _highLow;


        public HighLowBets(double amount, HighLow highLow) : base(amount, 1)
        {
            _highLow = highLow;
        }

        public override double CalculateWinnings(Pocket pocket)
        {
            double winnings = 0 - Amount;
            if (pocket.IsZeroOrDoubleZero())
            {
                return winnings;
            }

            var highBet = _highLow == HighLow.High && pocket.Number > 18;
            var lowBet = _highLow == HighLow.Low && pocket.Number <= 18;
            if (highBet || lowBet)
            {
                winnings += Amount * 2;
            }

            return winnings;
        }
    }
}
