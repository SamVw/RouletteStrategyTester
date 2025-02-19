﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game;
using Roulette.Core.Game.Bets;
using Roulette.Core.Models;

namespace Roulette.Core.Simulator.Strategies
{
    public class MartingaleStrategy : Strategy
    {
        public MartingaleStrategy(int cycles, Player player) : base(cycles, player)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, int betStartAmount)
        {
            C = 0;
            W = betStartAmount;
            double minBet = betStartAmount,
                maxBet = betStartAmount,
                startBudget = Player.Budget,
                minBudget = Player.Budget,
                maxBudget = Player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                W =  PreventImpossibleBet(Player.Budget, W);
                var result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Red));

                UpdateWagerAndLossesAccordingToResult(betStartAmount, result);

                Player.Budget += result;
                CyclesRan++;
                CollectStats(W, bets, ref maxBet, ref minBet, ref minBudget, ref maxBudget, Player.Budget);

                if (Player.IsBroke)
                {
                    break;
                }
            }

            return new StrategyResult()
            {
                EndBudget = Player.Budget,
                Strategy = "Martingale",
                CyclesRan = CyclesRan,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget,
                Name = Player.Name,
                MaxBudget = maxBudget,
                MinBudget = minBudget
            };
        }

        private void UpdateWagerAndLossesAccordingToResult(int betStartAmount, double result)
        {
            if (result < 0)
            {
                W = W * 2;
                C++;
            }

            if (result > 0)
            {
                C = 0;
                W = betStartAmount;
            }
        }
    }
}
