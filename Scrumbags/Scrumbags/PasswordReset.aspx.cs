using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static Random generator = new Random(Convert.ToInt32(TimeStamp.DateTimeToUnixTimestamp(DateTime.Now)));

        protected void Page_Load(object sender, EventArgs e)
        {
            resetButton.Attributes.Add("onclick", "popup()");
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Generate new password
                String range = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!&$#*@_-";
                char[] charray = new char[8];

                for (int i = 0; i < 8; i++)
                {
                    charray[i] = range[generator.Next(range.Length)];
                }

                String password = new string(charray);

                //Save hash in DB
                DBQueries.changePassword(emailTexbox.Text, password);

                //Send new password to email address 
            }
        }

        protected void emailExistsValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Check if email exists
            if (1 == 1) // Do DB lookup
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}