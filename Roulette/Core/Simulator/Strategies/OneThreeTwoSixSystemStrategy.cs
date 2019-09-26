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
    public class OneThreeTwoSixSystemStrategy : Strategy
    {

        public OneThreeTwoSixSystemStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, int betStartAmount)
        {
            W = betStartAmount;
            D = 0;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                Bet bet = new ColorBet(W, PocketColor.Red);
                double result = SpinRouletteWithExceptionHandling(rouletteGame);
                player.Budget += result;

                CollectStats(W, bets, ref maxBet, ref minBet);

                bool loss = result < 0;
                if (loss)
                {
                    D = 0;
                    W = betStartAmount;
                }
                if (!loss)
                {
                    D++;
                    IncreaseWagersAccordingToStreak(betStartAmount);
                }
            }

            return new StrategyResult()
            {
                EndBudget = player.Budget,
                Strategy = "1-3-2-6",
                CyclesRan = Cycles,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget,
                Name = player.Name
            };
        }

        private void IncreaseWagersAccordingToStreak(int betStartAmount)
        {
            W = betStartAmount;
            if (D == 1)
            {
                W *= 3;
            }
            else if (D == 2)
            {
                W *= 2;
            }
            else if (D == 3)
            {
                W *= 6;
            }
            else if (D == 4)
            {
                D = 0;
            }
        }
    }
}
