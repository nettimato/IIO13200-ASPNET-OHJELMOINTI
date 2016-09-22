<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tapa3.aspx.cs" Inherits="Tapa3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tapa 3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Tapa 3: käytetään Session</h1>
        <p>Sessionista luettu viesti: <%=Session["viesti"]%></p>
    </div>
    </form>
</body>
</html>
