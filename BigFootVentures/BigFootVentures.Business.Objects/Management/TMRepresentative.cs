namespace BigFootVentures.Business.Objects.Management
{
    public sealed class TMRepresentative : BusinessBase
    {
        #region "Properties"

        public Trademark Trademark { get; set; }
        public Company Representative { get; set; }

        #endregion
    }
}
