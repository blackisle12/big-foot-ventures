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

        #endregion
    }
}
