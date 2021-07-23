using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Poig.DAL.Encje
{
    class Atrybut
    {
        public int Id_gry { get; set; }
        public int Single_Player { get; set; }
        public int Multiplayer { get; set; }
        public int FPS { get; set; }
        public int Open_World { get; set; }
        public int Fabularna { get; set; }
        public int Strategia { get; set; }
        public int RPG { get; set; }
        public int RogueLike { get; set; }
        public int Akcja { get; set; }
        public int Puzzle { get; set; }
        public int Symulacja { get; set; }
        public int Horror { get; set; }
        public int Przygodowa { get; set; }

        //odczyt
        public Atrybut(MySqlDataReader reader)
        {
            Id_gry = int.Parse(reader["id_gry"].ToString());
            Single_Player = int.Parse(reader["Single_Player"].ToString());
            Multiplayer = int.Parse(reader["Multiplayer"].ToString());
            FPS = int.Parse(reader["FPS"].ToString());
            Open_World = int.Parse(reader["Open_World"].ToString());
            Fabularna = int.Parse(reader["Fabularna"].ToString());
            Strategia = int.Parse(reader["Strategia"].ToString());
            RPG = int.Parse(reader["RPG"].ToString());
            RogueLike = int.Parse(reader["RogueLike"].ToString());
            Akcja = int.Parse(reader["Akcja"].ToString());
            Puzzle = int.Parse(reader["Puzzle"].ToString());
            Symulacja = int.Parse(reader["Symulacja"].ToString());
            Horror = int.Parse(reader["Horror"].ToString());
            Przygodowa = int.Parse(reader["Przygodowa"].ToString());
        }
        //tworzenie nowego z pustym id do dodania
        public Atrybut(int id_gry ,int singleplayer, int multiplayer, int fps, int open_world, int fabularna, int strategia, int rpg, int roguelike, int akcja, int puzzle, int symulacja, int horror, int przygodowa)
        {
            Id_gry = id_gry;
            Single_Player = singleplayer;
            Multiplayer = multiplayer;
            FPS = fps;
            Open_World = open_world;
            Fabularna = fabularna;
            Strategia = strategia;
            RPG = rpg;
            RogueLike = roguelike;
            Akcja = akcja;
            Puzzle = puzzle;
            Symulacja = symulacja;
            Horror = horror;
            Przygodowa = przygodowa;
        }
        public Atrybut(Atrybut atrybut)
        {
            Id_gry = atrybut.Id_gry;
            Single_Player = atrybut.Single_Player;
            Multiplayer = atrybut.Multiplayer;
            FPS = atrybut.FPS;
            Open_World = atrybut.Open_World;
            Fabularna = atrybut.Fabularna;
            Strategia = atrybut.Strategia;
            RPG = atrybut.RPG;
            RogueLike = atrybut.RogueLike;
            Akcja = atrybut.Akcja;
            Puzzle = atrybut.Puzzle;
            Symulacja = atrybut.Symulacja;
            Horror = atrybut.Horror;
            Przygodowa = atrybut.Przygodowa;
        }
        public override string ToString()
        {
            return $"{Id_gry} {Single_Player} {Multiplayer} {FPS} {Open_World} {Fabularna} {Strategia} {RPG} {RogueLike} {Akcja} {Puzzle} {Symulacja} {Horror} {Przygodowa}";
        }
        public string ToInsert()
        {
            return $"({Id_gry}, {Single_Player}, {Multiplayer}, {FPS}, {Open_World}, {Fabularna}, {Strategia}, {RPG}, {RogueLike}, {Akcja}, {Puzzle}, {Symulacja}, {Horror}, {Przygodowa})";
        }
    }
}
