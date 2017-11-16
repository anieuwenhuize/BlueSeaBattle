using System;

namespace BlueSeaBattle
{
    public class BackgroundLayer : ILayer
    {
        public const int NoValue = 0;
        public const int DefaultValue = 1;
        public const int WaveValue = 2;

        public int GetDisplayValue(int x, int y)
        {
            if ((x + y) % 2 == 0)
            {
                return DefaultValue;
            }

            return WaveValue;
        }

        public void Recalculate()
        {
            // noop 
        }
    }
}
