using System;
using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Factories
{
    public class PocketFactory
    {
        public static Pocket Create(string color)
        {
            switch (color)
            {
                case "green":
                    if (Pocket.Count == -1)
                        return new DoubleZeroPocket() { Number = Pocket.Count++ };
                    else
                        return new ZeroPocket() { Number = Pocket.Count++ };
                case "red":
                    return new RedPocket() { Number = Pocket.Count++ };
                case "black":
                    return new BlackPocket() { Number = Pocket.Count++ };
            }

            throw new ArgumentException();
        }
    }
}
