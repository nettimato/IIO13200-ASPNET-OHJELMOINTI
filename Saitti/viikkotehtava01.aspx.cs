using System;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viikkotehtava01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLaske_Click(object sender, EventArgs e)
    {
        // lasketaan ikkunan tarjoushinta
        try
        {
            // käyttäjän syötteet on aina syytä tarkistaa
            if (txtKorkeus.Text.Length * txtLeveys.Text.Length * txtKarminLeveys.Text.Length > 0)
            {
                double leveys = Convert.ToDouble(txtLeveys.Text)/1000;
                double korkeus = Convert.ToDouble(txtKorkeus.Text)/1000;
                double karmi = Convert.ToDouble(txtKarminLeveys.Text)/1000;
                double pintaAla = (korkeus - 2 * karmi) * (leveys - 2 * karmi); // m2
                double piiri = 2 * (korkeus + leveys); //jm
                double aluhinta = Convert.ToDouble(ConfigurationManager.AppSettings["alumiininhinta"]); // m2
                double lasihinta = Convert.ToDouble(ConfigurationManager.AppSettings["lasinhinta"]); // jm
                double tyomenekki = 150; // per ikkuna
                double kate = 0.3; // 30% kate
                // hinnan laskenta
                double hinta = (1+kate)*((pintaAla*lasihinta) + (piiri*aluhinta) + tyomenekki);
                // näytetään tulokset
                lblPintaAla.Text = pintaAla.ToString();
                lblPiiri.Text = piiri.ToString();
                lblHinta.Text = hinta.ToString("C2", CultureInfo.CreateSpecificCulture("fi-Fi"));
            }
            else
            {
                lblMessages.Text = "Puutteellisesti täytetty syöte!";
            }
        }
        catch (Exception ex)
        {
            lblMessages.Text = ex.Message;
        }
    }
}