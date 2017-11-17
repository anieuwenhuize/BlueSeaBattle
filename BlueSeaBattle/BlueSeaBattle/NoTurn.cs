using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class NoTurn : Turn
    {
        public NoTurn(IEnumerable<BattleShip> BattleShips, Sea sea, IUpdateable form) : 
            base(BattleShips, sea, form)
        {
        }

        public override string GetCurrentShipDescripton()
        {
            return "Game not started";
        }
    }
}
