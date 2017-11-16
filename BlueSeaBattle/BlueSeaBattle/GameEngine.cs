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
        private IUpdateable Form;
        private Sea TheSea;

        public GameEngine(IUpdateable form)
        {
            Form = form;

            TheSea = new Sea();
        }

        public void Start()
        {
            RunTestScenario();
        }

        public ViewModel GetViewModel()
        {
            ViewModel vm = new ViewModel(this.TheSea);

            return vm;
        }

        public void RunTestScenario()
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
    }
}
