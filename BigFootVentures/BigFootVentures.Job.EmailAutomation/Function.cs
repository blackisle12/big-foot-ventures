using Amazon.Lambda.Core;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BigFootVentures.Job.EmailAutomation
{
    public class Function
    {
        #region "Members"

        private readonly IEmailAutomationService _client = null;
        private readonly IEmailNotificationService<LegalCase> _legalCaseEmailNotificationService = null;

        #endregion

        #region "Constructors"

        public Function()
        {
            this._client = new EmailAutomationService(
                Environment.GetEnvironmentVariable("SMTP_Host"),
                Int32.Parse(Environment.GetEnvironmentVariable("SMTP_Port")),
                Environment.GetEnvironmentVariable("SMTP_FromEmail"),
                Environment.GetEnvironmentVariable("SMTP_Username"),
                Environment.GetEnvironmentVariable("SMTP_Password"));

            this._legalCaseEmailNotificationService = new EmailNotificationService<LegalCase>(Environment.GetEnvironmentVariable("DB_ConnectionString"));
        }

        #endregion

        #region "Public Methods"

        public void FunctionHandler()
        {
            try
            {
                this.RunLegalCaseAutomation();
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        #endregion

        #region "Private Methods"

        private void RunLegalCaseAutomation()
        {
            for(var i = 1; i <= 4; i++)
            {
                var legalCases = this._legalCaseEmailNotificationService.Get(i);

                Console.WriteLine($"Legal Cases Count: {legalCases.Count}");

                foreach (var legalCase in legalCases)
                {
                    Console.WriteLine($"Legal Case (Trademark Number): {legalCase.TrademarkNumber}");
                    Console.WriteLine($"Legal Case (Trademark Name): {legalCase.Trademark?.Name}");

                    //this._client.SendEmail(
                    //    to: "blackisle_12@yahoo.com",
                    //    subject: "Legal Case",
                    //    body: LegalCaseTemplate.GetTaskDeadlineTemplate(
                    //        legalCaseNumber: legalCase.ID.ToString(),
                    //        trademarkName: legalCase.Trademark?.Name,
                    //        trademarkNumber: legalCase.TrademarkNumber,
                    //        dueDate: legalCase.DateAssigned),
                    //    fromName: "Big Foot Ventures",
                    //    isHtml: true);
                }
            }
        }

        #endregion
    }
}
