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
        private double _w;
        private int _c;

        public MartingaleStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, double betStartAmount)
        {
            _c = 0;
            _w = betStartAmount;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                var result = rouletteGame.PlaceBetAndSpin(new ColorBet(_w, PocketColor.Red));

                CollectStats(_w, bets, ref maxBet, ref minBet);

                if (result < 0)
                {
                    _w = _w * 2;
                    _c++;
                }

                if (result > 0)
                {
                    _c = 0;
                    _w = betStartAmount;
                }

                player.Budget += result;
            }

            return new StrategyResult()
            {
                EndBudget = player.Budget,
                Strategy = "Martingale",
                CyclesRan = Cycles,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget
            };
        }
    }
}
