using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Sea
    {
        public static IEnumerable<Coordinate> GetAllCoordinatesFrom(IEnumerable<BattleShip> ships)
        {
            IEnumerable<Coordinate> allLocations = ships
                .SelectMany(x => x.GetLocation()
                    .GetCoordinates());

            return allLocations;
        }

        private IList<BattleShip> AllShips;

        public Sea()
        {
            AllShips = new List<BattleShip>();
        }

        public void AcceptMissile(Missile missile)
        {
            foreach(BattleShip ship in GetAllSurvivingShips())
            {
                ship.AcceptMissile(missile);
            }
        }

        public void AcceptShip(BattleShip ship)
        {
            // check first
            AllShips.Add(ship);
        }

        public IEnumerable<BattleShip> GetAllSunkShips()
        {
            IEnumerable<BattleShip> allSunkShips = this.AllShips
                .Where(x => x.IsSunk());

            return allSunkShips;
        }

        public IEnumerable<BattleShip> GetAllSurvivingShips()
        {
            IEnumerable<BattleShip> allSurvivingShips = this.AllShips
                .Where(x => ! x.IsSunk());

            return allSurvivingShips;
        }
    }
}
