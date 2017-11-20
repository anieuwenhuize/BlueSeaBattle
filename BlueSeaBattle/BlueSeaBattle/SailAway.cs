using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueSeaBattle
{
    public class SailAway
    {
        private BattleShip Ship;
        private Sea TheSea;

        public SailAway(BattleShip ship, Sea sea)
        {
            Ship = ship;
            TheSea = sea;
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

        private bool IsNewLocationValid(Location location, BattleShip battleship)
        {
            var collisiondetection = new CollisionDetection(TheSea, Ship);

            // no collision
            var isValid = collisiondetection.IsLocationValid(location)
                
                // no outside seaboundaries
                && TheSea.IsValid(location);

            return isValid;
        }

        public void MoveShip(IKapitein captain)
        {
            Location from = Ship.GetLocation();

            Location to = GetNewLocation(from, captain);

            if(IsNewLocationValid(to, Ship))
            {
                Ship.SetLocation(to);
            }
        }

        private Location GetNewLocation(Location from, IKapitein captain)
        {
            var direction = captain.GetDirection();
            
            if( ShouldTurn(direction, from))
            {
                return GetNewLocationByTurning(direction, from);
            }

            return GetNewLocationByMoving(direction, from);
        }

        private bool ShouldTurn(Direction direction, Location location)
        {
            if (direction == Direction.Noord 
                || direction == Direction.Zuid)
            {
                return location.IsYInLine();
            }

            else
            {
                return location.IsXInLine();
            }
        }

        private Location GetNewLocationByTurning(Direction direction, Location from)
        {
            if (direction == Direction.Noord
               || direction == Direction.Zuid)
            {
                return from.GetWithXinline();
            }

            else
            {
                return from.GetWithYinline();
            }
        }

        private Location GetNewLocationByMoving(Direction direction, Location from)
        {
            ICollection<ICoordinate> to = new List<ICoordinate>();

            foreach (ICoordinate current in from.GetCoordinates())
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
            var to = new Coordinate(from.GetX(), from.GetY() - 1);

            return to;
        }

        private ICoordinate MoveEast(ICoordinate from)
        {
            var to = new Coordinate(from.GetX() + 1, from.GetY());

            return to;
        }

        private ICoordinate MoveSouth(ICoordinate from)
        {
            var to = new Coordinate(from.GetX(), from.GetY() + 1);

            return to;
        }

        private ICoordinate MoveWest(ICoordinate from)
        {
            var to = new Coordinate(from.GetX() - 1, from.GetY());

            return to;
        }
    }
}
