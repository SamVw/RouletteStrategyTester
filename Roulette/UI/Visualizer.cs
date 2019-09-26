using System.Collections.Generic;
using System.Text;
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


        public void ShowStatistics(List<StrategyStatistics> strategyStatistics)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var strategyStatistic in strategyStatistics)
            {
                builder.AppendLine(" Player\t\t =>\t" + strategyStatistic.Name);
                builder.AppendLine();
                builder.AppendLine(" Strategy\t =>\t" + strategyStatistic.Strategy);
                builder.AppendLine(" Cycles\t\t =>\t" + strategyStatistic.Cycles);
                builder.AppendLine();
                builder.AppendLine(" Start budget\t =>\t" + strategyStatistic.StartBudget + " dollars");
                builder.AppendLine(" End budget\t =>\t" + strategyStatistic.EndBudget + " dollars");
                builder.AppendLine(" Amount " + (strategyStatistic.EndBalance > 0 ? "Won" : "Lost") + "\t =>\t" + strategyStatistic.EndBalance + " dollars");
                builder.AppendLine();
                builder.AppendLine(" Max bet\t =>\t" + strategyStatistic.MaxBet);
                builder.AppendLine(" Min bet\t =>\t" + strategyStatistic.MinBet);
                builder.AppendLine();
                builder.AppendLine(" Average bet\t =>\t" + strategyStatistic.Average);
                builder.AppendLine(" Median bet\t =>\t" + strategyStatistic.Median);
            }

            _logger.Log(builder.ToString());
        }
    }
}
