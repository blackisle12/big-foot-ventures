namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class PageUtils
    {
        #region "Public Methods"

        public static int GetPageCount(int total, int rowCount)
        {
            var pages = total / rowCount;

            if ((total % rowCount) > 0)
            {
                pages += 1;
            }

            return pages;
        }        

        #endregion
    }
}