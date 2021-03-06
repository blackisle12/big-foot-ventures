﻿using BigFootVentures.Business.Objects.Utilities;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Enquiry : BusinessBase
    {
        #region "Properties"

        public string RecordType { get; set; }
        public string OwnerName { get; set; }

        public string NegotiationBFAmount { get; set; }
        public string Negotiation3rdPartyAmount { get; set; }
        public string OldCaseNumber { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public bool SendEmail { get; set; }
        public bool UnreadEmail { get; set; }
        public bool DoNotContact { get; set; }
        public string Subject { get; set; }
        public string PercentOfCompletion { get; set; }
        public string CaseAssign { get; set; }

        public string PrivateRegistrationEmail { get; set; }
        public string Registrant { get; set; }
        public string CaseOrigin { get; set; }
        public string ReferenceNumber { get; set; }

        public string DomainName { get; set; }        
        public Company RegistrantCompany { get; set; }
        public Register Registrar { get; set; }        
        public string RegistrantEmail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Description { get; set; }

        public string FieldNames { get; set; }
        public string InternalComments { get; set; }
        public string ObjectNames { get; set; }
        public string TechnicalAssessment { get; set; }

        public string TestPlan { get; set; }
        public string StepsToTest { get; set; }
        public string TestOutcome { get; set; }

        #endregion

        #region "Calculated Properties"

        public string CaseNumber { get { return StringUtils.GenerateAutoNumber(this.ID); } }

        #endregion
    }
}
