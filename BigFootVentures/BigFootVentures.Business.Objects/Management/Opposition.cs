using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Opposition : BusinessBase
    {
        #region "Properties"

        public string OppositionName { get; set; }

        public string TrademarkRoleA { get; set; }
        public string TrademarkRoleD { get; set; }
        public Trademark TrademarkNameA { get; set; }
        public Trademark TrademarkNameD { get; set; }
        public string ClassDescriptionsAttacking { get; set; }
        public string ClassDescriptionsDefending { get; set; }
        public string OppositionStatus { get; set; }
        public string InternalCaseNumber { get; set; }
        public bool DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }

        public string OppositionDeadline { get; set; }
        public string OppositionCost { get; set; }
        public string CeaseAndDesistLetterPreApproval { get; set; }
        public string CeaseAndDesistLetterPreApprovedBy { get; set; }
        public string CeaseAndDesistLetterPreApprovedOn { get; set; }
        public string CeaseAndDesistLetterApproval { get; set; }
        public string CeaseAndDesistLetterApprovedBy { get; set; }
        public string CeaseAndDesistLetterApprovedOn { get; set; }
        public string CeaseAndDesistLetterReference { get; set; }
        public string CeaseAndDesistLetterOrigin { get; set; }
        public string CeaseAndDesistLetterSendingMethod { get; set; }
        public string CeaseAndDesistLetterSentOn { get; set; }
        public string CeaseAndDesistLetterOutcome { get; set; }
        public string IPOOppositionApproval { get; set; }
        public string IPOOppositionApprovedBy { get; set; }
        public string IPOOppositionApprovedOn { get; set; }
        public Company OwnerApplicantsRepresentative { get; set; }
        public Company OpponentsRepresentative { get; set; }
        public string IPOOppositionNumber { get; set; }
        public string IPOOppositionLanguage { get; set; }
        public DateTime? IPOOppositionDate { get; set; }
        public string IPOOppositionLink { get; set; }
        public string IPOOppositionStatus { get; set; }
        public DateTime? IPOOppositionOutcomeDate { get; set; }
        public DateTime? OwnerResponseDeadline { get; set; }
        public string OppositionComments { get; set; }

        #endregion
    }
}
