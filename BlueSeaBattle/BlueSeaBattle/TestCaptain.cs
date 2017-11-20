using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class TestCaptain : IKapitein, IFitInSocket
    {
        private int State;
        private int Slow;
        private Direction Direction;
        private Carousel<Direction> Carousel;

        public TestCaptain(int slow, Direction direction)
        {
            State = 0;
            Slow = slow;

            Direction = direction;
        }

        public void EnableCircles()
        {
            Carousel = new Carousel<Direction>(new List<Direction>()
            {
                Direction.Oost, Direction.Oost, Direction.Oost,
                Direction.Zuid, Direction.Zuid, Direction.Zuid,
                Direction.West, Direction.West, Direction.West,
                Direction.Noord, Direction.Noord, Direction.Noord
            });
        }

        private bool HasCarousel()
        {
            return Carousel != null;
        }

        public Direction GetDirection()
        {
            if (HasCarousel())
            {
                return Carousel.GetNext();
            }

            return Direction;
        }

        public bool ShouldMove()
        {
            State++;

            return State % Slow == 0;
        }
    }
}
