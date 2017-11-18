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
        private IUpdateable Form;

        private ILayer BackgroundLayer;
        private ILayer SeaBottomLayer; 
        private ILayer SeaSurfaceLayer;

        public ViewModel(Sea Sea, IUpdateable form)
        {
            TheSea = Sea;

            Form = form;

            BackgroundLayer = new BackgroundLayer();
            SeaBottomLayer = new SeaBottomLayer(this.TheSea);
            SeaSurfaceLayer = new SeaSurfaceLayer(this.TheSea);
        }

        public int GetDisplayValue(int x, int y)
        {
            int backgroundValue = this.BackgroundLayer.GetDisplayValue(x, y);
            int SeaBottomValue = this.SeaBottomLayer.GetDisplayValue(x, y);
            int SeaSurfaceLayer = this.SeaSurfaceLayer.GetDisplayValue(x, y);

            int valueToReturn = new List<int>() { backgroundValue, SeaBottomValue, SeaSurfaceLayer }
                .Max();

            return valueToReturn;
        }

        public void Recalculate()
        {
            BackgroundLayer.Recalculate();
            SeaBottomLayer.Recalculate();
            SeaSurfaceLayer.Recalculate();

            Form.DoUpdate();
        }

        public void RecalculateSurface()
        {
            SeaSurfaceLayer.Recalculate();

            Form.DoUpdate();
        }
    }
}
