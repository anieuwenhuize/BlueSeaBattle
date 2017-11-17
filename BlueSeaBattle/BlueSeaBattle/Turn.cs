using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Turn
    {
        private IEnumerable<BattleShip> BattleShips;

        public Turn(IEnumerable<BattleShip> BattleShips)
        {
            this.BattleShips = BattleShips;

            Visit();
        }

        private void Visit()
        {
            foreach(BattleShip battleShip in BattleShips)
            {
                BattleshipAssestProvider assetsprovider = new BattleshipAssestProvider(battleShip);

                // Shoot first


                // Move  
            }
        }

        private void HandleShip(BattleShip ship)
        {

        }

    }
}
