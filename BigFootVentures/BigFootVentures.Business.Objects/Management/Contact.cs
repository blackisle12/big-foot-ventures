namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Contact : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string Suffix { get; set; }
        public Company Company { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Department { get; set; }
        public string OHIMOwnerID { get; set; }
        public string OHIMNumTrademarks { get; set; }
        public DomainN WebsiteIndividual { get; set; }

        public string MailingCountry { get; set; }
        public string MailingStreet { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingPostalCode { get; set; }

        #endregion
    }
}
