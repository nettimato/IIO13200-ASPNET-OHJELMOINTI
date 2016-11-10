using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bookshop : System.Web.UI.Page
{
    bool KustiValittu = false; // voi olla väärässä paikassa
    protected static BookShopEntities ctx;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // luodaan konteksti
            ctx = new BookShopEntities();
        }
    }
    #region METHODS
    protected void GetBooks()
    {
        gvBooks.DataSource = ctx.Books.ToList();
        gvBooks.DataBind();
    }
    protected void GetCustomers()
    {
        gvCustomers.DataSource = ctx.Customers.ToList();
        gvCustomers.DataBind();
    }
    protected void FillControls()
    {
        // ui-kontrollien alustaminen
        var result = from c in ctx.Customers
                     orderby c.lastname
                     select new { c.id, c.lastname };
        // määritellään dropdownlistille mitä se esittää
        ddlCustomers.SelectedIndex = -1;
        ddlCustomers.DataSource = result.ToList();
        ddlCustomers.DataTextField = "lastname";
        ddlCustomers.DataValueField = "id";
        ddlCustomers.DataBind();
        ddlCustomers.Items.Insert(0, string.Empty); // tyhjä rivi
        //11.10
        txtFirstname.Text = string.Empty;
        txtLastname.Text = string.Empty;
    }
    protected void SetButtons()
    {
        btnCreateCustomer.Enabled = !KustiValittu;
        btnSaveCustomer.Enabled = KustiValittu;
        btnDeleteCustomer.Enabled = KustiValittu;
    }
    #endregion
    protected void btnGetBooks_Click(object sender, EventArgs e)
    {
        GetBooks();
    }
    protected void btnGetCustomers_Click(object sender, EventArgs e)
    {
        GetCustomers();
    }

    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCustomers.SelectedIndex > 0)
        {
            // tyhjennetään tilaukset ddlOrders-listasta
            ddlOrders.Items.Clear();

            int cid = -1;
            cid = Int32.Parse(ddlCustomers.SelectedValue);
            // haetaan valittu asiakas
            var ret = from c in ctx.Customers where c.id == cid select c;
            var asiakas = ret.FirstOrDefault();
            if (asiakas != null)
            {
                KustiValittu = true;
                lblMessages.Text = string.Format("Valitsit asiakkaan {0}", asiakas.lastname);
                // tutkitaan onko valitulla asiakkaalla tilauksia ja jos on, näytetään ne
                if (asiakas.Orders.Count > 0)
                {
                    lblMessages.Text += string.Format(", tilauksia {0}", asiakas.Orders.Count);
                    var ret2 = (from o in asiakas.Orders select new { o.odate }).ToList();
                    ddlOrders.DataSource = ret2;
                    ddlOrders.DataTextField = "odate";
                    ddlOrders.DataBind();
                    // haetaan tilausten tilausrivit ja näytetään päivämäärät
                    foreach (var item in asiakas.orders)
                    {
                        lblMessages.Text += string.Format("<br>Tilaus: {0}", item.odate.ToShortDateString());
                        // loopitetaan tilauksen tilausrivi
                        foreach (var or in item.OrderItems)
                        {
                            lblMessages.Text += string.Format("<br>tilattu kirja {0}", or.Book.name);
                        }
                    }
                }
                else
                {
                    lblMessages.Text += ", ei ole tilauksia.";
                }
            }
        }
        else
        {
            lblMessages.Text = string.Empty;
            KustiValittu = false;
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            SetButtons();
        }
    }

    protected void btnCreateCustomer_Click(object sender, EventArgs e)
    {
        // tarkistetaan onko ko. asiakasta jo olemassa LINQ:n lambda-funktiolla
        bool isThere = ctx.Customers.Any(c => (c.firstname.Contains(txtFirstname.Text) & c.lastname.Contains(txtLastname.Text)));
        if (isThere)
        {
            lblMessages.Text = string.Format("Asiakas {0} {1} on jo olemassa", txtFirstname, txtLastname);
        }
        else
        {
            // luodaan uusi asiakasentiteetti
            Customer kusti = new Customer();
            kusti.firstname = txtFirstname.Text;
            kusti.Lastname = txtLastname.Text;
            ctx.Customers.Add(kusti);
            // save changes to database
            ctx.SaveChanges();
            lblMessages.Text = string.Format("Uusi asiakas {0} {1} {2} luotu unnistuneesti", kusti.id, kusti.firstname, kusti.lastname);
            // päivitetään kontrollit
            FillControls();
        }
    }

    protected void btnSaveCustomer_Click(object sender, EventArgs e)
    {
        // haetaan valitun asiakkaan ID
        int i = int.Parse(ddlCustomers.SelectedValue);
        if (i > 0)
        {
            var ret = ctx.Customers.Where(c => c.id == i);
            Customer kusti = ret.FirstOrDefault();
            if (kusti != null)
            {
                if (kusti.firstname != txtFirstname.Text) kusti.firstname = txtFirstname.Text;
                if (kusti.lastname != txtLastname.Text) kusti.lastname = txtLastname.Text;
                ctx.SaveChanges();
                FillControls();
            }
        }
    }

    protected void btnDeleteCustomer_Click(object sender, EventArgs e)
    {
        // poistetaan valittu asiakas
        if (KustiValittu)
        {
            // poistetaan kontekstista ja databasesta
            // huomioi myös businesslogiikka eli onko oikeasti järkevää poistaa asiakas
            // tässä casessa saa poistaa vain sellaisia asiakkaita joilla EI OLE tilauksia
            // haetaan valitun asiakkaan ID
            int i = int.Parse(ddlCustomers.SelectedValue);
            if (i > 0)
            {
                var ret = ctx.Customers.Where(c => c.id == i);
                Customer kusti = ret.FirstOrDefault();
                if (kusti != null)
                {
                    // tutkitaan onko kustilla tilauksia, ei poisteta jos on
                    if (kusti.Orders.Count == 0)
                    {
                        ctx.Customers.Remove(kusti);
                        ctx.SaveChanges();
                        // ui:n päivitys
                        KustiValittu = false;
                        FillControls();
                        lblMessages.Text = string.Format("Asiakas {0} {1} poistettu!", kusti.firstname, kusti.lastname);
                    }
                    else
                    {
                        lblMessages.Text = string.Format("Asiakasta {0} {1} ei voi poistaa, koska heillä on {2} tilausta", kusti.firstname, kusti.lastname, kusti.Orders.Count());
                    }
                }
            }
        }
    }
}