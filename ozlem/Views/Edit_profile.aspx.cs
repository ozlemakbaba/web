using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Views_Edit_profile : System.Web.UI.Page
{
    public String par;
    public Personne personne;
    public String path;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=PHOENIX-PC\SQLEXPRESS;Initial Catalog=UsersImgs;Integrated Security=True;Pooling=False");
        con.Open();
        SqlCommand cmd = new SqlCommand("Select image from Image where username = '" + Session["username"].ToString() + "'", con);
        SqlDataReader dataReader = cmd.ExecuteReader();
        dataReader.Read();
        path = dataReader["image"].ToString();
        con.Close();
        try
        {
            if (!Session["logged"].Equals("true"))
                Response.Redirect("../");
        }
        catch
        {
            Response.Redirect("../");
        }
        par = Request.QueryString["b"];
        String username = Session["username"].ToString();
        PersonneDao personnedao = new PersonneDao();
        personne = personnedao.Select(username);
    }
    protected void update(object sender, EventArgs e)
    {
        PersonneDao personnedao = new PersonneDao();
        Personne personne = personnedao.Select(emailT.Text);
        personne.Nom = nomT.Text;
        personne.Prenom = prenomT.Text;
        personne.Email = emailT.Text;
        personne.Telephone = telT.Text;
        personne.Date_naissance = date_naissT.Text;
        personnedao.Update(personne);
        Response.Redirect("Edit_profile.aspx");
    }
}