using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement_Williams
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			if ((txtUser.Text == "Dean" && txtPassword.Text == "Williams") || (txtUser.Text == "Dan" && txtPassword.Text == "Hagen"))
			{
				string user = txtUser.Text;
				string pass = txtPassword.Text;
				
				Response.Redirect("SecondPage.aspx?u=" + txtUser.Text + "&p=" + txtPassword.Text);
			}
			else
			{
				lblMessage.Text = "Account not recognized";
			}
	
		}
	}
}