using Roulette.Core.Game.Bets;

namespace Roulette.Core.Game
{
    public interface IRouletteGame
    {
        double PlaceBetAndSpin(Bet b);
    }
}