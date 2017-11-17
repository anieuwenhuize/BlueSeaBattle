namespace BlueSeaBattle
{
    public interface IGoalkeeper
    {
        /// <summary>
        /// Challenge is: 
        /// prefix sommetje + 1 2
        /// of infix sommetje: 1 % 3
        /// De rekenkundige operators zijn: +, -, *, /, %
        /// </summary>
        /// <param name="challenge"></param>
        /// <returns></returns>
        int AcceptChallenge(string challenge);
    }
}
