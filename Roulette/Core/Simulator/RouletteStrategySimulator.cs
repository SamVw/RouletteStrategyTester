using Roulette.Core.Game;
using Roulette.Core.Models;
using Roulette.Core.Simulator.Strategies;
using Roulette.Infrastructure.Loaders;

namespace Roulette.Core.Simulator
{
    public class RouletteStrategySimulator : IRouletteStrategySimulator
    {
        private Player _player;

        private LimitedRoulette _rouletteGame;

        public StrategyResult ExecuteStrategy(Strategy strategy, double budget, double betStartAmount)
        {
            _player = new Player(budget);
            return strategy.Execute(_rouletteGame, _player, betStartAmount);
        }

        public void UseLimitedRouletteGame(int min, int max)
        {
            UseRouletteGame();
            _rouletteGame.SetLimits(min, max);
        }

        public void UseRouletteGame()
        {
            _rouletteGame = new LimitedRoulette(new Wheel(), new MockTableLoader());
        }
    }
}
