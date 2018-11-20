using System;
using System.Net;
using System.Net.Mail;

namespace BigFootVentures.Service.BusinessService
{
    public interface IEmailAutomationService
    {
        #region "Public Methods"

        void SendEmail(string to, string subject, string body, string fromName = "", bool isHtml = false);

        #endregion
    }

    public sealed class EmailAutomationService : IEmailAutomationService
    {
        #region "Members"

        private readonly string _host;
        private readonly int _port;
        private readonly string _fromEmail;
        private readonly string _username;
        private readonly string _password;

        #endregion

        #region "Constructors"

        public EmailAutomationService(string host, int port, string fromEmail, string username, string password)
        {
            this._host = host;
            this._port = port;
            this._fromEmail = fromEmail;
            this._username = username;
            this._password = password;
        }

        #endregion

        #region "Public Methods"

        public void SendEmail(string to, string subject, string body, string fromName = "", bool isHtml = false)
        {
            var message = new MailMessage
            {
                IsBodyHtml = isHtml,
                From = new MailAddress(this._fromEmail, fromName),
                Subject = subject,
                Body = body
            };

            message.To.Add(new MailAddress(to));

            using (var client = new SmtpClient(this._host, this._port))
            {
                client.Credentials = new NetworkCredential(this._username, this._password);
                client.EnableSsl = true;
                
                try
                {
                    Console.WriteLine("Attempting to send email...");
                    client.Send(message);
                    Console.WriteLine("Email sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }
        }

        #endregion
    }
}
