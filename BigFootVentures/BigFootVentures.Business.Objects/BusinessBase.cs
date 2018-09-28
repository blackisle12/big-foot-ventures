namespace BigFootVentures.Business.Objects
{
    public abstract class BusinessBase
    {
        #region "Properties"

        public int ID { get; set; }

        #endregion

        #region "Calculated Properties"

        public string DisplayName { get; set; }

        #endregion
    }
}
