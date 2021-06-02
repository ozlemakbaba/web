using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLClass;
using MySql.Data.MySqlClient;
/// <summary>
/// Summary description for CategorieDao
/// </summary>
public class CategorieDao
{
    private MySQLClient mysqlClient;
	public CategorieDao()
	{
        this.mysqlClient = new MySQLClient();
	}
    public LinkedList<Categorie> Select()
    {
        Categorie cat = new Categorie();
        string query = "SELECT * FROM categorie";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.mysqlClient.Conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            LinkedList<Categorie> list = new LinkedList<Categorie>();
            while (dataReader.Read())
            {
                cat.Nom = dataReader["nom"].ToString();
                cat.Nbr = Convert.ToInt32(dataReader["nbr"]);
                list.AddFirst(cat);
                cat = new Categorie();
            }
            dataReader.Close();
            return list;
        }
        catch
        {
            return null;
        }
    }
}