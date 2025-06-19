using InvestigationsProject.Classes;
using Malshinon.DataBase;
using MySql.Data.MySqlClient;
using System;

namespace InvestigationsProject.DAL
{
    public static class DALAgents
    {
        static MySqlConnection conn;
        static SQLConnection SqlConnection = new SQLConnection("invastigation");

        public static Agent GetRandomAgentByRank()
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string query = @"SELECT * FROM agents ORDER BY RAND() LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Agent(
                        id: reader.GetInt32("id"),
                        firstName: reader.GetString("first_name"),
                        lastName: reader.GetString("last_name"),
                        location: reader.GetString("location"),
                        favoriteWeapon: reader.GetString("favorite_weapon"),
                        contactNumber: reader.GetString("contact_number"),
                        secretPhrase: reader.GetString("secret_phrase"),
                        affiliation: reader.GetString("affiliation")
                    );
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("[ERROR] GetRandomAgentByRank: " + ex.Message);
                return null;
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }
    }

    
}
