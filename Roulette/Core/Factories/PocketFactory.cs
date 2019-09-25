using Roulette.Core.Game.Table.Pockets;

namespace Roulette.Core.Factories
{
    public class PocketFactory
    {
        public static Pocket Create(string type, int number)
        {
            switch (type)
            {
                case "double-zero":
                    return new DoubleZeroPocket() { Number = number };
                case "zero":
                    return new ZeroPocket() { Number = number };
                case "red":
                    return new RedPocket() { Number = number };
                case "black":
                    return new BlackPocket() { Number = number };
            }

            return null;
        }
    }
}
