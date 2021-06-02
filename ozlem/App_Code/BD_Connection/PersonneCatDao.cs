using System.Web;
using MySQLClass;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for PersonneCatDao
/// </summary>
public class PersonneCatDao
{
    private MySQLClient mysqlClient;
    public PersonneCatDao()
    {
        mysqlClient = new MySQLClient();
    }
    public void Insert(String cin, String nom)
    {
        string query = "INSERT INTO personne_cat VALUES(@cin, @nom)";
        try
        {
                mysqlClient.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
                cmd.Parameters.AddWithValue("cin", cin);
                cmd.Parameters.AddWithValue("nom", nom);
                cmd.ExecuteNonQuery();
                this.mysqlClient.CloseConnection();
        }
        catch { }
        return;
    }
    public LinkedList<String> isSelected(String cin, String nom)
    {
        String query = "Select * from personne_cat where cin = @cin and nom = @nom";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
            cmd.Parameters.AddWithValue("cin", cin);
            cmd.Parameters.AddWithValue("nom", nom);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            String cin_p = dataReader["cin"].ToString();
            String nom_c = dataReader["nom"].ToString();
            LinkedList<String> list = new LinkedList<string>();
            list.AddFirst(cin_p);
            list.AddLast(nom_c);
            mysqlClient.CloseConnection();
            return list;
        }
        catch
        {
            mysqlClient.CloseConnection();
            return null;
        }
    }
    public LinkedList<Categorie> Select(String cin)
    {
        Categorie cat = new Categorie();
        string query = "SELECT * FROM personne_cat where cin = @cin";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.mysqlClient.Conn);
            cmd.Parameters.AddWithValue("cin", cin);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            LinkedList<Categorie> list = new LinkedList<Categorie>();
            while (dataReader.Read())
            {
                cat.Nom = dataReader["nom"].ToString();
                cat.Nbr = 0;
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