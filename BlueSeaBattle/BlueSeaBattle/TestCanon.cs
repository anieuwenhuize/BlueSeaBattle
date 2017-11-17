using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class TestCanon : IKanon, IFitInSocket
    {
        private int State;
        private IList<ICoordinate> Targets;

        public TestCanon(IList<ICoordinate> targets)
        {
            State = 0;
            Targets = targets;
        }

        public ICoordinate Fire(ICoordinate coordinate)
        {
            return Fire();
        }

        public ICoordinate Fire()
        {
            State++;

            int index = State % Targets.Count;

            return Targets[index];
        }
    }
}
