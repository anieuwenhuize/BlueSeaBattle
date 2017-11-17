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
            Location from = Ship.GetLocation();

            Location to = GetNewLocation(from, captain);

            Ship.SetLocation(to);
        }

        private Location GetNewLocation(Location from, IKapitein captain)
        {
            var direction = captain.GetDirection();
            ICollection<ICoordinate> to = new List<ICoordinate>();

            foreach(ICoordinate current in from.GetCoordinates())
            {
                switch (direction)
                {
                    case Direction.Noord:
                        to.Add(MoveNorth(current));
                        break;

                    case Direction.Oost:
                        to.Add(MoveEast(current));
                        break;

                    case Direction.Zuid:
                        to.Add(MoveSouth(current));
                        break;

                    case Direction.West:
                        to.Add(MoveWest(current));
                        break;

                    default:
                        throw new InvalidOperationException($"Onbekende richting gegeven: {direction}");
                }
            }

            return new Location(to);
        }

        private ICoordinate MoveNorth(ICoordinate from)
        {
            var to = new Coordinate(from.GetX(), from.GetY() + 1);

            return to;
        }

        private ICoordinate MoveEast(ICoordinate from)
        {
            var to = new Coordinate(from.GetX() + 1, from.GetY());

            return to;
        }

        private ICoordinate MoveSouth(ICoordinate from)
        {
            var to = new Coordinate(from.GetX(), from.GetY() - 1);

            return to;
        }

        private ICoordinate MoveWest(ICoordinate from)
        {
            var to = new Coordinate(from.GetX() - 1, from.GetY());

            return to;
        }
    }
}
