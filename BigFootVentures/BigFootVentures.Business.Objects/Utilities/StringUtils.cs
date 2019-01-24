using System.Linq;

namespace BigFootVentures.Business.Objects.Utilities
{
    public static class StringUtils
    {
        #region "Public Methods"

        public static bool HasNumber(string word)
        {
            return word.Any(char.IsDigit);
        }

        public static string GenerateAutoNumber(int ID)
        {
            var value = ID.ToString();

            if (value.Length == 1)
                return $"00000{value}";
            else if (value.Length == 2)
                return $"0000{value}";
            else if (value.Length == 3)
                return $"000{value}";
            else if (value.Length == 4)
                return $"00{value}";
            else if (value.Length == 5)
                return $"0{value}";
            else
                return value;
        }

        #endregion
    }
}
