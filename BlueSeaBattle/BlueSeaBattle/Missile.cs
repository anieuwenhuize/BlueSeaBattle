namespace BlueSeaBattle
{
    public class Missile
    {
        private ICoordinate Target;
        private BattleShip Owner;

        public Missile(ICoordinate target, BattleShip owner)
        {
            this.Target = target;
            this.Owner = owner;
        }

        public ICoordinate GetTarget()
        {
            return this.Target;
        }
    }
}
