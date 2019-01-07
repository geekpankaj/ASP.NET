<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateProduct.aspx.cs" Inherits="UpdateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="form-group">
      <label>Product Name</label>
         <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
      </div>

   
    <fieldset>
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Update"/>
  </fieldset>
        <fieldset>
        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Cancel" />
  </fieldset>
      
        </form>
</asp:Content>

