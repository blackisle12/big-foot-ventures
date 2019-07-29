using System;

namespace BigFootVentures.Business.Objects.Notifications.Trademark
{
    public sealed class SixMonthsAnniversary
    {
        #region "Properties"

        public string TrademarkName { get; set; }
        public string TrademarkNumber { get; set; }
        public DateTime SixMonthsAnniversaryDate { get; set; }
        public string StaffName { get; set; }
        public string StaffEmailAddress { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmailAddress { get; set; }

        #endregion
    }
}
