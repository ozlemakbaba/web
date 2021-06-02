using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Preferences_Default : System.Web.UI.Page
{
    public LinkedList<Categorie> list;
    public PersonneCatDao percatdao;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["logged"].Equals("true"))
                Response.Redirect("../../");
        }
        catch
        {
            Response.Redirect("../../");
        }
        PersonneDao personnedao = new PersonneDao();
        Personne personne = personnedao.Select(Session["username"].ToString());
        CategorieDao catdao = new CategorieDao();
        list = catdao.Select();
        percatdao = new PersonneCatDao();
        if (Request.QueryString["tech"] != null)
            percatdao.Insert(personne.CIN, Request.QueryString["tech"]);
    }
    protected void End(object sender, EventArgs e)
    {
        CompteDao comptedao = new CompteDao();
        Compte compte = comptedao.Select(Session["username"].ToString());
        compte.Visit = 1;
        comptedao.Update(compte);
        Response.Redirect("../");
    }
}