using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Factories;
using Roulette.Core.Game;
using Roulette.Core.Interfaces;
using Roulette.Core.Models;
using Roulette.Core.Simulator;
using Roulette.Infrastructure.Logging;
using Roulette.UI;

namespace Roulette.Core
{
    public class RouletteStrategyTester
    {
        private readonly IRouletteStrategySimulator _simulator;
        private readonly IVisualizer _visualizer;
        private readonly IUserInputManager _userInputManager;
        private readonly IStatisticsManager _statisticsManager;
        private readonly ILogger _logger;

        public RouletteStrategyTester(IRouletteStrategySimulator simulator, IVisualizer visualizer, IUserInputManager userInputManager, IStatisticsManager statisticsManager, ILogger logger)
        {
            _simulator = simulator;
            _visualizer = visualizer;
            _userInputManager = userInputManager;
            _statisticsManager = statisticsManager;
            _logger = logger;
        }

        public void Test(string[] args)
        {
            try
            {
                _userInputManager.InterpretArguments(args);
            }
            catch (ArgumentException e)
            {
                _logger.Log(e.Message);
                return;
            }

            _simulator.UseLimitedRouletteGame(_userInputManager.MinimumBid, _userInputManager.MaximumBid);

            do
            {
                var strategy = StrategyFactory.Create(_userInputManager.Strategy, _userInputManager.Cycles);
                var result = _simulator.ExecuteStrategy( strategy, _userInputManager.Budget, _userInputManager.StartBet);
                _statisticsManager.Process(result);
                _visualizer.ShowStatistics(_statisticsManager.GetStatistics());
            } while (_userInputManager.RestartStrategy());

        }
    }
}
