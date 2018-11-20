namespace BigFootVentures.Business.EmailTemplates.Management
{
    public static class LegalCaseTemplate
    {
        public static string GetTaskDeadlineTemplate(string legalCaseNumber, string trademarkName, string trademarkNumber, string dueDate)
        {
            return $@"<div>
                        <span>Task Deadline</span><br />
                        <span>Legal Case Number: <strong>{legalCaseNumber}</strong></span><br />
                        <span>Trademark: <strong>{trademarkName}</strong></span><br />
                        <span>Trademark Number: <strong>{trademarkNumber}</strong></span><br />
                        <span>Due Date: <strong>{dueDate}</strong></span><br />
                    </div>
                    <p>This is to remind you that the above-mentioned task is to be completed before the date specified above.</p>";
        }
    }
}
