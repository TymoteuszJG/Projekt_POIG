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
        }
    }
}
