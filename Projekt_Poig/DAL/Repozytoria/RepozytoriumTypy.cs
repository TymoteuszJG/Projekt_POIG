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
    }
}