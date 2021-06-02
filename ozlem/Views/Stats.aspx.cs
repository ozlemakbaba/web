using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Stats : System.Web.UI.Page
{
    public bool b;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void evaluer(object sender, EventArgs e)
    {
        try
        {
            b = true;
            double tarif_ = Convert.ToDouble(tarif.Text);
            double duree_ = Convert.ToDouble(duree.Text);
            double exp = Convert.ToDouble(experience.Text);
            String temps = rbtLstRating.Text;
            String classe = this.treeDecision(tarif_, duree_, exp, temps);
            res.Text = "<br /><br /><br /><br /><div>Le meilleur choix correspondant aux informations <br/>que vous avez entré est <span>" + classe + "</span></div>";
        }
        catch(Exception ex)
        {
            b = false;
            erreur.Text = ex.Message;
        }
    }
    private String treeDecision(double tarif, double duree, double exp, String temps)
    {
        String classe ="";
        if (tarif < 13750)
        {
            if (duree < 2.5)
            {
                if (tarif < 11100)
                {
                    if (tarif < 6750)
                    {
                        classe = "Big Data";
                    }
                    else
                    {
                        if (exp < 1.5)
                        {
                            classe = "Administrateur BD";
                        }
                        else
                        {
                            classe = "PHP";
                        }
                    }
                }
                else
                {
                    classe = "Business Intelligence";
                }
            }
            else
            {
                if (exp < 2.5)
                {
                    if (tarif < 12250)
                    {
                        if (duree < 4.5)
                        {
                            if (tarif < 9500)
                            {
                                classe = "Administrateur BD";
                            }
                            else
                            {
                                if (tarif < 10250)
                                {
                                    classe = "JEE";
                                }
                                else
                                {
                                    classe = "Plateformes de JS";
                                }
                            }
                        }
                        else
                        {
                            if (duree < 27)
                            {
                                if (tarif < 10250)
                                {
                                    classe = "Sql Server";
                                }
                                else
                                {
                                    if (duree < 9)
                                    {
                                        classe = "PHP";
                                    }
                                    else
                                    {
                                        if (tarif < 11400)
                                        {
                                            classe = "PHP";
                                        }
                                        else
                                        {
                                            classe = "Sql Server";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                classe = "Big Data";
                            }
                        }
                    }
                    else
                    {
                        if (duree < 7.5)
                        {
                            classe = "Administrateur BD";
                        }
                        else
                        {
                            if (duree < 10.5)
                            {
                                classe = "Big Data";
                            }
                            else
                            {
                                classe = "Administrateur BD";
                            }
                        }
                    }
                }
                else
                {
                    if (tarif < 12800)
                    {
                        if (duree < 4.5)
                        {
                            classe = "PHP";
                        }
                        else
                        {
                            if (tarif < 10900)
                            {
                                classe = "PHP";
                            }
                            else
                            {
                                if (duree < 22.5)
                                {
                                    if (duree < 13.5)
                                    {
                                        classe = "JEE";
                                    }
                                    else
                                    {
                                        classe = "Business Intelligence";
                                    }
                                }
                                else
                                {
                                    classe = "JEE";
                                }
                            }
                        }
                    }
                    else
                    {
                        classe = "Sql Server";
                    }
                }
            }
        }
        else
        {
            if (exp < 2.5)
            {
                if (duree < 18)
                {
                    if (duree < 3.5)
                    {
                        classe = "Business Intelligence";
                    }
                    else
                    {
                        if (duree < 9)
                        {
                            classe = "SAP";
                        }
                        else
                        {
                            classe = ".NET";
                        }
                    }
                }
                else
                {
                    if (duree < 30)
                    {
                        classe = "Big Data";
                    }
                    else
                    {
                        if (exp < 1)
                        {
                            classe = "JEE";
                        }
                        else
                        {
                            classe = "Administrateur BD";
                        }
                    }
                }
            }
            else
            {
                if (exp < 7)
                {
                    if (tarif < 14700)
                    {
                        if (duree < 87)
                        {
                            if(temps.Equals("plein"))
                                classe = ".NET";
                            else
                                classe = "Platformes JS";
                        }
                        else
                        {
                            classe = "Platformes JS";
                        }
                    }
                    else
                    {
                        if(tarif < 17250)
                        {
                            if(duree < 2)
                            {
                                classe = "PHP";
                            }
                            else
                            {
                                classe = "SAP";
                            }
                        }
                        else
                        {
                            classe = ".NET";
                        }
                    }
                }
                else
                {
                    if(duree <4.5)
                    {
                        classe = "Platformes JS";
                    }
                    else
                    {
                        classe = "Sql Server";
                    }
                }
            }
        }
        return classe;
    }
}