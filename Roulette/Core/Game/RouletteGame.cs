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

        protected RouletteGame(IWheel wheel, ITableLoader tableLoader)
        {
            _wheel = wheel;
            _tableLoader = tableLoader;
            
            LoadTable();
        }

        public void LoadTable()
        {
            List<Pocket> pockets = _tableLoader.Load();
            _rouletteTable = new RouletteTable(pockets);
        }


        // Returns winnings for given bet
        public virtual double PlaceBetAndSpin(Bet b)
        {
            int result = _wheel.Spin();

            Pocket pocket = _rouletteTable.GetPocket(result);

            double winnings = b.CalculateWinnings(pocket);

            return winnings;
        }
    }
}
