using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Coordinate : Tuple<int, int>
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
    }
}
