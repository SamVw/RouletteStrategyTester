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
    public class CancellationStrategy : Strategy
    {
        private List<int> _sequence;

        public CancellationStrategy(int cycles, Player player) : base(cycles, player)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, int betStartAmount)
        {
            InitSequence(betStartAmount);
            double minBet = betStartAmount,
                maxBet = betStartAmount,
                startBudget = Player.Budget,
                minBudget = Player.Budget,
                maxBudget = Player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                // Sequence is finished
                if (_sequence.Count == 0)
                {
                    break;
                }

                W = _sequence.Count == 1 ? _sequence.First() : _sequence.First() + _sequence.Last();

                W = PreventImpossibleBet(Player.Budget, W);
                double result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Red));

                UpdateSequenceAccordingToResult(result);

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
                Strategy = "Cancellation",
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

        private void UpdateSequenceAccordingToResult(double result)
        {
            if (result < 0)
            {
                _sequence.Add(W);
            }
            else
            {
                if (_sequence.Count != 1)
                {
                    _sequence.RemoveAt(_sequence.Count - 1);
                }

                _sequence.RemoveAt(0);
            }
        }

        private void InitSequence(double betStartAmount)
        {
            _sequence = new List<int>();

            for (int i = 1; i <= betStartAmount; i++)
            {
                _sequence.Add(i);
            }
        }
    }
}
