using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Scrumbags
{
    public class MailSender
    {

        public string emailaddress { get; set; }
        public string subject { get; set; }
        public string body { get; set; }


        public MailSender(string emailaddress, string subject, string body)
        {
            this.emailaddress = emailaddress;
            this.subject = subject;
            this.body = body;
        }

        //SEND FUNCTION
        public void Send()
        {
            try
            {
                Mailing mail = new Mailing();
                mail.to = this.emailaddress;   // HIER WORD HET EMAIL ADRES VAN DE ONTVANGER INGEVULD
                mail.subject = this.subject; // HIER KOMT HET ONDERWERP VAN DE MAIL
                mail.body = this.body; //HIER DE BOODSCHAP
                mail.send();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
