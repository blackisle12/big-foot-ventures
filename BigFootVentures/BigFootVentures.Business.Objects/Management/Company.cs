using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Company : BusinessBase
    {
        #region "Private Members"

        private string _deletionRequest { get; set; }

        #endregion

        #region "Properties"

        public string AccountRecordType { get; set; }
        public string AccountOwner { get; set; }

        public Company ParentAccount { get; set; }

        public string CompanyName { get; set; }
        public string FormerName { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string Salutation { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public string Industry { get; set; }
        public string Employees { get; set; }

        public string NameID { get; set; }
        public string OfficeIDOHIM { get; set; }
        public string OfficeIDGB { get; set; }
        public string OHIMNumTrademarks { get; set; }
        public string OHIMNUMOppositions { get; set; }
        public string OHIMOwnerID { get; set; }
        public string AddressType { get; set; }
        public string CompanySize { get; set; }
        public bool EscrowAgent { get; set; }
        public bool Broker { get; set; }

        public string DeletionRequest { get { return this._deletionRequest; } set { this._deletionRequest = value; this.DeletionRequestChk = string.Equals(value, true.ToString(), StringComparison.InvariantCultureIgnoreCase); } }
        public string DeletionRequestReason { get; set; }

        public string CompanyRegistrationNumber { get; set; }
        public string CountryOfIncorporation { get; set; }
        public string DateOfIncorporation { get; set; }
        public string TaxNumber { get; set; }
        public string Officers { get; set; }

        public string TMFilingCost { get; set; }
        public string TMCancellationCost { get; set; }
        public string TMOppositionCost { get; set; }
        public string TMPriorityCost { get; set; }
        public string TMRegistrationCertificateCost { get; set; }
        public string TMResearchCost { get; set; }
        public string OtherCosts { get; set; }

        public bool BigFootAccredited { get; set; }
        public bool BigFootGroup { get; set; }

        public string ShippingCountry { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }

        public UserAccount AssignedStaff { get; set; }
        public UserAccount AssignedSupervisor { get; set; }

        public string DueDate { get; set; }

        #endregion

        #region "Calculated Properties"

        public bool DeletionRequestChk { get; set; }

        #endregion
    }
}