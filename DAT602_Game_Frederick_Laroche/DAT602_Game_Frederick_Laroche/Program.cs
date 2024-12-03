using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Game_Frederick_Laroche
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserDao.Testing();
            AdminDao.Testing();
            GameDao.Testing();
            Application.Run(new LoginForm());  
        }
    }
}