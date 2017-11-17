using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSeaBattle
{
    class GameEngine
    {
        private Sea TheSea;
        private ViewModel ViewModel;

        private IUpdateable Form;

        public GameEngine(IUpdateable form)
        {
            TheSea = new Sea();
            ViewModel = new ViewModel(this.TheSea);

            Form = form;
        }

        public void Start()
        {
            PlaceShips();
            ViewModel.Recalculate();

            UpdateUI();

            StartGameLoop();
        }

        private void StartGameLoop()
        {
            //while (true)
            {
                Shoot(0, 1);
                Shoot(1, 1);
                Shoot(2, 1);
                Shoot(3, 1);
                Shoot(4, 1);

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            ViewModel.Recalculate();
            Form.DoUpdate();
        }

        private void Shoot(int x, int y)
        {
            var missile = new Missile(new Coordinate(x, y), null);

            this.TheSea.AcceptMissile(missile);
        }

        public ViewModel GetViewModel()
        {
            return ViewModel;
        }

        public Sea GetSea()
        {
            return TheSea;
        }

        private void AddSurvivingShip()
        {
            var c1 = new Coordinate(0, 1);
            var c2 = new Coordinate(1, 1);
            var c3 = new Coordinate(2, 1);
            var c4 = new Coordinate(3, 1);
            var c5 = new Coordinate(4, 1);

            var location = new Location(c1, c2, c3, c4, c5);

            BattleShip albatros = new Albatros(location);

            TheSea.AcceptShip(albatros);
        }

        private void AddSunkShip()
        {
            var c1 = new Coordinate(2, 2);
            var c2 = new Coordinate(2, 3);
            var c3 = new Coordinate(2, 4);
            var c4 = new Coordinate(2, 5);
            var c5 = new Coordinate(2, 6);

            var location = new Location(c1, c2, c3, c4, c5);

            BattleShip scraper = new SunkShip(location);

            TheSea.AcceptShip(scraper);
        }

        public void PlaceShips()
        {
            AddSunkShip();

            AddSurvivingShip();
        }
    }
}
