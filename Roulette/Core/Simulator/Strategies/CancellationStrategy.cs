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
    public class CancellationStrategy : Strategy
    {
        private List<int> _sequence;

        public CancellationStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, int betStartAmount)
        {
            InitSequence(betStartAmount);
            int cyclesRan = 0;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget;
            List<double> bets = new List<double>();

            for (int i = 0; i < Cycles; i++)
            {
                // Sequence is finished
                if (_sequence.Count == 0)
                {
                    break;
                }

                W = _sequence.Count == 1 ? _sequence.First() : _sequence.First() + _sequence.Last();
                
                double result = SpinRouletteWithExceptionHandling(rouletteGame);

                CollectStats(W, bets, ref maxBet, ref minBet);

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

                player.Budget += result;
                cyclesRan++;
            }

            return new StrategyResult()
            {
                EndBudget = player.Budget,
                Strategy = "Cancellation",
                CyclesRan = cyclesRan,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget,
                Name = player.Name
            };
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
