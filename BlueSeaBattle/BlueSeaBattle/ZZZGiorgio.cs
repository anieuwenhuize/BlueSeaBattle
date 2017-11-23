using System;
namespace BlueSeaBattle
{
    public class KapiteinGiorgio : IKapitein, IFitInSocket
    {
        private Random rand;
        private Direction direction;

        public KapiteinGiorgio()
        {
            rand = new Random();
            direction = Direction.Noord;
        }
        public bool ShouldMove()
        {

            return (rand.Next(2) == 1) ? true : false;
        }

        public Direction GetDirection()
        {
            var richting = rand.Next(1, 4);

            if (richting == 1)
            {
                direction = Direction.Noord;
            }
            else if (richting == 2)
            {
                direction = Direction.Oost;
            }
            else if (richting == 3)
            {
                direction = Direction.Zuid;
            }
            else if (richting == 4)
            {
                direction = Direction.West;

            }

            return direction;
        }


    }
}
