/*Pankaj Talwar #300986202*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using System.Web.Security;

public partial class AddClubs : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                AddClub.Visible = true;
                Mustlogin.Visible = false;
            }
        }
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            AddClub.Visible = true;
            Mustlogin.Visible = false;

        }
        Panel1.Visible = false;
    }
    protected void redi_club(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void save_club_Click(object sender, EventArgs e)
    {

       
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
        try
        {
            Club club_data = new Club();
            club_data.clubName = usercontrolfields.ClubName;
            club_data.Clubcity = usercontrolfields.ClubCity;
            club_data.clubregno = Convert.ToInt32(txtregister.Text);
            club_data.clubadd = txtadd.Text;

            
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Club (Registration_Number,Club_Name,Club_City,Address)VALUES( @regno,@Clubname,@Clubcity,@Clubadd)", con);
            comm.Parameters.Add("@regno", SqlDbType.Int);
            comm.Parameters["@regno"].Value = club_data.clubregno;

            comm.Parameters.Add("@Clubname", SqlDbType.VarChar);
            comm.Parameters["@Clubname"].Value = club_data.clubName;

            comm.Parameters.Add("@Clubcity", SqlDbType.VarChar);
            comm.Parameters["@Clubcity"].Value = club_data.Clubcity;

            comm.Parameters.Add("@Clubadd", SqlDbType.VarChar);
            comm.Parameters["@Clubadd"].Value =club_data.clubadd;

            

            comm.ExecuteNonQuery();
            con.Close();
            addplayer.Visible = true;
        }
        catch (Exception ex)
        {
            response.Visible = true;
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
        finally
        {
            con.Close();
        }

        /*Pankaj Talwar #300986202*/

    }
    protected void btn_addplayer_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);

        try
        {
          

            con.Open();
            SqlCommand comm = new SqlCommand("Select Club_Id,Club_Name from Club", con);

            comm.ExecuteNonQuery();

            SqlDataReader reader = comm.ExecuteReader();
            Clubslist.Items.Clear();

            Clubslist.DataSource = reader;
            Clubslist.DataValueField = "Club_Id";
            Clubslist.DataTextField = "Club_Name";
            Clubslist.DataBind();



            con.Close();

            reader.Close();
            Panel1.Visible = true;
        }
        catch (Exception ex)
        {
            response.Visible = true;
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
        finally
        {
            con.Close();
        }


    }
    protected void add_player_btn_Click(object sender, EventArgs e)
    {
    
        string clubid = Clubslist.SelectedValue;
        Players pplayers = new Players();
        pplayers.jercyno = Convert.ToInt32(Jercy_Number.Text);
        pplayers.player_dob = playerdob.Text;
        pplayers.playername = player_name.Text;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
        try
        {
             con.Open();
            SqlCommand comm = new SqlCommand("select Club_Id from Club where Club_Id =@Club_Id", con);
             comm.Parameters.Add("@Club_Id", SqlDbType.VarChar);
            comm.Parameters["@Club_Id"].Value = clubid;

            SqlDataReader read = comm.ExecuteReader();
            int clubregno;
            while (read.Read())
            {
                clubregno = (int)read["Club_Id"];
                comm = new SqlCommand("INSERT INTO Player (Player_Name,DOB,Jercy_No,Club_Id)VALUES(@Player_Name,@Player_Dob,@Player_jercy,@Club_id)", con);
                comm.Parameters.Add("@Player_Name", SqlDbType.VarChar);
                comm.Parameters["@Player_Name"].Value = pplayers.playername;

                comm.Parameters.Add("@Player_Dob", SqlDbType.VarChar);
                comm.Parameters["@Player_Dob"].Value = pplayers.player_dob;

                comm.Parameters.Add("@Player_jercy", SqlDbType.VarChar);
                comm.Parameters["@Player_jercy"].Value = pplayers.jercyno;

                comm.Parameters.Add("@Club_id", SqlDbType.VarChar);
                comm.Parameters["@Club_id"].Value = clubid;
            }

            read.Close();
            comm.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            response.Visible = true;
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
        finally
        {
            con.Close();
        }


    }

    protected void btn_cancelclub_Click(object sender, EventArgs e)
    {
        
        usercontrolfields.ClubName = "";
        usercontrolfields.ClubCity = "";
        txtregister.Text = "";
       txtadd.Text = "" ;

    }
    protected void btn_cancelplayer_Click(object sender, EventArgs e)
    {
        player_name.Text = "";
        playerdob.Text = "";
        Jercy_Number.Text = "";
        
    }

   
}
/*Pankaj Talwar #300986202*/
