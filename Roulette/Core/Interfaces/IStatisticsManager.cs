using System.Collections.Generic;
using Roulette.Core.Models;

namespace Roulette.Core.Interfaces
{
    public interface IStatisticsManager
    {
        void Process(StrategyResult result);
        List<StrategyStatistics> GetStatistics();
    }
}