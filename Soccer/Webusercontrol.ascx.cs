using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webusercontrol : System.Web.UI.UserControl
{

   
    public string ClubName
    {
        get { return txt_name.Text; }
        set { txt_name.Text = value;  }
    }
    public string ClubCity
    {
        get { return txt_city.Text; }
        set {  txt_city.Text=value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}