namespace BlueSeaBattle
{
    public class TestCaptain : IKapitein, IFitInSocket
    {
        private int State;
        private int Slow;
        private Direction Direction;

        public TestCaptain(int slow, Direction direction)
        {
            State = 0;
            Slow = slow;

            Direction = direction;
        }

        public Direction GetDirection()
        {
            return Direction;
        }

        public bool ShouldMove()
        {
            State++;

            return State % Slow == 0;
        }
    }
}
