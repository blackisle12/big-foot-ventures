namespace BigFootVentures.Business.Objects.Management
{
    public sealed class LoginInformation: BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public string Country { get; set; }
        public string Office { get; set; }
        public string Url { get; set; }
        public string LoginInformationID { get; set; }
        public string PW { get; set; }
        public string AccountName { get; set; }
        public string CurrentAccount { get; set; }
        public string SecretPhase { get; set; }
        public string MonitoringStaff { get; set; }
        public string OfficeID { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string Balance { get; set; }
        public string EmailAddress { get; set; }

        #endregion
    }
}
