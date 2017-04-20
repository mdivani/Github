using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service
{
    public class MailService
    {
        public string MailSubject;
        public string MailBody;

        public MailService()
        {
            MailSubject = "";
            MailBody = "";
        }

        public void SendMail(string address)
        {
            SmtpClient Client = new SmtpClient("smtp.gmail.com");
            MailMessage Mail = new MailMessage()
            {
                Subject = MailSubject,
                Body = MailBody,
                IsBodyHtml = true
            };

            Mail.To.Add(address);
            Mail.From = new MailAddress("group18test@gmail.com");

            Client.Port = 587;
            Client.Credentials = new System.Net.NetworkCredential("group18test@gmail.com", "skami123");
            Client.EnableSsl = true;
            Client.Send(Mail);
        }
    }
}
