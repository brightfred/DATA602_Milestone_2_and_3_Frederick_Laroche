-- Drop and create the database
DROP DATABASE IF EXISTS dat_602_game;
CREATE DATABASE dat_602_game;
USE dat_602_game;

-- Stored Procedure to create all the tables
DELIMITER //
CREATE PROCEDURE createAllTables()
BEGIN
    -- Drop and create the game table
    DROP TABLE IF EXISTS game;
    CREATE TABLE game (
        game_id INT AUTO_INCREMENT PRIMARY KEY,
        game_type VARCHAR(50) NOT NULL,
        start_time TIMESTAMP NOT NULL,
        end_time TIMESTAMP
    );

    -- Drop and create the map table
    DROP TABLE IF EXISTS map;
    CREATE TABLE map (
        map_id INT AUTO_INCREMENT PRIMARY KEY,
        game_id INT,
        FOREIGN KEY (game_id) REFERENCES game(game_id)
    );

    -- Drop and create the tile table
    DROP TABLE IF EXISTS tile;
    CREATE TABLE tile (
        tile_id INT AUTO_INCREMENT PRIMARY KEY,
        map_id INT,
        FOREIGN KEY (map_id) REFERENCES map(map_id)
    );

    -- Drop and create the tile_type table
    DROP TABLE IF EXISTS tile_type;
    CREATE TABLE tile_type (
        tile_type_id INT AUTO_INCREMENT PRIMARY KEY,
        `name` VARCHAR(50) NOT NULL,
        effect VARCHAR(50) NOT NULL,
        score_value INT NOT NULL
    );

    -- Drop and create the player table
    DROP TABLE IF EXISTS player;
    CREATE TABLE player (
        player_id INT AUTO_INCREMENT PRIMARY KEY,
        game_id INT NULL,
        tile_id INT NULL,
        username VARCHAR(50) NOT NULL UNIQUE,
        player_password VARCHAR(255) NOT NULL,
        login_attempt INT NOT NULL DEFAULT 0,
        is_admin BOOLEAN NOT NULL DEFAULT FALSE,
        `status` VARCHAR(20) NOT NULL DEFAULT 'offline',
        healthpoint INT NOT NULL DEFAULT 3,
        FOREIGN KEY (game_id) REFERENCES game(game_id),
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id)
    );

    -- Drop and create the score table
    DROP TABLE IF EXISTS score;
    CREATE TABLE score (
        score_id INT AUTO_INCREMENT PRIMARY KEY,
        player_id INT,
        game_id INT,
        score_timestamp DATETIME NOT NULL,
        score_value INT NOT NULL,
        FOREIGN KEY (player_id) REFERENCES player(player_id),
        FOREIGN KEY (game_id) REFERENCES game(game_id)
    );

    -- Drop and create the log table
    DROP TABLE IF EXISTS log;
    CREATE TABLE log (
        log_id INT AUTO_INCREMENT PRIMARY KEY,
        player_id INT,
        login_timestamp TIMESTAMP NOT NULL,
        FOREIGN KEY (player_id) REFERENCES player(player_id)
    );

    -- Drop and create the chat_session table
    DROP TABLE IF EXISTS chat_session;
    CREATE TABLE chat_session (
        chat_id INT AUTO_INCREMENT PRIMARY KEY,
        session_start DATETIME NOT NULL,
        session_end DATETIME
    );

    -- Drop and create the player_chat table
    DROP TABLE IF EXISTS player_chat;
    CREATE TABLE player_chat (
        player_id INT,
        chat_id INT,
        `timestamp` DATETIME NOT NULL,
        message VARCHAR(255) NOT NULL,
        PRIMARY KEY (player_id, chat_id, `timestamp`),
        FOREIGN KEY (player_id) REFERENCES player(player_id),
        FOREIGN KEY (chat_id) REFERENCES chat_session(chat_id)
    );

    -- Drop and create the tile_location table
    DROP TABLE IF EXISTS tile_location;
    CREATE TABLE tile_location (
        tile_id INT PRIMARY KEY,
        tile_type_id INT,
        `row` INT NOT NULL,
        `column` INT NOT NULL,
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id),
        FOREIGN KEY (tile_type_id) REFERENCES tile_type(tile_type_id)
    );

    -- Drop and create the inventory table
    DROP TABLE IF EXISTS inventory;
    CREATE TABLE inventory (
        inventory_id INT AUTO_INCREMENT PRIMARY KEY,
        player_id INT,
        game_id INT,
        tile_type_id INT,
        quantity INT NOT NULL,
        FOREIGN KEY (player_id) REFERENCES player(player_id),
        FOREIGN KEY (game_id) REFERENCES game(game_id),
        FOREIGN KEY (tile_type_id) REFERENCES tile_type(tile_type_id)
    );
END //
DELIMITER ;

-- Call the procedure to create all tables
CALL createAllTables();

-- Stored Procedure to Insert Test Data
DELIMITER //
CREATE PROCEDURE insertTestData()
BEGIN
    -- Test data in the player table
    INSERT INTO player (username, player_password, is_admin, healthpoint, `status`, login_attempt)
    VALUES ('Toaddy', 'password123', FALSE, 3, 'online', 1),
           ('123', '123', TRUE, 3, 'online', 2),
           ('Hello', 'password12345', FALSE, 3, 'locked-out', 5),
           ('WhatAmI', 'password123456', FALSE, 3, 'banned', 4);

    -- Test data in the game table
    INSERT INTO game (game_type, start_time)
    VALUES ('single-player', NOW());

    -- Tile types with simple IDs
    INSERT INTO tile_type (tile_type_id, `name`, effect, score_value)
    VALUES 
        (1, 'NonMowed', 'Basic grass', 1),
        (2, 'Mowed', 'Mowed grass', 0),
        (3, 'Pattern', 'Pattern to mow', 10),
        (4, 'PatternMowed', 'Mowed pattern', 0),
        (5, 'Rock', 'Lose 1 HP', -5),
        (6, 'Gnome', 'Moving enemy', -5),
        (7, 'Heart', 'Gain 1 HP', 5),
        (8, 'Biggerblade', 'Mow wider', 0),
        (9, 'Home', 'Start here', 0),
        (10, 'PatternUser1', 'P1 pattern', 10),
        (11, 'PatternMowedUser1', 'P1 mowed', 0),
        (12, 'PatternUser2', 'P2 pattern', 10),
        (13, 'PatternMowedUser2', 'P2 mowed', 0);

    -- Add test inventory items
    INSERT INTO inventory (player_id, game_id, tile_type_id, quantity)
    VALUES (1, 1, 7, 1),  -- Toaddy has 1 Heart
           (2, 1, 8, 2);  

    -- Add test scores
    INSERT INTO score (player_id, game_id, score_timestamp, score_value)
    VALUES (1, 1, '2024-08-29 08:24:00', 42),
           (2, 1, '2024-08-29 08:25:00', 36),
           (3, 1, '2024-08-29 08:26:00', 34),
           (4, 1, '2024-08-29 08:27:00', 30);

    -- Add test logs
    INSERT INTO log (player_id, login_timestamp)
    VALUES (1, '2024-08-29 08:28:00'),
           (2, '2024-08-29 08:29:00'),
           (3, '2024-08-29 08:30:00'),
           (3, '2024-08-29 08:31:00'),
           (3, '2024-08-29 08:32:00'),
           (3, '2024-08-29 08:33:00'),
           (3, '2024-08-29 08:34:00'),
           (4, '2024-08-29 08:35:00');

    -- Add test chat session
    INSERT INTO chat_session (session_start)
    VALUES ('2024-08-29 08:24:00');

    -- Add test chat messages
    INSERT INTO player_chat (player_id, chat_id, `timestamp`, message)
    VALUES (1, 1, '2024-08-29 08:37:00', 'Hello world'),
           (2, 1, '2024-08-29 08:36:00', 'Hi Toaddy!');
END //
DELIMITER ;

-- Call the procedure to insert test data
CALL insertTestData();
-- *************************************************************************************************************************
-- I made sure to use a prefix (p and v) for parameters and variables
-- I didnt have time or maybe dit not manage it properly to add the multi player map and the gnome movement (NPC movement)
-- *************************************************************************************************************************

-- ========== Login procedure ==========
-- This procedure handles the user login process using these tables:
-- The player table to verify credentials, track login attempts and manage player status
-- The log table to record all login timestamps
--
-- The procedure first checks if the username and password match in the player table.
-- If successful:
--   Updates player status to 'online'
--   Resets login attempts to 0
--   Records login timestamp in log table
-- If failed:
--   Increments login attempts
--   Locks account after 5 failed attempts
--   Records failed login attempts in log table

DELIMITER //
DROP PROCEDURE IF EXISTS Login //
CREATE PROCEDURE Login(
    IN p_username VARCHAR(50),
    IN p_password VARCHAR(255)
)
COMMENT 'Check user login'
BEGIN
    DECLARE v_attempts INT DEFAULT 0; 
    DECLARE v_player_id INT;
    DECLARE v_status VARCHAR(20);

    -- Check if player exists and password matches
    SELECT player_id, status INTO v_player_id, v_status
    FROM player
    WHERE username = p_username AND player_password = p_password;

    IF v_player_id IS NOT NULL THEN
        -- Check if player is not banned or locked-out
        IF v_status = 'banned' THEN
            SELECT 'Your account is banned' AS Message;
        ELSEIF v_status = 'locked-out' THEN
            SELECT 'Your account is locked out' AS Message;
        ELSE
            -- Successful login
            UPDATE player 
            SET status = 'online', 
                login_attempt = 0 
            WHERE player_id = v_player_id;
            
            -- Insert login timestamp
            INSERT INTO log (player_id, login_timestamp)
            VALUES (v_player_id, now());
            
            SELECT 'Login successful' AS Message, 
                   v_player_id AS PlayerID;
        END IF;
    ELSE
        -- Failed login
        -- Check if username exists
        SELECT player_id, login_attempt 
        INTO v_player_id, v_attempts 
        FROM player 
        WHERE username = p_username;

        IF v_player_id IS NOT NULL THEN
            -- Increment the login attempts
            SET v_attempts = v_attempts + 1;
            
            UPDATE player 
            SET login_attempt = v_attempts 
            WHERE player_id = v_player_id;
            
            -- Insert login timestamp
            INSERT INTO log (player_id, login_timestamp)
            VALUES (v_player_id, now());
            
            -- Check for lockout
            IF v_attempts >= 5 THEN
                UPDATE player 
                SET status = 'locked-out' 
                WHERE player_id = v_player_id;
                
                SELECT 'Too many failed attempts. Your account is locked out.' AS Message;
            ELSE
                SELECT CONCAT('Invalid credentials. Attempt ', v_attempts, ' of 5.') AS Message;
            END IF;
        ELSE
            -- Username does not exist
            SELECT 'Username not found. Do you want to register?' AS Message;
        END IF;
    END IF;
END //
DELIMITER ;

-- ========== Register procedure ==========
-- This store procedure is for player registration by working with the player and log tables.
-- It first checks if the username already exist. If not, creates the account and logs their first
-- connection time.
--
-- It also uses last_insert_id() to get the new player ID instead of doing
-- an extra query.

DELIMITER //
DROP PROCEDURE IF EXISTS Register //
CREATE PROCEDURE Register(
    IN p_username VARCHAR(50),    -- Username provided by the player
    IN p_password VARCHAR(255)    -- Player password
)
COMMENT 'Register new player'
BEGIN
    IF EXISTS(SELECT 1 FROM player WHERE username = p_username) THEN
        SELECT 'Username already exists. Choose another one' AS Message;
    ELSE
        -- Create new player
        INSERT INTO player (username, player_password, status)
        VALUES (p_username, p_password, 'online');

        -- Insert first log entry
        INSERT INTO log (player_id, login_timestamp)
        VALUES (last_insert_id(), now());

        SELECT 'Registration successful' AS Message, 
               last_insert_id() AS PlayerID;
    END IF;
END //
DELIMITER ;



-- ========== Update player data procedure ==========
-- This procedure lets players change their username and password. It looks in the player table
-- to make sure no one else has the username they want before letting them change it.
--
-- what it does:
-- First looks if any other player already has this username
-- If no one has it, updates their info in the player table
-- Tells them if it worked or if something went wrong
--
-- I had to add a transaction here because milestone 3 needs it for when lots of 
-- players use the game at once. This stops things from breaking if two players
-- try to use the same username at the same time, or if something goes wrong
-- halfway through changing the player info.

DELIMITER //
DROP PROCEDURE IF EXISTS UpdatePlayerData //
CREATE PROCEDURE UpdatePlayerData(
   IN p_player_id INT,         -- Which player wants to update
   IN p_username VARCHAR(50),   -- What username they want
   IN p_password VARCHAR(255)   -- Their new password
)
COMMENT 'Update player data: username and password'
BEGIN
   START TRANSACTION;
   
   IF EXISTS(SELECT 1 FROM player 
            WHERE username = p_username 
            AND player_id != p_player_id) THEN
       SELECT 'Username already exists. Choose another one' AS Message;
       ROLLBACK;
   ELSE
       -- Update player data
       UPDATE player
       SET username = p_username,
           player_password = p_password
       WHERE player_id = p_player_id;
       
       IF row_count() = 0 THEN
           SELECT 'Player not found' AS Message;
           ROLLBACK;
       ELSE
           SELECT 'Player data updated' AS Message;
           COMMIT;
       END IF;
   END IF;
END //
DELIMITER ;




-- ========== Stop game procedure ==========
-- This procedure stops a game by adding an end time to it. It uses the game table
-- to mark when the game finished.
--
-- what it does:
-- Puts the current time in the game's end_time column
-- Tells us if it worked
--
-- I added a transaction here because milestone 3 needs it for when lots of 
-- players might try to stop games at once. This way we know for sure if the
-- game actually stopped or not.

DELIMITER //
DROP PROCEDURE IF EXISTS StopGame //
CREATE PROCEDURE StopGame(
    IN p_game_id INT    -- Which game to stop
)
COMMENT 'Stop a running game'
BEGIN    
    START TRANSACTION;
    
    UPDATE game 
    SET end_time = now() 
    WHERE game_id = p_game_id;
    
    IF row_count() = 0 THEN
        SELECT 'Game not found' AS Message;
        ROLLBACK;
    ELSE
        SELECT 'Game stopped' AS Message;
        COMMIT;
    END IF;
END //
DELIMITER ;


-- ========== Delete player procedure ==========
-- This procedure removes a player and all their data from the game. It cleans up
-- everything about them from all the tables.
--
-- what it does:
-- Removes their scores from the score table
-- Removes their items from the inventory table
-- Removes their login history from the log table
-- Removes their chat messages from player_chat
-- Finally removes them from the player table
--
-- I added a transaction here because milestone 3 needs it when removing player data.
-- This way either everything gets removed or nothing does - no half-deleted players!

DELIMITER //
DROP PROCEDURE IF EXISTS DeletePlayer //
CREATE PROCEDURE DeletePlayer(
    IN p_player_id INT    -- Which player we want to delete
)
COMMENT 'Delete a player and related data'
BEGIN
    START TRANSACTION;
    
    -- Remove all player data in the right order
    DELETE FROM score WHERE player_id = p_player_id;
    DELETE FROM inventory WHERE player_id = p_player_id;
    DELETE FROM log WHERE player_id = p_player_id;
    DELETE FROM player_chat WHERE player_id = p_player_id;
    DELETE FROM player WHERE player_id = p_player_id;
    
    IF row_count() = 0 THEN
        SELECT 'Player not found' AS Message;
        ROLLBACK;
    ELSE
        SELECT 'Player deleted' AS Message;
        COMMIT;
    END IF;
END //
DELIMITER ;


-- ========== Get all players procedure ==========
-- This procedure gets a list of all players from the player table.
--
-- what it does:
-- Shows us each player's ID, username and what they're doing (online, offline etc)

DELIMITER //
DROP PROCEDURE IF EXISTS GetAllPlayers //
CREATE PROCEDURE GetAllPlayers()
BEGIN
    SELECT player_id, username, status
    FROM player;
END //
DELIMITER ;

-- ========== Update player status procedure ==========
-- This procedure changes what a player is doing in the game using the player table.
--
-- what it does:
-- Changes a player's status (like online, offline, banned)
-- Tells us if it worked
--
-- I added a transaction here because milestone 3 needs it for when lots of
-- players are changing status at once. This way we know the status actually changed.

DELIMITER //
DROP PROCEDURE IF EXISTS UpdatePlayerStatus //
CREATE PROCEDURE UpdatePlayerStatus(
    IN p_player_id INT,      -- Which player we're updating
    IN p_status VARCHAR(20)  -- What we're changing their status to
)
BEGIN
    START TRANSACTION;
    
    UPDATE player 
    SET `status` = p_status 
    WHERE player_id = p_player_id;
    
    IF row_count() = 0 THEN
        SELECT 'Player not found.' AS Message;
        ROLLBACK;
    ELSE
        SELECT CONCAT('Player status updated to ', p_status) AS Message;
        COMMIT;
    END IF;
END //
DELIMITER ;

-- ========== Check admin status procedure ==========
-- This procedure checks if a player is an admin by looking in the player table.
--
-- what it does:
-- Checks the is_admin column for this player
-- Returns true if they're an admin, false if they're not

DELIMITER //
DROP PROCEDURE IF EXISTS CheckAdminStatus //
CREATE PROCEDURE CheckAdminStatus(
    IN p_player_id INT    -- Which player we're checking
)
BEGIN
    SELECT is_admin 
    FROM player 
    WHERE player_id = p_player_id;
END //
DELIMITER ;

-- ========== Get online players procedure ==========
-- This procedure shows who is online right now using the player table.
--
-- what it does:
-- Finds all players with the 'online' status
-- Show their ID and username

DELIMITER //
DROP PROCEDURE IF EXISTS GetOnlinePlayers //
CREATE PROCEDURE GetOnlinePlayers()
BEGIN
    SELECT player_id, username 
    FROM player 
    WHERE `status` = 'online';
END //
DELIMITER ;

-- ========== Send chat message procedure ==========
-- This procedure handles sending chat messages using the chat_session and player_chat tables.
-- It checks if there's an active chat session first. If not, it makes a new one.
--
-- What it does:
-- Looks for an active chat session
-- Makes a new one if there isn't one
-- Adds the player's message to player_chat

DELIMITER //
DROP PROCEDURE IF EXISTS SendChatMessage //
CREATE PROCEDURE SendChatMessage(
    IN p_player_id INT,           -- Which player is sending the message
    IN p_message VARCHAR(255)     -- What they want to say
)
BEGIN
    DECLARE v_chat_id INT;        -- For storing the chat session ID
    
    -- Get or create active chat session
    SELECT chat_id INTO v_chat_id 
    FROM chat_session 
    WHERE session_end IS NULL 
    LIMIT 1;
    
    IF v_chat_id IS NULL THEN
        INSERT INTO chat_session (session_start) 
        VALUES (now());
        SET v_chat_id = last_insert_id();
    END IF;

    -- Insert the message
    INSERT INTO player_chat (player_id, chat_id, `timestamp`, message)
    VALUES (p_player_id, v_chat_id, now(), p_message);
    
    SELECT 'Message sent' AS Message;
END //
DELIMITER ;


-- <========== Get Chat Messages Procedure ==========>
-- This procedure shows the last 50 messages from the chat using player_chat and player tables.
--
-- What it does:
-- Gets messages with the sender's username
-- Shows newest messages first
-- Limits to last 50 messages

DELIMITER //
DROP PROCEDURE IF EXISTS GetChatMessages //
CREATE PROCEDURE GetChatMessages()
BEGIN
   SELECT pc.message, 
          p.username, 
          pc.timestamp 
   FROM player_chat pc
   JOIN player p ON pc.player_id = p.player_id
   ORDER BY pc.timestamp DESC
   LIMIT 50;
END //
DELIMITER ;

-- ========== Get player inventory procedure ==========
-- This procedure shows what items a player has in their inventory for a specific game.
-- It uses the inventory and tile_type tables to give us item details.
--
-- What it does:
-- Gets all the items this player has in this game
-- Shows the item name, what it does, and how many they have
-- Only shows items from one specific game since players might be in different games

DELIMITER //
DROP PROCEDURE IF EXISTS GetPlayerInventory //
CREATE PROCEDURE GetPlayerInventory(
   IN p_player_id INT,    -- Which player's inventory to check
   IN p_game_id INT       -- Which game to look in
)
BEGIN
   SELECT 
       tile_type.name AS item_name, 
       tile_type.effect AS item_description, 
       inventory.quantity
   FROM inventory
   JOIN tile_type ON inventory.tile_type_id = tile_type.tile_type_id
   WHERE inventory.player_id = p_player_id 
   AND inventory.game_id = p_game_id;
END //
DELIMITER ;



-- ========== Generate single player map procedure ==========
-- This procedure creates a new game map with all its tiles and objects. It works with
-- multiple tables: map, tile, tile_location, and player to set everything up.
--
-- What it does:
-- Makes a new 10x10 map for the game
-- Fills it with grass tiles (NonMowed type)
-- Makes a U-shaped pattern to mow
-- Adds rocks as obstacles
-- Adds a gnome (npc)
-- Puts down items (heart, bigger blade)
-- Sets the player starting spot(home)
-- Resets player's health to 3
--
-- I added a transaction here because milestone 3 needs it for when lots of players
-- start games at once. This way the map either gets fully created or not at all.

DELIMITER //
DROP PROCEDURE IF EXISTS GenerateSinglePlayerMap //
CREATE PROCEDURE GenerateSinglePlayerMap(
   IN p_game_id INT    -- Which game to make the map for
)
BEGIN
   DECLARE v_map_id INT;
   DECLARE v_current_row INT DEFAULT 0;
   DECLARE v_current_col INT DEFAULT 0;
   DECLARE v_max_row INT DEFAULT 10;
   DECLARE v_max_col INT DEFAULT 10;
   
   START TRANSACTION;
   
   -- Create new map
   INSERT INTO map (game_id) VALUES (p_game_id);
   SET v_map_id = last_insert_id();
   
   -- Create tiles using WHILE loops (all tiles start as NonMowed - type 1)
   WHILE v_current_row < v_max_row DO
       WHILE v_current_col < v_max_col DO
           -- Insert new tile and its location
           INSERT INTO tile (map_id) VALUES (v_map_id);
           INSERT INTO tile_location (tile_id, tile_type_id, `row`, `column`) 
           VALUES (last_insert_id(), 1, v_current_row, v_current_col);
           
           SET v_current_col = v_current_col + 1;
       END WHILE;
       SET v_current_col = 0;
       SET v_current_row = v_current_row + 1;
   END WHILE;
   
   -- Place Pattern tiles (U shape)
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 3
   WHERE tile.map_id = v_map_id 
   AND (
       -- Left vertical line of U
       (tile_location.row = 3 AND tile_location.column = 3) OR
       (tile_location.row = 4 AND tile_location.column = 3) OR
       (tile_location.row = 5 AND tile_location.column = 3) OR
       -- Bottom of U
       (tile_location.row = 5 AND tile_location.column = 4) OR
       (tile_location.row = 5 AND tile_location.column = 5) OR
       (tile_location.row = 5 AND tile_location.column = 6) OR
       -- Right vertical line of U
       (tile_location.row = 3 AND tile_location.column = 6) OR
       (tile_location.row = 4 AND tile_location.column = 6) OR
       (tile_location.row = 5 AND tile_location.column = 6)
   );
   
   -- Place rocks
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 5
   WHERE tile.map_id = v_map_id 
   AND (
       (tile_location.row = 2 AND tile_location.column = 2) OR
       (tile_location.row = 2 AND tile_location.column = 7) OR
       (tile_location.row = 6 AND tile_location.column = 3) OR
       (tile_location.row = 6 AND tile_location.column = 6)
   );
   
   -- Place gnome
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 6
   WHERE tile.map_id = v_map_id 
   AND tile_location.row = 4 AND tile_location.column = 8;
   
   -- Place heart
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 7
   WHERE tile.map_id = v_map_id 
   AND tile_location.row = 3 AND tile_location.column = 1;
   
   -- Place bigger blade
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 8
   WHERE tile.map_id = v_map_id 
   AND tile_location.row = 7 AND tile_location.column = 4;
   
   -- Place home position (bottom middle)
   UPDATE tile_location 
   INNER JOIN tile ON tile_location.tile_id = tile.tile_id
   SET tile_location.tile_type_id = 9
   WHERE tile.map_id = v_map_id 
   AND tile_location.row = 9 AND tile_location.column = 5;

   -- Place player at home position
   UPDATE player 
   INNER JOIN tile ON tile.map_id = v_map_id
   INNER JOIN tile_location ON tile_location.tile_id = tile.tile_id
   SET player.tile_id = tile.tile_id,
       player.healthpoint = 3  -- Reset health when starting new game
   WHERE player.game_id = p_game_id
   AND tile_location.row = 9 
   AND tile_location.column = 5;
   
   IF row_count() > 0 THEN
       SELECT 'Map generated successfully' AS Message;
       COMMIT;
   ELSE
       SELECT 'Error generating map' AS Message;
       ROLLBACK;
   END IF;
END //
DELIMITER ;

-- <========== Start Game Procedure ==========>
-- This procedure starts a new game and gets the player ready to play. It uses
-- the game and player tables to set everything up. For single player games,
-- it also calls GenerateSinglePlayerMap to create the game board.
--
-- What it does:
-- Makes a new game entry with start time
-- Links the player to this game
-- Resets player's health to 3
-- Makes the game map if it's single player
--
-- I added a transaction here because milestone 3 needs it for when lots of 
-- players start games at once. This way everything gets set up properly
-- or nothing changes at all.

DELIMITER //
DROP PROCEDURE IF EXISTS StartGame //
CREATE PROCEDURE StartGame(
   IN p_player_id INT,           -- Which player is starting the game
   IN p_game_type VARCHAR(50)    -- What type of game (single-player, etc)
)
BEGIN
   DECLARE v_game_id INT;

   START TRANSACTION;

   -- Create new game
   INSERT INTO game (game_type, start_time) 
   VALUES (p_game_type, current_timestamp);
   SET v_game_id = LAST_INSERT_ID();

   -- Update player game_id and reset health
   UPDATE player
   SET game_id = v_game_id,
       healthpoint = 3
   WHERE player_id = p_player_id;

   -- Generate single player map if game type is single player
   IF p_game_type = 'single-player' THEN
       CALL GenerateSinglePlayerMap(v_game_id);
   END IF;

   -- Validate the transaction
   IF EXISTS(SELECT 1 FROM game WHERE game_id = v_game_id) THEN
       SELECT 'Game started successfully' AS Message, 
              v_game_id AS game_id;
       COMMIT;
   ELSE
       SELECT 'Error starting game' AS Message;
       ROLLBACK;
   END IF;
END //
DELIMITER ;


-- ========== Get game board procedure ==========
-- This procedure shows what the game board looks like. It uses the game, map, tile,
-- tile_location and player tables to build a the board.
--
-- What it does:
-- Gets the position of every tile on the board
-- Shows what type each tile is
-- Shows if a player is standing on each tile
-- Orders everything by row and column so it's easy to display
--
-- No transaction needed i think for this one .

DELIMITER //
DROP PROCEDURE IF EXISTS GetGameBoard //
CREATE PROCEDURE GetGameBoard(
   IN p_game_id INT    -- Which game board to show
)
BEGIN
   SELECT 
       tile_location.row,
       tile_location.column,
       tile_location.tile_type_id,
       -- Get player position (1 if player is on this tile, 0 if not)
       CASE 
           WHEN player.tile_id = tile.tile_id THEN 1 
           ELSE 0 
       END AS has_player
   FROM game
   INNER JOIN map ON map.game_id = game.game_id
   INNER JOIN tile ON tile.map_id = map.map_id
   INNER JOIN tile_location ON tile_location.tile_id = tile.tile_id
   LEFT JOIN player ON player.tile_id = tile.tile_id
   WHERE game.game_id = p_game_id
   ORDER BY tile_location.row, tile_location.column;
END //
DELIMITER ;

-- ========== Check game status procedure ==========
-- This procedure checks if a game is finished or still going. It looks at multiple
-- tables (game, player, tile_location, tile, map) to figure this out.
--
-- What it does:
-- For single player games:
--   Checks player's health
--   Counts how many pattern tiles are left to mow
--   Calculates how long the game has been running
--   Updates game end time if it's over
-- For multiplayer:
--   Just says game is in progress (not implemented yet, running out of time)
--
-- I added a transaction here because milestone 3 needs it when ending games.
-- This way we don't get weird states where the game is half-ended.

DELIMITER //
DROP PROCEDURE IF EXISTS CheckGameStatus //
CREATE PROCEDURE CheckGameStatus(
   IN p_game_id INT,                 -- Which game to check
   OUT p_is_game_over BOOLEAN,       -- Will be true if game is done
   OUT p_status_message VARCHAR(100) -- What to tell the player
)
BEGIN
   DECLARE v_game_type VARCHAR(50);
   DECLARE v_pattern_count INT;
   DECLARE v_start_time TIMESTAMP;
   DECLARE v_health INT;
   DECLARE v_minutes INT;
   DECLARE v_seconds INT;
   
   START TRANSACTION;
   
   -- Get game info
   SELECT game_type, start_time, player.healthpoint
   INTO v_game_type, v_start_time, v_health
   FROM game
   INNER JOIN player ON player.game_id = game.game_id
   WHERE game.game_id = p_game_id
   LIMIT 1;
   
   -- Calculate game duration
   SET v_minutes = timestampdiff(MINUTE, v_start_time, current_timestamp());
   SET v_seconds = MOD(timestampdiff(SECOND, v_start_time, current_timestamp()), 60);
   
   IF v_game_type = 'single-player' THEN
       -- Count remaining pattern tiles
       SELECT COUNT(*) INTO v_pattern_count
       FROM tile_location
       INNER JOIN tile ON tile.tile_id = tile_location.tile_id
       INNER JOIN map ON map.map_id = tile.map_id
       WHERE map.game_id = p_game_id 
       AND tile_location.tile_type_id = 3;
       
       -- Check game end conditions
       IF v_health <= 0 THEN
           SET p_is_game_over = TRUE;
           SET p_status_message = 'Your lawnmower broke!';
       ELSEIF v_pattern_count = 0 THEN
           SET p_is_game_over = TRUE;
           SET p_status_message = CONCAT('Victory! Completed in ', v_minutes, ' minutes and ', v_seconds, ' seconds');
       ELSE
           SET p_is_game_over = FALSE;
           SET p_status_message = 'Game in progress';
       END IF;
       
       -- Update game end time if game is over
       IF p_is_game_over THEN
           UPDATE game 
           SET end_time = current_timestamp() 
           WHERE game_id = p_game_id;
           COMMIT;
       ELSE
           COMMIT;
       END IF;
   ELSE 
       -- For multiplayer (will implement later as im running out of time )
       SET p_is_game_over = FALSE;
       SET p_status_message = 'Game in progress';
       COMMIT;
   END IF;
END //
DELIMITER ;


-- <========== Move Player Procedure ==========>
-- This procedure handles everything about moving a player on the game board. It uses
-- multiple tables (player, tile, tile_location, score, inventory) to:
--   Check if the move is allowed
--   Handle what happens when they land on special tiles
--   Update their health and score
--   Manage their inventory
--
-- What it does:
-- First checks if player can move (has health)
-- Makes sure they're only moving to a nearby tile
-- Handles special tiles they land on:
--   Rock/Gnome: loses health and points
--   Heart: heals or goes to inventory
--   BiggerBlade: goes to inventory
--   Pattern/NonMowed: gives points
-- Updates tile to show it's been mowed
-- Checks if game is over
--
-- I added a transaction here because milestone 3 needs it for when players
-- are moving around at the same time. This way all the updates happen together
-- (health, position, inventory, score) or none of them do.

DELIMITER //
DROP PROCEDURE IF EXISTS MovePlayer //
CREATE PROCEDURE MovePlayer(
    IN p_player_id INT,      -- Which player is moving
    IN p_game_id INT,        -- Which game they're in
    IN p_new_row INT,        -- Where they want to move (row)
    IN p_new_col INT         -- Where they want to move (column)
)
BEGIN
    DECLARE v_current_row INT;
    DECLARE v_current_col INT;
    DECLARE v_new_tile_id INT;
    DECLARE v_new_tile_type INT;
    DECLARE v_health INT;
    DECLARE v_score INT DEFAULT 0;
    DECLARE v_game_over BOOLEAN;
    DECLARE v_status VARCHAR(100);
    DECLARE v_inv_quantity INT;

    START TRANSACTION;

    -- Check player's health first
    SELECT healthpoint INTO v_health
    FROM player 
    WHERE player_id = p_player_id;

    -- Get current game's score
    SELECT IFNULL(SUM(score_value), 0) INTO v_score
    FROM score
    WHERE player_id = p_player_id 
    AND game_id = p_game_id;

    -- If health is 0, can't move
    IF v_health <= 0 THEN
        SELECT 
            'Cannot move - Lawnmower broken' AS Message,
            NULL AS new_row,
            NULL AS new_column,
            0 AS health_points,
            v_score AS total_score,
            TRUE AS game_completed;
    ELSE
        -- Get current position
        SELECT tile_location.row, tile_location.column 
        INTO v_current_row, v_current_col
        FROM player 
        INNER JOIN tile ON player.tile_id = tile.tile_id
        INNER JOIN tile_location ON tile.tile_id = tile_location.tile_id
        WHERE player.player_id = p_player_id;
        
        -- Check if move is valid (adjacent tile)
        IF ABS(p_new_row - v_current_row) <= 1 AND 
           ABS(p_new_col - v_current_col) <= 1 AND 
           NOT(p_new_row = v_current_row AND p_new_col = v_current_col) 
        THEN
            -- Get new tile info
            SELECT tile.tile_id, tile_location.tile_type_id
            INTO v_new_tile_id, v_new_tile_type
            FROM tile
            INNER JOIN tile_location ON tile.tile_id = tile_location.tile_id
            INNER JOIN map ON tile.map_id = map.map_id
            WHERE map.game_id = p_game_id 
            AND tile_location.row = p_new_row 
            AND tile_location.column = p_new_col;
            
            -- Handle tile effects
            IF v_new_tile_type = 5 THEN -- Rock
                UPDATE player 
                SET healthpoint = healthpoint - 1 
                WHERE player_id = p_player_id;
                SET v_health = v_health - 1;
                
                INSERT INTO score (player_id, game_id, score_timestamp, score_value)
                VALUES (p_player_id, p_game_id, current_timestamp(), -5);
                
            ELSEIF v_new_tile_type = 6 THEN -- Gnome
                UPDATE player 
                SET healthpoint = healthpoint - 1 
                WHERE player_id = p_player_id;
                SET v_health = v_health - 1;
                
                INSERT INTO score (player_id, game_id, score_timestamp, score_value)
                VALUES (p_player_id, p_game_id, current_timestamp(), -5);
                
            ELSEIF v_new_tile_type = 7 THEN -- Heart
                IF v_health < 3 THEN
                    -- Increase healthpoint by 1
                    UPDATE player 
                    SET healthpoint = healthpoint + 1 
                    WHERE player_id = p_player_id;
                    SET v_health = v_health + 1;
                ELSE
                    -- Add heart to inventory
                    CALL AddItemToInventory(p_player_id, p_game_id, 7);
                END IF;
                
            ELSEIF v_new_tile_type = 8 THEN -- BiggerBlade
                -- Add BiggerBlade to inventory
                CALL AddItemToInventory(p_player_id, p_game_id, 8);
                
            ELSEIF v_new_tile_type IN (3, 10, 12) THEN -- Pattern tiles
                INSERT INTO score (player_id, game_id, score_timestamp, score_value)
                VALUES (p_player_id, p_game_id, current_timestamp(), 10);
                
            ELSEIF v_new_tile_type = 1 THEN -- NonMowed
                INSERT INTO score (player_id, game_id, score_timestamp, score_value)
                VALUES (p_player_id, p_game_id, current_timestamp(), 1);
            END IF;
            
            -- Update tile type to reflect it has been interacted with
            UPDATE tile_location
            SET tile_type_id = CASE 
                WHEN tile_type_id = 1 THEN 2
                WHEN tile_type_id = 3 THEN 4
                WHEN tile_type_id = 7 THEN 2 -- Remove heart from tile
                WHEN tile_type_id = 8 THEN 2 -- Remove BiggerBlade from tile
                WHEN tile_type_id = 10 THEN 11
                WHEN tile_type_id = 12 THEN 13
                ELSE tile_type_id
            END
            WHERE tile_id = v_new_tile_id;
            
            -- Update player position to the new tile
            UPDATE player 
            SET tile_id = v_new_tile_id 
            WHERE player_id = p_player_id;
            
            -- After move, check if player's health is below max and they have a heart in inventory
            IF v_health < 3 THEN
                -- Check if player has a heart in inventory
                SELECT quantity INTO v_inv_quantity
                FROM inventory
                WHERE player_id = p_player_id 
                AND game_id = p_game_id 
                AND tile_type_id = 7;

                IF v_inv_quantity >= 1 THEN
                    -- Increase player's healthpoint by 1
                    UPDATE player
                    SET healthpoint = healthpoint + 1
                    WHERE player_id = p_player_id;
                    SET v_health = v_health + 1;

                    -- Remove one heart from inventory
                    UPDATE inventory
                    SET quantity = quantity - 1
                    WHERE player_id = p_player_id 
                    AND game_id = p_game_id 
                    AND tile_type_id = 7;

                    -- If quantity reaches zero, delete inventory record
                    DELETE FROM inventory
                    WHERE player_id = p_player_id 
                    AND game_id = p_game_id 
                    AND tile_type_id = 7 
                    AND quantity <= 0;
                END IF;
            END IF;
            
            -- Get updated score
            SELECT IFNULL(SUM(score_value), 0) INTO v_score
            FROM score
            WHERE player_id = p_player_id 
            AND game_id = p_game_id;
            
            -- Check game status
            CALL CheckGameStatus(p_game_id, v_game_over, v_status);
            
            SELECT 
                CASE 
                    WHEN v_game_over THEN v_status
                    ELSE 'Move successful'
                END AS Message,
                p_new_row AS new_row,
                p_new_col AS new_column,
                v_health AS health_points,
                v_score AS total_score,
                v_game_over AS game_completed;
        ELSE
            SELECT 
                'Invalid move' AS Message,
                v_current_row AS new_row,
                v_current_col AS new_column,
                v_health AS health_points,
                v_score AS total_score,
                FALSE AS game_completed;
        END IF;
    END IF;
    COMMIT;
END //
DELIMITER ;


-- <========== Add Item To Inventory Procedure ==========>
-- This procedure adds items to a player's inventory when they pick them up.
-- It looks in the inventory table to see if they already have some of this item.
--
-- What it does:
-- Checks if they already have this type of item
-- If not, makes a new inventory entry with 1 item
-- If yes, adds 1 more to what they have
--
-- I added a transaction here because milestone 3 needs it. When lots of players
-- are grabbing items at once, we need to make sure the inventory counts stay right.

DELIMITER //
DROP PROCEDURE IF EXISTS AddItemToInventory //
CREATE PROCEDURE AddItemToInventory(
    IN p_player_id INT,      -- Which player gets the item
    IN p_game_id INT,        -- Which game they're in
    IN p_tile_type_id INT    -- What item they're getting
)
BEGIN
    DECLARE v_quantity INT;
    
    START TRANSACTION;

    -- Check if they already have some
    SELECT quantity INTO v_quantity
    FROM inventory
    WHERE player_id = p_player_id 
    AND game_id = p_game_id 
    AND tile_type_id = p_tile_type_id;

    IF v_quantity IS NULL THEN
        -- Make new inventory entry
        INSERT INTO inventory (player_id, game_id, tile_type_id, quantity)
        VALUES (p_player_id, p_game_id, p_tile_type_id, 1);
    ELSE
        -- Add one more
        UPDATE inventory
        SET quantity = quantity + 1
        WHERE player_id = p_player_id 
        AND game_id = p_game_id 
        AND tile_type_id = p_tile_type_id;
    END IF;

    COMMIT;
END //
DELIMITER ;


-- <========== Update Game Score Procedure ==========>
-- This procedure adds points to a player's score in a game and shows their total.
-- It uses the score table to keep track of all scoring.
--
-- What it does:
-- Adds a new score with current time
-- Adds up all their points in this game
-- Shows their new total
--
-- I added a transaction here because milestone 3 needs it. When players get points
-- at the same time, we need to make sure we don't miss any scores.

DELIMITER //
DROP PROCEDURE IF EXISTS UpdateGameScore //
CREATE PROCEDURE UpdateGameScore(
   IN p_player_id INT,    -- Which player scored
   IN p_game_id INT,      -- Which game they're in
   IN p_score INT         -- How many points to add
)
BEGIN
   START TRANSACTION;
   
   -- Add new score
   INSERT INTO score (player_id, game_id, score_timestamp, score_value)
   VALUES (p_player_id, p_game_id, current_timestamp(), p_score);

   -- Get their new total
   SELECT 
       IFNULL(SUM(score_value), 0) AS total_score
   FROM score
   WHERE player_id = p_player_id 
   AND game_id = p_game_id;

   COMMIT;
END //
DELIMITER ;


-- <========== Get LeaderBoard Procedure ==========>
-- This procedure shows our top 10 players based on their scores. It looks in the
-- game, player, and score tables to figure out who did the best.
--
-- What it does:
-- Gets all completed games
-- Adds up each player's score
-- Works out how long they took to finish
-- Shows the top 10 highest scores
-- Orders them by score then by who finished fastest
--
-- No transaction needed since we're just looking at scores, not changing them

DELIMITER //
DROP PROCEDURE IF EXISTS GetLeaderBoard //
CREATE PROCEDURE GetLeaderBoard()
BEGIN
   -- Get top scores for completed games
   SELECT 
       player.username,
       game.game_type,
       (
           SELECT SUM(score.score_value)
           FROM score
           WHERE score.game_id = game.game_id
           AND score.player_id = player.player_id
       ) AS total_score,
       timestampdiff(SECOND, game.start_time, game.end_time) AS finish_time,
       game.start_time,
       game.end_time,
       game.game_id
   FROM game
   INNER JOIN player ON player.player_id IN (
       SELECT DISTINCT player_id 
       FROM score 
       WHERE game_id = game.game_id
   )
   WHERE game.end_time IS NOT NULL  -- Only show finished games
   GROUP BY game.game_id, player.player_id, player.username, 
            game.game_type, game.start_time, game.end_time
   HAVING total_score IS NOT NULL
   ORDER BY total_score DESC,       -- Highest scores first
            finish_time ASC  -- Faster time in case they got same score
   LIMIT 10;  -- Just show top 10
END //
DELIMITER ;

-- <========== Get Player Stats Procedure ==========>
-- This procedure shows how well a player is doing overall. It uses the player,
-- game, and score tables to get all their stats.
--
-- What it does:
-- Counts how many games they've played
-- Sees how many they've finished
-- Finds their best score
-- Works out their average score
--
-- No transaction needed since we're just checking stats, not changing anything

DELIMITER //
DROP PROCEDURE IF EXISTS GetPlayerStats //
CREATE PROCEDURE GetPlayerStats(
   IN p_player_id INT    -- Which player to check
)
BEGIN
   SELECT 
       player.username,
       COUNT(DISTINCT game.game_id) AS games_played,
       SUM(CASE 
           WHEN game.end_time IS NOT NULL THEN 1 
           ELSE 0 
       END) AS games_completed,
       MAX(score.score_value) AS highest_score,
       AVG(score.score_value) AS average_score
   FROM player
   LEFT JOIN game ON player.game_id = game.game_id
   LEFT JOIN score ON player.player_id = score.player_id 
       AND game.game_id = score.game_id
   WHERE player.player_id = p_player_id
   GROUP BY player.player_id;
END //
DELIMITER ;


-- <========== Get Active Games Procedure ==========>
-- This procedure shows which games are still being played. It looks in the
-- game and player tables to find unfinished games.
--
-- What it does:
-- Gets all games that haven't ended yet
-- Shows what type each game is
-- Shows which player is in each game
--
-- No transaction needed since we're just looking at current games, not changing them

DELIMITER //
DROP PROCEDURE IF EXISTS GetActiveGames //
CREATE PROCEDURE GetActiveGames()
BEGIN
   SELECT 
       game.game_id, 
       game.game_type, 
       player.player_id
   FROM game
   LEFT JOIN player ON game.game_id = player.game_id
   WHERE game.end_time IS NULL;  -- Only show games that aren't finished
END //
DELIMITER ;


-- *********************************************************
-- Testing all procedures with my test data
-- *********************************************************


-- *********************************************************
-- Disable safe update mode for testing, wasnt working without it
SET SQL_SAFE_UPDATES = 0;
-- *********************************************************




-- ====================== Login tests ======================

-- test regular user login
CALL Login('123', '123');  

-- test wrong username
CALL Login('1234', '123'); 

-- test locked account
CALL Login('Hello', 'password12345'); 

-- testing banned account
CALL Login('WhatAmI', 'password123456'); 

-- test wrong password
CALL Login('123', 'badpass');



-- ====================== Register tests ======================  

-- new player
CALL Register('12345', 'newpass123');

-- use existing names
CALL Register('123', '123');     -- should fail, 123 exists



-- ====================== Player update tests ======================

-- update Toaddy info
CALL UpdatePlayerData(1, '12344', '12344');  -- should work

-- rename to existing name
CALL UpdatePlayerData(1, '123', '12344');  -- should fail, 123 exists



-- ====================== Game tests ======================

-- start game for Toaddy
CALL StartGame(1, 'single-player');  -- Toaddy ID is 1

-- check game board
CALL GetGameBoard(1);  -- look at Toaddy game

-- test moves
CALL MovePlayer(1, 1, 8, 5);  -- moving Toaddy


-- ====================== Delete player ======================
CALL DeletePlayer(5); -- should work
CALL DeletePlayer(999); -- should fail

-- ====================== Update Score ======================
CALL UpdateGameScore(1, 1, 10);
CALL UpdateGameScore(1, 1, 1);
CALL UpdateGameScore(1, 1, -5);

-- ====================== Add new player ======================
CALL Register('TestUser1', 'pass123'); -- should work
CALL Register('123', '123'); -- should fail

-- ====================== Stop game ======================
CALL StopGame(1); -- should work
CALL StopGame(999); -- should fail

-- ====================== Player inventory ======================
CALL AddItemToInventory(4, 1, 7);
CALL GetPlayerInventory(4, 1);

CALL AddItemToInventory(4, 1, 8);
CALL GetPlayerInventory(4, 1);

-- ====================== Laying out tile on a board(generating a map) and placing item on a tile (get items on tiles) ======================
SELECT * FROM game WHERE game_id = 1;
SELECT * FROM player WHERE game_id = 2;
CALL StartGame(2, 'single-player');
CALL GenerateSinglePlayerMap(1);
CALL GetGameBoard(2);
SELECT * FROM tile_location tl JOIN tile t ON tl.tile_id = t.tile_id WHERE tl.tile_type_id = 7; 
-- (checks heart placement at row 3, column 1)
SELECT * FROM tile_location tl JOIN tile t ON tl.tile_id = t.tile_id WHERE tl.tile_type_id = 8;
-- (checks bigger blade placement at row 7, column 4)


-- ====================== Move player ======================
-- Start the game first
CALL StartGame(1, 'single-player');

-- (moving up from home position)
CALL MovePlayer(1, 2, 8, 5); 
-- (trying to move across board)
CALL MovePlayer(1, 2, 1, 1); 




-- ====================== Chat tests ======================

-- get existing chat (should see Hello world and Hi Toaddy!)
CALL GetChatMessages();

-- adding new message from 123
CALL SendChatMessage(2, 'testing chat!');


