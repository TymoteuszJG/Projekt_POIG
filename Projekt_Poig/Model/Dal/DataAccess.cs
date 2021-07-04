using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projekt_Poig.Model.Dal
{
    class DataAccess
    {
        
        MySqlConnectionStringBuilder connStrBuilder;
        MySqlConnection connection;

        private static string komenda = "SELECT * FROM gry";

        public DataAccess()
        {
            //tworzymy connectionString
            connStrBuilder = new MySqlConnectionStringBuilder();


            //w przykładzie testowym dane zapisane w kodzie w kolejnym projekcie zapiszemy w zasonach aplikacji
            connStrBuilder.UserID = "guest";
            connStrBuilder.Password = "Guest.1234";
            connStrBuilder.Server = "localhost";
            connStrBuilder.Database = "bazagier";
            connStrBuilder.Port = 3306;
        }


        public List<Gry> GetAllGames()
        {
            List<Gry> games = new List<Gry>();

            using (connection = new MySqlConnection(connStrBuilder.ToString()))
            {
                MySqlCommand command = new MySqlCommand(komenda, connection);

                connection.Open();
                var dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        games.Add(new Gry((int)dataReader["ID_GRY"], dataReader["NAZWA_GRY"].ToString(), (int)dataReader["ID_TYPU"]));
                    }
                }
                else
                {
                    Console.WriteLine("Brak wyników zapytania");
                }
                connection.Close();
            }
            return games;
        }
    }
}
