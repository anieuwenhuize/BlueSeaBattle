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
