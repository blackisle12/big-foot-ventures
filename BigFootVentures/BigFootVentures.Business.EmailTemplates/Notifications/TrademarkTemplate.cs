using System;

namespace BigFootVentures.Business.EmailTemplates.Notifications
{
    public static class TrademarkTemplate
    {
        public static string GetProofOfUseTemplate(string officeName, string trademarkName, string trademarkNumber, string deadlineForSubmission, string assignedStaff, string assignedSupervisor)
        {
            return $@"<div>
                        <span>Office: <strong>{officeName ?? "not specified" }</strong></span><br />
                        <span>Trademark: <strong>{trademarkName}</strong></span><br />
                        <span>Trademark Number: <strong>{trademarkNumber}</strong></span><br />
                        <span>Deadline for submission: <strong>{DateTime.ParseExact(deadlineForSubmission, "yyyy-MM-dd", null).ToString("MMMM dd, yyyy")}</strong></span><br />
                        <span>Assigned Staff: <strong>{assignedStaff}</strong></span><br />
                        <span>Supervisor: <strong>{assignedSupervisor}</strong></span><br />
                    </div>
                    <p>This is to remind you that a proof of use needs to be submitted before the date specified above.</p>";
        }

        public static string GetSixMonthsAnniversaryTemplate(string trademarkName, string trademarkNumber, string sixMonthsAnniversary, string assignedStaff, string assignedSupervisor)
        {
            return $@"<div>
                        <span>Trademark: <strong>{trademarkName}</strong></span><br />
                        <span>Trademark Number: <strong>{trademarkNumber}</strong></span><br />
                        <span>6 Month Anniversary: <strong>{DateTime.ParseExact(sixMonthsAnniversary, "yyyy-MM-dd", null).ToString("MMMM dd, yyyy")}</strong></span><br />
                        <span>Assigned Staff: <strong>{assignedStaff}</strong></span><br />
                        <span>Supervisor: <strong>{assignedSupervisor}</strong></span><br />
                    </div>
                    <p>This is to remind you that we need to file a priority mark before the date specified above. </p>";
        }
    }
}
