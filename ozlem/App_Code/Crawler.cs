using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Crawler
/// </summary>
public class Crawler
{
    private WebClient webClient;
    private string contenu;
    private Regex regex;
    private MatchCollection matchColl;
    private LinkedList<BD_lien> bd;

    public Crawler()
    {
        bd = new LinkedList<BD_lien>();
    }

    public LinkedList<Offre> lancerCrawler(String tec)
    {
        BD_lien lien = new BD_lien();
        lien.Lien = "http://www.freelance-info.fr/missions.php?mots=tec&p=_page_";
        lien.Nom = "Freelance-info";
        bd.AddLast(lien);
        
        //lien = new BD_lien();
        //lien.Lien = "https://www.upwork.com/o/jobs/browse/?q=" + tec;
        //lien.Nom = "Upwork";
        //bd.AddLast(lien);

        lien = new BD_lien();
        lien.Lien = "http://www.guru.com/d/freelancers/q/tec/pg/_page_";
        lien.Nom = "Guru";
        bd.AddLast(lien);
        
        lien = new BD_lien();
        lien.Lien = "https://www.codeur.com/projects/page/_page_?q=tec";
        lien.Nom = "Codeur";
        bd.AddLast(lien);
        

        LinkedList<Offre> list = new LinkedList<Offre>();
        foreach (BD_lien l in bd)
        {
            l.Lien = l.Lien.Replace("tec", tec);
            for (int page = 1; page <= 5; page++)
            {
                l.Lien = l.Lien.Replace("_page_", page+"");
                this.webClient = new WebClient();
                this.contenu = webClient.DownloadString(l.Lien);
                Offre offre = new Offre();
                switch (l.Nom)
                {
                    case "Freelance-info":
                        this.regex = new Regex(@"<div id=""offre_.*"".*>(\n*\s*.*\s*\n*)*?<div id=""offre_.*"".*>");
                        this.matchColl = regex.Matches(contenu);
                        foreach (Match m in matchColl)
                        {

                            Regex reg_link_title = new Regex(@"<a\s*class=""rtitre"".*</a>");
                            Match match_l_t = reg_link_title.Match(m.Value);
                            //if(m.Groups[1].Value != "...") pour exclure ce qu'on veut pas.

                            Regex reg_link = new Regex(@"href\s*="".*""");
                            Match match = reg_link.Match(match_l_t.Value);
                            string link = match.Value;
                            link = link.Replace("href=", "");
                            link = link.Replace(@"""", "");
                            link = "http://www.freelance-info.fr/" + link;

                            Regex reg_title = new Regex(@">.*</a>");
                            Match match_t = reg_title.Match(match_l_t.Value);
                            string title = match_t.Value;
                            title = title.Replace("<b>", "");
                            title = title.Replace("</b>", "");
                            title = title.Replace("</a>", "");
                            title = title.Replace(">", "");

                            Regex regall = new Regex(@"5px.*");
                            Match mat = regall.Match(m.Value);
                            Regex reg_desc_prix = new Regex(@"<span>.*?<");
                            MatchCollection match_d_p = reg_desc_prix.Matches(m.Value);
                            List<string> strs = new List<string>();
                            foreach (Match ma in match_d_p)
                            {
                                String desc = ma.Value;
                                desc = desc.Replace("<span>", "");
                                desc = desc.Replace("<", "");
                                strs.Add(desc);
                            }

                            Regex reg_img = new Regex(@"src\s*="".*png""");
                            Match match_img = reg_img.Match(m.Value);
                            string img = match_img.Value;
                            img = img.Replace("src=", "");
                            img = img.Replace(@"""", "");

                            offre.Img = img;
                            offre.Description = strs.ElementAt(0);
                            offre.Prix = strs.ElementAt(1);
                            offre.Lien = link;
                            offre.Titre = title;
                            offre.Categorie = new Categorie(tec);
                            list.AddLast(offre);
                            offre = new Offre();
                        }
                        break;
                    case "Upwork":
                        this.regex = new Regex(@"<a class=""break visited"".*(\s*\n*.*\n*\s*)*?</a>");
                        this.matchColl = regex.Matches(contenu);
                        offre = new Offre();
                        foreach (Match m in matchColl)
                        {
                            //if(m.Groups[1].Value != "...") pour exclure ce qu'on veut pas.
                            Regex reg_link = new Regex(@"href\s*="".*""");
                            Match match = reg_link.Match(m.Value);
                            string link = match.Value;
                            link = link.Replace("href=", "");
                            link = link.Replace(@"""", "");
                            link = "https://www.upwork.com/" + link;

                            Regex reg_title = new Regex(@">(\s*\n*.*\n*\s*)*?</a>");
                            Match match_t = reg_title.Match(m.Value);
                            string title = match_t.Value;
                            title = title.Replace("<b>", "");
                            title = title.Replace("</b>", "");
                            title = title.Replace("</a>", "");
                            title = title.Replace(@"<span class=""highlight"">", "");
                            title = title.Replace("</span>", "");
                            title = title.Replace("&amp;", "&");
                            title = title.Replace(">", "");
                            offre.Lien = link;
                            offre.Titre = title;
                            list.AddLast(offre);
                            offre = new Offre();
                        }
                        break;
                    case "Guru":
                        this.regex = new Regex(@"<li\s*class=""serviceItem clearfix""(\n*\s*.*\s*\n*)*?</li>");
                        this.matchColl = regex.Matches(contenu);
                        foreach (Match m in this.matchColl)
                        {
                            //if(m.Groups[1].Value != "...") pour exclure ce qu'on veut pas.

                            // Extract Link
                            Regex reg_link = new Regex(@"href\s*="".*""");
                            Match match = reg_link.Match(m.Value);
                            string link = match.Value;
                            link = link.Replace("href=", "");
                            link = link.Replace(@"""", "");
                            link = "http://www.guru.com" + link;

                            // Extract Title
                            Regex reg_title = new Regex(@""">.*</a>");
                            Match match_t = reg_title.Match(m.Value);
                            string title = match_t.Value;
                            title = title.Replace("</a>", "");
                            title = title.Replace(">", "");
                            title = title.Replace(@"""", "");

                            // Ectract Image
                            Regex reg_img = new Regex(@"<img\s*.*class=""work""\s*.*></a>");
                            Match match_i = reg_img.Match(m.Value);
                            string image = match_i.Value;
                            image = image.Replace("</a>", "");
                            image = image.Replace(@"<img class=""work"" src=", "");
                            image = image.Replace(">", "");
                            image = image.Replace(@"""/", "");
                            image = image.Replace(@"""", "");

                            // Extract Price
                            Regex reg_price = new Regex(@""">.*\s*</strong>");
                            Match match_p = reg_price.Match(m.Value);
                            string price = match_p.Value;
                            price = price.Replace("</strong>", "");
                            price = price.Replace("<strong>", "");
                            price = price.Replace(">", "");
                            price = price.Replace(@"""", "");

                            offre.Lien = link;
                            offre.Titre = title;
                            offre.Prix = price;
                            offre.Img = image;
                            offre.Description = "";
                            offre.Categorie = new Categorie(tec);
                            list.AddLast(offre);
                            offre = new Offre();
                        }
                        break;
                    case "Codeur":
                        this.regex = new Regex(@"<div class='normal small-project'>(\n*\s*.*\s*\n*)*?</span>(\n*\s*\.*)*</div>");
                        this.matchColl = regex.Matches(contenu);
                        foreach (Match m in this.matchColl)
                        {
                            //if(m.Groups[1].Value != "...") pour exclure ce qu'on veut pas.
                            Regex reg_link = new Regex(@"href\s*="".*""");
                            Match match = reg_link.Match(m.Value);
                            string link = match.Value;
                            link = link.Replace("href=", "");
                            link = link.Replace(@"""", "");
                            link = "https://www.codeur.com/" + link;

                            Regex reg_title = new Regex(@""">.*</a>");
                            Match match_t = reg_title.Match(m.Value);
                            string title = match_t.Value;
                            byte[] bytes = Encoding.Default.GetBytes(title);
                            bytes = Encoding.Default.GetBytes(title);
                            title = Encoding.UTF8.GetString(bytes);
                            title = title.Replace("</a>", "");
                            title = title.Replace(">", "");
                            title = title.Replace(@"""", "");

                            Regex reg_state = new Regex(@"<span class=""label label-success"">.*</span>");
                            Match match_s = reg_state.Match(m.Value);
                            string state = match_s.Value;
                            bytes = Encoding.Default.GetBytes(state);
                            state = Encoding.UTF8.GetString(bytes);
                            state = state.Replace(@"<span class=""label label-success"">", "");
                            state = state.Replace("</span>", "");
                            state = state.Replace(@"""", "");

                            Regex reg_price = new Regex(@"<i\s*class='icon-cre.*'></i>\n.*\n</span>");
                            Match match_p = reg_price.Match(m.Value);
                            string price = match_p.Value;
                            bytes = Encoding.Default.GetBytes(price);
                            price = Encoding.UTF8.GetString(bytes);
                            price = price.Replace("\u20AC", "");
                            price = price.Replace("</span>", "");
                            price = price.Replace("</i>", "");
                            price = price.Replace("<i class='icon-credit-card'>", "");
                            price = price.Replace(@"""", "");

                            offre.Lien = link;
                            offre.Titre = title;
                            offre.Prix = price;
                            offre.Img = "";
                            offre.Description = state;
                            offre.Categorie = new Categorie(tec);
                            list.AddLast(offre);
                            offre = new Offre();
                        }
                        break;
                }
            }
        }
        return list;
    }
}