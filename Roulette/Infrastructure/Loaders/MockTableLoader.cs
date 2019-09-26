using System.Collections.Generic;
using System.Linq;
using Roulette.Core.Factories;
using Roulette.Core.Game.Table.Pockets;
using Roulette.Core.Interfaces;

namespace Roulette.Infrastructure.Loaders
{
    public class MockTableLoader : ITableLoader
    {
        public List<Pocket> Load(string path)
        {
            var pockets = new List<Pocket>();

            string type = "";
            int[] reds = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            int[] blacks = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            for (int i = -1; i <= 36; i++)
            {
                if (i == -1)
                {
                    type = "double-zero";
                }
                else if (i == 0)
                {
                    type = "zero";
                }
                else if (reds.Contains(i))
                {
                    type = "red";
                }
                else if (blacks.Contains(i))
                {
                    type = "black";
                }

                pockets.Add(PocketFactory.Create(type));
            }

            return pockets;
        }
    }
}
