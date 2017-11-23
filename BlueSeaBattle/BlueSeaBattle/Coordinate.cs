using System;

namespace BlueSeaBattle
{
    public class Coordinate : Tuple<int, int>, ICoordinate
    {
        public static bool AreSame(ICoordinate a, ICoordinate b)
        {
            return a.GetX() == b.GetX()
                && a.GetY() == b.GetY();
        }

        public Coordinate(int item1, int item2) 
            : base(item1, item2)
        {
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
