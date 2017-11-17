using System;

namespace BlueSeaBattle
{
    public class ChallengeProvider
    {
        public Tuple<int, string> GetChallenge()
        {
            return new Tuple<int, string>(5, "+ 1 4");
        }
    }
}
