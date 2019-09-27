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
        static void Main()
        {
            var rouletteStrategyTester = CreateServices();
            rouletteStrategyTester.Run();
        }

        private static RouletteStrategyTester CreateServices()
        {
            ConsoleLogger logger = new ConsoleLogger();
            ConsoleReader reader = new ConsoleReader();

            UserInputManager userInputManager = new UserInputManager(logger, reader);
            StatisticsManager statisticsManager = new StatisticsManager();
            Visualizer visualizer = new Visualizer(logger);

            return new RouletteStrategyTester(visualizer, userInputManager, statisticsManager);
        }
    }
}
