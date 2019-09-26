//using System;
//using Roulette.Core.Game;
//using Roulette.Core.Game.Bets;
//using Roulette.Core.Models;
//using Roulette.Infrastructure.Loaders;
//using Roulette.Infrastructure.Logging;

//namespace Roulette
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ConsoleLogger logger = new ConsoleLogger();
//            Wheel wheel = new Wheel();
//            MockTableLoader mockTableLoader = new MockTableLoader();

//            RouletteGame game = new RouletteGame(wheel, mockTableLoader);
//            game.LoadTable();

//            double result;
//            logger.Log("Color bet: black");
//            do
//            {
//                result = game.PlaceBetAndSpin(new ColorBet(200, PocketColor.Black));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Color bet: red");
//            do
//            {
//                result = game.PlaceBetAndSpin(new ColorBet(200, PocketColor.Red));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Parity bet: Even");
//            do
//            {
//                result = game.PlaceBetAndSpin(new ParityBet(200, Parity.Even));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Parity bet: odd");
//            do
//            {
//                result = game.PlaceBetAndSpin(new ParityBet(200, Parity.Odd));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("High low bet: Low");
//            do
//            {
//                result = game.PlaceBetAndSpin(new HighLowBets(200, HighLow.Low));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("High low bet: High");
//            do
//            {
//                result = game.PlaceBetAndSpin(new HighLowBets(200, HighLow.High));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Full column bet: 1");
//            do
//            {
//                result = game.PlaceBetAndSpin(new FullColumnBet(200, 1));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Full column bet: 2");
//            do
//            {
//                result = game.PlaceBetAndSpin(new FullColumnBet(200, 2));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Full column bet: 3");
//            do
//            {
//                result = game.PlaceBetAndSpin(new FullColumnBet(200, 3));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Number Ranges: 1");
//            do
//            {
//                result = game.PlaceBetAndSpin(new NumberRangesBet(200, 1));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Number Ranges: 2");
//            do
//            {
//                result = game.PlaceBetAndSpin(new NumberRangesBet(200, 2));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Number Ranges: 3");
//            do
//            {
//                result = game.PlaceBetAndSpin(new NumberRangesBet(200, 3));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Line bet: 1");
//            do
//            {
//                result = game.PlaceBetAndSpin(new LineBet(200, 1));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Line bet: 4");
//            do
//            {
//                result = game.PlaceBetAndSpin(new LineBet(200, 4));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Five numbers bet");
//            do
//            {
//                result = game.PlaceBetAndSpin(new FiveNumbersBet(200));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Corners bet: 1");
//            do
//            {
//                result = game.PlaceBetAndSpin(new CornerBet(200, 1));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Corners bet: 2");
//            do
//            {
//                result = game.PlaceBetAndSpin(new CornerBet(200, 26));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Street bet: 1");
//            do
//            {
//                result = game.PlaceBetAndSpin(new StreetBet(200, 1));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Street bet: 19");
//            do
//            {
//                result = game.PlaceBetAndSpin(new StreetBet(200, 19));
//                logger.Log(result);
//            } while (result < 0);
//            logger.Log("Street bet: 34");
//            do
//            {
//                result = game.PlaceBetAndSpin(new StreetBet(200, 34));
//                logger.Log(result);
//            } while (result < 0);


//            logger.Log("Split bet: 32, 33");
//            do
//            {
//                result = game.PlaceBetAndSpin(new SplitBet(200, new AdjacentPair() { Number1 =  32, Number2 = 33 }));
//                logger.Log(result);
//            } while (result < 0);

//            logger.Log("Straight bet: 34");
//            do
//            {
//                result = game.PlaceBetAndSpin(new StraightBet(200, 34));
//                logger.Log(result);
//            } while (result < 0);

//            logger.Log("Straight bet: 14");
//            do
//            {
//                result = game.PlaceBetAndSpin(new StraightBet(200, 14));
//                logger.Log(result);
//            } while (result < 0);
//        }
//    }
//}
