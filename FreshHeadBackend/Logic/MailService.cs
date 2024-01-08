using System.Net.Mail;
using System.Net;
using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class MailService : IMailService
    {
        private readonly string senderMail = "edudeals@outlook.com";
        private readonly string senderMailPW = "Welkom123";

        public bool SendEmailAsync(string mail, string subject, string mailMSG)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderMail, senderMailPW)
            };

            try {
                MailMessage message = new MailMessage(from: senderMail,
                                to: mail,
                                subject,
                                mailMSG);
                message.IsBodyHtml = true;
                smtpClient.Send(message);
                return true;
            } catch (Exception ex) { 
                return false;
            }
        }
    }
}
