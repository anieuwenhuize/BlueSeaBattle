using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Location
    {
        private IEnumerable<Coordinate> Coordinates;

        public Location(IEnumerable<Coordinate> coordinates)
        {
            this.Coordinates = coordinates;
        }

        public Location(
            Coordinate coordinate1,
            Coordinate coordinate2,
            Coordinate coordinate3,
            Coordinate coordinate4,
            Coordinate coordinate5)
        {
            IEnumerable<Coordinate> coordinates = new List<Coordinate>() {
                coordinate1,
                coordinate2,
                coordinate3,
                coordinate4,
                coordinate5
            };

            this.Coordinates = coordinates;
        }

        public IEnumerable<Coordinate> GetCoordinates()
        {
            return Coordinates;
        }

        public bool Contains(Coordinate coordinate)
        {
            bool hasCoordinate = this.Coordinates.Contains<Coordinate>(coordinate);

            return hasCoordinate;
        }

        public int GetIndex(Coordinate coordinate)
        {
            int index = 1;

            foreach(Coordinate current in this.Coordinates)
            {
                if(current.Equals(coordinate))
                {
                    return index;
                }

                index++;
            }

            throw new InvalidOperationException($"Coordinate: {coordinate} niet bekend in locatie");
        }
    }
}
