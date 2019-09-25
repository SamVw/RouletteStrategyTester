using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game;
using Roulette.Core.Models;

namespace Roulette.Core.Simulator.Strategies
{
    public abstract class Strategy
    {
        protected int Cycles { get; set; }

        protected Strategy(int cycles)
        {
            Cycles = cycles;
        }

        public abstract StrategyResult Execute(IRouletteGame rouletteGame, Player player, double betStartAmount);
    }
}
