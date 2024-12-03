using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAT602_Game_Frederick_Laroche.Forms
{
    // This is my single player form where players can play my lawn mowing game
    // It uses my BaseGameForm to handle the timer and quitting
    public partial class SinglePlayerForm : BaseGameForm
    {
        // These variables keep track of what happening in the game
        private new int gameId;          // Which game is being played
        private int currentRow;          // Where the player is (up/down)
        private int currentColumn;       // (left/right)
        private Button[,] gridButtons;   // My grid of buttons for the game board
        private const int GridSize = 10; // I made it 10x10 will be 20x20 for multiplayer

        // I learned about Dictionary from Microsoft:
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
        // I use it to store what color each tile type should be(similar to python key and value):
        // Key: tile type ID from my database
        // Value: color of the tile
        private readonly Dictionary<int, Color> TileColors = new Dictionary<int, Color>
        {
            { 1, Color.LightGreen },   // Normal grass that needs mowing
            { 2, Color.Brown },        // Grass that's been mowed
            { 3, Color.Purple },       // Special pattern player needs to mow
            { 4, Color.DarkGray },     // Pattern after it's mowed
            { 5, Color.Gray },         // Rocks that hurt the player
            { 6, Color.Red },          // Gnome that moves around (enemy)
            { 7, Color.Pink },         // Heart that gives health
            { 8, Color.Orange },       // Tool to mow bigger area
            { 9, Color.Yellow }        // Where player starts
        };

        // I learned about overriding timer from Windows forms docs:(I had problem without the overide)
        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.timer
        // This runs every second to update how long player has been playing
        protected override void GameTimer_Tick(object sender, EventArgs e)
        {
            base.GameTimer_Tick(sender, e);  // Keep counting in base form
            TimerValue.Text = elapsedSeconds + "s";  // Show time in seconds
        }

        // Constructor for SinglePlayerForm, takes playerID as a parameter
        public SinglePlayerForm(int playerID) : base(playerID)
        {
            if (playerID <= 0)
            {
                throw new ArgumentException("Invalid player ID"); // Make sure player ID is valid
            }

            InitializeComponent(); // Initialize all the UI components
            InitializeGame();      // Start setting up the game
        }

        // This method sets up the starting state of the game
        private void InitializeGame()
        {
            try
            {
                // Start new game in database
                var (message, gameIdValue) = GameDao.StartGame(currentPlayerID, "single-player");

                if (gameIdValue == null)
                {
                    throw new Exception(message); // If game ID isn't returned, something went wrong
                }

                gameId = gameIdValue.Value; // Save the game ID
                base.gameId = gameId;       // Also set it in the base form

                // Put player at home position(hardcoded)
                currentRow = 9;    // Starting row
                currentColumn = 5; // Starting column

                CreateGameGrid();   // Create the game grid UI
                RefreshGameBoard(); // Update the game board to show initial state

                // Set starting values for health, score, and timer
                HealthPointValue.Text = "3"; // Player starts with 3 health points
                ScoreValue.Text = "0";        // Starting score is 0
                TimerValue.Text = "0s";       // Timer starts at 0 seconds

                RefreshInventory(); // Show player inventory

                // Start the game timer
                StartGameTimer();
            }
            catch (Exception ex)
            {
                // If there is an error starting the game, show a message and go back to lobby
                MessageBox.Show("Error starting game: " + ex.Message);
                this.Hide();
                new LobbyForm(currentPlayerID).Show();
            }
        }

        // Learned about TableLayoutPanel and dynamic button creation from:
        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel
        // This method creates the grid of buttons for the game board
        private void CreateGameGrid()
        {
            if (GameGrid == null) return; // If gamegrid isn't set up, do nothing

            gridButtons = new Button[GridSize, GridSize]; // Initialize the gridbuttons array
            GameGrid.Controls.Clear(); // Clear any existing buttons

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    var button = new Button
                    {
                        Dock = DockStyle.Fill,                   // Make button fill the cell
                        Margin = new Padding(0),                 // No margin around buttons
                        BackColor = TileColors[1],               // Start with NonMowed color
                        FlatStyle = FlatStyle.Flat,              // Flat style for buttons
                        Tag = new Point(row, col)                // Save position in Tag for later reference
                    };

                    button.Click += GridButton_Click; // When button is clicked, handle it
                    GameGrid.Controls.Add(button, col, row); // Add button to the grid
                    gridButtons[row, col] = button; // Save reference to the button
                }
            }
        }

        /// <summary>
        /// Event handler for when a grid button (tile) is clicked.
        /// Attempts to move the player to the selected tile.
        /// </summary>
        private void GridButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Tag is Point coordinates)
            {
                int newRow = coordinates.X; // New row position from the clicked button
                int newCol = coordinates.Y; // New column position from the clicked button

                // Try to move player
                var (message, resultRow, resultCol, health, score, isGameOver) = GameDao.MovePlayer(
                    currentPlayerID, gameId, newRow, newCol);

                // Update my display values
                HealthPointValue.Text = health.ToString();
                ScoreValue.Text = score.ToString();

                // Refresh board to update tile colors and positions
                RefreshGameBoard();

                // Refresh inventory if I pick up item or use one
                RefreshInventory();

                // Check if the game is over
                if (isGameOver)
                {
                    MessageBox.Show(message);
                    this.Hide();
                    new LobbyForm(currentPlayerID).Show();
                }
            }
        }

        /// <summary>
        /// Refreshes the game board by getting the latest gameboard state from the database.
        /// Updates the colors and texts of the grid buttons accordingly.
        /// </summary>
        private void RefreshGameBoard()
        {
            try
            {
                if (gridButtons == null || gameId == 0) return; // If grid isn't set up, do nothing

                var gameBoard = GameDao.GetGameBoard(gameId); // Get current game board from database

                if (gameBoard == null) return; // If no game board data, do nothing

                foreach (DataRow row in gameBoard.Rows)
                {
                    int r = Convert.ToInt32(row["row"]);          // Row position
                    int c = Convert.ToInt32(row["column"]);       // Column position
                    int tileTypeId = Convert.ToInt32(row["tile_type_id"]); // Type of tile
                    int hasPlayer = Convert.ToInt32(row["has_player"]);   // Is player on this tile

                    if (r >= 0 && r < GridSize && c >= 0 && c < GridSize)
                    {
                        // Get the color for this tile type
                        Color tileColor = TileColors.ContainsKey(tileTypeId)
                            ? TileColors[tileTypeId]
                            : TileColors[1]; // Default to NonMowed if type ID not found

                        gridButtons[r, c].BackColor = tileColor; // Set tile color
                        gridButtons[r, c].Text = GetTileTypeName(tileTypeId); // Set tile name

                        // Set the player current position in blue(easier to track movement)
                        if (hasPlayer == 1)
                        {
                            gridButtons[r, c].BackColor = Color.Blue; // Player is blue
                            currentRow = r;      // Update current row
                            currentColumn = c;   // Update current column
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing game board: " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the name of the tile type based on its ID.
        /// </summary>
        /// <param name="tileTypeId">ID of the tile type from the database.</param>
        /// <returns>String name of the tile type.</returns>
        private string GetTileTypeName(int tileTypeId)
        {
            switch (tileTypeId)
            {
                case 1: return "NonMowed";
                case 2: return "Mowed";
                case 3: return "Pattern";
                case 4: return "PatternMowed";
                case 5: return "Rock";
                case 6: return "Gnome";
                case 7: return "Heart";
                case 8: return "Blade";
                case 9: return "Home";
                default: return "";
            }
        }

        /// <summary>
        /// Refreshes the inventory display by getting the player inventory from the database.
        /// </summary>
        private void RefreshInventory()
        {
            try
            {
                var inventoryItems = GameDao.GetPlayerInventory(currentPlayerID, gameId); // Get inventory

                // Clear the existing items in the ListBox
                List.Items.Clear();

                // Add new items to the listBox
                foreach (var (itemName, itemDescription, quantity) in inventoryItems)
                {
                    List.Items.Add($"{itemName} x{quantity}"); // Show item name and quantity
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving inventory: " + ex.Message);
            }
        }

        // Auto Generated
        private void PlayerStatsBox_Enter(object sender, EventArgs e) { }
        private void GameGrid_Paint(object sender, PaintEventArgs e) { }
        private void SinglePlayerForm_Load(object sender, EventArgs e) { }
        private void List_SelectedIndexChanged(object sender, EventArgs e) { }
        private void InventoryBox_Enter(object sender, EventArgs e) { }
        private void HealthLabel_Click(object sender, EventArgs e) { }
        private void HealthPointValue_Click(object sender, EventArgs e) { }
        private void ScoreLabel_Click(object sender, EventArgs e) { }
        private void ScoreValue_Click(object sender, EventArgs e) { }
        private void TimeLabel_Click(object sender, EventArgs e) { }
        private void TimerValue_Click(object sender, EventArgs e) { }
    }
}
