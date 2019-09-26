using Roulette.Core.Models;
using Roulette.Core.Simulator.Strategies;

namespace Roulette.Core.Interfaces
{
    public interface IRouletteStrategySimulator
    {
        StrategyResult ExecuteStrategy(Strategy strategy, double budget, int betStartAmount, string name);

        void InitRouletteGame(int? minimumBid, int? maximumBid);
    }
}