namespace BlueSeaBattle
{
    public interface IKapitein
    {
        /// <summary>
        /// Geeft aan dat de boot deze turn moet verplaatsen.
        /// </summary>
        /// <returns></returns>
        bool ShouldMove();

        /// <summary>
        /// Verplaatst 1 naar gegeven richting.
        /// </summary>
        /// <returns></returns>
        Direction GetDirection();
    }
}
