namespace BigFootVentures.Business.Objects.Management
{
    public sealed class LegalCase : BusinessBase
    {
        #region "Properties"

        public string TypeOfCase { get; set; }
        public string TypeOfCaseExternalClients { get; set; }
        public Trademark Trademark { get; set; }
        public string TrademarkNumber { get; set; }
        //public cancellation
        public string Keywords { get; set; }
        public string DateAssigned { get; set; }
        public string CourtURL { get; set; }
        public Company Plaintiff { get; set; }
        public Company Defendant { get; set; }
        public Company PlaintiffRepresentative { get; set; }
        public Company DefendantRepresentative { get; set; }
        public bool DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }

        #endregion
    }
}
