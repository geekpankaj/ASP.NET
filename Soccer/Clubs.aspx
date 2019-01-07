<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Clubs.aspx.cs" Inherits="Clubs" %>
<%@ Register src="Webusercontrol.ascx" tagname="webclubdisp" tagprefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <!--Pankaj Talwar #300986202-->
    <form id="form1" runat="server">
    <div class="under_const"> 
        <asp:Label ID="Clubnull" runat="server" ></asp:Label>
       <asp:Button ID="redirectbtn" runat="server" Text="Click Here to add Club" OnClick="redi_club" CssClass="btnstyle"/>

            <asp:GridView ID="Clubs_display" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="Clubs_display_SelectedIndexChanged"  datakeynames="Club_id" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField DataTextField="Club_Name" HeaderText="Club Name" CommandName="Select" Text="Club_Name"/>
            <asp:BoundField DataField="Club_City" HeaderText="Club City" />
          
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>


        <asp:DataList ID="repeater" runat="server">
           <EditItemStyle />
                <ItemTemplate>
                    <tr>
                       
                    <uc:webclubdisp  runat="server" id="usercontroldisplay"  ClubCity='<%# Eval("Club_City") %>' ClubName='<%# Eval("Club_Name") %>' />
                     
                    <asp:LinkButton ID="LinkButton1" runat="server">More Details</asp:LinkButton>  

                      </tr>
                     
                </ItemTemplate>
                <SeparatorTemplate><hr /><nr /></SeparatorTemplate>
               
          </asp:DataList>


        <br />
         <br /> 
     </div>
            <!--Pankaj Talwar #300986202-->
    </form>
    </asp:Content>

