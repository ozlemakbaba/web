using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Categorie
/// </summary>
public class Categorie
{
    private String nom;
    private int nbr;

	public Categorie()
	{
        nbr++;
	}
    public Categorie(String nom)
    {
        nbr++;
        this.nom = nom;
    }

    public String Nom
    {
        set { this.nom = value; }
        get { return this.nom; }
    }
    public int Nbr
    {
        set { this.nbr = value; }
        get { return this.nbr; }
    }

}