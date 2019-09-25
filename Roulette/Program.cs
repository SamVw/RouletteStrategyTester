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
            if (args.Length < 3)
            {
                System.Console.WriteLine("Please enter the correct format.");
                System.Console.WriteLine("Usage: Roulette <PlayerName> <BettingStrategy> <NumberOfCycles>");
                return 1;
            }

            string name = args[0];
            string strategy = args[1];
            bool test = int.TryParse(args[2], out int cycles);
            if (!test && cycles <= 1000)
            {
                System.Console.WriteLine("Please enter the correct format.");
                System.Console.WriteLine("Usage: Roulette <PlayerName> <BettingStrategy> <NumberOfCycles>");
                return 1;
            }

            var reader = CreatingServices(out var gameManager);

            try
            {
                gameManager.TestStrategy(strategy, cycles);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            reader.Read();

            return 0;
        }

        private static ConsoleReader CreatingServices(out GameManager gameManager)
        {
            ConsoleLogger logger = new ConsoleLogger();
            ConsoleReader reader = new ConsoleReader();

            Wheel wheel = new Wheel();
            MockTableLoader mockTableLoader = new MockTableLoader();
            LimitedRoulette game = new LimitedRoulette(wheel, mockTableLoader, 10);
            var simulator = new RouletteStrategySimulator(game);

            var visualizer = new Visualizer(logger);
            gameManager = new GameManager(simulator, visualizer, reader);
            return reader;
        }
    }
}
