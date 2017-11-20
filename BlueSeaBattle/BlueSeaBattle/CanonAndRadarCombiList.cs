using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    class CanonAndRadarCombiList : IEnumerable<System.Tuple<IKanon, IRadar>>
    {
        private IList<System.Tuple<IKanon, IRadar>> List;

        public CanonAndRadarCombiList(IEnumerable<IKanon> canons, IEnumerable<IRadar> radars)
        {
            List = new List<System.Tuple<IKanon, IRadar>>();

            foreach(IKanon canon in canons)
            {
                List.Add(new System.Tuple<IKanon, IRadar>(canon, null));
            }

            // Add the radars to the canons
            int i = 0;
            foreach (IRadar radar in radars)
            {
                List[i] = new System.Tuple<IKanon, IRadar>(List[i].Item1, radar);
            }
        }

        public IEnumerator<System.Tuple<IKanon, IRadar>> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }
    }
}
