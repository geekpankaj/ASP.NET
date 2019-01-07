
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClubDetails.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form runat="server">
               <asp:Label ID="response" runat="server" ></asp:Label>
      
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="397px" CssClass="matchdiv">
        <asp:DetailsView ID="ClubDetails" runat="server" Height="80px" Width="365px" CellPadding="4" ForeColor="#333333" GridLines="None"  >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView> 
        <br />
        <asp:GridView ID="PlayersDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PlayersDetails_SelectedIndexChanged"  DataKeyNames="Player_Id" Width="368px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                 <asp:ButtonField DataTextField="Player_Name" HeaderText="Player Name" CommandName="Select" Text="Player_Name"/>
               
                <asp:BoundField DataField="DOB" HeaderText="Date Of Birth"  DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="Jercy_No" HeaderText="Jercy Number" />
                
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <br />
        <asp:Button ID="deleteclub" runat="server" Text="Delete the Club" OnClick="deleteclub_Click"   CssClass="btnstylecan" Visible="false" />
       </asp:Panel>
    
        <asp:Panel ID="Panel2" runat="server" CssClass="matchdiv" Width="254px" >

             <asp:DetailsView ID="PlayersDetails1" runat="server" Height="50px" Width="251px" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnModeChanging="PlayersDetails1_ModeChanging" DefaultMode="Edit" OnItemUpdating="PlayersDetails1_ItemUpdating">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <EditRowStyle BackColor="#999999" />
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <Fields>
                            <asp:BoundField DataField="Player_Name" HeaderText="Player Name" />
                            <asp:BoundField DataField="DOB" HeaderText="Date Of Birth" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Jercy_No" HeaderText="Jercy Number" />
                            <asp:CommandField ShowEditButton="True" />
                        </Fields>

                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

                    </asp:DetailsView>
                
         
                   
               
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server"  CssClass="matchdiv">
              <asp:Login ID="Loginuser" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
                  <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                  <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
                  <TextBoxStyle Font-Size="0.8em" />
                  <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
              </asp:Login>
       
              <asp:Button ID="Register_form" runat="server" Text="Register" OnClick="Register_Form_Click" />
       
        </asp:Panel>
       <asp:Panel ID="Panel4" runat="server"  CssClass="matchdiv">
           <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
               <ContinueButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
               <CreateUserButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
               <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <WizardSteps>
                   <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                   </asp:CreateUserWizardStep>
                   <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                   </asp:CompleteWizardStep>
               </WizardSteps>
               <HeaderStyle BackColor="#666666" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
               <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
               <SideBarButtonStyle ForeColor="White" />
               <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
               <StepStyle BorderWidth="0px" />
           </asp:CreateUserWizard>
        </asp:Panel>
      
       
        
        </form>
      <!--Pankaj Talwar #300986202-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

