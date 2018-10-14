
namespace BigFootVentures.Business.Objects.Management
{
    public sealed class LegalCase : BusinessBase
    {
        #region "Properties"

        public string TypeOfCase { get; set; }
        public string TypeOfCaseExternalClients { get; set; }
        public string Trademark { get; set; }
        public string TrademarkNumber { get; set; }
        public string TobeAssignedTo { get; set; }
        public string Opposition { get; set; }
        public string CancellationExecution { get; set; }
        public string Keywords { get; set; }
        public string DateAssigned { get; set; }
        public string CourtUrl { get; set; }
        public string Plantiff { get; set; }
        public string Defendant { get; set; }
        public string PlantiffRepresentative { get; set; }
        public string DefendantRepsentative { get; set; }
        public string InChangeOfTracking { get; set; }
        public bool DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }

        #endregion
    }
}
