namespace BlueSeaBattle
{
    public class Albatros: BattleShip
    {
        public Albatros(Location location)
            :base(location)
        {
            this.Slot1 = new TestCanon();
        }
    }
}
