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

        protected int CyclesRan = 0;

        protected Strategy(int cycles)
        {
            Cycles = cycles;
        }

        public abstract StrategyResult Execute(RouletteGame rouletteGame, Player player, int betStartAmount);

        protected void CollectStats(double bet, List<double> bets, ref double maxBet, ref double minBet, ref double minBudget, ref double maxBudget, double budget)
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

            if (budget < minBudget)
            {
                minBudget = budget;
            }

            if (budget > maxBudget)
            {
                maxBudget = budget;
            }
        }

        protected double SpinRouletteWithExceptionHandling(RouletteGame rouletteGame, Bet bet)
        {
            double result = 0.0;
            try
            {
                result = rouletteGame.PlaceBetAndSpin(bet);
                WPrevious = W;
            }
            catch (ArgumentException)
            {
                bet.Amount = WPrevious;
                result = rouletteGame.PlaceBetAndSpin(bet);

                W = WPrevious;
            }

            return result;
        }

        protected static int PreventImpossibleBet(double budget, int wager)
        {
            if (budget - wager < 0)
            {
                wager = int.Parse(Math.Floor(budget).ToString());
            }

            return wager;
        }
    }
}
