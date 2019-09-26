using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Bets;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;

namespace Roulette.Core
{
    public class StatisticsManager : IStatisticsManager
    {
        private readonly Dictionary<string, StrategyStatistics> _strategyResults;

        public StatisticsManager()
        {
            _strategyResults = new Dictionary<string, StrategyStatistics>();
        }

        public void Process(StrategyResult result)
        {
            var statistic = new StrategyStatistics()
            {
                Cycles = result.CyclesRan,
                Strategy = result.Strategy,
                EndBudget = result.EndBudget,
                MaxBet = result.MaxBet,
                MinBet = result.MinBet,
                Average = result.AllBets.Average(),
                Median = GetMedian(result.AllBets),
                StartBudget = result.StartBudget,
                EndBalance = result.EndBudget - result.StartBudget,
                Name = result.Name
            };

            if (!_strategyResults.ContainsKey(result.Strategy))
            {
                _strategyResults.Add(result.Strategy, new StrategyStatistics());
            }

            _strategyResults[result.Strategy] = statistic;
        }

        private double GetMedian(List<double> bets)
        {
            var orderedBets = bets.OrderBy(b => b).ToList();
            return orderedBets[(int)(orderedBets.Count / 2)];
        }

        public List<StrategyStatistics> GetStatistics()
        {
            return _strategyResults.Values.ToList();
        }

        public void Clear()
        {
            _strategyResults.Clear();
        }
    }
}
