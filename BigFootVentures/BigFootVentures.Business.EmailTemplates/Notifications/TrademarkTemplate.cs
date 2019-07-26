namespace BigFootVentures.Business.EmailTemplates.Notifications
{
    public static class TrademarkTemplate
    {
        public static string GetProofOfUseTemplate(string officeName, string trademarkName, string trademarkNumber, string deadlineForSubmission, string assignedStaff, string assignedSupervisor)
        {
            return $@"<div>
                        <span>Office: {officeName ?? "not specified" },</span><br />
                        <span>Trademark: {trademarkName},</span><br />
                        <span>Trademark Number: {trademarkNumber},</span><br />
                        <span>Deadline for submission: {deadlineForSubmission},</span><br />
                        <span>Assigned Staff: {assignedStaff},</span><br />
                        <span>Supervisor: {assignedSupervisor},</span><br />
                    </div>
                    <p>This is to remind you that a proof of use needs to be submitted before the date specified above.</p>";
        }
    }
}
