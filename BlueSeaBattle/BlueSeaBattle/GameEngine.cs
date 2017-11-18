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

        public GameEngine(IUpdateable form)
        {
            TheSea = new Sea();
            ViewModel = new ViewModel(this.TheSea, form);

            Turns = new List<Turn>();
            CurrentTurn = new NoTurn(new List<BattleShip>(), TheSea, ViewModel);
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
                CurrentTurn = new Turn(TheSea.GetAllSurvivingShips(), TheSea, ViewModel);

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
            System.Threading.Thread.Sleep(0);
        }

        private void UpdateUI()
        {
            ViewModel.RecalculateSurface();
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
            IFitInSocket captainQuick = new TestCaptain(1, Direction.West);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(2, 2) });

            BattleShip albatros = new TestShip("Albatros", location, 
                captainQuick, captainQuick, captainQuick, captainQuick, captainQuick);

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
            IFitInSocket captainSlow = new TestCaptain(3, Direction.Oost);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(14, 1) });

            BattleShip albatros = new TestShip("De Eendracht", location, captainSlow, canon);

            TheSea.AcceptShip(albatros);
        }

        public void AddDeVliegendeHollander(Location location)
        {
            IFitInSocket captain = new TestCaptain(1, Direction.Noord);
            IFitInSocket canon = new TestCanon(new List<ICoordinate>() {
                new Coordinate(1, 1) });

            BattleShip albatros = new TestShip("De Vliegende Hollander", location, captain, canon);

            TheSea.AcceptShip(albatros);
        }

        public void PlaceShips()
        {
            var plan = new Plan();

            AddAlbatros(plan.GetNexLocation());
            AddSallySinke(plan.GetNexLocation());
            AddDeEendracht(plan.GetNexLocation());
            AddDeVliegendeHollander(plan.GetNexLocation());
        }
    }
}
