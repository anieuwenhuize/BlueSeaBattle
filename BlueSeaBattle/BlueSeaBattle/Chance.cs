using System;

namespace BlueSeaBattle
{
    public class Chance
    {
        private Random Randomizer;

        private int Deelkans;
        private int Totaal;
        private int Minvalue;

        public Chance(int deelkans, int totaal)
        {
            this.Randomizer = new Random();
            this.Minvalue = 1;

            this.Deelkans = deelkans;
            this.Totaal = totaal;
        }

        public bool GetChance()
        {
            int seed = this.Randomizer.Next(this.Minvalue, this.Totaal);

            return seed < Deelkans;
        }
    }
}
