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


        public MailingRegistration(string email)
        {
            this.email = email;
        }

        //SEND FUNCTION
        public void Send()
        {
            Mailing mail = new Mailing();
            mail.to = email;   // HIER WORD HET EMAIL ADRES VAN DE ONTVANGER INGEVULD
            mail.subject = "U piemel is net 2cm gekrompen."; // HIER KOMT HET ONDERWERP VAN DE MAIL
            mail.body = "Buy my Penis enlarging product now!"; //HIER DE BOODSCHAP
            mail.from = "";
            mail.send();
        }
    }
}