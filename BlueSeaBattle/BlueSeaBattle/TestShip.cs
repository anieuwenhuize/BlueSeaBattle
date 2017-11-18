namespace BlueSeaBattle
{
    public class TestShip: BattleShip
    {
        private string Name;

        public TestShip(
            string name,
            Location location, 
            IFitInSocket slot1,
            IFitInSocket slot2,
            IFitInSocket slot3,
            IFitInSocket slot4,
            IFitInSocket slot5
            )
            :base(location)
        {
            Name = name;

            this.Slot1 = slot1;
            this.Slot2 = slot2;
            this.Slot3 = slot3;
            this.Slot4 = slot4;
            this.Slot5 = slot5;
        }

        public TestShip(
            string name,
            Location location,
            IFitInSocket slot1,
            IFitInSocket slot2
            )
            : this(name, location, slot1, slot2, new EmptySlot(), new EmptySlot(), new EmptySlot())
        {}

        public TestShip(
            string name,
            Location location
            )
            : this(name, location, new EmptySlot(), new EmptySlot(), new EmptySlot(), new EmptySlot(), new EmptySlot())
        { }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
