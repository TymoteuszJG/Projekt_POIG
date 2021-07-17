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
    }
}
