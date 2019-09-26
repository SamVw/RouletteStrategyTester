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

        public bool IsBroke => Budget <= 0;

        public Player(string name, double budget)
        {
            Budget = budget;
            Name = name;
        }
    }
}
