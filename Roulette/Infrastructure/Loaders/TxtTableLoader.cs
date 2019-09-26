using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Factories;
using Roulette.Core.Game.Table.Pockets;
using Roulette.Core.Interfaces;

namespace Roulette.Infrastructure.Loaders
{
    public class TxtTableLoader : ITableLoader
    {
        public List<Pocket> Load(string path)
        {
            List<Pocket> pockets = new List<Pocket>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        pockets.Add(PocketFactory.Create(line));
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }

            return pockets;
        }
    }
}
