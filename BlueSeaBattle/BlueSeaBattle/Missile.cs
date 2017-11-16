using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class Missile
    {
        private Coordinate Target;
        private BattleShip Owner;

        public Missile(Coordinate target, BattleShip owner)
        {
            this.Target = target;
            this.Owner = owner;
        }

        public Coordinate GetTarget()
        {
            return this.Target;
        }
    }
}
