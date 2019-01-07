using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clubs : System.Web.UI.Page
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
            }
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
        SqlConnection con = new SqlConnection("");
            
        try
        {
             con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
            con.Open();
            SqlCommand comm = new SqlCommand("Select Club_id,Registration_Number,Club_Name,Club_City from Club", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {

                Clubnull.Text = "<div><strong>Clubs available right now:-</strong></div><br/>";
                redirectbtn.Visible = false;

                

                Clubs_display.DataSource = reader;
                Clubs_display.DataKeyNames = new string[] { "Club_id" };
                Clubs_display.DataBind();
                reader.Close();
                con.Close();
            }
            else
            {
                Clubnull.Text = "<div><strong>You have not Added any Club, You wanna Add ?</strong>  </div><br/>";
                redirectbtn.Visible = true;


            }
        }
        catch (Exception ex)
        {
            Clubnull.Visible = true;
            Clubnull.Text = ex.Message;
            Clubnull.CssClass = "error_msg";
        }
        finally
        {
            con.Close();
        }





    }
    protected void redi_club(object sender, EventArgs e)
    {
        Response.Redirect("AddClubs.aspx");
    }
    
    protected void Clubs_display_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int selectedRow = Clubs_display.SelectedIndex;
        Session["clubid"] = (int)Clubs_display.DataKeys[selectedRow].Value;

        Response.Redirect("ClubDetails.aspx");

    }
}
