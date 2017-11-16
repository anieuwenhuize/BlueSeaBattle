using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class ViewModel: ILayer
    {
        private Sea TheSea;

        private ILayer BackgroundLayer;

        public ViewModel(Sea Sea)
        {
            TheSea = Sea;

            BackgroundLayer = new BackgroundLayer();
        }

        public void AddDisplayValue(int x, int y, int displayValue)
        {
            throw new NotImplementedException();
        }

        public int GetDisplayValue(int x, int y)
        {
            return this.BackgroundLayer.GetDisplayValue(x, y);
        }
    }
}
