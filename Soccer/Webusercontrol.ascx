<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Webusercontrol.ascx.cs" Inherits="Webusercontrol" %>

<tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Club Name" CssClass="inputlabel"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txt_name" runat="server" CssClass="inputtext"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name of the club required*" ControlToValidate="txt_name" Visible="True" Font-Bold="True" Font-Italic="True" ValidateRequestMode="Disabled"></asp:RequiredFieldValidator>

    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Club City" CssClass="inputlabel"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txt_city" runat="server" CssClass="inputtext"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name of the city required*" ControlToValidate="txt_city" ValidateRequestMode="Disabled"></asp:RequiredFieldValidator>
    </td>
</tr>

