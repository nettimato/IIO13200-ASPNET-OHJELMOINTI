<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tyontekijat.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Työntekijät</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnHae" runat="server" Text="Hae työntekijät" OnClick="btnHae_Click" />
        <div id="esitys">
            <h2>Työntekijät</h2>
            <asp:GridView ID="gvData" runat="server"></asp:GridView>
        </div>
        <div id="footer">
            <asp:Label ID="lblMessages" runat="server" Text="Odotetaan sisältöä"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
