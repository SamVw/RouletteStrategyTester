using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Models
{
    public class StrategyResult
    {
        public double EndBudget { get; set; }

        public string Strategy { get; set; }

        public int CyclesRan { get; set; }

        public double MaxBet { get; set; }

        public double MinBet { get; set; }

        public List<double> AllBets { get; set; }

        public double StartBudget { get; set; }

        public string Name { get; set; }

        public double MaxBudget { get; set; }

        public double MinBudget { get; set; }
    }
}
