<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CalculateTax.aspx.cs" Inherits="CalculateTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <label>Status</label>
        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" Style="width=100px;"></asp:DropDownList>
        <label>Status</label>
        <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
         <label>Status</label>
        <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
         <fieldset>
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Submit" />
  </fieldset>
</form>
</asp:Content>

