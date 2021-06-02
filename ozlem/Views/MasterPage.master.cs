using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Views_MasterPage : System.Web.UI.MasterPage
{
    public String path;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Session["logged"].Equals("true"))
            //Response.Redirect("../Accueil/Authentification.aspx");
        SqlConnection con = new SqlConnection(@"Data Source=PHOENIX-PC\SQLEXPRESS;Initial Catalog=UsersImgs;Integrated Security=True;Pooling=False");
        con.Open();
        SqlCommand cmd = new SqlCommand("Select image from Image where username = '" + Session["username"].ToString() + "'", con);
        SqlDataReader dataReader = cmd.ExecuteReader();
        dataReader.Read();
        path = dataReader["image"].ToString();
        con.Close();
    }
}
