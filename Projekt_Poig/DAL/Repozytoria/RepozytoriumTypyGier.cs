using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumTypyGier
    {
        private const string ALL_TYPYGIER_QUERY = "SELECT * FROM Typy_Gier";
        public static List<TypyGier> PobierzWszystkieTypyGier()
        {
            List<TypyGier> typygier = new List<TypyGier>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_TYPYGIER_QUERY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    typygier.Add(new TypyGier(reader));
                connection.Close();
            }
            return typygier;
        }
    }
}
