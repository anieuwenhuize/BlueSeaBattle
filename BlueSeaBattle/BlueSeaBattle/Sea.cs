using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Sea
    {
        private IList<BattleShip> AllShips;

        public Sea()
        {
            AllShips = new List<BattleShip>();
        }

        public void AcceptShip(BattleShip ship)
        {
            // check first
            AllShips.Add(ship);
        }
    }
}
