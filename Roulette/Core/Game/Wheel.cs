using System;
using Roulette.Core.Interfaces;

namespace Roulette.Core.Game
{
    public class Wheel : IWheel
    {
        private const int MAX = 37;

        private const int MIN = -1;

        private Random _random = new Random();

        public int Spin()
        {
            return _random.Next(MIN, MAX);
        }
    }
}
