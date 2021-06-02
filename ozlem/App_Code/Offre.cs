using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Offre
/// </summary>
public class Offre
{
    private String id;
    private String titre;
    private String lien;
    private String description;
    private String prix;
    private Categorie categorie;
    private String img;

	public Offre()
	{
	}
    public Offre(String titre, String lien, String description, String prix, Categorie categorie, String img)
    {
        this.titre = titre;
        this.lien = lien;
        this.description = description;
        this.prix = prix;
        this.categorie = categorie;
        this.img = img;
    }

    public String Id
    {
        set { this.id = value; }
        get { return this.id; }
    }
    public String Img
    {
        set { this.img = value; }
        get { return this.img; }
    }
    public String Titre
    {
        set { this.titre = value; }
        get { return this.titre; }
    }
    public String Lien
    {
        set { this.lien = value; }
        get { return this.lien; }
    }
    public String Description
    {
        set { this.description = value; }
        get { return this.description; }
    }
    public String Prix
    {
        set { this.prix = value; }
        get { return this.prix; }
    }
    public Categorie Categorie
    {
        set { this.categorie = value; }
        get { return this.categorie; }
    }

    ~Offre()
    { 
    }
}