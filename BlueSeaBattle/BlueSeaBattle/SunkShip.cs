namespace BlueSeaBattle
{
    public class SunkShip: BattleShip
    {
        public SunkShip(Location location)
            :base(location)
        {
            this.Slot1 = null;
            this.Slot2 = null;
            this.Slot3 = null;
            this.Slot4 = null;
            this.Slot5 = null;
        }
    }
}
