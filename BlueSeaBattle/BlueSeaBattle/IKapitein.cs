namespace BlueSeaBattle
{
    public interface IKapitein
    {
        /// <summary>
        /// Geef aan dat de boot deze turn moet verplaatsen.
        /// </summary>
        /// <returns></returns>
        bool ShouldMove();

        /// <summary>
        /// Verplaats 1 naar gegeven richting.
        /// </summary>
        /// <returns></returns>
        Direction GetDirection();
    }
}
