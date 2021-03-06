﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAP.master" AutoEventWireup="true" CodeFile="Bookshop.aspx.cs" Inherits="Bookshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGetBooks" runat="server" Text="Hae Kirjat" OnClick="btnGetBooks_Click" />
        <asp:Button ID="btnGetCustomers" runat="server" Text="Hae Asiakkaat" OnClick="btnGetCustomers_Click" />
        <h1 style="w3-blue">Kirjakaupan X kirjat</h1>
        <asp:GridView ID="gvBooks" runat="server"></asp:GridView>
        <h1 style="w3-blue">Kirjakaupan X asiakkaat</h1>
        <asp:GridView ID="gvCustomers" runat="server" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged"></asp:GridView>
        <asp:DropDownList ID="ddlCustomers" runat="server"></asp:DropDownList>
        <p>
            etunimi: <asp:TextBox ID="txtFirstname" runat="server" Text="..." />
        </p>
        <p>
            sukunimi: <asp:TextBox ID="txtLastname" runat="server" Text="..." />
        </p>
        <asp:Button ID="btnCreateCustomer" runat="server" Text="Luo uusi" CssClass="w3-black" OnClick="btnCreateCustomer_Click" />
        <asp:Button ID="btnSaveCustomer" runat="server" Text="Tallenna" CssClass="w3-black" OnClick="btnSaveCustomer_Click" />
        <asp:Button ID="btnDeleteCustomer" runat="server" Text="Poista" CssClass="w3-black" OnClick="btnDeleteCustomer_Click" />
        <h3>asiakaan tilaukset</h3>
        <asp:DropDownList ID="ddlOrders" runat="server" OnSelectedIndexChanged="ddlOrders_SelectedIndexChanged"></asp:DropDownList>
        <!-- ilmoitukset käyttäjälle -->
        <h2><asp:Label ID="lblMessages" runat="server"></asp:Label></h2>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server"></asp:Content>
