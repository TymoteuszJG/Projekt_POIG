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
            foreach(var g in Gry)
            {
                if (g.Nazwa_gry == nazwa)
                    return g.Id_gry;
            }
            return -1;
        }
        public int ZnajdzIdPoTypie(string nazwa)
        {
            foreach(var t in Typy)
            {
                if (t.Nazwa_gracza == nazwa)
                    return t.Id_typu;
            }
            return -1;
        }
        public bool CzyGraJestJuzWRepozytorium(Gra gra) => Gry.Contains(gra);
        public bool CzyTypJestJuzWRepozytorium(Typ typ) => Typy.Contains(typ);
    }
}
