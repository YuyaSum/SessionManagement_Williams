using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement_Williams
{
    public partial class SecondPage : System.Web.UI.Page
    {
        string user;
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["u"];
            pass = Request.QueryString["p"];

            lblUser.Text = "Hello, " + user + "! Your password is " + pass;

            //string URL = Request.Path;

            //context.RewritePath(URL, string.Empty, "u=" + userSHA + "&p=" + passSHA, true);
            //if (table.ContainsKey(pass) && table.ContainsValue(pass))
            //{
            //    if (table.ContainsKey(user))
            //    {
            //        context.RewritePath(URL, string.Empty, "u=" + table[user] + "&p=" + table[pass], true);
            //    }
            //}
            //else if (table.ContainsValue(user)) { context.Response.Redirect(context.Request.Url.ToString()); }

            

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("MembersMain.aspx?u=" + user + "&p=" + pass);
        }
    }
}