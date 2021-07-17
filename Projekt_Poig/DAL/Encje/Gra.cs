using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Encje
{
    class Gra
    {
        public int Id_gry { get; set; }
        public string Nazwa_gry { get; set; }
        public int Id_typu { get; set; }

        //odczyt
        public Gra(MySqlDataReader reader)
        {
            Id_gry = int.Parse(reader["id_gry"].ToString());
            Nazwa_gry = reader["nazwa_gry"].ToString();
            Id_typu = int.Parse(reader["id_Typu"].ToString());
        }
        //dodawanie
        public Gra(string nazwa_gry, int id_typu)
        {
            Nazwa_gry = nazwa_gry;
            Id_typu = id_typu;
        }
        public Gra(Gra gra)
        {
            Id_gry = gra.Id_gry;
            Nazwa_gry = gra.Nazwa_gry.Trim();
            Id_typu = gra.Id_typu;
        }

        public override string ToString()
        {
            return $"{Id_gry} {Nazwa_gry} {Id_typu}";
        }

        public string ToInsert()
        {
            return $"( '{Nazwa_gry}', {Id_typu})";
        }
        public override bool Equals(object obj)
        {
            var gra = obj as Gra;
            if (gra is null) return false;
            if (Nazwa_gry.ToLower() != gra.Nazwa_gry.ToLower()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
