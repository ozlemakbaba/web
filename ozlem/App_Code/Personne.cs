using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Personne
/// </summary>
public class Personne
{
    private String cin;
    private String nom;
    private String prenom;
    private String date_naissance;
    private String email;
    private String telephone;
    private String img;
    private Compte compte;
    private LinkedList<Categorie> preferences;

	public Personne(String cin, String nom, String prenom, String date_naissance, String email, String telephone, Compte compte, LinkedList<Categorie> preferences, String img)
	{
        this.cin = cin;
        this.prenom = prenom;
        this.nom = nom;
        this.date_naissance = date_naissance;
        this.email = email;
        this.telephone = telephone;
        this.compte = compte;
        this.preferences = preferences;
        this.img = img;
	}
    public Personne()
    {
    }

    public String CIN
    {
        set { this.cin = value; }
        get { return this.cin; }
    }
    public String Nom
    {
        set { this.nom = value; }
        get { return this.nom; }
    }
    public String Prenom
    {
        set { this.prenom = value; }
        get { return this.prenom; }
    }
    public String Date_naissance
    {
        set { this.date_naissance = value; }
        get { return this.date_naissance; }
    }
    public String Email
    {
        set { this.email = value; }
        get { return this.email; }
    }
    public String Telephone
    {
        set { this.telephone = value; }
        get { return this.telephone; }
    }
    public Compte Compte
    {
        set { this.compte = value; }
        get { return this.compte; }
    }
    public LinkedList<Categorie> Preferences
    {
        set { this.preferences = value; }
        get { return this.preferences; }
    }
    public String Img
    {
        set { this.img = value; }
        get { return this.img; }
    }
}