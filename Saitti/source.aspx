<%@ Page Language="C#" AutoEventWireup="true" CodeFile="source.aspx.cs" Inherits="source" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tiedon välitys demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Source-sivu</h1>
        <p>lähetettävä viesti: <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox></p>
        <!-- tähän valmis lista josta voi valita sopivan lauseen -->
        <asp:DropDownList ID="ddlMessages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMessages_SelectedIndexChanged" ></asp:DropDownList>
        <br />
        <!-- tapa 1: querystring -->
        <asp:Button ID="btnQueryString" runat="server" Text="Käytä QueryString:iä" onClick="btnQueryString_Click" />
        <!-- tapa 2: HTTP Post -->
        <asp:Button ID="btnHttpPost" runat="server" Text="Käytä HTTP Post:ia"  PostBackUrl="~/Tapa2.aspx" />
        <!-- tapa 3: Session -->
        <asp:Button ID="btnSession" runat="server" Text="Käytä Session" onClick="btnSession_Click" />
        <!-- tapa 4: eväste -->
        <asp:Button ID="btnCookie" runat="server" Text="Käytä evästettä" onClick="btnCookie_Click" />
        <!-- tapa 5: public property -->
        <asp:Button ID="btnProperty" runat="server" Text="Käytä ominaisuutta (public property)" onClick="btnProperty_Click" />
    </div>
    </form>
</body>
</html>
