using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class MissileLayer : ILayer
    {
        public int GetDisplayValue(int x, int y)
        {
            return 0;
        }

        public void Recalculate()
        {
            // noop
        }
    }
}
