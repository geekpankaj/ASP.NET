using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Configuration;

/*Pankaj Talwar #300986202*/
public partial class _Default : System.Web.UI.Page 
{
    string clubid = "";
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
        deleteclub.Visible = false;
      
            bind_details();
            Panel2.Visible = false;
        if (!IsPostBack)
        {
            Panel3.Visible = false;
            Panel4.Visible = false;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                deleteclub.Visible = true;
            
            }
        }
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            deleteclub.Visible = true;
      
        }


    }/*Pankaj Talwar #300986202*/

    protected void bind_details()
    {
        
            try
            {
                response.Visible = false;
                if (Session["clubid"] == null)
                {
                    response.Visible = true;
                    deleteclub.Visible = false;
                    response.Text = "<b>You are not required to access directly.</b>";
                    response.CssClass = "error_msg";
                }
                else
                {
                    response.Text = "<div><b>Club Details</b></div>";

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
                con.Open();
                    SqlCommand comm = new SqlCommand("Select Club_Id,Registration_Number,Club_Name,Club_City,Address from Club where Club_Id=@Clubid", con);

                comm.Parameters.Add("@Clubid", SqlDbType.Int);
                comm.Parameters["@Clubid"].Value = Session["clubid"];

                SqlDataReader reader = comm.ExecuteReader();
                    ClubDetails.DataSource = reader;
                    ClubDetails.DataBind();
                clubid = ClubDetails.Rows[1].Cells[1].Text.ToString();

                    reader.Close();

                    comm = new SqlCommand("Select Player_Id,Player_Name,DOB,Jercy_No from Player where Club_Id=@Clubid", con);
                  

                comm.Parameters.Add("@Clubid", SqlDbType.Int);
                comm.Parameters["@Clubid"].Value = Session["clubid"];
                reader = comm.ExecuteReader();
                PlayersDetails.DataSource = reader;
                    PlayersDetails.DataKeyNames = new string[] { "Player_Id" };

                    PlayersDetails.DataBind();
                    reader.Close();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                response.Visible = true;
                response.Text = ex.Message;
                response.CssClass = "error_msg";
            }

        

    }
    protected void deleteclub_Click(object sender, EventArgs e)
    {
        response.Visible=true;
        
        string clubid = Session["clubid"].ToString();
        try
        {
            int first=0, second=0, third = 0;
            SqlDataReader check1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
            con.Open();
            SqlCommand check = new SqlCommand("Select * from Match where HostClub=@Clubid OR GuestClub=@Clubid", con);

            check.Parameters.Add("@Clubid", SqlDbType.Int);
            check.Parameters["@Clubid"].Value = clubid;

            check1 = check.ExecuteReader();
            if(check1.HasRows)
            {
                check1.Close();
                SqlCommand comm3 = new SqlCommand("Delete from Match where HostClub=@Clubid OR GuestClub=@Clubid", con);
                check.Parameters.Add("@Clubid", SqlDbType.Int);
                check.Parameters["@Clubid"].Value = clubid;
               
                third = comm3.ExecuteNonQuery();
            }
            else
            {
                check1.Close();
            }
            

            check = new SqlCommand("Select * from Player where Club_id=@Club_id", con);
            check.Parameters.Add("@Clubid", SqlDbType.Int);
            check.Parameters["@Clubid"].Value = clubid;
            check1 = check.ExecuteReader();
            if (check1.HasRows)
            {
                check1.Close();
                SqlCommand comm = new SqlCommand("Delete from Player where Club_id=@Club_id", con);
                check.Parameters.Add("@Clubid", SqlDbType.Int);
                check.Parameters["@Clubid"].Value = clubid;
                first = comm.ExecuteNonQuery();
            }
            else
            {
                check1.Close();
            }

            check = new SqlCommand("Select * from Club where Club_id=@Club_id", con);
            check.Parameters.Add("@Clubid", SqlDbType.Int);
            check.Parameters["@Clubid"].Value = clubid;
            check1 = check.ExecuteReader();
            if (check1.HasRows)
            {

                check1.Close();
                SqlCommand comm2 = new SqlCommand("Delete from Club where Club_id=@Club_id", con);
                check.Parameters.Add("@Clubid", SqlDbType.Int);
                check.Parameters["@Clubid"].Value = clubid;
                second = comm2.ExecuteNonQuery();

            }
            else
            {
                check1.Close();
            }

            if (first == 1 || second == 1 || third == 1)
            {
                response.Text = "Successfully Deleted the club";
                response.CssClass = "success";
                Session["clubid"] = null;
               
             
            }
            else
            {
                response.Text = "Error Deleting the club";
                response.CssClass = "error_msg";
            }
        }
        catch(Exception ex)
        {
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
    }
    protected void bind_details(int player_selectid)
    {
       
            try
            {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
            con.Open();
                SqlCommand comm; 
            SqlDataReader reader;

                comm = new SqlCommand("Select Player_Id,Player_Name,DOB,Jercy_No from Player where Player_Id='" + player_selectid + "'", con);
            comm.Parameters.Add("@Playerid", SqlDbType.Int);
            comm.Parameters["@Playerid"].Value = player_selectid ;
            reader = comm.ExecuteReader();

                PlayersDetails1.DataSource = reader;
                PlayersDetails1.DataKeyNames = new string[] { "Player_Id" };

                PlayersDetails1.DataBind();
                reader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                response.Visible = true;
                response.Text = ex.Message;
                response.CssClass = "error_msg";
            }
        
    }
    int player_selected_id;
    protected void PlayersDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRow = PlayersDetails.SelectedIndex;
         player_selected_id = (int)PlayersDetails.DataKeys[selectedRow].Value;
        bind_details(player_selected_id);

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Panel2.Visible = true;
        }
        else
        {
            Panel3.Visible = true;
        }



    }



    protected void PlayersDetails1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            PlayersDetails1.ChangeMode(e.NewMode);

            bind_details(player_selected_id);

        }
        else
        {
            Panel3.Visible = true;
        }
    }




    protected void PlayersDetails1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            int selectedRow = PlayersDetails.SelectedIndex;
            player_selected_id = (int)PlayersDetails.DataKeys[selectedRow].Value;
            updatedetails(player_selected_id);
        }
        else
        {
            Panel3.Visible = true;
        }

    }
    protected void updatedetails(int id)
    {
        try
        {
           TextBox updated_name= PlayersDetails1.Rows[0].Cells[1].Controls[0] as TextBox;
            TextBox updated_dob =PlayersDetails1.Rows[1].Cells[1].Controls[0] as TextBox;
            TextBox updated_jercy = PlayersDetails1.Rows[2].Cells[1].Controls[0] as TextBox ;
            int updated_jercy_check =Convert.ToInt32(updated_jercy.Text.ToString());
            if(updated_jercy_check <= 99 && updated_jercy_check >= 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
                con.Open();
                SqlCommand commupdate = new SqlCommand("Update Player set Player_Name=@Playername, DOB=@Playerdob, Jercy_No=@Playerjercy where Player_Id=@Playerid", con);

                commupdate.Parameters.Add("@Playername", SqlDbType.VarChar);
                commupdate.Parameters["@Playername"].Value = updated_name.Text;

                commupdate.Parameters.Add("@Playerdob", SqlDbType.VarChar);
                commupdate.Parameters["@Playerdob"].Value = updated_dob.Text;

                commupdate.Parameters.Add("@Playerjercy", SqlDbType.Int);
                commupdate.Parameters["@Playerjercy"].Value = updated_jercy.Text;

                commupdate.Parameters.Add("@Playerid", SqlDbType.Int);
                commupdate.Parameters["@Playerid"].Value = id;



                int update = commupdate.ExecuteNonQuery();

                if (update == 1)
                {
                    bind_details();
                    response.Visible = true;
                    response.Text = "Successfully Updated Details of Players";
                    response.CssClass = "success";

                   

                }
                else
                {
                    response.Visible = true;
                    response.Text = "Error in Updating Records";
                    response.CssClass = "error_msg";
                }
            }
            else
            {
                response.Visible = true;
                response.Text = "Jercy Number should be 0 to 99";
                response.CssClass = "error_msg";
            }
        }
        catch (Exception ex)
        {
            response.Visible = true;
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
    }



    protected void Register_Form_Click(object sender, EventArgs e)
    {
        
            Panel3.Visible = false;
            Panel4.Visible = true;
       
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Response.Redirect("ClubDetails.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       
            FormsAuthentication.SignOut();
      

    }
     
}/*Pankaj Talwar #300986202*/