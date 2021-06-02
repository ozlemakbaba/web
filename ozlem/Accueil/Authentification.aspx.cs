using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Timers;

public partial class Accueil_Authentification : System.Web.UI.Page
{
    /*Crawler cr = new Crawler();
    OffreDao offredao = new OffreDao();
    CategorieDao catdao = new CategorieDao();
    public String str;
    public void Create()
    {
        LinkedList<Categorie> listCat = catdao.Select();
        LinkedList<Offre> listOffre = new LinkedList<Offre>();
        foreach (Categorie c in listCat)
        {
            listOffre = cr.lancerCrawler(c.Nom);
            foreach (Offre o in listOffre)
            {
                label__.Text = "no no no";
                offredao.Create(o);
                label__.Text = "ouiiiiiii xD";
            }
            listOffre = new LinkedList<Offre>();
        }
    }
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        int lastHour = DateTime.Now.Hour;
        if (lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0))
        {
            lastHour = DateTime.Now.Hour;
            Create();
        }

    }*/
    protected void Page_Load(object sender, EventArgs e)
    {
        /*System.Timers.Timer aTimer = new System.Timers.Timer(1000); //One second, (use less to add precision, use more to consume less processor time
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        */
        //label__.Text = "no";
        //Create();
    }
    protected void login(object sender, EventArgs e)
    {
        CompteDao comptedao = new CompteDao();
        Compte compte = comptedao.Select(username.Text, password.Text);
        if (compte != null)
        {
            FormsAuthentication.RedirectFromLoginPage(username.Text, false);
            Session["logged"] = "true";
            Session["username"] = compte.Username;
            PersonneDao persdao = new PersonneDao();
            Personne personne = persdao.Select(username.Text);
            Session["cin"] = personne.CIN;
            if(compte.Visit == 0)
                Response.Redirect("../Views/Preferences");
            else
                Response.Redirect("../Views/");
        }
        else
        {
            label.Text = "error";
        }
            
    }
}