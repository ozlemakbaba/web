using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Accueil_Registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=PHOENIX-PC\SQLEXPRESS;Initial Catalog=UsersImgs;Integrated Security=True;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void add(object sender, EventArgs e)
    {
        if (!pass.Text.Equals(passRep.Text))
            label.Text = "Les mots de passes ne sont pas identiques.";
        else {
            Compte compte = new Compte(email.Text, pass.Text, 0);
            LinkedList<Categorie> list = new LinkedList<Categorie>();
            Personne personne = new Personne(cin.Text, nom.Text, prenom.Text, birth.Text, email.Text, phone.Text, compte, list, "img");
            CompteDao comptedao = new CompteDao();
            PersonneDao personnedao = new PersonneDao();
            comptedao.Insert(compte);
            personnedao.Insert(personne);
            if (upload.HasFile)
            {
                String str = upload.FileName;
                upload.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str);
                String path = "~//Accueil//uploads//" + str.ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Image values('" + email.Text + "','" + path + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                label.Text = "Veuillez choisir votre image.";
            }
            Response.Redirect("Authentification.aspx");
        }
    }
}