using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Factories;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;
using Roulette.Core.Simulator;
using Roulette.UI;

namespace Roulette.Core
{
    public class GameManager
    {
        private readonly RouletteStrategySimulator _simulator;
        private readonly IVisualizer _visualizer;
        private readonly IInputReader _inputReader;
        private readonly StatisticsManager _statisticsManager;

        public GameManager(RouletteStrategySimulator simulator, IVisualizer visualizer, IInputReader inputReader)
        {
            _simulator = simulator;
            _visualizer = visualizer;
            _inputReader = inputReader;
            _statisticsManager = new StatisticsManager();
        }

        public void TestStrategy(string strategy, int cycles)
        {
            var result = _simulator.ExecuteStrategy(StrategyFactory.Create(strategy, cycles), 1000, 10);

            _statisticsManager.Process(result, strategy, cycles);
            _visualizer.ShowStatistics(_statisticsManager.GetStatistics());
        }
    }
}
