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
        private const string USUN_GRE = "DELETE FROM `gry` where `id_gry`= ";
        private const string EDIT_GRA_1 = "UPDATE `gry` SET `nazwa_gry`=";
        private const string EDIT_GRA_2 = ",`id_Typu`=";
        private const string EDIT_GRA_3 = " where `id_gry`=";

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
        public static bool EdytujGreZBazy(string nazwa_gry, int id_Typu, string ID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{EDIT_GRA_1} '{nazwa_gry}' {EDIT_GRA_2} '{id_Typu}' {EDIT_GRA_3} {ID}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
        public static bool DodajGreDoBazy(Gra gry)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_GRE} {gry.ToInsert()}", connection);
                connection.Open();
                try
                {
                    var id = command.ExecuteNonQuery();
                    stan = true;
                    gry.Id_gry = (int)command.LastInsertedId;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Blad" + e);
                }
                connection.Close();
            }
            return stan;
        }
        public static bool UsunGreZBazy(Gra gry)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{USUN_GRE} {gry.ZwrocID()}", connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    stan = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Blad" + e);
                }

                connection.Close();
            }
            return stan;
        }
    }
}
