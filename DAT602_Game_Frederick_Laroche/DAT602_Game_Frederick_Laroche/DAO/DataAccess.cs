using MySql.Data.MySqlClient;
namespace DAT602_Game_Frederick_Laroche
{
    internal class DataAccess
    {
        // Changed to protected internal so inheriting classes can access it
        protected internal static string ConnectionString
        {
            get
            {
                return "Server=localhost; Port=3306; Database=dat_602_game; Uid=root; Password='Laroche1';";
            }
        }
        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(ConnectionString);
                }
                return _mySqlConnection;
            }
        }
    }
}