using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Scrumbags
{
    public class MailingRegistration
    {

        public string email { get; set; }
        public string subject { get; set; }
        public string body { get; set; }


        public MailingRegistration(string emailadres, string subject, string body)
        {
            this.email = emailadres;
            this.subject = subject;
            this.body = body;
        }

        //SEND FUNCTION
        public void Send()
        {
            Mailing mail = new Mailing();
            mail.to = this.email;   // HIER WORD HET EMAIL ADRES VAN DE ONTVANGER INGEVULD
            mail.subject = this.subject; // HIER KOMT HET ONDERWERP VAN DE MAIL
            mail.body = this.body; //HIER DE BOODSCHAP
            mail.from = "";
            mail.send();
        }
    }
}