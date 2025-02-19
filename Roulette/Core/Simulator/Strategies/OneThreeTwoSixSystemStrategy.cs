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
    public class OneThreeTwoSixSystemStrategy : Strategy
    {

        public OneThreeTwoSixSystemStrategy(int cycles, Player player) : base(cycles, player)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, int betStartAmount)
        {
            W = betStartAmount;
            D = 0;
            double minBet = betStartAmount,
                maxBet = betStartAmount,
                startBudget = Player.Budget,
                minBudget = Player.Budget,
                maxBudget = Player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                Bet bet = new ColorBet(W, PocketColor.Red);
                W = PreventImpossibleBet(Player.Budget, W);
                double result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Red));

                UpdateWagerAndStraightWinsAccordingToResult(betStartAmount, result);

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
                Strategy = "1-3-2-6",
                CyclesRan = Cycles,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget,
                Name = Player.Name,
                MaxBudget = maxBudget,
                MinBudget = minBudget
            };
        }

        private void UpdateWagerAndStraightWinsAccordingToResult(int betStartAmount, double result)
        {
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
