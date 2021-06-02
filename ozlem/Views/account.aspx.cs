using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_account : System.Web.UI.Page
{
    public Personne personne;
    public Compte compte;
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
        String username = Session["username"].ToString();
        PersonneDao personnedao = new PersonneDao();
        personne = personnedao.Select(username);
        CompteDao comptedao = new CompteDao();
        compte = comptedao.Select(personne.Email);
    }
    protected void update(object sender, EventArgs e)
    {
        CompteDao comptedao = new CompteDao();
        if (ancmdp.Text.Equals(compte.Password) && nvmdp.Text.Equals(nvmdp2.Text))
        {
            compte.Password = nvmdp.Text;
            comptedao.Update(compte);
            Response.Redirect("Edit_profile.aspx");
        }
        else
        {
            if (!ancmdp.Text.Equals(compte.Password))
                err.Text = "L'ancien mot de passe est incorrect.";
            else
                err.Text = "Les mots de passes ne sont pas identiques.";
        }
    }
}