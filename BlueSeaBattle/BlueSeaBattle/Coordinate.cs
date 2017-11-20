using System;

namespace BlueSeaBattle
{
    public class Coordinate : System.Tuple<int, int>, ICoordinate
    {
        public Coordinate(int item1, int item2) 
            : base(item1, item2)
        {
        }

        public override bool Equals(object obj)
        {
            Coordinate coordinate = obj as Coordinate;

            if (coordinate != null)
            {
                return coordinate.Item1 == this.Item1
                    && coordinate.Item2 == this.Item2;
            }

            return base.Equals(obj);
        }

        public int GetX()
        {
            return Item1;
        }

        public int GetY()
        {
            return Item2;
        }
    }
}
