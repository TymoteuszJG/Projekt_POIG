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
        private const string ALL_GRY_QUERY = "SELECT * FROM gry";

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
    }
}
