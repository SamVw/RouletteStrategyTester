using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Simulator.Strategies;

namespace Roulette.Core.Factories
{
    public class StrategyFactory
    {
        public static Strategy Create(string type, int cycles)
        {
            if (type == "Martingale")
            {
                return new MartingaleStrategy(cycles);
            }
            else if (type == "Waiting")
            {
                return new WaitingStrategy(cycles);
            }
            else if (type == "1-3-2-6")
            {
                return new OneThreeTwoSixSystemStrategy(cycles);
            }

            throw new ArgumentException("Not a valid strategy name ('Martingale' - 'Waiting' - '1-3-2-6')");
        }
    }
}
