namespace BlueSeaBattle
{
    public interface ILayer {
        void AddDisplayValue(int x, int y, int displayValue);

        int GetDisplayValue(int x, int y);
    }
}
