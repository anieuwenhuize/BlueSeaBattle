using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class TestCanon : IKanon, IFitInSocket
    {
        private ICollection<ICoordinate> Targets;

        public TestCanon()
        {
            Targets = new List<ICoordinate>() {
                new Coordinate(2, 2),
                    new Coordinate(2, 3),
                    new Coordinate(2, 4),
                    new Coordinate(2, 5),
                    new Coordinate(2, 6)
            };
        }

        public ICoordinate Fire(ICoordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public ICoordinate Fire()
        {
            var missile = Targets.First();

            Targets.Remove(missile);

            return missile;
        }
    }
}
