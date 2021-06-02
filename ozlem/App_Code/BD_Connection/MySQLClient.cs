using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQLClass
{

    //Don't forget to add the MySQL.Data dll to your projects references
    //It can be downloaded for free from MySQL's official website.
    //Link to the .NET Connector (MS Installer) http://dev.mysql.com/downloads/connector/net/


    class MySQLClient
    {
        MySqlConnection conn = null;

        #region Constructors
        public MySQLClient()
        {
            conn = new MySqlConnection("server=127.0.0.1;uid=root;" +"pwd=kingFlow;database=freelancebot;");
        }
        #endregion

        public MySqlConnection Conn
        {
            set { this.conn = value; }
            get { return this.conn; }
        }

        #region Open/Close Connection
        public Boolean OpenConnection()
        {
            //This opens temporary connection
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //Here you could add a message box or something like that so you know if there were an error.
                return false;
            }
        }

        public Boolean CloseConnection()
        {
            //This method closes the open connection
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /* Common methods */

        public void Insert(string table, string column, string value)
        {
            string query = "INSERT INTO " + table +" ("+column+") VALUES (" + value + ")";

            try
            {
                if (this.OpenConnection())
                {               
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    string quer1 = "commit;";
                    MySqlCommand cmd1 = new MySqlCommand(quer1,conn);
                    cmd1.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch { }
            return;
        }

        public void Update(string table, string SET, string WHERE)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=kingFlow;database=aidweb;");
            string query = "UPDATE " + table + " SET " + SET + " WHERE id = " + WHERE;

                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                this.CloseConnection();

        }

        public void Delete(string table, string WHERE) 
        {
            string query = "DELETE FROM " + table + " WHERE " + WHERE + "";
                    MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=kingFlow;database=aidweb;");
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
            return;
        }
        public int Count(String table, String Where)
        {
            string query = "SELECT Count(*) FROM " + table + " Where " + Where + "";
            int Count = -1;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.CloseConnection();
                }
                catch { this.CloseConnection(); }

                return Count;
            }
            else
            {
                return Count;
            }
        }
        public int Count(String table)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=kingFlow;database=aidweb;");
            con.Open();
            string query = "SELECT Count(*) FROM " + table + "";
            int Count = -1;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.CloseConnection();
                }
                catch { this.CloseConnection(); }

                return Count;
            }
            else
            {
                return Count;
            }
        }
        
        /* Select for Projets */
            // Select all projects
        /*public List<Projet> SelectAllProjets()
        {
            string query = "SELECT * FROM Projet";
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=kingFlow;database=aidweb;");
            List<Projet> selectResult = new List<Projet>();
            int tailleMax = this.Count("Projet");
            Projet[] projet = new Projet[tailleMax];
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            while (dataReader.Read())
            {
                projet[i] = new Projet(0, "");
                projet[i].Id = Convert.ToInt16(dataReader["id"]);
                projet[i].Intitule = dataReader["intitule"].ToString();
                selectResult.Add(projet[i]);
                i++;
            }
            dataReader.Close();
            this.Close();

            return selectResult;
        }
            // Select using Id
        public Projet SelectIdProjet(String table, String where)
        {
            string query = "SELECT * FROM " + table + " Where " + where + "";

            Projet projet = null;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    projet = new Projet(0, "");
                    projet.Intitule = dataReader["intitule"].ToString();
                    dataReader.Close();
                }
            }
            catch { }
            finally
            {
                this.Close();
            }
            return projet;
        }

        /* Select Clients */
            // Select all clients
        /*public List<Client> SelectAllClient()
        {
            string query = "SELECT * FROM Client";
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=kingFlow;database=aidweb;");
            List<Client> selectResult = new List<Client>();
            int tailleMax = this.Count("Client");
            Client[] client = new Client[tailleMax];
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            while(dataReader.Read())
            {
                client[i] = new Client("", "", "", "", new Projet(10,""), "", "","", "","","","");
                client[i].Id = Convert.ToInt16(dataReader["id"]);
                client[i].NomClient = dataReader["nomClient"].ToString();
                client[i].NomDirigeant = dataReader["nomDirigeant"].ToString();
                client[i].Adresse = dataReader["adresse"].ToString();
                client[i].Email = dataReader["email"].ToString();
                client[i].Projet.Id = Convert.ToInt16(dataReader["projetID"]);
                client[i].NumFixe = dataReader["numFixe"].ToString();
                client[i].NumMobile = dataReader["numMobile"].ToString();
                client[i].PageFacebook = dataReader["pageFacebook"].ToString();
                client[i].SiteWeb = dataReader["siteWeb"].ToString();
                client[i].ProfilLinkedIn = dataReader["profilLinkedIn"].ToString();
                client[i].Whatsapp = dataReader["whatsapp"].ToString();
                client[i].DateHebergement = dataReader["dateHebergement"].ToString();
                selectResult.Add(client[i]);
                i++;
             }
                    dataReader.Close();
                    this.Close();

                return selectResult;
            }

            // Select client using Id
        public Client SelectIdClient(String table,String where)
        {
            string query = "SELECT * FROM " + table + " Where "+where+"";

                Client client=null;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                
                try
                {
                    while (dataReader.Read())
                    {
                        client = new Client("", "", "", "",null, "", "", "", "", "", "","");
                        client.NomClient = dataReader["nomClient"].ToString();
                        client.NomDirigeant = dataReader["nomDirigeant"].ToString();
                        client.Adresse = dataReader["adresse"].ToString();
                        client.Email = dataReader["email"].ToString();
                        client.NumFixe = dataReader["numFixe"].ToString();
                        client.NumMobile = dataReader["numMobile"].ToString();
                        client.PageFacebook = dataReader["pageFacebook"].ToString();
                        client.SiteWeb = dataReader["siteWeb"].ToString();
                        client.ProfilLinkedIn = dataReader["profilLinkedIn"].ToString();
                        client.Whatsapp = dataReader["whatsapp"].ToString();
                        client.DateHebergement = dataReader["dateHebergement"].ToString();
                        dataReader.Close();
                    }
                }
                catch { }
                finally
                {
                    this.Close();
                }
                return client;
        }

        /* Select Admin */
        /*public Admin SelectIdAdmin(String user,String pass)
        {
            string query = "SELECT * FROM Admin Where username = @user and password = @pass";

            Admin admin = null;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    admin = new Admin(0, "", "");
                    admin.Id = Convert.ToInt16(dataReader["id"]); ;
                    admin.Username = dataReader["username"].ToString();
                    admin.Password = dataReader["password"].ToString();
                    dataReader.Close();
                }
            }
            catch { }
            finally
            {
                this.Close();
            }
            return admin;
        }
        public int CountAdmin(String table, String user, String pass)
        {
            string query = "SELECT Count(*) FROM " + table + " Where username = @user and password = @pass";
            int Count = -1;
            if (this.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.Close();
                }
                catch { this.Close(); }

                return Count;
            }
            else
            {
                return Count;
            }
        }
        public LinkedList<Admin> SelectAll(String table)
        {
            string query = "SELECT * FROM " + table + "";

            LinkedList<Admin> selectResult = new LinkedList<Admin>();
            Admin admin = null;

            if (this.Open())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                try
                {
                    while (dataReader.Read())
                    {

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {

                            admin.Username = dataReader["username"].ToString();
                            Console.WriteLine(admin.Username);
                            admin.Password = dataReader["password"].ToString();
                            selectResult.AddLast(admin);
                        }

                    }
                    dataReader.Close();
                }
                catch { }
                this.Close();

                return selectResult;
            }
            else
            {
                return selectResult;
            }
        }*/
    }
    }
