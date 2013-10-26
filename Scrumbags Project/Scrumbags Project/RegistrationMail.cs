using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrumbags_Project
{
    public class RegistrationMail
    {
        public RegistrationMail()
        { 
        }

        public void Send()
        {
            Mailing mail = new Mailing();
            mail.to = "Yolan@Coeman.net";
            mail.subject = "U piemel is net 2cm gekrompen.";
            mail.body = "Buy my Penis enlarging product now!";
            mail.send();
        }

        static void Main(string[] args)
        {
            RegistrationMail r = new RegistrationMail();
            r.Send();
               
        }           
   }

    
}