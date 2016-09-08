using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hello : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // laukeaa aina sivunavauksen yhteydessä
    }

    protected void btnTervehdi_Click(object sender, EventArgs e)
    {
        // luetaan käyttäjän antama syöte
        string putin = "Terve: " + txtNimi.Text;
        // esitetään tulos
        lblTulos.Text = putin;
    }
}