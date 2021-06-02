using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLClass;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for PersonneDao
/// </summary>
public class PersonneDao
{
    private MySQLClient mysqlClient;
    public PersonneDao()
    {
        mysqlClient = new MySQLClient();
    }
    public void Insert(Personne personne)
    {
        string query = "INSERT INTO Personne VALUES(@cin,@nom,@prenom,@username,@date_naissance,@email,@telephone,@img)";
        try
        {
            mysqlClient.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
                cmd.Parameters.AddWithValue("cin", personne.CIN);
                cmd.Parameters.AddWithValue("nom", personne.Nom);
                cmd.Parameters.AddWithValue("prenom", personne.Prenom);
                cmd.Parameters.AddWithValue("username", personne.Compte.Username);
                cmd.Parameters.AddWithValue("date_naissance", personne.Date_naissance);
                cmd.Parameters.AddWithValue("email", personne.Email);
                cmd.Parameters.AddWithValue("telephone", personne.Telephone);
                cmd.Parameters.AddWithValue("img", personne.Img);
                cmd.ExecuteNonQuery();
                this.mysqlClient.CloseConnection();
        }
        catch { }
    }
    public void Update(Personne personne)
    {
        string query = "update personne set nom = @nom, prenom = @prenom, date_naissance = @date_naiss, email = @email, telephone = @tel, img = @img where cin = @cin";
        mysqlClient.OpenConnection();
        MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
        cmd.Parameters.AddWithValue("nom", personne.Nom);
        cmd.Parameters.AddWithValue("prenom", personne.Prenom);
        cmd.Parameters.AddWithValue("date_naiss", personne.Date_naissance);
        cmd.Parameters.AddWithValue("email", personne.Email);
        cmd.Parameters.AddWithValue("tel", personne.Telephone);
        cmd.Parameters.AddWithValue("img", personne.Img);
        cmd.Parameters.AddWithValue("cin", personne.CIN);
        cmd.ExecuteNonQuery();
        mysqlClient.CloseConnection();
    }
    public void Delete(String cin)
    {
        string query = "delete from personne where cin = @cin";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
            cmd.Parameters.AddWithValue("cin", cin);
            cmd.ExecuteNonQuery();
            mysqlClient.CloseConnection();
        }
        catch
        { }

    }
    public Personne Select(String username)
    {
        Personne personne = new Personne();
        string query = "SELECT * FROM personne where username = @username";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.mysqlClient.Conn);
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            personne.CIN = dataReader["cin"].ToString();
            personne.Nom = dataReader["nom"].ToString();
            personne.Prenom = dataReader["prenom"].ToString();
            personne.Date_naissance = dataReader["date_naissance"].ToString();
            personne.Email = dataReader["email"].ToString();
            personne.Telephone = dataReader["telephone"].ToString();
            personne.Img = dataReader["img"].ToString();
            dataReader.Close();
            return personne;
        }
        catch
        {
            return null;
        }
    }
}