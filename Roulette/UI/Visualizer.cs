using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;

namespace Roulette.UI
{
    public class Visualizer : IVisualizer
    {
        private readonly ILogger _logger;

        public Visualizer(ILogger logger)
        {
            _logger = logger;
        }


        public void ShowStatistics(List<StrategyStatistic> strategyStatistics)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var strategyStatistic in strategyStatistics)
            {
                builder.AppendLine("Strategy: " + strategyStatistic.Strategy + " | " + strategyStatistic.Cycles + " cycles");
                builder.AppendLine(" - End result: " + strategyStatistic.EndResult);
            }

            _logger.Log(builder.ToString());
        }
    }
}
