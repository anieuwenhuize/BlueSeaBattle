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

        public GameEngine()
        {
            TheSea = new Sea();
            ViewModel = new ViewModel(this.TheSea);
        }

        public void Start()
        {
            RunTestScenario();
            ViewModel.Recalculate();
        }

        public ViewModel GetViewModel()
        {
            return ViewModel;
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

        public void RunTestScenario()
        {
            AddSunkShip();

            AddSurvivingShip();
        }
    }
}
