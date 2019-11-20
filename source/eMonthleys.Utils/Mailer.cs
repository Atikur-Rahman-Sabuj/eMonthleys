using System;
using System.Web.Configuration;
using System.Net.Mail;
using System.Web;

namespace eMonthleys.Utils
{
    public class Mailer
    {
        public static bool SendRequest(string EmailMessage, string SubjectLine)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            MailAddress senderemail = new MailAddress(WebConfigurationManager.AppSettings["supportaccount"]);
            MailAddress recepient = new MailAddress(WebConfigurationManager.AppSettings["salesaccount"]);
            bool rc = false;

            msg.IsBodyHtml = true;
            msg.Subject = SubjectLine;
            msg.Body = EmailMessage;
            msg.From = senderemail;
            msg.To.Add(recepient);
            try
            {
                if (!HttpContext.Current.Request.IsLocal)
                    smtp.Send(msg);

                rc = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.writeExceptionToLogFile(ex);
            }
            return rc;
        }

        public static bool SendMail2Client(string Email, string EmailMessage, string SubjectLine)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            MailAddress senderemail = new MailAddress(WebConfigurationManager.AppSettings["salesaccount"]);
            MailAddress recepient = new MailAddress(Email);
            bool rc = false;

            msg.IsBodyHtml = true;
            msg.Subject = SubjectLine;
            msg.Body = EmailMessage;
            msg.From = senderemail;
            msg.To.Add(recepient);
            try
            {
                if (!HttpContext.Current.Request.IsLocal)
                    smtp.Send(msg);

                rc = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.writeExceptionToLogFile(ex);
            }
            return rc;
        }
    }
}
