using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Default : System.Web.UI.Page
{
    public String name;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["logged"].Equals("true"))
                Response.Redirect("../");
        }
        catch
        {
            Response.Redirect("../");
        }
        PersonneDao perdao = new PersonneDao();
        Personne p = perdao.Select(Session["username"].ToString());
        name = p.Nom + " " + p.Prenom;
    }
}