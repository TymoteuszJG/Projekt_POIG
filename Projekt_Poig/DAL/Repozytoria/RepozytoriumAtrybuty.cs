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
        private const string USUN_ATRYBUT = "DELETE FROM `atrybuty` where `id_gry`= ";
        private const string DODAJ_ATRYBUT = "INSERT INTO atrybuty(id_gry,Single_player,Multiplayer,FPS,Open_World,Fabularna,Strategia,RPG,RogueLike,Akcja,Puzzle,Symulacja,Horror,Przygodowa) VALUES ";

        private const string EDIT_GRA_1 = "UPDATE `atrybuty` SET `Single_Player`=";
        private const string EDIT_GRA_2 = ",`Multiplayer`=";
        private const string EDIT_GRA_3 = ",`FPS`=";
        private const string EDIT_GRA_4 = ",`Open_World`=";
        private const string EDIT_GRA_5 = ",`Fabularna`=";
        private const string EDIT_GRA_6 = ",`Strategia`=";
        private const string EDIT_GRA_7 = ",`RPG`=";
        private const string EDIT_GRA_8 = ",`RogueLike`=";
        private const string EDIT_GRA_9 = ",`Akcja`=";
        private const string EDIT_GRA_10 = ",`Puzzle`=";
        private const string EDIT_GRA_11 = ",`Symulacja`=";
        private const string EDIT_GRA_12 = ",`Horror`=";
        private const string EDIT_GRA_13 = ",`Przygodowa`=";
        private const string EDIT_GRA_14 = " where `id_gry`=";
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
        public static bool DodajAtrybutyDoBazy(Atrybut atrybuty)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ATRYBUT} {atrybuty.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                if(id==1) stan = true;
                connection.Close();
            }
            return stan;
        }
        public static bool EdytujAtrybutyZBazy(int singleplayer, int multiplayer, int fps, int open_world, int fabularna, int strategia, int rpg, int roguelike, int akcja, int puzzle, int symulacja, int horror, int przygodowa, string ID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{EDIT_GRA_1} '{singleplayer}' {EDIT_GRA_2} '{multiplayer}' {EDIT_GRA_3} '{fps}' {EDIT_GRA_4} '{open_world}' {EDIT_GRA_5} '{fabularna}' {EDIT_GRA_6} '{strategia}' {EDIT_GRA_7} '{rpg}' {EDIT_GRA_8} '{roguelike}' {EDIT_GRA_9} '{akcja}' {EDIT_GRA_10} '{puzzle}' {EDIT_GRA_11} '{symulacja}' {EDIT_GRA_12} '{horror}' {EDIT_GRA_13} '{przygodowa}' {EDIT_GRA_14} {ID}", connection);
                connection.Open();
                command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
        public static bool UsunAtrybutyZBazy(Atrybut atrybut)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{USUN_ATRYBUT} {atrybut.ZwrocID()}", connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    stan = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Blad" + e);
                }

                connection.Close();
            }
            return stan;
        }
    }
}
