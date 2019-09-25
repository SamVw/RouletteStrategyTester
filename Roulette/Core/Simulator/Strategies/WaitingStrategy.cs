using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Game;
using Roulette.Core.Game.Bets;
using Roulette.Core.Models;

namespace Roulette.Core.Simulator.Strategies
{
    public class WaitingStrategy : Strategy
    {
        // Amount of losses in a row
        private int _c;
        // Wager amount
        private double _w;

        public WaitingStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, double betStartAmount)
        {
            _c = 0;
            _w = betStartAmount;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget;
            List<double> bets = new List<double>();

            int redStraightWins = 0, blackStraightWins = 0;
            PocketColor lastHitColor = PocketColor.Green;

            for (int i = 0; i < Cycles; i++)
            {
                double result = 0;
                if (redStraightWins == 7)
                {
                    redStraightWins = 0;
                    lastHitColor = PocketColor.Green;

                    result = rouletteGame.PlaceBetAndSpin(new ColorBet(_w, PocketColor.Black));
                }
                else if (blackStraightWins == 7)
                {
                    blackStraightWins = 0;
                    lastHitColor = PocketColor.Green;

                    result = rouletteGame.PlaceBetAndSpin(new ColorBet(_w, PocketColor.Red));
                }
                else
                {
                    result = rouletteGame.PlaceBetAndSpin(new ColorBet(_w, PocketColor.Red));

                    lastHitColor = HandleRegularResult(betStartAmount, result, lastHitColor, ref blackStraightWins, ref redStraightWins);
                }

                CollectStats(_w, bets, ref maxBet, ref minBet);
                player.Budget += result;
            }

            return new StrategyResult()
            {
                EndBudget = player.Budget,
                Strategy = "Waiting",
                CyclesRan = Cycles,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget
            };
        }

        private PocketColor HandleRegularResult(double betStartAmount, double result, PocketColor lastHitColor,
            ref int blackStraightWins, ref int redStraightWins)
        {
            if (result < 0)
            {
                _w = _w * 2;
                _c++;

                if (lastHitColor == PocketColor.Black)
                {
                    blackStraightWins++;
                }
                else
                {
                    blackStraightWins = 0;
                }

                lastHitColor = PocketColor.Black;
            }

            if (result > 0)
            {
                _c = 0;
                _w = betStartAmount;

                if (lastHitColor == PocketColor.Red)
                {
                    redStraightWins++;
                }
                else
                {
                    redStraightWins = 0;
                }

                lastHitColor = PocketColor.Red;
            }

            return lastHitColor;
        }
    }
}
