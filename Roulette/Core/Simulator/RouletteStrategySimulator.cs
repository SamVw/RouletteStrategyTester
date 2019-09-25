using Roulette.Core.Game;
using Roulette.Core.Models;
using Roulette.Core.Simulator.Strategies;

namespace Roulette.Core.Simulator
{
    public class RouletteStrategySimulator
    {
        private Player _player;

        private IRouletteGame _rouletteGame;

        public RouletteStrategySimulator(IRouletteGame game)
        {
            _rouletteGame = game;
        }

        public StrategyResult ExecuteStrategy(Strategy strategy, double budget, double betStartAmount)
        {
            _player = new Player(budget);
            return strategy.Execute(_rouletteGame, _player, betStartAmount);
        }
    }
}
