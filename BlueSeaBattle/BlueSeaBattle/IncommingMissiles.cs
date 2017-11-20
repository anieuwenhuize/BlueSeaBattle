using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSeaBattle
{
    public class IncommingMissiles
    {
        private Sea TheSea;
        private IEnumerable<Missile> Missiles;
        private Chance Chance;
        private Challenge Challenge;

        public IncommingMissiles(Sea sea, IEnumerable<Missile> missiles)
        {
            TheSea = sea;
            Missiles = missiles;
            Chance = new Chance(1, 3);
            Challenge = new Challenge();
        }

        public void Launch()
        {
            foreach(Missile missile in Missiles)
            {
                BattleShip targetShip = TheSea.GetShipOn(missile.GetTarget());
                bool hasTarget = targetShip != null;

                if (hasTarget)
                {
                    HitShip(targetShip, missile);
                }
            }
        }

        private void HitShip(BattleShip targetShip, Missile missile)
        {
            var assestprovider = new BattleshipAssestProvider(targetShip);
            IEnumerable<IGoalkeeper> goalkeepers = assestprovider.GetGoalkeepers();
            IGoalkeeper goalkeeper = goalkeepers.FirstOrDefault();
            bool hasGoalkeeper = goalkeeper != null;

            if (hasGoalkeeper && IsMissileCatched(goalkeeper))
            {
                return;
            }

            targetShip.AcceptMissile(missile);
        }

        private bool IsMissileCatched(IGoalkeeper goalkeeper)
        {
            System.Tuple<int, string> challenge = Challenge.GetChallenge();

            try
            {
                int answer = goalkeeper.AcceptChallenge(challenge.Item2);

                bool catched = Chance.GetChance()
                    && answer == challenge.Item1;

                return catched;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
