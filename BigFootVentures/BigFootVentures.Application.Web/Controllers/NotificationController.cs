using BigFootVentures.Business.EmailTemplates.Notifications;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Notifications;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Controllers
{
    [RoutePrefix("Notification")]
    public class NotificationController : Controller
    {
        #region Private Members

        private readonly INotificationTrademarkService _notificationTrademarkService = null;

        private readonly IEmailAutomationService _emailAutomationService = null;

        private readonly string _username = "sa";
        private readonly string _password = "FxWaWJ3csC58k";

        #endregion

        #region Constructors

        public NotificationController(INotificationTrademarkService notificationTrademarkService)
        {
            this._notificationTrademarkService = notificationTrademarkService;

            this._emailAutomationService = new EmailAutomationService(
                ConfigurationManager.AppSettings["SMTP_Host"],
                Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]),
                ConfigurationManager.AppSettings["SMTP_FromEmail"],
                ConfigurationManager.AppSettings["SMTP_Username"],
                ConfigurationManager.AppSettings["SMTP_Password"]);
        }

        #endregion

        #region Action Results

        public ActionResult Index()
        {
            return null;
        }

        [Route("TrademarkGetProofOfUse", Name = "TrademarkGetProofOfUse")]
        public ActionResult TrademarkGetProofOfUse(string username, string password)
        {
            if (string.Equals(username, _username, StringComparison.InvariantCulture) && string.Equals(password, _password, StringComparison.InvariantCulture))
            {
                #region Proof of Use

                var list = this._notificationTrademarkService.GetProofOfUse();

                foreach(var entry in list)
                {
                    try
                    {
                        this._emailAutomationService.SendEmail(
                            to: entry.StaffEmailAddress,
                            subject: "Proof of Use",
                            body: TrademarkTemplate.GetProofOfUseTemplate(
                                entry.OfficeName,
                                entry.TrademarkName,
                                entry.TrademarkNumber,
                                entry.DeadlineForSubmission,
                                entry.StaffName,
                                entry.SupervisorName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._emailAutomationService.SendEmail(
                                to: entry.SupervisorEmailAddress,
                                subject: "Proof of Use",
                                body: TrademarkTemplate.GetProofOfUseTemplate(
                                    entry.OfficeName,
                                    entry.TrademarkName,
                                    entry.TrademarkNumber,
                                    entry.DeadlineForSubmission,
                                    entry.StaffName,
                                    entry.SupervisorName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);
                    }
                    catch
                    {
                        continue;
                    }
                }

                #endregion

                #region Proof of Use "2"

                list = this._notificationTrademarkService.GetProofOfUse(iteration: "2");

                foreach (var entry in list)
                {
                    try
                    {
                        this._emailAutomationService.SendEmail(
                            to: entry.StaffEmailAddress,
                            subject: "Proof of Use",
                            body: TrademarkTemplate.GetProofOfUseTemplate(
                                entry.OfficeName,
                                entry.TrademarkName,
                                entry.TrademarkNumber,
                                entry.DeadlineForSubmission,
                                entry.StaffName,
                                entry.SupervisorName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._emailAutomationService.SendEmail(
                                to: entry.SupervisorEmailAddress,
                                subject: "Proof of Use",
                                body: TrademarkTemplate.GetProofOfUseTemplate(
                                    entry.OfficeName,
                                    entry.TrademarkName,
                                    entry.TrademarkNumber,
                                    entry.DeadlineForSubmission,
                                    entry.StaffName,
                                    entry.SupervisorName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);
                    }
                    catch
                    {
                        continue;
                    }
                }

                #endregion

                #region Proof of Use "3"

                list = this._notificationTrademarkService.GetProofOfUse(iteration: "3");

                foreach (var entry in list)
                {
                    try
                    {
                        this._emailAutomationService.SendEmail(
                            to: entry.StaffEmailAddress,
                            subject: "Proof of Use",
                            body: TrademarkTemplate.GetProofOfUseTemplate(
                                entry.OfficeName,
                                entry.TrademarkName,
                                entry.TrademarkNumber,
                                entry.DeadlineForSubmission,
                                entry.StaffName,
                                entry.SupervisorName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._emailAutomationService.SendEmail(
                                to: entry.SupervisorEmailAddress,
                                subject: "Proof of Use",
                                body: TrademarkTemplate.GetProofOfUseTemplate(
                                    entry.OfficeName,
                                    entry.TrademarkName,
                                    entry.TrademarkNumber,
                                    entry.DeadlineForSubmission,
                                    entry.StaffName,
                                    entry.SupervisorName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);
                    }
                    catch
                    {
                        continue;
                    }
                }

                #endregion
            }

            return null;
        }

        [Route("TrademarkGetSixMonthsAnniversary", Name = "TrademarkGetSixMonthsAnniversary")]
        public ActionResult TrademarkGetSixMonthsAnniversary(string username, string password)
        {
            if (string.Equals(username, _username, StringComparison.InvariantCulture) && string.Equals(password, _password, StringComparison.InvariantCulture))
            {
                var list = this._notificationTrademarkService.GetSixMonthsAnniversary();

                foreach (var entry in list)
                {
                    try
                    {
                        this._emailAutomationService.SendEmail(
                            to: entry.StaffEmailAddress,
                            subject: "6 Month Anniversary",
                            body: TrademarkTemplate.GetSixMonthsAnniversaryTemplate(
                                entry.TrademarkName,
                                entry.TrademarkNumber,
                                entry.SixMonthsAnniversaryDate,
                                entry.StaffName,
                                entry.SupervisorName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._emailAutomationService.SendEmail(
                                to: entry.SupervisorEmailAddress,
                                subject: "6 Month Anniversary",
                                body: TrademarkTemplate.GetSixMonthsAnniversaryTemplate(
                                    entry.TrademarkName,
                                    entry.TrademarkNumber,
                                    entry.SixMonthsAnniversaryDate,
                                    entry.StaffName,
                                    entry.SupervisorName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return null;
        }

        [Route("TrademarkGetTrademarkRenewal", Name = "TrademarkGetTrademarkRenewal")]
        public ActionResult TrademarkGetTrademarkRenewal(string username, string password)
        {
            if (string.Equals(username, _username, StringComparison.InvariantCulture) && string.Equals(password, _password, StringComparison.InvariantCulture))
            {
                var list = this._notificationTrademarkService.GetTrademarkRenewal();

                foreach (var entry in list)
                {
                    try
                    {
                        this._emailAutomationService.SendEmail(
                            to: entry.StaffEmailAddress,
                            subject: "Trademark Renewal",
                            body: TrademarkTemplate.GetTrademarkRenewalTemplate(
                                entry.TrademarkName,
                                entry.TrademarkNumber,
                                entry.ExpirationDate,
                                entry.StaffName,
                                entry.SupervisorName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._emailAutomationService.SendEmail(
                                to: entry.SupervisorEmailAddress,
                                subject: "Trademark Renewal",
                                body: TrademarkTemplate.GetTrademarkRenewalTemplate(
                                    entry.TrademarkName,
                                    entry.TrademarkNumber,
                                    entry.ExpirationDate,
                                    entry.StaffName,
                                    entry.SupervisorName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}