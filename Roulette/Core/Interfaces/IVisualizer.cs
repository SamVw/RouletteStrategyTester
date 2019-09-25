using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Models;

namespace Roulette.Core.Interfaces
{
    public interface IVisualizer
    {
        void ShowStatistics(List<StrategyStatistic> strategyStatistics);
    }
}
