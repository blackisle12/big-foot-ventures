namespace BigFootVentures.Business.Objects.Notifications.Trademark
{
    public sealed class ProofOfUse
    {
        #region "Properties"

        public string OfficeName { get; set; }
        public string TrademarkName { get; set; }
        public string TrademarkNumber { get; set; }
        public string DeadlineForSubmission { get; set; }
        public string StaffName { get; set; }
        public string StaffEmailAddress { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmailAddress { get; set; }

        #endregion
    }
}
