using System.Collections.Generic;
using System.Linq;

namespace BlueSeaBattle
{
    public class Plan
    {
        private IList<Location> Location;

        public Plan()
        {
            Location = new List<Location>();

            Location.Add(new Location(
                new Coordinate(19, 1),
                new Coordinate(20, 1),
                new Coordinate(21, 1),
                new Coordinate(22, 1),
                new Coordinate(23, 1)));

            Location.Add(new Location(
                new Coordinate(19, 3),
                new Coordinate(20, 3),
                new Coordinate(21, 3),
                new Coordinate(22, 3),
                new Coordinate(23, 3)));

            Location.Add(new Location(
                new Coordinate(0, 4), 
                new Coordinate(1, 4), 
                new Coordinate(2, 4), 
                new Coordinate(3, 4), 
                new Coordinate(4, 4)));

            Location.Add(new Location(
                new Coordinate(13, 7),
                new Coordinate(13, 8),
                new Coordinate(13, 9),
                new Coordinate(13, 10),
                new Coordinate(13, 11)));
        }

        public Location GetNexLocation()
        {
            var location = Location.First();

            Location.Remove(location);

            return location;
        }
    }
}
