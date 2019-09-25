using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Game.Table
{
    public class RouletteTable
    {
        private readonly List<Pocket> _pockets;

        public RouletteTable(List<Pocket> pockets)
        {
            _pockets = pockets;
        }

        public Pocket GetPocket(int pocket)
        {
            return _pockets.FirstOrDefault(p => p.Number == pocket);
        }
    }
}
