/*Pankaj Talwar #300986202*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MatchScheduling : System.Web.UI.Page
{
   
    public List<String> Clubs_Dates = new List<String>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            response.Visible = false;
            if (!Page.IsPostBack)
            {

                dropdown_display_clubs();


            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        
    }

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

    protected void Match_Calender(object sender, DayRenderEventArgs e)
    {
        try
        {
            
            if (Match.SelectedDate.Date == DateTime.MinValue.Date && Match.SelectedDate.Date>=DateTime.Now)
            {

                response.Visible = true;
                response.Text = "Date needs to be selected.";
                response.CssClass = "error_msg";

            }
                if ((HostClub.SelectedIndex >= 0 || GuestClub.SelectedIndex >= 0) || (HostClub.SelectedIndex >= 0 || GuestClub.SelectedIndex >= 0))
                {
                    DateTime date = DateTime.Now;
                    int year = date.Year;
                    int month = date.Month;
                    int day = date.Day;
                    DateTime todayday = new DateTime(year, month, day);
                    DateTime previousdays = e.Day.Date;


                    if (previousdays.CompareTo(todayday) < 0)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Day.IsSelectable = false;
                    }
                if (IsPostBack)
                {
                    string Guestlistselect = GuestClub.SelectedValue;
                    List_Changed(Guestlistselect, "Guest");
                    Date_fetch(Guestlistselect, "Guest");

                    string Hostlistselect = HostClub.SelectedValue;
                    List_Changed(Hostlistselect, "Host");
                    Date_fetch(Hostlistselect, "Host");
                }

                if (Clubs_Dates.Count != 0)
                    {
                        foreach (var dates in Clubs_Dates)
                        {
                            DateTime disable_dates = Convert.ToDateTime(dates);
                            for (int day_count = -2; day_count < 3; day_count++)
                            {
                                if (e.Day.Date.CompareTo(disable_dates.AddDays(day_count)) == 0)
                                {
                                    e.Cell.BackColor = System.Drawing.Color.Gray;
                                    e.Cell.ForeColor = System.Drawing.Color.AntiqueWhite;
                                    e.Day.IsSelectable = false;
                                }
                            }
                        }

                    }
                
            
            }
        }
        catch (Exception ex)
        {

            response.Visible = true;
            response.Text = ex.Message;
            response.CssClass = "error_msg";
        }
        finally
        {
            response.Visible = false;
        }
    }

    protected void GuestClub_SelectedIndexChanged(object sender, EventArgs e)
    {

        string Guestlistselect = GuestClub.SelectedValue.ToString() ;
        List_Changed(Guestlistselect, "Guest");
        Date_fetch(Guestlistselect, "Guest");

    }

    protected void HostClub_SelectedIndexChanged(object sender, EventArgs e)
    {


        string Hostlistselect = HostClub.SelectedValue.ToString();
        List_Changed(Hostlistselect, "Host");
        Date_fetch(Hostlistselect, "Host");


    }
    protected void List_Changed(string selected, string dropname)
    {
        string previousselected = "";
        SqlConnection   con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);

        try
        {
            con.Open();
            SqlCommand comm = new SqlCommand("Select Club_Id,Club_Name from Club Where Club_id!=@selected", con);
            comm.Parameters.Add("@selected", SqlDbType.Int);
            comm.Parameters["@selected"].Value = selected;

            SqlDataReader fetchclub = comm.ExecuteReader();
            if (dropname == "Guest")
            {
                previousselected = HostClub.SelectedValue.ToString();
                HostClub.Items.Clear();
                HostClub.DataSource = fetchclub;
                HostClub.DataValueField = "Club_Id";
                HostClub.DataTextField = "Club_Name";
                HostClub.DataBind();
              
                fetchclub.Close();
                con.Close();
            }
            if (dropname == "Host")
            {
                previousselected = GuestClub.SelectedValue.ToString(); ;

                GuestClub.Items.Clear();
             
                GuestClub.DataSource = fetchclub;
                GuestClub.DataValueField = "Club_Id";
                GuestClub.DataTextField = "Club_Name";
                GuestClub.DataBind();
        
                fetchclub.Close();
                con.Close();
            }
        

          


        
            if (dropname == "Guest")
            {
                HostClub.SelectedValue = previousselected;
            }
            if (dropname == "Host")

            {
                GuestClub.SelectedValue = previousselected;

            }
            con.Close();
            fetchclub.Close();
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

    protected void submitschedule_Click(object sender, EventArgs e)
    {
        SqlConnection   con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);

        try
        {
            response.Visible = true;
            con.Open();
            string selectedhostclub = HostClub.SelectedItem.Text;
            string datecalender = Match.SelectedDate.ToString();

            string selectedguestclub = GuestClub.SelectedItem.Text;
            SqlCommand com = new SqlCommand("Select *  From Match where( " +
                "HostClub=@HostClub and GuestClub=@GuestClub" +
                " OR" +
                " GuestClub=@HostClub and HostClub=@GuestClub)" +
                " and Date_schedule=@DateSelected", con);

            com.Parameters.Add("@HostClub", SqlDbType.VarChar);
            com.Parameters["@HostClub"].Value = selectedhostclub;

            com.Parameters.Add("@GuestClub", SqlDbType.VarChar);
            com.Parameters["@GuestClub"].Value = selectedguestclub;

            com.Parameters.Add("@DateSelected", SqlDbType.Date);
            com.Parameters["@DateSelected"].Value = datecalender;

            SqlDataReader checkreader = com.ExecuteReader();

            if (checkreader.HasRows)
            {
                checkreader.Close();
                com = new SqlCommand("Select *  From Match where " +
            " HostClub = @HostClub  OR GuestClub=@GuestClub" +
               " and Date_schedule=@DateSelected", con);

                com.Parameters.Add("@HostClub", SqlDbType.VarChar);
                com.Parameters["@HostClub"].Value = selectedhostclub;

                com.Parameters.Add("@GuestClub", SqlDbType.VarChar);
                com.Parameters["@GuestClub"].Value = selectedguestclub;

                com.Parameters.Add("@DateSelected", SqlDbType.Date);
                com.Parameters["@DateSelected"].Value = datecalender;


                SqlDataReader checkreader2 = com.ExecuteReader();

                if (checkreader2.HasRows)
                {
                    response.Visible = true;
                    response.Text = "Sorry,The clubs has already scheduled the match.";
                    response.CssClass = "error_msg";
                    checkreader.Close();
                }

            }/*Pankaj Talwar #300986202*/
            else
            {
                checkreader.Close();
                if (HostClub.SelectedIndex >= 0 && GuestClub.SelectedIndex >= 0)
                {
                    com = new SqlCommand("INSERT INTO  Match(HostClub,GuestClub,Date_schedule) Values(@HostClub,@GuestClub,@DateSelected)", con);
                    com.Parameters.Add("@HostClub", SqlDbType.VarChar);
                    com.Parameters["@HostClub"].Value = selectedhostclub;

                    com.Parameters.Add("@GuestClub", SqlDbType.VarChar);
                    com.Parameters["@GuestClub"].Value = selectedguestclub;

                    com.Parameters.Add("@DateSelected", SqlDbType.Date);
                    com.Parameters["@DateSelected"].Value = datecalender;

                    if (com.ExecuteNonQuery() == 1)
                    {
                        response.Text = "Successfully Scheduled Your Match.";
                        response.CssClass = "success";
                    }
                }
                else
                {
                    response.Text = "! Invalid Club Choosen.";
                    response.CssClass = "error_msg";
                }
            }
            matchdisplay();

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
    protected void matchdisplay()
    {
        SqlConnection   con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);

        try
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from Match order by Date_schedule desc", con);
            SqlDataReader matchread = com.ExecuteReader();
            Matchschedule.DataSource = matchread;
            Matchschedule.DataBind();

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
    protected void Date_fetch(string getclubid, string listtype)
    {
        string valueget;
        SqlConnection   con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand("");
        if (listtype == "Host")
        {
            valueget = GuestClub.SelectedValue;
            comm = new SqlCommand("Select Distinct(Date_schedule) as 'Date_schedule' from Match where " +
              "( GuestClub = @GuestClubget OR HostClub=@HostClub ) OR (GuestClub =@HostClub OR HostClub=@GuestClubget) ", con);

            comm.Parameters.Add("@GuestClubget", SqlDbType.VarChar);
            comm.Parameters["@GuestClubget"].Value = valueget;

            comm.Parameters.Add("@HostClub", SqlDbType.VarChar);
            comm.Parameters["@HostClub"].Value = getclubid;
        }
        if (listtype == "Guest")
        {
            valueget = HostClub.SelectedValue;
            comm = new SqlCommand("Select Distinct(Date_schedule) as 'Date_schedule' from Match where " +
            "( GuestClub = @GuestClub OR HostClub=@HostClubget) OR (GuestClub = @HostClubget OR HostClub=@GuestClub) ", con);
            comm.Parameters.Add("@HostClubget", SqlDbType.VarChar);
            comm.Parameters["@HostClubget"].Value = valueget;

            comm.Parameters.Add("@GuestClub", SqlDbType.VarChar);
            comm.Parameters["@GuestClub"].Value = getclubid;
        }
        try
        {

            con.Open();
            SqlDataReader readerdate = comm.ExecuteReader();
            while (readerdate.Read())
            {
                Clubs_Dates.Add(readerdate["Date_schedule"].ToString());
            }
            readerdate.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            response.Visible = true;
            response.Text = ex.Message + "atdatefetch";
            response.CssClass = "error_msg";
        }
        finally
        {
            con.Close();
        }
    }

    protected void dropdown_display_clubs()
    { 
               SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SoccerConnectionString"].ConnectionString);
        try
        {
                con.Open();
                SqlCommand comm = new SqlCommand("Select Club_Id,Club_Name from Club", con);
                SqlDataReader fetchclub = comm.ExecuteReader();
               HostClub.Items.Clear();
         
            HostClub.DataSource = fetchclub;
                HostClub.DataValueField = "Club_Id";
                HostClub.DataTextField = "Club_Name";
                HostClub.DataBind();
           
            fetchclub.Close();
                con.Close();

                con.Open();
                 comm = new SqlCommand("Select Club_Id,Club_Name from Club", con);
                 fetchclub = comm.ExecuteReader();
                 GuestClub.Items.Clear();

            GuestClub.DataSource = fetchclub;
                GuestClub.DataValueField = "Club_Id";
                GuestClub.DataTextField = "Club_Name";
                GuestClub.DataBind();
          
            fetchclub.Close();
                con.Close();

            /*Pankaj Talwar #300986202*/
            

            con.Close();
            matchdisplay();
            Clubs_Dates.Clear();


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



   
}/*Pankaj Talwar #300986202*/
