using System.Collections.Generic;
using System.Linq;

namespace BlueSeaBattle
{
    public class CollisionDetection
    {
        private Sea TheSea;
        private Location OwnLocation;

        public CollisionDetection(Sea sea, BattleShip ship)
        {
            TheSea = sea;
            OwnLocation = ship.GetLocation();
        }

        private IEnumerable<ICoordinate> GetAllShipCoordinates()
        {
            var allOccupiedCoordinates = TheSea.GetAllSurvivingShips()
                .Select(x => x.GetLocation())
                .SelectMany(x => x.GetCoordinates());

            return allOccupiedCoordinates;
        }

        // Omdat de interface al is vrijgegeven deze methode hier opnemen
        // Hoort in de ICoordinate-interface thuis: Equals
        private bool AreSame(ICoordinate a, ICoordinate b)
        {
            return a.GetX() == b.GetX()
                && a.GetY() == b.GetY();
        }

        private IEnumerable<ICoordinate> Without(IEnumerable<ICoordinate> allCoordinates, Location location)
        {
            var locationCoordinates = location.GetCoordinates();

            ICoordinate firstCoordinate = locationCoordinates.First();
            ICoordinate secondCoordinate = locationCoordinates.ElementAt(1);
            ICoordinate thirdCoordinate = locationCoordinates.ElementAt(2);
            ICoordinate fourthCoordinate = locationCoordinates.ElementAt(3);
            ICoordinate fifthCoordinate = locationCoordinates.ElementAt(4);


            var allOtherCoordinates = allCoordinates
                .Where(x => !AreSame(x, firstCoordinate))
                .Where(x => !AreSame(x, secondCoordinate))
                .Where(x => !AreSame(x, thirdCoordinate))
                .Where(x => !AreSame(x, fourthCoordinate))
                .Where(x => !AreSame(x, fifthCoordinate));

            return allOtherCoordinates;
        }


        public bool IsLocationValid(Location location)
        {
            var allCoordinates = GetAllShipCoordinates();

            var blacklist = Without(allCoordinates, OwnLocation);

            var future = Without(blacklist, location);

            // als we de nieuwe locatie van de gebruikte
            // coordinaten afhalen, en er is geen verschil
            // opgetreden, betekent dit dat de nieuwe 
            // locatie ongebruikt is.
            return blacklist.Count() == future.Count();
        }
    }
}
