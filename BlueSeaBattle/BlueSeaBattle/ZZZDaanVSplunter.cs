using System;
using System.Collections.Generic;
using System.Text;

namespace BlueSeaBattle
{
    class Kapitein : IKapitein, IFitInSocket
    {

        public bool ShouldMove()
        {
            return true;
        }

        public Direction GetDirection()
        {
            Random rnd = new Random();
            int richting = rnd.Next(1, 5);
            if (richting == 1)
            {
                return Direction.West;
            }
            if (richting == 2)
            {
                return Direction.Oost;
            }
            if (richting == 3)
            {
                return Direction.Zuid;
            }
            if (richting == 4)
            {
                return Direction.Noord;
            }
            return Direction.Zuid;
        }

    }
}