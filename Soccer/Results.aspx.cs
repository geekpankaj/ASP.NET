/*Pankaj Talwar #300986202*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Results : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["selectedtheme"];
        if (usercookie != null)
        {
            string selecttheme = usercookie.Value;
            if (selecttheme == "Dark")
            {
                Page.Theme = "Dark";
            }/*Pankaj Talwar #300986202*/
            else if (selecttheme == "Light")
            {
                Page.Theme = "Light";
            }
        }
        else
        {
            Page.Theme = "Light";

        }
    }
        protected void Page_Load(object sender, EventArgs e)
    {

    }
}/*Pankaj Talwar #300986202*/