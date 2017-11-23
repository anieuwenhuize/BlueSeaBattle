using System.Collections.Generic;

namespace BlueSeaBattle
{
    public interface IAnimation
    {
        int GetDisplayValue(int x, int y);

        void CalculateNewFrame();

        bool IsDone();
    }
}
