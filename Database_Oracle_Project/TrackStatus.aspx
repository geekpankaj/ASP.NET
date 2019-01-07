<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrackStatus.aspx.cs" Inherits="TrackStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="form-group">
      <label>Product Name</label>
         <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
      </div>
           <fieldset>
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Track" />
  </fieldset>
<label>Date</label>
         <asp:TextBox class="form-control" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
       </div>

   <label>Status</label>
         <asp:TextBox class="form-control" ID="TextBox3" runat="server" ReadOnly="true" ></asp:TextBox>
      </div>
   
 
</form>
</asp:Content>

