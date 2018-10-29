namespace BigFootVentures.Business.Objects.Management
{
    public sealed class SimilarTrademark : BusinessBase
    {
        #region "Properties"

        public string OwnerName { get; set; }

        public Trademark Trademark { get; set; }
        public Trademark TrademarkSimilar { get; set; }
        public string Comment { get; set; }
        public bool Conflict { get; set; }
        public bool CreateOppositionCheck { get; set; }

        public string ClassSummaryTM { get; set; }
        public string ClassSummarySimilarTM { get; set; }

        public string Remarks { get; set; }
        public string RefilingEvaluation { get; set; }
        public string RefilingComment { get; set; }
        public string OppositionEvaluation { get; set; }
        public string OppositionComment { get; set; }

        #endregion
    }
}
