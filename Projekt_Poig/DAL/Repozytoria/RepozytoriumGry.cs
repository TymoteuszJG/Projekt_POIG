using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Repozytoria
{
    using Encje;
     class RepozytoriumGry
    {
        //private const string RESET = "alter table gry auto_increment=1;";
        private const string ALL_GRY_QUERY = "SELECT * FROM gry";
        private const string DODAJ_GRE = "INSERT INTO `gry`(`nazwa_gry`,`id_Typu`) VALUES ";

        public static List<Gra> PobierzWszystkieGry()
        {
            List<Gra> gra = new List<Gra>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_GRY_QUERY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    gra.Add(new Gra(reader));
                connection.Close();
            }
            return gra;
        }
        public static bool DodajGreDoBazy(Gra gry)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                //MySqlCommand reset = new MySqlCommand(RESET, connection);
                MySqlCommand command = new MySqlCommand($"{DODAJ_GRE} {gry.ToInsert()}", connection);
                /*connection.Open();
                var reseter = reset.ExecuteReader();
                connection.Close();*/
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                gry.Id_gry = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
    }
}
