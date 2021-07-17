using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }
        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {

            //stworzenie connection stringa na podstawie danych zapisanych w Sttings do których mamy dostęp spoza aplikacji 
            stringBuilder.UserID = "guest";
            stringBuilder.Password = "Guest.1234";
            stringBuilder.Server = "localhost";
            stringBuilder.Database = "baza_gier";
            stringBuilder.Port = 3306;
        }
    }
}
