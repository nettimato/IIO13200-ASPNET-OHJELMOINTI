using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class source : System.Web.UI.Page
{
    public string Messu
    {
        get { return txtMessage.Text; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // täällä yleensä tehdään kaikki sivun alustukseen liittyvät asiat
        // yleensä vain yhden kerran!
        if (!IsPostBack)
        {
            ddlMessages.Items.Add("Ping!");
            ddlMessages.Items.Add("Kiitos kaunis!");
            ddlMessages.Items.Add("Goodbye.");
            ddlMessages.Items.Add("Ripperoni!");
        }
    }

    protected void btnQueryString_Click(object sender, EventArgs e)
    {
        // ohjataan pyyntö uudelle sivulle ja välitetään teksti mukana
        Response.Redirect("Tapa1.aspx?Data=" + txtMessage.Text);
    }

    protected void btnSession_Click(object sender, EventArgs e)
    {
        // kirjoitetaan sessioniin
        Session["viesti"] = txtMessage.Text;
        Response.Redirect("Tapa3.aspx");
    }

    protected void btnCookie_Click(object sender, EventArgs e)
    {
        // luodaan eväste ja kirjoitetaan siihen
        HttpCookie keksi = new HttpCookie("viesti", txtMessage.Text);
        keksi.Expires = DateTime.Now.AddMinutes(5);
        Response.Cookies.Add(keksi);
    }

    protected void btnProperty_Click(object sender, EventArgs e)
    {
        // Response.Redirect("Tapa5.aspx"); // ei kelpaa tässä tapauksessa koska PreviousPage ei synny
        Server.Transfer("Tapa5.aspx");
    }

    protected void ddlMessages_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMessage.Text = ddlMessages.SelectedItem.ToString();
    }
}