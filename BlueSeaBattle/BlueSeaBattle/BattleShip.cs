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

        private bool IsHit(Missile missile)
        {
            return this.Location.Contains(missile.GetTarget());
        }

        private void AcceptDamageOn(Coordinate coordinate)
        {

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
