namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Agreement : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public string Name { get; set; }
        public Company BFCompany { get; set; }
        public Company Counterpart { get; set; }
        public string ObjectOfAgreement { get; set; }
        //trademark
        public string OtherRelatedTrademarks { get; set; }
        public string Type { get; set; }
        public string Applicability { get; set; }
        public string DateOfSignature { get; set; }
        public string Comments { get; set; }

        #endregion
    }
}
