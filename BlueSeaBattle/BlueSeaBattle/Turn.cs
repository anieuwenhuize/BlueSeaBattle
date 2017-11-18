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
        private List<Missile> FiredMissiles;

        private Sea TheSea;

        public Random Randomizer;

        public ViewModel ViewModel;

        private BattleShip CurrentShip;

        public Turn(IEnumerable<BattleShip> BattleShips, Sea sea, ViewModel viewModel)
        {
            Randomizer = new Random();
            FiredMissiles = new List<Missile>();

            this.BattleShips = new List<BattleShip> (BattleShips);
            this.TheSea = sea;
            this.ViewModel = viewModel;
        }

        public virtual string GetCurrentShipDescripton()
        {
            bool hasCurrentShip = CurrentShip != null;

            return (hasCurrentShip)
                ? CurrentShip.ToString()
                : "Geen schip";
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

        public void Start()
        {
            foreach(BattleShip battleShip in BattleShips)
            {
                CurrentShip = battleShip;

                HandleCurrentShip();

                this.ViewModel.Recalculate();

                Delay();
            }
        }

        private void Delay()
        {
            System.Threading.Thread.Sleep(100);
        }

        private void HandleCurrentShip()
        {
            BattleshipAssestProvider assetsprovider = new BattleshipAssestProvider(CurrentShip);

            // Shoot first
            var canons = assetsprovider.GetCanons();
            var radars = assetsprovider.GetRadars();

            var weaponscombi = new CanonAndRadarCombiList(canons, radars);

            IEnumerable<Missile> missiles = Shoot(weaponscombi, CurrentShip);

            this.FiredMissiles.AddRange(missiles);

            var incommin = new IncommingMissiles(TheSea, missiles);
            incommin.Launch();

            // Move  
            var sail = new SailAway(CurrentShip);
            sail.Navigate();
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
