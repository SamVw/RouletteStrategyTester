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
        public WaitingStrategy(int cycles) : base(cycles)
        {
        }

        public override StrategyResult Execute(RouletteGame rouletteGame, Player player, int betStartAmount)
        {
            C = 0;
            W = betStartAmount;
            double minBet = betStartAmount, maxBet = betStartAmount, startBudget = player.Budget, minBudget = player.Budget, maxBudget = player.Budget;
            List<double> bets = new List<double>();

            int redStraightWins = 0, blackStraightWins = 0;
            PocketColor lastHitColor = PocketColor.Green;

            for (int i = 0; i < Cycles; i++)
            {
                double result = 0;
                if (redStraightWins == 7)
                {
                    redStraightWins = Handle7RedStraightWins(rouletteGame, player, out lastHitColor, out result);
                }
                else if (blackStraightWins == 7)
                {
                    blackStraightWins = Handle7BlackStraightWins(rouletteGame, player, out lastHitColor, out result);
                }
                else
                {
                    result = HandleNo7StraightWins(rouletteGame, player, betStartAmount, ref lastHitColor, ref blackStraightWins, ref redStraightWins);
                }

                player.Budget += result;
                CyclesRan++;
                CollectStats(W, bets, ref maxBet, ref minBet, ref minBudget, ref maxBudget, player.Budget);

                if (player.IsBroke)
                {
                    break;
                }
            }

            return new StrategyResult()
            {
                EndBudget = player.Budget,
                Strategy = "Waiting",
                CyclesRan = Cycles,
                MaxBet = maxBet,
                MinBet = minBet,
                AllBets = bets,
                StartBudget = startBudget,
                Name = player.Name,
                MaxBudget = maxBudget,
                MinBudget = minBudget
            };
        }

        private double HandleNo7StraightWins(RouletteGame rouletteGame, Player player, int betStartAmount,
            ref PocketColor lastHitColor, ref int blackStraightWins, ref int redStraightWins)
        {
            double result;
            W = PreventImpossibleBet(player.Budget, W);
            result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Red));

            lastHitColor =
                HandleRegularResult(betStartAmount, result, lastHitColor, ref blackStraightWins, ref redStraightWins);
            return result;
        }

        private int Handle7BlackStraightWins(RouletteGame rouletteGame, Player player, out PocketColor lastHitColor,
            out double result)
        {
            int blackStraightWins;
            blackStraightWins = 0;
            lastHitColor = PocketColor.Green;

            W = PreventImpossibleBet(player.Budget, W);
            result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Red));
            return blackStraightWins;
        }

        private int Handle7RedStraightWins(RouletteGame rouletteGame, Player player, out PocketColor lastHitColor,
            out double result)
        {
            int redStraightWins;
            redStraightWins = 0;
            lastHitColor = PocketColor.Green;

            W = PreventImpossibleBet(player.Budget, W);
            result = SpinRouletteWithExceptionHandling(rouletteGame, new ColorBet(W, PocketColor.Black));
            return redStraightWins;
        }

        private PocketColor HandleRegularResult(int betStartAmount, double result, PocketColor lastHitColor,
            ref int blackStraightWins, ref int redStraightWins)
        {
            if (result < 0)
            {
                W = W * 2;
                C++;

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
                C = 0;
                W = betStartAmount;

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
