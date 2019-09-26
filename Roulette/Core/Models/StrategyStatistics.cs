using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Models
{
    public class StrategyStatistics
    {
        public int Cycles { get; set; }

        public string Strategy { get; set; }

        public double EndBudget { get; set; }

        public double Average { get; set; }

        public double Median { get; set; }

        public double MaxBet { get; set; }

        public double MinBet { get; set; }

        public double StartBudget { get; set; }

        public double EndBalance { get; set; }

        public string Name { get; set; }
    }
}
