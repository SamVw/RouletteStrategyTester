using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Models;

namespace Roulette.Core
{
    public class StatisticsManager
    {
        public Dictionary<string, StrategyStatistic> _strategyResults;

        public StatisticsManager()
        {
            _strategyResults = new Dictionary<string, StrategyStatistic>();
        }

        public void Process(StrategyResult result, string type, int cycles)
        {
            if (!_strategyResults.ContainsKey(type))
            {
                _strategyResults.Add(type, new StrategyStatistic());
            }

            _strategyResults[type].Cycles = cycles;
            _strategyResults[type].Strategy = type;
            _strategyResults[type].EndResult = result.EndBudget;
        }

        public List<StrategyStatistic> GetStatistics()
        {
            return _strategyResults.Values.ToList();
        }
    }
}
