namespace BlueSeaBattle
{
    public interface IKanon
    {
        /// <summary>
        /// Als je een radar hebt, krijg je een coordinaat van een schip.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        ICoordinate Fire(ICoordinate coordinate);
    }
}
