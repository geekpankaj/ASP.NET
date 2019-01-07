
/*Pankaj Talwar #300986202*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    /*Pankaj Talwar #300986202*/
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
       
        string name = HttpContext.Current.Request.Url.AbsolutePath;
        if (name.Contains("Home.aspx"))
        {
            Label1.Text = "<li><a href='Setup.aspx'>Setup</a></li>";
            Label1.Visible = true;

        }
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            login.Text = "<li><a href='Logout.aspx'>Logout</a></li>";
        }
        else
        {
            login.Text = "<li><a href='Login.aspx'>Login</a></li>";
        }



    }
      
}/*Pankaj Talwar #300986202*/
