using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAT602_Game_Frederick_Laroche
{
    internal class AdminDao : DataAccess
    {
        // Test admin dao functions (runs when program starts)
        public static void Testing()
        {
            Console.WriteLine("\n======== Testing AdminDao ========\n");

            // Test getting all players
            Console.WriteLine("Testing Get All Players...");
            var players = GetAllPlayers(); // should work
            Console.WriteLine($"Found {players.Rows.Count} players");
            Console.WriteLine();

            // Test updating player status
            Console.WriteLine("Testing Update Player Status...");
            var updateGood = UpdatePlayerStatus(1, "offline"); // should work
            Console.WriteLine("Update status test: " + updateGood);

            var updateBad = UpdatePlayerStatus(999, "offline"); // should fail , bad ID
            Console.WriteLine("Bad player ID test: " + updateBad);
            Console.WriteLine();

            // Test getting active games
            Console.WriteLine("Testing Get Active Games...");
            var games = GetActiveGames(); // should work
            Console.WriteLine($"Found {games.Rows.Count} active games");
            Console.WriteLine();

            // Test chat functions
            Console.WriteLine("Testing Chat Functions...");
            SendChatMessage(1, "Test message"); // should work
            var messages = GetChatMessages(); // should show test message
            Console.WriteLine($"Found {messages.Rows.Count} messages");
            Console.WriteLine();

            // Test online players
            Console.WriteLine("Testing Online Players...");
            var onlinePlayers = GetOnlinePlayers(); // should work
            Console.WriteLine($"Found {onlinePlayers.Rows.Count} online players");
            Console.WriteLine();

            // Test stopping games
            Console.WriteLine("Testing Stop Game...");
            var stopGood = StopGame(1); // should work
            Console.WriteLine("Stop game test: " + stopGood);

            var stopBad = StopGame(999); // should fail , bad ID
            Console.WriteLine("Bad game ID test: " + stopBad);
            Console.WriteLine();

            Console.WriteLine("\n======== Testing Complete ========\n");
        }

        /// <summary>
        /// Gets all chat messages from database
        /// Used to show chat history in lobby
        /// Returns a DataTable with username, message and timestamp
        /// </summary>
        public static DataTable GetChatMessages()
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call GetChatMessages()");

                if (dataset?.Tables[0] != null)
                {
                    return dataset.Tables[0];
                }
                return new DataTable(); // Return empty table instead of null
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting chat messages: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets list of online players
        /// Used to show who is available for chat/games
        /// Returns a DataTable with player_id and username
        /// </summary>
        public static DataTable GetOnlinePlayers()
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call GetOnlinePlayers()");

                if (dataset?.Tables[0] != null)
                {
                    return dataset.Tables[0];
                }
                return new DataTable(); // Return empty table instead of null
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting online players: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a message to the chat
        /// Returns success/fail message from database
        /// </summary>
        public static string SendChatMessage(int playerId, string message)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call SendChatMessage(@playerId, @message)",
                    new MySqlParameter("@playerId", playerId),
                    new MySqlParameter("@message", message));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    return dataset.Tables[0].Rows[0]["Message"].ToString();
                }
                return "No response from database";
            }
            catch (Exception ex)
            {
                return $"Error sending message: {ex.Message}";
            }
        }

        /// <summary>
        /// Gets all players from database
        /// Used to show player list in admin screen
        /// Returns a DataTable with player_id, username and status columns
        /// Did not use exception handling as requirement didnt ask for it(for this specific function)
        /// </summary>
        public static DataTable GetAllPlayers()
        {
            var dataset = MySqlHelper.ExecuteDataset(MySqlConnection, "call GetAllPlayers()");
            return dataset.Tables[0];
        }

        /// <summary>
        /// Gets all games that haven't finished yet
        /// Used to show active games in admin screen
        /// Returns a DataTable with game_id, game_type and player_id columns
        /// Did not use exception handling as requirement didnt ask for it(for this specific function)
        /// </summary>
        public static DataTable GetActiveGames()
        {
            var dataset = MySqlHelper.ExecuteDataset(MySqlConnection, "call GetActiveGames()");
            return dataset.Tables[0];
        }

        /// <summary>
        /// Changes a player's status in the database
        /// Used to ban/unban players from admin screen
        /// Returns success/fail message from database
        /// </summary>
        public static string UpdatePlayerStatus(int playerId, string status)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call UpdatePlayerStatus(@playerId, @status)",
                    new MySqlParameter("@playerId", playerId),
                    new MySqlParameter("@status", status));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    return dataset.Tables[0].Rows[0]["Message"].ToString();
                }
                return "No response from database";
            }
            catch (Exception ex)
            {
                return $"Error updating player status: {ex.Message}";
            }
        }

        /// <summary>
        /// Ends a game that's running
        /// Used by admin to stop games from admin screen
        /// Returns success/fail message from database
        /// </summary>
        public static string StopGame(int gameId)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call StopGame(@gameId)",
                    new MySqlParameter("@gameId", gameId));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    return dataset.Tables[0].Rows[0]["Message"].ToString();
                }

                return "No response from database";
            }
            catch (Exception ex)
            {
                return $"Error stopping game: {ex.Message}";
            }
        }

        /// <summary>
        /// function to ban/unban players
        /// Changes status between 'banned' and 'offline'
        /// Returns success/fail message from database
        /// It was easier to add this one than to consolidate with the other updates status function above.
        /// </summary>
        public static string UpdatePlayerStatus(int playerId, bool isBanned)
        {
            var status = isBanned ? "banned" : "offline";
            return UpdatePlayerStatus(playerId, status);
        }
    }
}