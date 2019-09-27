using Roulette.Core.Factories;
using Roulette.Core.Game;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;
using Roulette.Core.Simulator.Strategies;
using Roulette.Infrastructure.Loaders;

namespace Roulette.Core.Simulator
{
    public class RouletteStrategySimulator : IRouletteStrategySimulator
    {
        private RouletteGame _rouletteGame;

        public StrategyResult ExecuteStrategy(Strategy strategy, int betStartAmount)
        {
            return strategy.Execute(_rouletteGame, betStartAmount);
        }

        public void InitRouletteGame(int? minimumBid, int? maximumBid)
        {
            _rouletteGame = RouletteGameFactory.Create(minimumBid, maximumBid);
        }
    }
}
