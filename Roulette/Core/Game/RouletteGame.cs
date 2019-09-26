using System;
using System.Collections.Generic;
using Roulette.Core.Game.Bets;
using Roulette.Core.Game.Table;
using Roulette.Core.Game.Table.Pockets;
using Roulette.Core.Interfaces;

namespace Roulette.Core.Game
{
    public class RouletteGame
    {
        private readonly IWheel _wheel;
        private readonly ITableLoader _tableLoader;

        private RouletteTable _rouletteTable;

        public RouletteGame(IWheel wheel, ITableLoader tableLoader)
        {
            _wheel = wheel;
            _tableLoader = tableLoader;
            
            LoadTable();
        }

        public void LoadTable()
        {
            _rouletteTable = _tableLoader.Load(@"./Assets/RouletteTable.txt");
        }


        // Returns winnings for given bet
        public virtual double PlaceBetAndSpin(Bet b)
        {
            int result = _wheel.Spin();
            Pocket pocket = _rouletteTable.GetPocket(result);

            return b.CalculateWinnings(pocket);
        }
    }
}
