using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumAtrybuty
    {
        private const string ALL_ATRYBUTY_QUERY = "SELECT * FROM atrybuty;";
        private const string DODAJ_ATRYBUT = "INSERT INTO atrybuty(id_gry,Single_player,Multiplayer,FPS,Open_World,Fabularna,Strategia,RPG,RogueLike,Akcja,Puzzle,Symulacja,Horror,Przygodowa) VALUES ";

        public static List<Atrybut> PobierzWszystkieAtrybuty()
        {
            List<Atrybut> atrybut = new List<Atrybut>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ATRYBUTY_QUERY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    atrybut.Add(new Atrybut(reader));
                connection.Close();
            }
            return atrybut;
        }
        public static bool DodajAtrybutyDoBazy(Atrybut atrybuty)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ATRYBUT} {atrybuty.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                if(id==1) stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
