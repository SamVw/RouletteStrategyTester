using System;
using Roulette.Core;
using Roulette.Core.Game;
using Roulette.Core.Game.Bets;
using Roulette.Core.Models;
using Roulette.Core.Simulator;
using Roulette.Core.Simulator.Strategies;
using Roulette.Infrastructure.Loaders;
using Roulette.Infrastructure.Logging;
using Roulette.Infrastructure.Reader;
using Roulette.UI;

namespace Roulette
{
    class Program
    {
        static int Main(string[] args)
        {
            var rouletteStrategyTester = CreatingServices();

            rouletteStrategyTester.Test(args);

            return 0;
        }

        private static RouletteStrategyTester CreatingServices()
        {
            ConsoleLogger logger = new ConsoleLogger();
            ConsoleReader reader = new ConsoleReader();

            UserInputManager userInputManager = new UserInputManager(logger, reader);
            StatisticsManager statisticsManager = new StatisticsManager();
            Visualizer visualizer = new Visualizer(logger);

            return new RouletteStrategyTester(visualizer, userInputManager, statisticsManager, logger);
        }
    }
}
