namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Cancellation : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public string ReferenceInternal { get; set; }
        public string ReferenceExternal { get; set; }
        public string SentOrigin { get; set; }
        public string ReceiptDate { get; set; }
        public string PaymentDate { get; set; }
        public string FilingCost { get; set; }
        public Trademark Trademark { get; set; }
        public string Status { get; set; }
        public string InternalCaseNumber { get; set; }
        public string SubmissionMethod { get; set; }
        public Company Applicant { get; set; }
        public string PaymentReference { get; set; }
        public string ResearchPerformance { get; set; }
        public string Comments { get; set; }

        public string AdmissibleDate { get; set; }
        public string OwnerResponseDeadline { get; set; }
        public string ObservationDeadline { get; set; }
        public string OwnerResponseDeadlineExt { get; set; }
        public string ObservationDeadlineExt { get; set; }

        public string AcquisitionLetterSentOrigin { get; set; }
        public string AcquisitionLetterSentMethod { get; set; }
        public string AcquisitionLetterDateSent { get; set; }
        public string OwnerResponseAcquisitionLetter { get; set; }
        public bool DomainEnquiry { get; set; }
        public string DomainEnquiryNotes { get; set; }
        public string Outcome { get; set; }
        public string OutcomeDate { get; set; }
        public string WithdrawalReason { get; set; }
        public string TrademarkAssignmentDate { get; set; }
        public string TrademarkAcquisitionCost { get; set; }
        public string UDRPStrategy { get; set; }
        public string UDRPStrategyComment { get; set; }
        public string NegotiationComments { get; set; }
        public string WithdrawalDate { get; set; }
        public string ExpenseClaimReceivedDate { get; set; }
        public string CostRefund { get; set; }

        #endregion
    }
}
