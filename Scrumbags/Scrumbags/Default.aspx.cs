using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scrumbags
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textLabel.Text = DBQueries.login("tim.acke@artesis.be", "abc").ToString();
            Hashing.GetHash("abc");
        }
    }
}