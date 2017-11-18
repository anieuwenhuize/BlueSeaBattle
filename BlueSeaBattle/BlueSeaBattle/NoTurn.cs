using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class NoTurn : Turn
    {
        public NoTurn(IEnumerable<BattleShip> BattleShips, Sea sea, ViewModel viewModel) : 
            base(BattleShips, sea, viewModel)
        {
        }

        public override string GetCurrentShipDescripton()
        {
            return "Game not started";
        }
    }
}
