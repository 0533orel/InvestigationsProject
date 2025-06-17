using InvestigationsProject.players;
using Malshinon.DataBase;
using MySql.Data.MySqlClient;
using System;

namespace InvestigationsProject.DAL
{
    public static class DALPlayers
    {
        static MySqlConnection conn;
        static SQLConnection SqlConnection = new SQLConnection("invastigation");

        public static Player GetPlayerByUserName(string userName)
        {
            try
            {
                Player player = null;
                conn = SqlConnection.OpenConnect();
                string query = "SELECT * FROM players WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    player = new Player(
                        id: reader.GetInt32("id"),
                        userName: reader.GetString("user_name"),
                        fullName: reader.GetString("full_name"),
                        rankExposed: reader.GetString("rank_exposed"),
                        successfulAttempts: reader.GetInt32("successful_attempts"),
                        failedAttempts: reader.GetInt32("failed_attempts"),
                        totalAttempts: reader.GetInt32("total_attempts"),
                        createdAt: reader.GetDateTime("created_at")
                    );
                }

                return player;
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine($"[ERROR] GetPlayerByUserName: {ex.Message}");
                return null;
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }


        public static void Add(string userName, string fullName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string query = @"INSERT INTO players (user_name, full_name) VALUES (@userName, @fullName);";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] AddPlayer: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }
    }
}
