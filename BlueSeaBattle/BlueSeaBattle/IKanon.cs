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

        /// <summary>
        /// Wordt aangeroepen wanneer je geen radar meer hebt.
        /// </summary>
        /// <returns></returns>
        ICoordinate Fire();
    }
}
