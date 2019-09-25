using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Simulator
{
    public class Player
    {
        public string Name { get; set; }

        public double Budget { get; set; }

        public Player(double budget)
        {
            Budget = budget;
        }
    }
}
