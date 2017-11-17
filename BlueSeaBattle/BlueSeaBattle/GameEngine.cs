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
            System.Threading.Thread.Sleep(800);
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

        public void AddAlbatros(Location location)
        {
            IFitInSocket captainSlow = new TestCaptain(3, Direction.Oost);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(20, 3) });

            BattleShip albatros = new TestShip("Albatros", location, captainSlow, canon);

            TheSea.AcceptShip(albatros);
        }

        public void AddSallySinke(Location location)
        {
            IFitInSocket captainNormal = new TestCaptain(2, Direction.West);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(2, 2) });

            BattleShip albatros = new TestShip("Sally Sinke", location, captainNormal, canon);

            TheSea.AcceptShip(albatros);
        }

        public void AddDeEendracht(Location location)
        {
            IFitInSocket captainQuick = new TestCaptain(1, Direction.West);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(2, 2) });

            BattleShip albatros = new TestShip("De Eendracht", location, captainQuick, canon);

            TheSea.AcceptShip(albatros);
        }

        public void PlaceShips()
        {
            var plan = new Plan();

            AddAlbatros(plan.GetNexLocation());
            AddSallySinke(plan.GetNexLocation());
            AddDeEendracht(plan.GetNexLocation());
        }
    }
}
