﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Sea
    {
        public const int GridWidth = 50;
        public const int GridHeight = 20;

        public static IEnumerable<ICoordinate> GetAllCoordinatesFrom(IEnumerable<BattleShip> ships)
        {
            IEnumerable<ICoordinate> allLocations = ships
                .SelectMany(x => x.GetLocation()
                    .GetCoordinates());

            return allLocations;
        }

        private IList<BattleShip> AllShips;

        public Sea()
        {
            AllShips = new List<BattleShip>();
        }

        public BattleShip GetShipOn(ICoordinate coordinate)
        {
            foreach(BattleShip ship in GetAllSurvivingShips())
            {
                if (ship.HasCoordinate(coordinate))
                {
                    return ship;
                }
            }

            return null;
        }

        public void AcceptShip(BattleShip ship)
        {
            // check first
            AllShips.Add(ship);
        }

        public IEnumerable<BattleShip> GetAllSunkShips()
        {
            IEnumerable<BattleShip> allSunkShips = this.AllShips
                .Where(x => x.IsSunk());

            return allSunkShips;
        }

        public IEnumerable<BattleShip> GetAllSurvivingShips()
        {
            IEnumerable<BattleShip> allSurvivingShips = this.AllShips
                .Where(x => ! x.IsSunk());

            return allSurvivingShips;
        }

        public bool IsValid(Location location)
        {
            var locationCoordinates = location.GetCoordinates();

            var lowestX = locationCoordinates
                .Select(x => x.GetX())
                .Min();

            var highestX = locationCoordinates
                .Select(x => x.GetX())
                .Max();

            var lowestY = locationCoordinates
                .Select(x => x.GetY())
                .Min();

            var highestY = locationCoordinates
                .Select(x => x.GetY())
                .Max();

            var isValid = lowestX >= 0
                && lowestY >= 0
                && highestX < GridWidth
                && highestY < GridHeight;

            return isValid;
        }
    }
}
