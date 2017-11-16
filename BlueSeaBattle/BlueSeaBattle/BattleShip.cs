using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    abstract class BattleShip
    {
        private IFitInSocket Slot1;
        private IFitInSocket Slot2;
        private IFitInSocket Slot3;
        private IFitInSocket Slot4;
        private IFitInSocket Slot5;

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

        private bool IsSunk()
        {
            return this.Slot1 == null
                && this.Slot2 == null
                && this.Slot3 == null
                && this.Slot4 == null
                && this.Slot5 == null;
        }

        private bool IsHit(Missile missile)
        {
            return this.Location.Contains(missile.GetTarget());
        }

        private void AcceptDamageOn(Coordinate coordinate)
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

        public void AcceptMissile(Missile missile)
        {
            if (this.IsHit(missile))
            {
                AcceptDamageOn(missile.GetTarget());
            }
        }
    }
}
