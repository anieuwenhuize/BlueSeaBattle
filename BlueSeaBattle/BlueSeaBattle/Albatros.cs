namespace BlueSeaBattle
{
    public class Albatros: BattleShip
    {
        public Albatros(Location location)
            :base(location)
        {
            this.Slot1 = new TestCanon();
            this.Slot2 = new TestCaptain();
        }

        public override string ToString()
        {
            return $"Albatros";
        }
    }

    public class SnelleJelle : Albatros
    {
        public SnelleJelle(Location location)
            :base(location)
        {
            this.Slot1 = new TestCanon();
            this.Slot2 = new TestCaptain();
        }

        public override string ToString()
        {
            return $"Snelle Jelle";
        }
    }
}
