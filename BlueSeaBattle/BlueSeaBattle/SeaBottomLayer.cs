using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class SeaBottomLayer : Layer, ILayer
    {
        private Sea TheSea;

        public const int NoValue = 0;
        public const int SunkShipValue = 11;

        public SeaBottomLayer(Sea sea)
        {
            this.TheSea = sea;
        }

        public void Recalculate()
        {
            this.Clear();

            IEnumerable<BattleShip> sunkShips = this.TheSea.GetAllSunkShips();

            IEnumerable<Coordinate> coordinates = Sea.GetAllCoordinatesFrom(sunkShips);

            foreach (Coordinate coordinate in coordinates)
            {
                this.AddDisplayValue(coordinate.GetX(), coordinate.GetY(), SunkShipValue);
            }
        }
    }
}
