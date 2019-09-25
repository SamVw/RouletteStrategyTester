using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Models;

namespace Roulette.Core.Game.Table.Pockets
{
    public class ZeroPocket : Pocket
    {
        public override int Number { get; set; }
        public override PocketColor Color => PocketColor.Green;
    }
}
