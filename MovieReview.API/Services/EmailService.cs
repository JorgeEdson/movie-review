using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Xml.Linq;
using System;

namespace MovieReview.API.Services
{
    public class EmailService
    {
        public bool Send(
            string paramToName,
            string paramToEmail,
            string paramSubject,
            string paramBody,
            string paramFromName = "MovieReview Team",
            string paramFromEmail = "support@moviereview.com") 
        {
            var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);

            smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            var mail = new MailMessage();

            mail.From = new MailAddress(paramFromEmail, paramFromName);
            mail.To.Add(new MailAddress(paramToEmail, paramToName));
            mail.Subject = paramSubject;
            mail.Body = paramBody;
            mail.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
