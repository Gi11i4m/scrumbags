using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace Scrumbags
{
    public class Mailing
    {
        public MailMessage msg = new MailMessage();
        SmtpClient client = new SmtpClient();

        // MAILCONSTRUCTOR (OK)
        public Mailing()
        {
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SendMailSMTPUserName"].ToString(), ConfigurationManager.AppSettings["SendMailSMTPUserPassword"].ToString());
            client.Host = ConfigurationManager.AppSettings["SendMailSMTPHostAddress"].ToString();
        }


        //VERZENDEN VAN DE MAIL (OK - LOGGING REQ.)
        public void send()
        {
            try
            {
                client.Send(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // PROPERTY'S GEVEN AUTOMATISCH DOOR NAAR MAILOBJECT.
        public string to
        {
            get  
            {
                return to;
            }
            set
            {
                msg.To.Add(value);
            }
        }

        public string from
        {
            set
            {
                msg.Sender = msg.From = new MailAddress(ConfigurationManager.AppSettings["SendMailMessagesFromAddress"].ToString());
            }
        }

        public string subject
        {
            set
            {
                msg.Subject = value;
            }
        }

        public string body
        {
            set
            {
                msg.Body = value;

            }
        }


    }
}