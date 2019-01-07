
<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AddClubs.aspx.cs" Inherits="AddClubs" %>
<%@ Register src="Webusercontrol.ascx" tagname="webclub" tagprefix="uc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Pankaj Talwar #300986202-->
    <div class="under-const"> 
            <form runat="server">
                <asp:Label ID="response" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Panel ID="Mustlogin" runat="server" CssClass="matchdiv">
                       <asp:Button ID="redirectbtn" runat="server" Text="You Must Login To Add Clubs" OnClick="redi_club" CssClass="btnstyle"/>
             
                </asp:Panel>
      
             
                <asp:ValidationSummary ID="ValidatiSummary1" runat="server" CssClass="error_msg" ShowMessageBox="True"  HeaderText="Mandatory Fields*" ForeColor="Red" Font-Size="Medium" BackColor="#FFDFDF" />
                <asp:Panel ID="AddClub" runat="server" Visible="false">
        <table class="clubdetails">
             <tr>
               <th colspan="2">
                   Enter Clubs Details
               </th>
                 </tr>
                    
             <uc:webclub  runat="server" id="usercontrolfields"/>
          
            <tr>
                <td>
                     <asp:Label ID="Label3" runat="server" Text="Registration" CssClass="inputlabel"></asp:Label>
                </td>
                <td>
                                <asp:TextBox ID="txtregister" runat="server" CssClass="inputtext"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtregister" ErrorMessage=" Registration Number is required*" SetFocusOnError="True"  ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>            <asp:Label ID="Label4" runat="server" Text="Address" CssClass="inputlabel"></asp:Label>
</td>
                <td>            <asp:TextBox ID="txtadd" runat="server" CssClass="inputtext"></asp:TextBox>
</td>
            </tr>
            <tr>
                    <td colspan="2" >       
                        <asp:Button ID="submitclub" runat="server" Text="Save Club" OnClick="save_club_Click" CssClass="btnstyle"/>
                        <asp:Button ID="addplayer" runat="server" Text="Add Player" OnClick="btn_addplayer_Click" Visible="False" CssClass="btnstyle" />
                        <asp:Button ID="cancelclub" runat="server" Text="Cancel" OnClick="btn_cancelclub_Click"   CssClass="btnstylecan" />

                        </td>
            </tr>
        </table>
                    </asp:Panel>
        <!--Pankaj Talwar #300986202-->
           
            
        <asp:Panel ID="Panel1" runat="server" CssClass="player">
             <table class="playerdetails">
             <tr>
               <th colspan="2" >
                   Select Club
                   <asp:DropDownList ID="Clubslist" runat="server" >
                   </asp:DropDownList>
               </th>
                 </tr>
               <tr>
                <td>
                     <asp:Label ID="Label1" runat="server" Text="Playername" CssClass="inputlabel"></asp:Label>
                </td>
                <td>
                                <asp:TextBox ID="player_name" runat="server" CssClass="inputtext"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>            <asp:Label ID="Label2" runat="server" Text="Date Of birth" CssClass="inputlabel"></asp:Label>
</td>
                <td>            <asp:TextBox ID="playerdob" runat="server" CssClass="inputtext"></asp:TextBox>
</td>
            </tr>
                 <tr>
                <td>            <asp:Label ID="label5" runat="server" Text="Jercy Number" CssClass="inputlabel"></asp:Label>
</td>
                <td>            <asp:TextBox ID="Jercy_Number" runat="server" CssClass="inputtext"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" Text="(must be from 0 to 99" ControlToValidate="Jercy_Number" MaximumValue="99" MinimumValue="0"></asp:RangeValidator>
</td>
            </tr>
            <tr>
                    <td >       
                        <asp:Button ID="button_addplayer" runat="server" Text="Add Player" OnClick="add_player_btn_Click" CssClass="btnstyle"/>

                    </td>
                <td>
                       <asp:Button ID="cancelplayer" runat="server" Text="Cancel" OnReset="btn_cancelplayer"  CssClass="btnstylecan" PostBackUrl="~/AddClubs.aspx" />

                </td>
            </tr>
        </table>
        
        </asp:Panel>
               
       </form>
    </div>
  <!--Pankaj Talwar #300986202-->
</asp:Content>