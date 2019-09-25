using System.Collections.Generic;
using Roulette.Core.Models;

namespace Roulette.Core
{
    public interface IStatisticsManager
    {
        void Process(StrategyResult result);
        List<StrategyStatistics> GetStatistics();
    }
}