using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Location
    {
        private IEnumerable<ICoordinate> Coordinates;

        public Location(IEnumerable<ICoordinate> coordinates)
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
            IEnumerable<ICoordinate> coordinates = new List<ICoordinate>() {
                coordinate1,
                coordinate2,
                coordinate3,
                coordinate4,
                coordinate5
            };

            this.Coordinates = coordinates;
        }

        public IEnumerable<ICoordinate> GetCoordinates()
        {
            return Coordinates;
        }

        public bool Contains(ICoordinate coordinate)
        {
            bool hasCoordinate = this.Coordinates.Contains<ICoordinate>(coordinate);

            return hasCoordinate;
        }

        public int GetIndex(ICoordinate coordinate)
        {
            int index = 1;

            foreach(ICoordinate current in this.Coordinates)
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
