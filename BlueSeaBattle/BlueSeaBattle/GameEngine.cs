using System.Collections.Generic;
using System.Linq;

namespace BlueSeaBattle
{
    class GameEngine
    {
        private Sea TheSea;
        private ViewModel ViewModel;
        private ICollection<Turn> Turns;
        private Turn CurrentTurn;

        private IUpdateable Form;

        public GameEngine(IUpdateable form)
        {
            TheSea = new Sea();
            ViewModel = new ViewModel(this.TheSea);

            Turns = new List<Turn>();
            CurrentTurn = new NoTurn(new List<BattleShip>(), TheSea, Form);

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
            while (true)
            {
                CurrentTurn = new Turn(TheSea.GetAllSurvivingShips(), TheSea, Form);

                CurrentTurn.Start();

                UpdateUI();

                if (HasWinner())
                {
                    return;
                }

                Turns.Add(CurrentTurn);

                Delay();
            }
        }

        public StatusReport GetStatusReport()
        {
            int allSurvivingShips = TheSea.GetAllSurvivingShips().Count();
            int allSunkShips = TheSea.GetAllSunkShips().Count();
            int allShips = allSurvivingShips + allSunkShips;

            var statusreport = new StatusReport(allShips, allSunkShips, this.Turns.Count());
            statusreport.CurrentShipDescription = CurrentTurn.GetCurrentShipDescripton();

            return statusreport;
        }

        private bool HasWinner()
        {
            return TheSea.GetAllSurvivingShips().Count() <= 1;
        }

        private void Delay()
        {
            System.Threading.Thread.Sleep(1500);
        }

        private void UpdateUI()
        {
            ViewModel.Recalculate();
            Form.DoUpdate();
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

        private void AddSurvivingShip2()
        {
            var c1 = new Coordinate(0, 4);
            var c2 = new Coordinate(1, 4);
            var c3 = new Coordinate(2, 4);
            var c4 = new Coordinate(3, 4);
            var c5 = new Coordinate(4, 4);

            var location = new Location(c1, c2, c3, c4, c5);

            BattleShip albatros = new SnelleJelle(location);

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

            AddSurvivingShip2();
        }
    }
}
