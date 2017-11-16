using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    class Location
    {
        private IEnumerable<Coordinate> Coordinates;

        public Location(IEnumerable<Coordinate> coordinates)
        {
            this.Coordinates = coordinates;
        }

        public bool Contains(Coordinate coordinate)
        {
            bool hasCoordinate = this.Coordinates.Contains<Coordinate>(coordinate);

            return hasCoordinate;
        }
    }
}
