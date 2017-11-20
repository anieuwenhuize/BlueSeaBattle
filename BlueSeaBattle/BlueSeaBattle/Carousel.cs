using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Carousel<T>
    {
        private ICollection<T> List;

        private int State;

        public Carousel(ICollection<T> list)
        {
            List = list;

            State = 0;
        }

        public T GetNext() {

            State++;

            int index = State % List.Count;

            return List.ElementAt(index);
        }
    }
}
