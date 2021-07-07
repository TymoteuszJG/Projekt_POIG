using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Projekt_Poig.Model.DAL
{
    class DataAccess
    {
        MySqlConnectionStringBuilder connStrBuilder;
        MySqlConnection connection;

        private static string ALL_ATRYBUTY_QUERY = "SELECT * FROM atrybuty";

        public DataAccess()
        {
            //tworzymy connectionString
            connStrBuilder = new MySqlConnectionStringBuilder();
            //w przykładzie testowym dane zapisane w kodzie w kolejnym projekcie zapiszemy w zasonach aplikacji
            connStrBuilder.UserID = "guest";
            connStrBuilder.Password = "Guest.1234";
            connStrBuilder.Server = "localhost";
            connStrBuilder.Database = "baza_gier";
            connStrBuilder.Port = 3306;

            //connection = new MySqlConnection(connStrBuilder.ToString());
        }

        public ObservableCollection<Atrybut> GetAllAtrybuty()
        {
            ObservableCollection<Atrybut> atrybut = new ObservableCollection<Atrybut>();
            //connection powiązane będzie z bazą danych tylko w zakresie sekcji unsing i obiekt zostanie automatycznie usunięty poza tym zakresem
            using (connection = new MySqlConnection(connStrBuilder.ToString()))
            {
                MySqlCommand command = new MySqlCommand(ALL_ATRYBUTY_QUERY, connection);
                connection.Open();
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        atrybut.Add(new Atrybut((int)dataReader["id_gry"], (int)dataReader["Single_Player"], (int)dataReader["Multiplayer"], (int)dataReader["FPS"], (int)dataReader["Open_World"], (int)dataReader["Fabularna"], (int)dataReader["Strategia"], (int)dataReader["RPG"], (int)dataReader["RogueLike"], (int)dataReader["Akcja"], (int)dataReader["Puzzle"], (int)dataReader["Symulacja"], (int)dataReader["Horror"], (int)dataReader["Przygodowa"]));
                    }
                }
                else
                {
                    Console.WriteLine("Brak wyników zapytania");
                }
                connection.Close();

            }


            return atrybut;//.ToArray();

        }


    }
}
