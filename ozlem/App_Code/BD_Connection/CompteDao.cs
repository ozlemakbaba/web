using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLClass;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for CompteDao
/// </summary>
public class CompteDao
{
    private MySQLClient mysqlClient;
    public CompteDao()
    {
        mysqlClient = new MySQLClient();
    }

    public void Insert(Compte compte)
    {
        string query = "INSERT INTO compte VALUES(@username, @pass, @sec, 0)";
        try
        {
            if (mysqlClient.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
                cmd.Parameters.AddWithValue("username", compte.Username);
                cmd.Parameters.AddWithValue("pass", compte.Password);
                cmd.Parameters.AddWithValue("sec", compte.Sec_code);
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                this.mysqlClient.CloseConnection();
            }
        }
        catch { }
        return;
    }
    public void Update(Compte compte)
    {
        string query = "update compte set mdp = '"+ compte.Password +"', first_visit= " + compte.Visit + " where username = @username";
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
            cmd.Parameters.AddWithValue("pass", compte.Password);
            cmd.Parameters.AddWithValue("vis", compte.Visit);
            cmd.Parameters.AddWithValue("username", compte.Username);
            cmd.ExecuteNonQuery();
            mysqlClient.CloseConnection();
        
    }
    public void Delete(String username)
    {
        string query = "delete from compte where username = @username";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, mysqlClient.Conn);
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
            mysqlClient.CloseConnection();
        }
        catch
        { }

    }
    public Compte Select(String username, String password)
    {
        Compte compte = new Compte();
        string query = "SELECT * FROM Compte where username = @username and mdp = @pass";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.mysqlClient.Conn);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("pass", password);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            compte.Username = dataReader["username"].ToString();
            compte.Password = dataReader["mdp"].ToString();
            compte.Sec_code = dataReader["sec_code"].ToString();
            compte.Visit = Convert.ToInt16(dataReader["first_visit"]);
            dataReader.Close();
            return compte;
        }
        catch
        {
            return null;
        }
    }
    public Compte Select(String username)
    {
        Compte compte = new Compte();
        string query = "SELECT * FROM Compte where username = @username";
        try
        {
            mysqlClient.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, this.mysqlClient.Conn);
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            compte.Username = dataReader["username"].ToString();
            compte.Password = dataReader["mdp"].ToString();
            compte.Sec_code = dataReader["sec_code"].ToString();
            compte.Visit = Convert.ToInt16(dataReader["first_visit"]);
            dataReader.Close();
            return compte;
        }
        catch
        {
            return null;
        }
    }
}