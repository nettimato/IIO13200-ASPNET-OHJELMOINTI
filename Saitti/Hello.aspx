<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hello.aspx.cs" Inherits="Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtNimi" runat="server"></asp:TextBox>
        <asp:Button ID="btnTervehdi" runat="server" Text="say Hello" OnClick="btnTervehdi_Click" />
        <asp:Label ID="lblTulos" runat="server" />
    </div>
    </form>
</body>
</html>
