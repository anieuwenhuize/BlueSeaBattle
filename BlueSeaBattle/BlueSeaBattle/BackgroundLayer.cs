using System;

namespace BlueSeaBattle
{
    public class BackgroundLayer : ILayer
    {
        public void AddDisplayValue(int x, int y, int displayValue)
        {
            throw new NotImplementedException();
        }

        public int GetDisplayValue(int x, int y)
        {
            if ((x + y) % 2 == 0)
            {
                return 1;
            }

            return 2;
        }
    }
}
