using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Factories;
using Roulette.Core.Interfaces;
using Roulette.Infrastructure.Logging;

namespace Roulette.Core
{
    public class UserInputManager : IUserInputManager
    {
        private readonly ILogger _logger;
        private readonly IInputReader _reader;

        public UserInputManager(ILogger logger, IInputReader reader)
        {
            _logger = logger;
            _reader = reader;
        }

        public string Name { get; private set; }

        public string Strategy { get; private set; }

        public int Cycles { get; private set; }

        public int? MinimumBid { get; private set; }

        public int? MaximumBid { get; private set; }

        public int Budget { get; private set; }

        public int StartBet { get; private set; }

        public void RequestConfigurationData()
        {
            Reset();
            _logger.Clear();

            SetPlayerName();

            SetBudget();

            SetTableLimits();

            SetStrategy();

            SetCycles();

            SetStartBet();

            _logger.Clear();
        }

        private void Reset()
        {
            Name = null;
            Strategy = null;
            Cycles = 0;
            MinimumBid = null;
            MaximumBid = null;
            Budget = 0;
            StartBet = 0;
        }

        public bool ShowModal(string message, string acceptText, string denyText)
        {
            _logger.Log(message);
            string answer = _reader.Read();
            if (answer == denyText)
            {
                return false;
            }

            return true;
        }

        private void SetBudget()
        {
            Budget = Request<int>("Player budget: ");
        }

        private void SetCycles()
        {
            do
            {
                Cycles = Request<int>("Cycles ( < 1000 ): ");
            } while (Cycles >= 1000);
        }

        private void SetStartBet()
        {
            do
            {
                StartBet = Request<int>("Start bet: ");
            } while (MinimumBid != null && StartBet < MinimumBid);
        }

        private T Request<T>(string message)
        {
            bool valid;
            T budget = default;
            do
            {
                _logger.Log(message);
                var input = _reader.Read();
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        // Cast ConvertFromString(string text) : object to (T)
                        budget = (T)converter.ConvertFromString(input);
                    }
                    valid = true;
                }
                catch (Exception)
                {
                    valid = false;
                }
            } while (!valid);

            return budget;
        }

        private void SetStrategy()
        {
            var input = "";
            do
            {
                _logger.Log("Strategy Martingale(default) | Waiting | 1-3-2-6 | Cancellation : ");
                input = _reader.Read();
            } while (!ValidateStrategy(input) && input != "");

            Strategy = input == "" ? "Martingale" : input;
        }

        public static bool ValidateStrategy(string input)
        {
            var strategies = new List<string>() { "Martingale", "Waiting", "1-3-2-6", "Cancellation" };

            return strategies.Contains(input);
        }

        private void SetPlayerName()
        {
            _logger.Log("Player name (default: test): ");
            var input = _reader.Read();

            Name = input == "" ? "test" : input;
        }

        private void SetTableLimits()
        {
            var limits = ShowModal("Table has minimum and maximum bid? (y or n)", "y", "n");
            if (limits)
            {
                do
                {
                    if (MinimumBid >= MaximumBid)
                    {
                        _logger.Clear();
                        _logger.Log("Minimum bid must be lower then Maximum bid!");
                    }

                    MinimumBid = Request<int>("Minimum bid: ");
                    MaximumBid = Request<int>("Maximum bid: ");
                } while (MinimumBid >= MaximumBid);
            }
        }

        private void HandleInvalidArguments(string extra)
        {
            _logger.Log(extra);
            _logger.Log("Usage: Roulette <PlayerName> <BettingStrategy> <NumberOfCycles> <budget> <startBet> <TableMinimum = optional> <TableMaximum = optional>");
            throw new ArgumentException("");
        }
    }
}
