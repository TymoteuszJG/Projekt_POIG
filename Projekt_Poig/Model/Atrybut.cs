using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poig.Model
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

        public Atrybut(int id_gry, int single_player, int multiplayer, int fps, int open_world, int fabularna, int strategia, int rpg, int roguelike, int akcja, int puzzle, int symulacja, int horror, int przygodowa)
        {
            Id_gry = id_gry;
            Single_Player = single_player;
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
        public override string ToString()
        {
            return $"{Id_gry} {Single_Player} {Multiplayer} {FPS} {Open_World} {Fabularna} {Strategia} {RPG} {RogueLike} {Akcja} {Puzzle} {Symulacja} {Horror} {Przygodowa}";
        }
    }
}