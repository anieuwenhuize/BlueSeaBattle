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
        private ILayer SeaBottomLayer;

        public ViewModel(Sea Sea)
        {
            TheSea = Sea;

            BackgroundLayer = new BackgroundLayer();
            SeaBottomLayer = new SeaBottomLayer(this.TheSea);
        }

        public int GetDisplayValue(int x, int y)
        {
            int backgroundValue = this.BackgroundLayer.GetDisplayValue(x, y);

            int SeaBottomValue = this.SeaBottomLayer.GetDisplayValue(x, y);

            int valueToReturn = new List<int>() { backgroundValue, SeaBottomValue }
                .Max();

            return valueToReturn;
        }

        public void Recalculate()
        {
            BackgroundLayer.Recalculate();
            SeaBottomLayer.Recalculate();
        }
    }
}
