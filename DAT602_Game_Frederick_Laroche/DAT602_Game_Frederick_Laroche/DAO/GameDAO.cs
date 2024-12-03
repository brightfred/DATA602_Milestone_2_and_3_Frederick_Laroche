using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DAT602_Game_Frederick_Laroche
{
    internal class GameDao : DataAccess
    {
        // Test game dao functions (i call it in my program to run when i start the program)
        public static void Testing()
        {
            Console.WriteLine("\n======== Testing GameDao ========\n");

            // Test start game
            Console.WriteLine("Testing Start Game...");
            var startGood = StartGame(1, "single-player"); // should work
            Console.WriteLine("Start game test: " + startGood.message);
            Console.WriteLine();

            // Test get game board
            Console.WriteLine("Testing Get Game Board...");
            var board = GetGameBoard(1); // should work
            Console.WriteLine($"Game board test: Found {board?.Rows.Count} tiles");
            Console.WriteLine();

            // Test move player
            Console.WriteLine("Testing Move Player...");
            var moveGood = MovePlayer(1, 1, 8, 5); // should work ,valid move
            Console.WriteLine("Move player test: " + moveGood.message);

            var moveBad = MovePlayer(1, 1, 1, 1); // should fail , too far
            Console.WriteLine("Bad move test: " + moveBad.message);
            Console.WriteLine();

            // Test get inventory
            Console.WriteLine("Testing Get Inventory...");
            var inventory = GetPlayerInventory(1, 1); // should work
            Console.WriteLine($"Inventory test: Found {inventory.Count} items");
            Console.WriteLine();

            // Test updatescore
            Console.WriteLine("Testing Update Score...");
            var patternScore = UpdateGameScore(1, 1, 10); // pattern tile score (+10)
            Console.WriteLine($"Pattern score test (+10): New score is {patternScore}");

            var rockScore = UpdateGameScore(1, 1, -5); // rock/gnome penalty (-5)
            Console.WriteLine($"Rock penalty test (-5): New score is {rockScore}");

            var grassScore = UpdateGameScore(1, 1, 1); // normal grass score (+1)
            Console.WriteLine($"Grass score test (+1): New score is {grassScore}");
            Console.WriteLine();


            // Test check game status
            Console.WriteLine("Testing Game Status...");
            var status = CheckGameCompletion(1); // should work
            Console.WriteLine($"Game status test: {status.message}");
            Console.WriteLine();

            // Test get leaderboard
            Console.WriteLine("Testing Get Leaderboard...");
            var leaderboard = GetLeaderBoard(); // should work
            Console.WriteLine($"Leaderboard test: Found {leaderboard?.Rows.Count} entries");
            Console.WriteLine();

            // Test get player stats
            Console.WriteLine("Testing Get Player Stats...");
            var stats = GetPlayerStats(1); // should work - Toaddy's stats
            Console.WriteLine("Stats test: " + (stats != null ? "Found stats" : "No stats found"));
            Console.WriteLine();

            Console.WriteLine("\n======== Testing Complete ========\n");
        }


        // Start a new game for a player
        // Returns a message and the new game ID
        public static (string message, int? gameId) StartGame(int playerId, string gameType)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call StartGame(@p_player_id, @p_game_type)",
                    new MySqlParameter("@p_player_id", playerId),
                    new MySqlParameter("@p_game_type", gameType));

                if (dataset?.Tables.Count > 0)
                {
                    var lastTable = dataset.Tables[dataset.Tables.Count - 1];

                    if (lastTable.Rows.Count > 0)
                    {
                        var message = lastTable.Rows[0]["Message"].ToString();
                        var gameId = lastTable.Columns.Contains("game_id") && lastTable.Rows[0]["game_id"] != DBNull.Value
                            ? Convert.ToInt32(lastTable.Rows[0]["game_id"])
                            : (int?)null;

                        return (message, gameId);
                    }
                }

                return ("No data returned from StartGame.", null);
            }
            catch (Exception ex)
            {
                return ($"Error starting game: {ex.Message}", null);
            }
        }

        // Get the current game board state
        // Returns a table with all tile info
        public static DataTable GetGameBoard(int gameId)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call GetGameBoard(@p_game_id)",
                    new MySqlParameter("@p_game_id", gameId));

                if (dataset?.Tables[0] != null)
                {
                    return dataset.Tables[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting game board: {ex.Message}");
            }
        }

        // Move player to a new position
        // Returns what happened during the move
        public static (string message, int newRow, int newColumn, int health, int score, bool isGameOver) MovePlayer(
            int playerId, int gameId, int newRow, int newColumn)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call MovePlayer(@p_player_id, @p_game_id, @p_new_row, @p_new_col)",
                    new MySqlParameter("@p_player_id", playerId),
                    new MySqlParameter("@p_game_id", gameId),
                    new MySqlParameter("@p_new_row", newRow),
                    new MySqlParameter("@p_new_col", newColumn));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    var row = dataset.Tables[0].Rows[0];
                    var message = row["Message"].ToString();
                    var resultRow = row["new_row"] != DBNull.Value ? Convert.ToInt32(row["new_row"]) : -1;
                    var resultCol = row["new_column"] != DBNull.Value ? Convert.ToInt32(row["new_column"]) : -1;
                    var health = Convert.ToInt32(row["health_points"]);
                    var score = Convert.ToInt32(row["total_score"]);
                    var gameCompleted = Convert.ToBoolean(row["game_completed"]);

                    return (message, resultRow, resultCol, health, score, gameCompleted);
                }

                return ("No data returned from MovePlayer", newRow, newColumn, 0, 0, false);
            }
            catch (Exception ex)
            {
                return ($"Error moving player: {ex.Message}", newRow, newColumn, 0, 0, false);
            }
        }

        // Get a player's inventory items
        // Returns a list of items with their info
        public static List<(string itemName, string itemDescription, int quantity)> GetPlayerInventory(int playerId, int gameId)
        {
            var conn = MySqlConnection;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                using (var cmd = new MySqlCommand("GetPlayerInventory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_player_id", playerId);
                    cmd.Parameters.AddWithValue("@p_game_id", gameId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var inventory = new List<(string itemName, string itemDescription, int quantity)>();
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("item_name");
                            string itemDescription = reader.GetString("item_description");
                            int quantity = reader.GetInt32("quantity");

                            inventory.Add((itemName, itemDescription, quantity));
                        }
                        return inventory;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting player inventory: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        // Check if game is finished
        // Returns if game is over and why
        public static (bool isCompleted, string message) CheckGameCompletion(int gameId)
        {
            try
            {
                using (var connection = new MySqlConnection(DataAccess.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand("CheckGameStatus", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_game_id", gameId);
                        cmd.Parameters["@p_game_id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(new MySqlParameter("@p_is_game_over", MySqlDbType.Bit) { Direction = ParameterDirection.Output });
                        cmd.Parameters.Add(new MySqlParameter("@p_status_message", MySqlDbType.VarChar, 100) { Direction = ParameterDirection.Output });

                        cmd.ExecuteNonQuery();

                        bool isCompleted = Convert.ToBoolean(cmd.Parameters["@p_is_game_over"].Value);
                        string message = cmd.Parameters["@p_status_message"].Value.ToString();

                        return (isCompleted, message);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error checking game status: {ex.Message}");
            }
        }

        // Get the top scores from all games
        // Returns a table with score info
        public static DataTable GetLeaderBoard()
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call GetLeaderBoard()");

                if (dataset?.Tables[0] != null)
                {
                    return dataset.Tables[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting leaderboard: {ex.Message}");
            }
        }

        // Get a player's game statistics
        // Returns their stats from database
        public static DataRow GetPlayerStats(int playerId)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call GetPlayerStats(@p_player_id)",
                    new MySqlParameter("@p_player_id", playerId));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    return dataset.Tables[0].Rows[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting player stats: {ex.Message}");
            }
        }

        // Add points to player's score
        // Returns new total score
        public static int UpdateGameScore(int playerId, int gameId, int scoreValue)
        {
            try
            {
                var dataset = MySqlHelper.ExecuteDataset(MySqlConnection,
                    "call UpdateGameScore(@p_player_id, @p_game_id, @p_score)",
                    new MySqlParameter("@p_player_id", playerId),
                    new MySqlParameter("@p_game_id", gameId),
                    new MySqlParameter("@p_score", scoreValue));

                if (dataset?.Tables[0]?.Rows.Count > 0)
                {
                    var totalScore = Convert.ToInt32(dataset.Tables[0].Rows[0]["total_score"]);
                    return totalScore;
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating game score: {ex.Message}");
            }
        }
    }
}