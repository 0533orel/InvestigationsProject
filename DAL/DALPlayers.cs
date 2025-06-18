using InvestigationsProject.players;
using Malshinon.DataBase;
using MySql.Data.MySqlClient;

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
                        level: reader.GetInt32("level"),
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


        public static void UpdateRankExposed(string userName, string newRank)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string Query = @"UPDATE players SET rank_exposed = @newRank WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@newRank", newRank);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] UpdateSecretCode: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }

        public static void UpdateSuccessfulAttempts(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string Query = @"UPDATE players SET successful_attempts = successful_attempts + 1 WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] UpdateSecretCode: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }

        public static void UpdateFailedAttempts(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string Query = @"UPDATE players SET failed_attempts = failed_attempts + 1 WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] UpdateSecretCode: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }

        public static void UpdateTotalAttempts(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string Query = @"UPDATE players SET total_attempts = total_attempts + 1 WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] UpdateSecretCode: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }

        public static void UpdateLevel(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string Query = @"UPDATE players SET level = level + 1 WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] UpdateSecretCode: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }

        public static void Delete(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string query = "DELETE FROM players WHERE user_name = @userName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] Delete: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }


        public static void ResetPlayerProgress(string userName)
        {
            try
            {
                conn = SqlConnection.OpenConnect();
                string query = @"UPDATE players SET Level = 1, rank_exposed = 'Foot Soldier'
                                 WHERE user_name = @UserName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[ERROR] ResetPlayerProgress: {ex.Message}");
            }
            finally
            {
                SqlConnection.CloseConnection(conn);
            }
        }



    }
}
