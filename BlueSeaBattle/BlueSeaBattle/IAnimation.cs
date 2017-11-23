using System.Collections.Generic;

namespace BlueSeaBattle
{
    public interface IAnimation
    {
        IEnumerable<ICoordinate> GetNextFrame();

        bool IsDone();
    }
}
