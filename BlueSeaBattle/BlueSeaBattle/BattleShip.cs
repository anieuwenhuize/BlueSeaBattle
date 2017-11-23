using System.Linq;
using System.Collections.Generic;

namespace BlueSeaBattle
{
    public abstract class BattleShip
    {
        public IFitInSocket Slot1;
        protected IFitInSocket Slot2;
        protected IFitInSocket Slot3;
        protected IFitInSocket Slot4;
        protected IFitInSocket Slot5;

        private Location Location;

        public BattleShip(Location location)
        {
            this.Location = location;

            this.Slot1 = new EmptySlot();
            this.Slot2 = new EmptySlot();
            this.Slot3 = new EmptySlot();
            this.Slot4 = new EmptySlot();
            this.Slot5 = new EmptySlot();
        }

        protected int GetMaxX()
         {
            return Sea.GridWidth;
        }

        protected int GetMaxY()
        {
            return Sea.GridHeight;
        }

        public IEnumerable<IFitInSocket> GetSlotItems()
        {
            IEnumerable<IFitInSocket> slotitems = new List<IFitInSocket>()
                {
                    this.Slot1, this.Slot2,this.Slot3,this.Slot4, this.Slot5
                }
                .Where(x => x != null);

            return slotitems;
        }

        protected IEnumerable<ICoordinate> GetCoordinates()
        {
            return this.Location.GetCoordinates();
        }

        public bool IsSunk()
        {
            return this.Slot1 == null
                && this.Slot2 == null
                && this.Slot3 == null
                && this.Slot4 == null
                && this.Slot5 == null;
        }

        public bool HasCoordinate(ICoordinate coordinate)
        {
            return this.Location.Contains(coordinate);
        }

        private bool IsHit(Missile missile)
        {
            return HasCoordinate(missile.GetTarget());
        }

        public void SetLocation(Location destination)
        {
            this.Location = destination;
        }

        public Location GetLocation()
        {
            return this.Location;
        }

        private void AcceptDamageOn(ICoordinate coordinate)
        {
            int damagedSlotNumber = this.Location.GetIndex(coordinate);

            if (damagedSlotNumber == 1)
            {
                this.Slot1 = null;
            }

            else if (damagedSlotNumber == 2)
            {
                this.Slot2 = null;
            }

            else if (damagedSlotNumber == 3)
            {
                this.Slot3 = null;
            }

            else if (damagedSlotNumber == 4)
            {
                this.Slot4 = null;
            }

            else if (damagedSlotNumber == 5)
            {
                this.Slot5 = null;
            }
        }

        public MissileEffect AcceptMissile(Missile missile)
        {
            if (this.IsHit(missile))
            {
                AcceptDamageOn(missile.GetTarget());

                return MissileEffect.HitAndDamage;
            }

            return MissileEffect.HitNoDamage;
        }
    }
}
