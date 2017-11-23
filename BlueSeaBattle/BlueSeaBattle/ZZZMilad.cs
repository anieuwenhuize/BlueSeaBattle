using System;
using System.Collections.Generic;
using System.Text;
namespace BlueSeaBattle
{
    class KapiteinMilad : IKapitein, IFitInSocket
    {
        private Random rnd;
        public KapiteinMilad()
        {
            this.rnd = new Random();
        }
        public Direction GetDirection()
        {
            int richting = rnd.Next(1, 5);
            if (richting == 1)
            {
                return Direction.West;
            }
            if (richting == 3)
            {
                return Direction.Oost;
            }
            if (richting == 2)
            {
                return Direction.Zuid;
            }
            if (richting == 4)
            {
                return Direction.Noord;
            }
            return Direction.Noord;
        }
        public bool ShouldMove()
        {
            return true;
        }

    }
}

