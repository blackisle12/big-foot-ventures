using System;

namespace BigFootVentures.Business.Objects.Management
{
    public sealed class Trademark : BusinessBase
    {
        #region "Private Members"

        private string _WIPODesignatedProtection;
        private string _WIPOBasicApplicationISO;
        private string _ARIPODesignatedStates;

        #endregion

        #region "Properties"

        public string OwnerName { get; set; }

        public string Name { get; set; }
        public Office Office { get; set; }
        public string OfficeStatus { get; set; }

        public string TrademarkNumber { get; set; }
        public string InternationalRegistrationNumber { get; set; }
        public string FilingNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string TMURL { get; set; }
        public Brand Brand { get; set; }
        public Office OriginalOffice { get; set; }
        public string ReceiptDate { get; set; }
        public string FilingDateValue { get; set; }
        public string PublicationDate { get; set; }
        public string RegistrationDate { get; set; }
        public string ExpiryDate { get; set; }
        public string SixMonthsAnniversary { get; set; }
        public string PriorityDate { get; set; }
        public string PriorityCountryAndPriorityTMNumber { get; set; }
        public bool SeniorityUsed { get; set; }
        public string SeniorityDetails { get; set; }
        public bool DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }
        public string DeletionDuplicate { get; set; }
        public bool RevocationTarget { get; set; }
        public string UserStatusDescription { get; set; }
        public bool Figurative { get; set; } = false;
        public string TrademarkType { get; set; }
        public string FigurativeURL { get; set; }
        public string LanguageFiling { get; set; }
        public string LanguageSecond { get; set; }
        public string Geography { get; set; }
        public bool InvolvedInRevocation { get; set; }
        public string BigfootGroupOwned { get; set; }

        public string OpenSimilarityResearchTask { get; set; }
        public string InitialSubmitter { get; set; }
        //last similarity research completed by
        public string LastSimilarityResearchCompletedOn { get; set; }
        public string OppositionResearch { get; set; }
        public string SimilarTrademarkSpellings { get; set; }

        public string WIPODesignatedProtection { get { return this._WIPODesignatedProtection; } set { this._WIPODesignatedProtection = value; if (!string.IsNullOrWhiteSpace(value)) { this.WIPODesignatedProtections = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
        public string ARIPODesignatedState { get { return this._ARIPODesignatedStates; } set { this._ARIPODesignatedStates = value; if (!string.IsNullOrWhiteSpace(value)) { this.ARIPODesignatedStates = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }
        public string TrademarkNameEnglishTranslation { get; set; }
        public string WIPOBasicApplicationISO { get { return this._WIPOBasicApplicationISO; } set { this._WIPOBasicApplicationISO = value; if (!string.IsNullOrWhiteSpace(value)) { this.WIPOBasicApplicationISOs = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries); } } }        
        public string WIPOBasicApplicationFilingDate { get; set; }
        public string WIPOBasicApplicationNumber { get; set; }

        public string PaymentStatusRegisteredLV { get; set; }
        public string AcceptanceDueDate { get; set; }
        public string CommentsLV { get; set; }
        public string LVAppealDeadline { get; set; }
        public string ReasonForTheRefusalLV { get; set; }

        public bool Class1 { get; set; }
        public string Class1Description { get; set; }
        public bool Class2 { get; set; }
        public string Class2Description { get; set; }
        public bool Class3 { get; set; }
        public string Class3Description { get; set; }
        public bool Class4 { get; set; }
        public string Class4Description { get; set; }
        public bool Class5 { get; set; }
        public string Class5Description { get; set; }
        public bool Class6 { get; set; }
        public string Class6Description { get; set; }
        public bool Class7 { get; set; }
        public string Class7Description { get; set; }
        public bool Class8 { get; set; }
        public string Class8Description { get; set; }
        public bool Class9 { get; set; }
        public string Class9Description { get; set; }
        public bool Class10 { get; set; }
        public string Class10Description { get; set; }
        public bool Class11 { get; set; }
        public string Class11Description { get; set; }
        public bool Class12 { get; set; }
        public string Class12Description { get; set; }
        public bool Class13 { get; set; }
        public string Class13Description { get; set; }
        public bool Class14 { get; set; }
        public string Class14Description { get; set; }
        public bool Class15 { get; set; }
        public string Class15Description { get; set; }
        public bool Class16 { get; set; }
        public string Class16Description { get; set; }
        public bool Class17 { get; set; }
        public string Class17Description { get; set; }
        public bool Class18 { get; set; }
        public string Class18Description { get; set; }
        public bool Class19 { get; set; }
        public string Class19Description { get; set; }
        public bool Class20 { get; set; }
        public string Class20Description { get; set; }
        public bool Class21 { get; set; }
        public string Class21Description { get; set; }
        public bool Class22 { get; set; }
        public string Class22Description { get; set; }
        public bool Class23 { get; set; }
        public string Class23Description { get; set; }
        public bool Class24 { get; set; }
        public string Class24Description { get; set; }
        public bool Class25 { get; set; }
        public string Class25Description { get; set; }
        public bool Class26 { get; set; }
        public string Class26Description { get; set; }
        public bool Class27 { get; set; }
        public string Class27Description { get; set; }
        public bool Class28 { get; set; }
        public string Class28Description { get; set; }
        public bool Class29 { get; set; }
        public string Class29Description { get; set; }
        public bool Class30 { get; set; }
        public string Class30Description { get; set; }
        public bool Class31 { get; set; }
        public string Class31Description { get; set; }
        public bool Class32 { get; set; }
        public string Class32Description { get; set; }
        public bool Class33 { get; set; }
        public string Class33Description { get; set; }
        public bool Class34 { get; set; }
        public string Class34Description { get; set; }
        public bool Class35 { get; set; }
        public string Class35Description { get; set; }
        public bool Class36 { get; set; }
        public string Class36Description { get; set; }
        public bool Class37 { get; set; }
        public string Class37Description { get; set; }
        public bool Class38 { get; set; }
        public string Class38Description { get; set; }
        public bool Class39 { get; set; }
        public string Class39Description { get; set; }
        public bool Class40 { get; set; }
        public string Class40Description { get; set; }
        public bool Class41 { get; set; }
        public string Class41Description { get; set; }
        public bool Class42 { get; set; }
        public string Class42Description { get; set; }
        public bool Class43 { get; set; }
        public string Class43Description { get; set; }
        public bool Class44 { get; set; }
        public string Class44Description { get; set; }
        public bool Class45 { get; set; }
        public string Class45Description { get; set; }

        public string ResearcherName { get; set; }
        public DomainN TMWebsite { get; set; }
        public DomainN OwnerWebsite { get; set; }
        public DomainN ComWebsite { get; set; }
        public string CancellationStrategy { get; set; }
        public string MarkUse { get; set; }
        public bool CompetingMarks { get; set; }
        public string CompetingMark { get; set; }
        public string CancelResearcherComments { get; set; }
        public string OwnerDefense { get; set; }

        public string SourceName { get; set; }
        public string BFStrategy { get; set; }
        public string StrategyNotes { get; set; }
        public string NameValue { get; set; }
        //case manager
        public string CancelBuyBudget { get; set; }

        public string RevocationReferenceExternal { get; set; }

        public string InvalidityNumber { get; set; }
        public Company InvalidityApplicant { get; set; }
        public string InvalidityInvokedGround { get; set; }
        public string InvalidityDate { get; set; }
        public string InvalidityActionOutcome { get; set; }

        public string LetterReference { get; set; }
        public string LetterOrigin { get; set; }
        public string LetterSendingMethod { get; set; }
        public string LetterSentOn { get; set; }
        public string OwnerResponseDeadline { get; set; }
        public string LetterOutcome { get; set; }

        #endregion

        #region "Calculated Properties"

        public string[] WIPODesignatedProtections { get; set; }
        public string[] WIPODesignatedProtectionsSelected { get; set; }
        public string[] WIPODesignatedProtectionsAvailable { get; set; }

        public string[] WIPOBasicApplicationISOs { get; set; }
        public string[] WIPOBasicApplicationISOsSelected { get; set; }
        public string[] WIPOBasicApplicationISOsAvailable { get; set; }

        public string[] ARIPODesignatedStates { get; set; }
        public string[] ARIPODesignatedStatesSelected { get; set; }
        public string[] ARIPODesignatedStatesAvailable { get; set; }

        public string TMNameAndBrandMatched { get { return this.Name == this.Brand?.Name ? "True" : "False"; } }
        public int NonUseScore
        {
            get
            {
                if (this.MarkUse == "Inactive")
                    return 100;
                else if (this.MarkUse == "Active")
                    return 0;
                else if (this.MarkUse == "Slightly Active")
                    return 10;
                else
                    return 5;
            }
        }
        public int NameScore
        {
            get
            {
                if (this.NameValue == "<$1K")
                    return 0;
                else if (this.NameValue == ">$1K - < $10K")
                    return 1;
                else if (this.NameValue == ">$10K - <$100K")
                    return 10;
                else if (this.NameValue == ">$100K")
                    return 100;
                else
                    return 0;
            }
        }
        public int DefenselessScore
        {
            get
            {
                if (this.OwnerDefense == "Strong - MNC")
                    return 0;
                else if (this.OwnerDefense == "Medium")
                    return 1;
                else if (this.OwnerDefense == "Weak")
                    return 10;
                else
                    return 2;
            }
        }
        public int CancellationScore { get { return this.NameScore * this.DefenselessScore * this.NonUseScore; } }

        #endregion
    }
}
