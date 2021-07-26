using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumTypy
    {
        //private const string RESET = "alter table typ_gracza auto_increment=1;";
        private const string ALL_TYPY_QUERY = "SELECT * FROM typ_gracza";
        private const string DODAJ_TYP = "INSERT INTO `typ_gracza`(`Nazwa_Gracza`,`Opis`) VALUES ";
        private const string USUN_TYP = "DELETE FROM `typ_gracza` where `id_Typu`= ";
        private const string EDIT_TYP_1 = "UPDATE `typ_gracza` SET `Nazwa_Gracza`=";
        private const string EDIT_TYP_2 = ",`Opis`=";
        private const string EDIT_TYP_3 = " where `id_Typu`=";

        public static List<Typ> PobierzWszystkieTypy()
        {
            List<Typ> typ = new List<Typ>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_TYPY_QUERY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    typ.Add(new Typ(reader));
                connection.Close();
            }
            return typ;
        }
        public static bool EdytujTyp_GraczaZBazy(string opis, string Nazwa_Gracza, string ID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                //MySqlCommand reset = new MySqlCommand(RESET, connection);
                MySqlCommand command = new MySqlCommand($"{EDIT_TYP_1} '{Nazwa_Gracza}' {EDIT_TYP_2} '{opis}' {EDIT_TYP_3} {ID}", connection);
                /*connection.Open();
                var reseter = reset.ExecuteReader();
                connection.Close();*/
                connection.Open();
                //var id =
                Console.WriteLine($"{EDIT_TYP_1} '{Nazwa_Gracza}' {EDIT_TYP_2} '{opis}' {EDIT_TYP_3} {ID}",connection);
                Console.WriteLine();
                Console.WriteLine();
                command.ExecuteNonQuery();
                stan = true;
                //typ_gracza.Id_typu = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
        public static bool DodajTyp_GraczaDoBazy(Typ typ_gracza)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                //MySqlCommand reset = new MySqlCommand(RESET, connection);
                MySqlCommand command = new MySqlCommand($"{DODAJ_TYP} {typ_gracza.ToInsert()}", connection);
                /*connection.Open();
                var reseter = reset.ExecuteReader();
                connection.Close();*/
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                typ_gracza.Id_typu = (int)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
        public static bool UsunTyp_GraczaZBazy(Typ typ_gracza)
        {
            bool stan = false;
            
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{USUN_TYP} {typ_gracza.ZwrocID()}", connection);
                connection.Open();
                //var id = command.ExecuteNonQuery();\
                
                
                try
                {
                    command.ExecuteNonQuery();
                    stan = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Blad" + e);
                }

                //typ_gracza.Id_typu = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
    }
}