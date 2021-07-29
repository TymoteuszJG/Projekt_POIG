using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Encje
{
    class TypyGier
    {
        public string Nazwa_gracza { get; set; }
        public string Nazwa_gry { get; set; }

        //odczyt
        public TypyGier(MySqlDataReader reader)
        {
            Nazwa_gracza = reader["Nazwa_Gracza"].ToString();
            Nazwa_gry = reader["nazwa_gry"].ToString();
        }
        public TypyGier(string nazwa_gracza, string nazwa_gry)
        {
            Nazwa_gracza = nazwa_gracza;
            Nazwa_gry = nazwa_gry;
        }
        public TypyGier(TypyGier typ)
        {
            Nazwa_gracza = typ.Nazwa_gracza;
            Nazwa_gry = typ.Nazwa_gry;
        }
        public override string ToString()
        {
            return $"{Nazwa_gracza} {Nazwa_gry}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
