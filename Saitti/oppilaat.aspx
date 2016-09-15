<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oppilaat.aspx.cs" Inherits="oppilaat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Oppilaat:</h2>
        <div>
            <asp:Button ID="btnGet3" runat="server" Text="Hae 3 testioppilasta" OnClick="btnGet3_Click" />
            <asp:Button ID="btnGetAll" runat="server" Text="Hae oppilaat tietokannasta" OnClick="btnGetAll_Click" />
        </div>
        <div id="tulos">
            <asp:GridView ID="gvStudents" runat="server"/>
        </div>
        <div id="footer">
            <asp:Label ID="lblMessages" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
