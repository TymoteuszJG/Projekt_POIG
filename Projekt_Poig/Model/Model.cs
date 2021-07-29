using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poig.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class Model
    {
        public ObservableCollection<Gra> Gry { get; set; } = new ObservableCollection<Gra>();
        public ObservableCollection<Atrybut> Atrybuty { get; set; } = new ObservableCollection<Atrybut>();
        public ObservableCollection<Typ> Typy { get; set; } = new ObservableCollection<Typ>();
        public ObservableCollection<TypyGier> TypyGry { get; set; } = new ObservableCollection<TypyGier>();
        public ObservableCollection<string> Combo { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<int> Comboid { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> Ida { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> Niemaid { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<string> Niemaidnazwa { get; set; } = new ObservableCollection<string>();



        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var gry = RepozytoriumGry.PobierzWszystkieGry();
            foreach (var g in gry)
                Gry.Add(g);
            var atrybuty = RepozytoriumAtrybuty.PobierzWszystkieAtrybuty();
            foreach (var a in atrybuty)
                Atrybuty.Add(a);
            var typy = RepozytoriumTypy.PobierzWszystkieTypy();
            foreach (var t in typy)
                Typy.Add(t);
            var typgier = RepozytoriumTypyGier.PobierzWszystkieTypyGier();
            foreach (var tg in typgier)
                TypyGry.Add(tg);
            foreach (var c in typy)
            {
                Combo.Add(c.Nazwa_gracza);
                Comboid.Add(c.Id_typu);
            }
            foreach (var ia in atrybuty)
                Ida.Add(ia.Id_gry);
            foreach (var ig in gry)
                if (Ida.Contains(ig.Id_gry)) { }
                else {Niemaid.Add(ig.Id_gry);Niemaidnazwa.Add(ig.Nazwa_gry); }
        }
        public bool DodajTyp_GraczaDoBazy(Typ typ_gracza)
        {
            if (!CzyTypJestJuzWRepozytorium(typ_gracza))
            {
                if (RepozytoriumTypy.DodajTyp_GraczaDoBazy(typ_gracza))
                {
                    Typy.Add(typ_gracza);
                    return true;
                } 
            }
            return false;
        }
        public bool UsunTyp_GraczaZBazy(Typ typ_gracza)
        {

            if (RepozytoriumTypy.UsunTyp_GraczaZBazy(typ_gracza))
            {
                Typy.Remove(typ_gracza);
                return true;
            }

            return false;
        }
        public bool UsunGreZBazy(Gra gra)
        {

            if (RepozytoriumGry.UsunGreZBazy(gra))
            {
                Gry.Remove(gra);
                return true;
            }

            return false;
        }
        public bool UsunAtrybutZBazy(Atrybut atrybut)
        {

            if (RepozytoriumAtrybuty.UsunAtrybutyZBazy(atrybut))
            {
                Atrybuty.Remove(atrybut);
                return true;
            }

            return false;
        }
        public bool EdytujTyp_GraczaZBazy(string opis, string Nazwa_Gracza, string ID)
        {

            if (RepozytoriumTypy.EdytujTyp_GraczaZBazy(opis, Nazwa_Gracza, ID))
            {

                return true;
            }

            return false;
        }
        public bool EdytujGreZBazy(string nazwa_gry, int id_Typu, string ID)
        {

            if (RepozytoriumGry.EdytujGreZBazy(nazwa_gry, id_Typu, ID))
            {

                return true;
            }

            return false;
        }
        public bool EdytujAtrybutyZBazy(int singleplayer, int multiplayer, int fps, int open_world, int fabularna, int strategia, int rpg, int roguelike, int akcja, int puzzle, int symulacja, int horror, int przygodowa, string ID)
        {

            if (RepozytoriumAtrybuty.EdytujAtrybutyZBazy(singleplayer, multiplayer,fps,open_world,fabularna,strategia,rpg,roguelike,akcja,puzzle,symulacja,horror,przygodowa, ID))
            {

                return true;
            }

            return false;
        }
        public bool DodajGreDoBazy(Gra gry)
        {
            if (!CzyGraJestJuzWRepozytorium(gry))
            {
                if (RepozytoriumGry.DodajGreDoBazy(gry))
                {
                    Gry.Add(gry);
                    return true;
                }
            }
            return false;
        }
        public bool DodajAtrybutyDoBazy(Atrybut atrybuty)
        {
            if (RepozytoriumAtrybuty.DodajAtrybutyDoBazy(atrybuty))
            {
                Atrybuty.Add(atrybuty);
                return true;
            }
            return false;
        }
        public int ZnajdzGrepoNazwie(string nazwa)
        {
            foreach (var g in Gry)
            {
                if (g.Nazwa_gry == nazwa)
                    return g.Id_gry;
            }
            return -1;
        }
        public string ZnajdzGrepoId(int nazwa)
        {
            foreach (var g in Gry)
            {
                if (g.Id_gry == nazwa)
                    return g.Nazwa_gry;
            }
            return string.Empty;
        }
        public int ZnajdzIdPoTypie(string nazwa)
        {
            foreach (var t in Typy)
            {
                if (t.Nazwa_gracza == nazwa)
                    return t.Id_typu;
            }
            return -1;
        }
        public string ZnajdzTypPoId(int id_szukaj)
        {
            foreach (var t in Typy)
            {
                if (t.Id_typu == id_szukaj)
                    return t.Nazwa_gracza;
            }
            return "";
        }
        public bool CzyZmieniono(string nazwa, string opis, object obj)
        {
            var typ = obj as Typ;
            if (nazwa != typ.Nazwa_gracza) return true;
            if (opis != typ.Opis) return true;
            else return false;
        }
        public bool CzyZmienionoNazweGry(string nazwa, object obj)
        {
            var gra = obj as Gra;
            if (nazwa != gra.Nazwa_gry) return true;
            else return false;
        }
        public bool CzyZmieninoIdGry(string typ, object obj)
        {
            var gra = obj as Gra;
            if (ZnajdzIdPoTypie(typ) != gra.Id_typu) return true;
            else return false;
        }
        public bool JestTypNazwa(string nazwa, string biezacytyp)
        {
            foreach (var n in Typy)
            {
                if (nazwa == n.Nazwa_gracza && biezacytyp != n.Nazwa_gracza) return false;
            }
            return true;
        }
        public bool JestGraNazwa(string nazwa, string biezacagra)
        {
            foreach (var g in Gry)
            {
                if (nazwa == g.Nazwa_gry && biezacagra != g.Nazwa_gry) return false;
            }
            return true;
        }
        public bool JestTypDodaj(string nazwa, string opis)
        {
            foreach (var n in Typy)
            {
                if (nazwa == n.Nazwa_gracza && opis == n.Opis) return false;
                if (nazwa == n.Nazwa_gracza) return false;
            }
            return true;
        }
        public bool JestGraDodaj(string nazwa,int id_typu)
        {
            foreach (var n in Gry)
            {
                if (nazwa == n.Nazwa_gry && id_typu == n.Id_typu) return false;
                if (nazwa == n.Nazwa_gry) return false;
            }
            return true;
        }
        public bool CzyGraJestJuzWRepozytorium(Gra gra) => Gry.Contains(gra);
        public bool CzyTypJestJuzWRepozytorium(Typ typ) => Typy.Contains(typ);
    }
}
