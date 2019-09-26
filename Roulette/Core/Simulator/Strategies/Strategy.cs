using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game;
using Roulette.Core.Game.Bets;
using Roulette.Core.Models;

namespace Roulette.Core.Simulator.Strategies
{
    public abstract class Strategy
    {
        protected int Cycles { get; set; }

        // Wager amount
        protected int W;

        // Previous wager amount for when rollback is required
        protected int WPrevious;

        // Losses in a row
        protected int C;

        // Wins in a row
        protected int D;

        protected Strategy(int cycles)
        {
            Cycles = cycles;
        }

        public abstract StrategyResult Execute(RouletteGame rouletteGame, Player player, int betStartAmount);

        protected void CollectStats(double bet, List<double> bets, ref double maxBet, ref double minBet)
        {
            bets.Add(bet);
            if (bet > maxBet)
            {
                maxBet = bet;
            }

            if (bet < minBet)
            {
                minBet = bet;
            }
        }

        protected double SpinRouletteWithExceptionHandling(RouletteGame rouletteGame)
        {
            double result = 0.0;
            try
            {
                result = rouletteGame.PlaceBetAndSpin(new ColorBet(W, PocketColor.Red));
                WPrevious = W;
            }
            catch (ArgumentException e)
            {
                if (e.Message == "max reached")
                {
                    result = rouletteGame.PlaceBetAndSpin(new ColorBet(WPrevious, PocketColor.Red));
                }
                else if (e.Message == "min reached")
                {
                    result = rouletteGame.PlaceBetAndSpin(new ColorBet(WPrevious, PocketColor.Red));
                }

                W = WPrevious;
            }

            return result;
        }
    }
}
