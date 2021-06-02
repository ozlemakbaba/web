using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Compte
/// </summary>
public class Compte
{
    private String username;
    private String password;
    private String sec_code;
    private int visit;
	
    public Compte()
	{
	}
    public Compte(String username, String password, int visit)
    {
        this.username = username;
        this.password = password;
        Random rdm = new Random();
        this.sec_code = this.username + rdm.Next();
        this.visit = visit;
    }

    public String Username
    {
        set { this.username = value; }
        get { return this.username; }
    }
    public String Password
    {
        set { this.password = value; }
        get { return this.password; }
    }
    public String Sec_code
    {
        set { this.sec_code = value; }
        get { return this.sec_code; }
    }
    public int Visit
    {
        set { this.visit = value; }
        get { return this.visit; }
    }
}