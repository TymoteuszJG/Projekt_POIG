﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Encje
{
    class Typ
    {
        public int Id_typu { get; set; }
        public string Nazwa_gracza { get; set; }
        public string Opis { get; set; }

        //odczyt
        public Typ(MySqlDataReader reader)
        {
            Id_typu = int.Parse(reader["id_Typu"].ToString());
            Nazwa_gracza = reader["Nazwa_Gracza"].ToString();
            Opis = reader["Opis"].ToString();
        }
        public void edytuj(string opis, string nazwa_Gracza)
        {
            
            Nazwa_gracza = nazwa_Gracza;
            Opis =opis ;
        }
        public Typ(string nazwa_gracza, string opis)
        {
            Nazwa_gracza = nazwa_gracza;
            Opis = opis;
        }
        public Typ(string nazwa_gracza, string opis,int id)
        {
            Nazwa_gracza = nazwa_gracza;
            Opis = opis;
            Id_typu = id;
        }
        public Typ(Typ typ)
        {
            Id_typu = typ.Id_typu;
            Nazwa_gracza = typ.Nazwa_gracza;
            Opis = typ.Opis;
        }
        public override string ToString()
        {
            return $"{Id_typu} {Nazwa_gracza} {Opis}";
        }
        public string ToInsert()
        {
            return $"('{Nazwa_gracza}', '{Opis}')";
        }
        public string ZwrocID()
        {
            return $"{Id_typu}";
        }
        public int ZwrocID_Int()
        {
            return Id_typu; 
        }
        public string ZwrocOpis()
        {
            return $"{Opis}";
        }
        public string ZwrocNazwe_Gracza()
        {
            return $"{Nazwa_gracza}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
