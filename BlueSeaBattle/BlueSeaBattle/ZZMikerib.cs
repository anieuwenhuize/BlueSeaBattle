using System;
using System.Collections.Generic;
using System.Text;

namespace BlueSeaBattle
{
    class KapiteinKoek : IKapitein, IFitInSocket
    {
        public bool ShouldMove()
        {
            return true;
        }

        public Direction GetDirection()
        {
            return Direction.Noord;
        }
    }
}
