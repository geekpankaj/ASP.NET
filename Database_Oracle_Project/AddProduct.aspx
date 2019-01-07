<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <form runat="server" >
 <fieldset>
    
    <div class="form-group row">
      <label class="col-sm-2 col-form-label">Product Details</label>
      <div class="col-sm-10">
        <input type="text" class="form-control-plaintext">
      </div>
    </div>
    <div class="form-group">
      <label>Product Name</label>
        <asp:TextBox class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
      
    </div>
      <div class="form-group">
      <label>Discription</label>
          <asp:TextBox class="form-control" ID="TextBox4" runat="server"></asp:TextBox>
      
    </div>
      <div class="form-group">
      <label>Image FieldName</label>
      
          <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
    </div>
      <div class="form-group">
      <label>Price</label>
          <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
      
    </div>
     <div class="form-group">
      <label>Status</label>
         <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
      
    </div>

   
    <fieldset>
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Submit"/>
  </fieldset>
</form>
        </div>
</asp:Content>

