namespace BigFootVentures.Business.Objects.Management
{
    public sealed class TrademarkOwner: BusinessBase
    {
        #region "Properties"

        public Trademark Trademark { get; set; }
        public Company Company { get; set; }

        #endregion
    }
}
