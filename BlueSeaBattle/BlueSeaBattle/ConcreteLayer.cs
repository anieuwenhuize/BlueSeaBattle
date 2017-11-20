using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class ConcreteLayer: Dictionary<Tuple<int, int>, int>, ILayer
    {
        public static ConcreteLayer CaluculateDiff(ConcreteLayer oldLayer, ConcreteLayer newLayer)
        {
            var diff = new ConcreteLayer();

            foreach(var displayvalue in oldLayer)
            {
                var key = displayvalue.Key;
                if (oldLayer[key] != newLayer[key])
                {
                    diff.Add(key, newLayer[key]);
                }
            }

            return diff;
        }

        public int GetDisplayValue(int x, int y)
        {
            var key = new Tuple<int, int>(x, y);

            if(this.ContainsKey(key))
            {
                return this[key];
            }

            return 0;
        }

        public void Recalculate()
        {
            // noop
        }
    }
}
