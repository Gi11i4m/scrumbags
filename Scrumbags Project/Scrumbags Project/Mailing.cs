using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace Scrumbags_Project
{
    public class Mailing
    {
        private MailMessage msg;

        public Mailing()
        {
            msg = new MailMessage();
            msg.Sender = msg.From = new MailAddress(ConfigurationManager.AppSettings["SendMailMessagesFromAddress"].ToString());

            msg.IsBodyHtml = true;
        }

        public void send()
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Host = ConfigurationManager.AppSettings["SendMailHostAdress"].ToString();
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SendMailSMTPUserName"].ToString(), ConfigurationManager.AppSettings["SendMailSMTPUserPassword"].ToString());
                sc.Send(msg);
            }
            catch (Exception e)
            {
                //Exceptionhandling
            }
        }

        public bool isHTML
        {
            set
            {
                msg.IsBodyHtml = value;
            }
        }

        public string to
        {
            set
            {
                msg.To.Add(value);
            }
        }

        public string from
        {
            set
            {
                msg.Sender = msg.From = new MailAddress(value);
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
            get
            {
                return body;
            }
            set
            {
                msg.Body = value;

            }
        }


    }
}