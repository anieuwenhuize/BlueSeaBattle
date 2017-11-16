using System.Collections.Generic;

namespace BlueSeaBattle
{
    public class Layer: Dictionary<string, int>
    {
        public void AddDisplayValue(int x, int y, int displayValue)
        {
            string key = GetKey(x, y);

            this.Add(key, displayValue);
        }

        public int GetDisplayValue(int x, int y)
        {
            string key = GetKey(x, y);

            if (this.ContainsKey(key))
            {
                return this[key];
            }

            return 0;
        }

        private string GetKey(int x, int y)
        {
            string key = $"{x:000}{y:000}";

            return key;
        }
    }
}
