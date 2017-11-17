using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    class CanonAndRadarCombiList : IEnumerable<Tuple<IKanon, IRadar>>
    {
        private IList<Tuple<IKanon, IRadar>> List;

        public CanonAndRadarCombiList(IEnumerable<IKanon> canons, IEnumerable<IRadar> radars)
        {
            List = new List<Tuple<IKanon, IRadar>>();

            foreach(IKanon canon in canons)
            {
                List.Add(new Tuple<IKanon, IRadar>(canon, null));
            }

            // Add the radars to the canons
            int i = 0;
            foreach (IRadar radar in radars)
            {
                List[i] = new Tuple<IKanon, IRadar>(List[i].Item1, radar);
            }
        }

        public IEnumerator<Tuple<IKanon, IRadar>> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }
    }
}
