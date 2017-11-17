using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Sea
    {
        public const int GridWidth = 24;
        public const int GridHeight = 12;

        public static IEnumerable<ICoordinate> GetAllCoordinatesFrom(IEnumerable<BattleShip> ships)
        {
            IEnumerable<ICoordinate> allLocations = ships
                .SelectMany(x => x.GetLocation()
                    .GetCoordinates());

            return allLocations;
        }

        private IList<BattleShip> AllShips;

        public Sea()
        {
            AllShips = new List<BattleShip>();
        }

        public void AcceptMissiles(IEnumerable<Missile> missiles)
        {
            foreach (Missile missile in missiles)
            {
                AcceptMissile(missile);
            }
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
