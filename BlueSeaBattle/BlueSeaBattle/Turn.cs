using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Turn
    {
        private ICollection<BattleShip> BattleShips;

        private Sea TheSea;

        public Random Randomizer;

        public Turn(ICollection<BattleShip> BattleShips, Sea sea)
        {
            Randomizer = new Random();

            this.BattleShips = BattleShips;
            this.TheSea = sea;

            Visit();
        }

        private T GetRadomItem<T>(ICollection<T> items)
        {
            int min = 0;
            int max = items.Count;

            int randomNumber = Randomizer.Next(min, max);

            T randomItem = items
                .Take(randomNumber)
                .Last();

            return randomItem;
        }

        private BattleShip GetRandomShip()
        {
            BattleShip randomship = GetRadomItem(BattleShips);

            return randomship;
        }

        public ICoordinate GetRandomShipCoordinate()
        {
            BattleShip ship = GetRandomShip();

            IEnumerable<ICoordinate> coordinates = ship
                .GetLocation()
                .GetCoordinates();

            ICoordinate coordinate = GetRadomItem(new List<ICoordinate>(coordinates));

            return coordinate;
        }

        private void Visit()
        {
            foreach(BattleShip battleShip in BattleShips)
            {
                HandleShip(battleShip);
            }
        }

        private void HandleShip(BattleShip battleship)
        {
            BattleshipAssestProvider assetsprovider = new BattleshipAssestProvider(battleship);

            // Shoot first
            var canons = assetsprovider.GetCanons();
            var radars = assetsprovider.GetRadars();

            var weaponscombi = new CanonAndRadarCombiList(canons, radars);

            IEnumerable<Missile> missiles = Shoot(weaponscombi, battleship);

            TheSea.AcceptMissiles(missiles);

            // Move  
        }

        

        private IEnumerable<Missile> Shoot(CanonAndRadarCombiList weaponcombi, BattleShip battleship)
        {
            ICollection<Missile> missiles = new List<Missile>();

            foreach (Tuple<IKanon, IRadar> weapons in weaponcombi)
            {
                ICoordinate coordinate = TakeShot(weapons);
                Missile missile = new Missile(coordinate, battleship);

                missiles.Add(missile);
            }

            return missiles;
        }

        private ICoordinate TakeShot(Tuple<IKanon, IRadar> weaponcombi)
        {
            IRadar radar = weaponcombi.Item2;
            IKanon canon = weaponcombi.Item1;

            if (radar != null)
            {
                ICoordinate givenTarget = GetRandomShipCoordinate();
                ICoordinate target = radar.Parse(givenTarget.GetX(), givenTarget.GetY());

                return canon.Fire(target);
            }

            else
            {
                return canon.Fire();
            }
        }

    }
}
