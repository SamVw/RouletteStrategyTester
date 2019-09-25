using Roulette.Core.Models;

namespace Roulette.Core.Game.Table.Pockets
{
    public abstract class Pocket
    {
        public abstract int Number { get; set; }

        public abstract PocketColor Color { get; }

        public int IsEven()
        {
            if (Number == 0 || Number == -1)
            {
                return -1;
            }

            int isEven = Number % 2 == 0 ? 1 : 0;
            return isEven;
        }

        public bool IsZeroOrDoubleZero()
        {
            return Number == 0 || Number == -1;
        }

        public static int ColumnOfPocket(int number)
        {
            var step1 = ((number + 0.0) / 3.0);
            var step2 = (int)(((decimal)step1 % 1) * 100);

            if (step2 == 33)
            {
                return 1;
            }
            if (step2 == 66)
            {
                return 2;
            }

            return 3;
        }
    }
}
