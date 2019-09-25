using Roulette.Core.Models;
using Roulette.Core.Simulator.Strategies;

namespace Roulette.Core.Simulator
{
    public interface IRouletteStrategySimulator
    {
        StrategyResult ExecuteStrategy(Strategy strategy, double budget, double betStartAmount);
        void UseLimitedRouletteGame(int min, int max);
    }
}