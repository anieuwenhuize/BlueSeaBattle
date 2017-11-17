namespace BlueSeaBattle
{
    public class StatusReport
    {
        private int NumberOfShips;
        private int NumberOfSunkShips;
        private int NumberOfTurns;

        public StatusReport(int numerOfShips, int numberOfSunkShips, int numberOfTurns)
        {
            NumberOfShips = numerOfShips;
            NumberOfSunkShips = numberOfSunkShips;
            NumberOfTurns = numberOfTurns;
        }

        public string GetNumerOfShips()
        {
            return $"{NumberOfShips}";
        }

        public string GetNumberOfSunkShips()
        {
            return $"{NumberOfSunkShips}";
        }
        public string GetNumberOfTurns()
        {
            return $"{NumberOfTurns}";
        }
    }
}
