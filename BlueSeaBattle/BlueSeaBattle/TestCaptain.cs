namespace BlueSeaBattle
{
    public class TestCaptain : IKapitein, IFitInSocket
    {
        private int State;

        private int Slow;

        public TestCaptain(int slow)
        {
            State = 0;

            Slow = slow;
        }

        public Direction GetDirection()
        {
            return Direction.Oost;
        }

        public bool ShouldMove()
        {
            State++;

            return State % Slow == 0;
        }
    }
}
