<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <!--Pankaj Talwar #300986202-->
    <form runat="server">
        <div class="setupdisp">
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Dark Theme" Value="Dark" GroupName="Themeselect" /><img src="/images/screen2.PNG" class="logo1"><br />
        <asp:RadioButton ID="RadioButton2" runat="server"  Text="Light Theme" Value="Light" GroupName="Themeselect" /><img src="/images/screen1.PNG" class="logo1"><br /><br>
        <asp:Button ID="Button1" runat="server" Text="Apply Theme" OnClick="apply_theme" CssClass="btnstyle"/><br><br>
            </div>
    </form>
    <!--Pankaj Talwar #300986202-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--Pankaj Talwar #300986202-->
</asp:Content>

