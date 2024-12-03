using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAT602_Game_Frederick_Laroche
{
    internal class UserDao : DataAccess
    {
        // Test user dao functions (i call it in my program to run when i start the program)
        public static void Testing()
        {
            Console.WriteLine("\n======== Testing UserDao ========\n");

            // Test login
            Console.WriteLine("Testing Login...");
            var validLogin = Login("123", "123"); // should work
            Console.WriteLine("Valid login test: " + validLogin.Message);

            var badLogin = Login("123", "1234"); // should fail
            Console.WriteLine("Bad password test: " + badLogin.Message);
            Console.WriteLine();

            // Test admin check
            Console.WriteLine("Testing Admin Check...");
            var isAdmin = CheckAdminStatus(2); // user 123 is admin (player id 2)
            Console.WriteLine("Is user 123 admin? " + isAdmin);

            var notAdmin = CheckAdminStatus(1); // Toaddy is not admin
            Console.WriteLine("Is Toaddy admin? " + notAdmin);
            Console.WriteLine();

            // Test register
            Console.WriteLine("Testing Register...");
            var registerNew = Register("123456", "pass123"); // should work
            Console.WriteLine("New account test: " + registerNew);

            var registerBad = Register("123", "123"); // should fail , usernname taken
            Console.WriteLine("Existing username test: " + registerBad);
            Console.WriteLine();

            // Test update player
            Console.WriteLine("Testing Update Player...");
            var updateGood = UpdatePlayer(1, "1234", "1234"); // should work
            Console.WriteLine("Update account test: " + updateGood);

            var updateBad = UpdatePlayer(999, "BadUser", "pass"); // should fail
            Console.WriteLine("Bad ID test: " + updateBad);
            Console.WriteLine();

            // Test delete player
            Console.WriteLine("Testing Delete Player...");
            var deleteGood = DeletePlayer(3); // delete WhatAmI account
            Console.WriteLine("Delete account test: " + deleteGood);

            Console.WriteLine("Testing Delete Player...");
            var deleteBad = DeletePlayer(999); // delete WhatAmI account
            Console.WriteLine("Delete account test: " + deleteBad);

            Console.WriteLine("\n======== Testing Complete ========\n");
        }

        /// <summary>
        /// Login method. return a tuple with a message and player ID
        /// </summary>
        public static (string Message, int? PlayerId) Login(string username, string password)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_password", password);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    string message = dataSet.Tables[0].Rows[0]["Message"].ToString();

                    if (message == "Login successful")
                    {
                        int playerId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PlayerID"]);
                        return (message, playerId);
                    }

                    return (message, null);
                }
            }
            catch (Exception ex)
            {
                return ($"Error: {ex.Message}", null);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Checks if a player has admin rights
        /// </summary>
        public static bool CheckAdminStatus(int playerID)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("CheckAdminStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_player_id", playerID);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    return Convert.ToBoolean(dataSet.Tables[0].Rows[0]["is_admin"]);
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Registers a new account.
        /// </summary>
        public static string Register(string username, string password)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("Register", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_password", password);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    string message = dataSet.Tables[0].Rows[0]["Message"].ToString();
                    return message;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Updates a player account data.
        /// </summary>
        public static string UpdatePlayer(int playerId, string username = null, string password = null)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("UpdatePlayerData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_player_id", playerId);
                    cmd.Parameters.AddWithValue("@p_username", username ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_password", password ?? (object)DBNull.Value);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    string message = dataSet.Tables[0].Rows[0]["Message"].ToString();
                    return message;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Delete a player account
        /// </summary>
        public static string DeletePlayer(int playerId)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("DeletePlayer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_player_id", playerId);

                    var adapter = new MySqlDataAdapter(cmd);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    string message = dataSet.Tables[0].Rows[0]["Message"].ToString();
                    return message;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}