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
        private const string ALL_TYPY_QUERY = "SELECT * FROM typ_gracza";
        private const string DODAJ_TYP = "INSERT INTO `typ_gracza`(`Nazwa_Gracza`,`Opis`) VALUES ";

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
        public static bool DodajTyp_GraczaDoBazy(Typ typ_gracza)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_TYP} {typ_gracza.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                typ_gracza.Id_typu = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
    }
}