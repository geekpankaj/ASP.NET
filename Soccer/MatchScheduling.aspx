<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="MatchScheduling.aspx.cs" Inherits="MatchScheduling" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Pankaj Talwar #300986202-->
    <form runat="server">
              <asp:Panel ID="Panel2" runat="server" Width="482px"  CssClass="matchdiv">
                  <br />
                                     <asp:Label ID="response" runat="server"  CssClass="error_msg" Text="Error"></asp:Label><br />

                  <table style="width: 100%;">
                      <tr>
                          <td>  <asp:Label ID="Label1" runat="server" Text="Host Club"></asp:Label></td>
                          <td>  <asp:DropDownList ID="HostClub" runat="server" OnSelectedIndexChanged="HostClub_SelectedIndexChanged" AutoPostBack="True" >
           
        </asp:DropDownList></td>
                        
                      </tr>
                      <tr>
                          <td>  <asp:Label ID="Label2" runat="server" Text="Guest Club"></asp:Label></td>
                          <td> <asp:DropDownList ID="GuestClub" runat="server" OnSelectedIndexChanged="GuestClub_SelectedIndexChanged" AutoPostBack="True"  >
           
        </asp:DropDownList></td>
                         
                      </tr>
                      
                  </table>
                
      
                  <br />
      
       
        <asp:Calendar ID="Match" runat="server" OnDayRender="Match_Calender" BackColor="White" BorderColor="#3366CC" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" ValidateRequestMode="Enabled"  >
            <TitleStyle BackColor="#33CC33" Font-Bold="True" Font-Size="10pt" ForeColor="#FFFFFF" Height="25px" BorderColor="#3366CC" BorderWidth="1px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    <asp:Button ID="submitschedule" runat="server" Text="Make Schedule" OnClick="submitschedule_Click" CssClass="btnstyle"/>
              </asp:Panel>

       
      
    <asp:Panel ID="Panel1" runat="server" Width="287px" CssClass="matchdiv">
        
           <asp:Label ID="Label3" runat="server" Text="Match Schedule" CssClass="heading"></asp:Label>
        <br\ > 
        <asp:GridView ID="Matchschedule" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="HostClub" HeaderText="HostClub" SortExpression="HostClub" />
                <asp:BoundField DataField="GuestClub" HeaderText="GuestClub" SortExpression="GuestClub" />
                <asp:BoundField DataField="Date_schedule" HeaderText="Date_schedule" SortExpression="Date_schedule" dataformatstring="{0:MMMM dd yyyy}"/>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView></asp:Panel>


       <!--Pankaj Talwar #300986202-->
        </form>
    </asp:Content>
