using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this._logger = logger;
            _reader = reader;
        }

        public string Name { get; private set; }

        public string Strategy { get; private set; }

        public int Cycles { get; private set; }

        public int MinimumBid { get; private set; }

        public int MaximumBid { get; private set; }

        public int Budget { get; private set; }

        public int StartBet { get; private set; }

        public void InterpretArguments(string[] args)
        {
            if (args.Length < 7)
            {
                HandleInvalidArguments("Provide at least 7 arguments");
            }

            Name = args[0];
            Strategy = args[1];
            bool test = int.TryParse(args[2], out int cycles);
            if (!test || cycles >= 1000)
            {
                HandleInvalidArguments("Provide a valid number of cycles < 1000");
            }
            Cycles = cycles;

            test = int.TryParse(args[3], out int tableMinimum);
            bool test2 = int.TryParse(args[4], out int tableMaximum);
            if ((!test || !test2) || tableMinimum > tableMaximum)
            {
                HandleInvalidArguments("Provide a valid min and max value for bets. min < max");
            }
            MinimumBid = tableMinimum;
            MaximumBid = tableMaximum;

            test = int.TryParse(args[5], out int budget);
            test2 = int.TryParse(args[6], out int startBet);
            if ((!test || !test2) || startBet > budget || startBet < MinimumBid)
            {
                HandleInvalidArguments("Provide a valid budget and startBet for the strategy. startBet < budget && startBet < minBid");
            }
            Budget = budget;
            StartBet = startBet;
        }

        public bool RestartStrategy()
        {
            _logger.Log("Run strategy again? (y or n):");
            string answer = _reader.Read();
            if (answer == "n")
            {
                return false;
            }

            return true;
        }

        private void HandleInvalidArguments(string extra)
        {
            _logger.Log(extra);
            _logger.Log("Usage: Roulette <PlayerName> <BettingStrategy> <NumberOfCycles> <TableMinimum> <TableMaximum> <budget> <startBet>");
            throw new ArgumentException("");
        }
    }
}
