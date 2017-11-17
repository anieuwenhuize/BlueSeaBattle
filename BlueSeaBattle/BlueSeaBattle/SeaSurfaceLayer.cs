using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class SeaSurfaceLayer : Layer, ILayer
    {
        private Sea TheSea;

        public const int NoValue = 0;
        public const int ShipValue = 21;

        public SeaSurfaceLayer(Sea sea)
        {
            this.TheSea = sea;
        }

        public void Recalculate()
        {
            this.Clear();

            IEnumerable<BattleShip> ships = this.TheSea.GetAllSurvivingShips();

            IEnumerable<ICoordinate> coordinates = Sea.GetAllCoordinatesFrom(ships);

            foreach (ICoordinate coordinate in coordinates)
            {
                this.AddDisplayValue(coordinate.GetX(), coordinate.GetY(), ShipValue);
            }
        }
    }
}
