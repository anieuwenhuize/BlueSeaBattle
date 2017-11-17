using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class BattleshipAssestProvider
    {
        private BattleShip Battleship;

        public BattleshipAssestProvider(BattleShip battleship)
        {
            this.Battleship = battleship;
        }

        public IEnumerable<T> GetAssets<T>()
        {
            IEnumerable<T> assets = Battleship.GetSlotItems()
               .Where(x => x is T)
               .Select(x => (T)x);

            return assets;
        }

        public IEnumerable<IKanon> GetCanons()
        {
            IEnumerable<IKanon> canons = GetAssets<IKanon>();

            return canons;
        }

        public IEnumerable<IKapitein> GetCaptains()
        {
            IEnumerable<IKapitein> canons = GetAssets<IKapitein>();

            return canons;
        }

        public IEnumerable<IGoalkeeper> GetGoalkeepers()
        {
            IEnumerable<IGoalkeeper> goalkeepers = GetAssets<IGoalkeeper>();

            return goalkeepers;
        }

        public IEnumerable<IRadar> GetRadars()
        {
            IEnumerable<IRadar> radars = GetAssets<IRadar>();

            return radars;
        }
    }
}
