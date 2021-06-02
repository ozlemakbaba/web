using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Offres : System.Web.UI.Page
{
    public List<Offre> list;
    public Crawler cr = new Crawler();
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

        PersonneCatDao p_c_dao = new PersonneCatDao();
        LinkedList<Categorie> listC = p_c_dao.Select(Session["cin"].ToString());
        list = new List<Offre>();
        foreach (Categorie c in listC)
            list.AddRange(cr.lancerCrawler(c.Nom));
    }
}