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
        public int? CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Department { get; set; }
        public string OHIMOwnerID { get; set; }
        public string OHIMNumTrademarks { get; set; }
        public int? WebsiteIndividualID { get; set; }
        public string WebsiteIndividualName { get; set; }

        #endregion
    }
}
