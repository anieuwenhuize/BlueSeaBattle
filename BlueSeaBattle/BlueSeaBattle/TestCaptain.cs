namespace BlueSeaBattle
{
    public class TestCaptain : IKapitein, IFitInSocket
    {
        public Direction GetDirection()
        {
            return Direction.Oost;
        }

        public bool ShouldMove()
        {
            return true;
        }
    }
}
