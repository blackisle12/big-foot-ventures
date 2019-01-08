using BigFootVentures.Business.Objects.Utilities;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class DomainN : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public Company RegistrantCompany { get; set; }                
        public string Name { get; set; }
        public Enquiry DomainEnquiry { get; set; }        
        public Brand Brand { get; set; }        
        public string BFStrategy { get; set; }
        public string BuysideFunnel { get; set; }
        public string Remarks { get; set; }
        public string FMVOrderOfMagnitude { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
        public string Category { get; set; }
        public string AccountID { get; set; }
        public bool BigFootOwned { get; set; }
        public bool WebsiteCurrent { get; set; }
        public bool Locked { get; set; } = true;
        public string WebsiteUse { get; set; }
        public string WebsiteDescription { get; set; }
        public string WebsiteRedirect { get; set; }
        public string ExpirationDate { get; set; }
        public bool CompanyWebsite { get; set; }
        public bool AutoRenew { get; set; } = true;
        public string WHOIS { get; set; }
        public string RegistrationPriceUSD { get; set; }
        public string RegistrationDate { get; set; }
        public string BigFootParkingPage { get; set; }
        public bool PrivacyProtected { get; set; }

        public Register Registrar { get; set; }        

        public Company Registrant { get; set; }
        public Company PreviousRegistrant { get; set; }        
        public string RegistrantEmail { get; set; }
        public string PrivateRegistrationEmail { get; set; }
        public string PreviousRegistrantChangedOn { get; set; }

        public string PurchasePriceUSD { get; set; }
        public string PurchaseDate { get; set; }
        public string SalePriceUSD { get; set; }
        public string SaleDate { get; set; }

        public string CDDateSent { get; set; }
        public string CDSentFrom { get; set; }
        public string CDSentMethod { get; set; }
        public string CDCourier { get; set; }
        public string CDTrackingNumber { get; set; }
        public int? TrademarkUsedInTheUDRPID { get; set; }
        public string TrademarkUsedInTheUDRPName { get; set; }
        public string UDRPFilingDate { get; set; }
        public string UDRPCostInUSD { get; set; }
        public string UDRPCostOtherThanUSD { get; set; }
        public string UDRPCaseNumber { get; set; }
        public string ArbitratorName { get; set; }
        public string UDRPJurisdiction { get; set; }
        public string LanguageOfProceedings { get; set; }
        public bool LegalActionRelatedProceedings { get; set; } = true;
        public string UDRPOutcome { get; set; }
        public string UDRPComment { get; set; }

        public bool DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }

        #endregion

        #region "Calculated Properties"

        public int DomainLength { get { return !this.Name.Contains(".") ? this.Name.Length : this.Name.Split(new char[] { '.' })[0].Length; } }
        public int NameLength { get { return this.Name.Length; } }
        public string NumberInTheName { get { return StringUtils.HasNumber(this.Name) ? "Yes" : "No"; } }

        #endregion
    }
}
