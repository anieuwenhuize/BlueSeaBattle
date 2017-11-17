using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueSeaBattle
{
    public class SailAway
    {
        private BattleShip Ship;

        public SailAway(BattleShip ship)
        {
            Ship = ship;
        }

        public void Navigate()
        {
            var assestprovider = new BattleshipAssestProvider(Ship);
            IKapitein captain = assestprovider
                .GetCaptains()
                .FirstOrDefault();
            bool hasCaptain = captain != null;

            if (hasCaptain && captain.ShouldMove())
            {
                MoveShip(captain);
            }
        }

        public void MoveShip(IKapitein captain)
        {
            var direction = captain.GetDirection();

            switch (captain.GetDirection())
            {
                case Direction.Noord:
                    Ship.SetLocation(MoveNorth(Ship.GetLocation()));
                    break;

                case Direction.Oost:
                    Ship.SetLocation(MoveEast(Ship.GetLocation()));
                    break;
                case Direction.Zuid:
                    Ship.SetLocation(MoveSouth(Ship.GetLocation()));
                    break;
                case Direction.West:
                    Ship.SetLocation(MoveWest(Ship.GetLocation()));
                    break;

                default:
                    throw new InvalidOperationException($"Onbekende richting gegeven: {direction}");

            }
        }

        private Location MoveNorth(Location currentlocation)
        {
            ICollection<ICoordinate> destination = new List<ICoordinate>();

            foreach(ICoordinate currentCoordinate in currentlocation.GetCoordinates())
            {
                var destinationCoordinate =
                    new Coordinate(currentCoordinate.GetX(), currentCoordinate.GetY() + 1);
            }

            return new Location(destination);
        }

        private Location MoveEast(Location currentlocation)
        {
            var destination = new List<ICoordinate>();

            foreach (ICoordinate currentCoordinate in currentlocation.GetCoordinates())
            {
                var destinationCoordinate =
                    new Coordinate(currentCoordinate.GetX() + 1, currentCoordinate.GetY());

                destination.Add(destinationCoordinate);
            }

            return new Location(destination);
        }

        private Location MoveSouth(Location currentlocation)
        {
            ICollection<ICoordinate> destination = new List<ICoordinate>();

            foreach (ICoordinate currentCoordinate in currentlocation.GetCoordinates())
            {
                var destinationCoordinate =
                    new Coordinate(currentCoordinate.GetX(), currentCoordinate.GetY() - 1);
            }

            return new Location(destination);
        }

        private Location MoveWest(Location currentlocation)
        {
            ICollection<ICoordinate> destination = new List<ICoordinate>();

            foreach (ICoordinate currentCoordinate in currentlocation.GetCoordinates())
            {
                var destinationCoordinate =
                    new Coordinate(currentCoordinate.GetX() - 1, currentCoordinate.GetY());
            }

            return new Location(destination);
        }
    }
}
