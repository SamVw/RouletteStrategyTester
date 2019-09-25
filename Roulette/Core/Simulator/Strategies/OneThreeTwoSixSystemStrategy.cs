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
        // wagering amount
        private double _w;
        // wins in a row
        private int _d;

        public OneThreeTwoSixSystemStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, double betStartAmount)
        {
            _w = betStartAmount;
            _d = 0;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                Bet bet = new ColorBet(_w, PocketColor.Red);
                double result = rouletteGame.PlaceBetAndSpin(bet);
                player.Budget += result;

                CollectStats(_w, bets, ref maxBet, ref minBet);

                bool loss = result < 0;
                if (loss)
                {
                    _d = 0;
                    _w = betStartAmount;
                }
                if (!loss)
                {
                    _d++;
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
                StartBudget = startBudget
            };
        }

        private void IncreaseWagersAccordingToStreak(double betStartAmount)
        {
            _w = betStartAmount;
            if (_d == 1)
            {
                _w *= 3;
            }
            else if (_d == 2)
            {
                _w *= 2;
            }
            else if (_d == 3)
            {
                _w *= 6;
            }
            else if (_d == 4)
            {
                _d = 0;
            }
        }
    }
}
