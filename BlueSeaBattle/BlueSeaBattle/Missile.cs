using System.Linq;

namespace BlueSeaBattle
{
    public class Missile
    {
        private ICoordinate Target;
        private BattleShip Owner;
        private MissileEffect Effect;

        public Missile(ICoordinate target, BattleShip owner)
        {
            this.Target = target;
            this.Owner = owner;
            this.Effect = MissileEffect.Unknown;
        }

        public void SetEffect(MissileEffect effect)
        {
            this.Effect = effect;
        }

        public ICoordinate GetTarget()
        {
            return this.Target;
        }

        public ICoordinate GetOwner()
        {
            // TODO: improve, showing fired gun, not a ship position
            return this.Owner.GetLocation().GetCoordinates().First();
        }

        public MissileEffect GetEffect()
        {
            return this.Effect;
        }
    }
}
