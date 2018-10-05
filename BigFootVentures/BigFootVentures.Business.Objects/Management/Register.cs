namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Register : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }
        
        public string Name { get; set; }
        public string RAAYear { get; set; }
        public string Country { get; set; }
        public string AccreditedTLDs { get; set; }

        #endregion
    }
}
