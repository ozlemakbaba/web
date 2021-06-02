using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BD_lien
/// </summary>
public class BD_lien
{
    private String nom;
    private String lien;

	public BD_lien()
	{
	}
    public BD_lien(String nom, String lien)
    {
        this.nom = nom;
        this.lien = lien;
    }

    public String Nom
    {
        set { this.nom = value; }
        get { return this.nom; }
    }
    public String Lien
    {
        set { this.lien = value; }
        get { return this.lien; }
    }
    ~BD_lien()
    {
    }
}