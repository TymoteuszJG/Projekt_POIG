using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;

namespace Projekt_Poig.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;
    class GryViewModel : ViewModelBase
    {
        private Model model = null;
        private ObservableCollection<Gra> gra = null;
        private ObservableCollection<string> combo = null;
        private ObservableCollection<int> comboid = null;
        private string nazwa_gry = "";
        private string nazwa_gracza = null;
        private int id_typu=-1,idZaznaczenia;
        private int index_gry=-1;
        private ICommand dodaj = null;
        private ICommand usun = null;
        private ICommand edytuj = null;
        private ICommand zaladuj_gre = null;
        public ICollectionView FiltrujGry{ get; }
        private string filtr = string.Empty;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            id_typu = model.ZnajdzIdPoTypie(nazwa_gracza);
                            var gra = new Gra(Nazwa_gry, id_typu);

                            if (model.DodajGreDoBazy(gra))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pomyslnie dodales gre");
                            }
                        }
                        ,
                        arg => (Nazwa_gry != "" && IdZaznaczenia!=-1 && model.JestGraDodaj(Nazwa_gry,id_typu) && index_gry == -1)
                        );


                return dodaj;
            }

        }
        public ICommand Usun
        {

            get
            {
                if (usun == null)
                    usun = new RelayCommand(
                        arg =>
                        {
                            var gra = new Gra(Nazwa_gry, Id_typu);


                            if (model.UsunGreZBazy(BiezacaGra))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pomyslnie usunales gre");
                            }
                        }
                        ,
                        arg => (BiezacaGra != null)
                        );


                return usun;
            }

        }
        public ICommand Edytuj
        {

            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                        arg =>
                        {
                            id_typu = model.ZnajdzIdPoTypie(nazwa_gracza);
                            var gra = new Gra(Nazwa_gry,id_typu, int.Parse(BiezacaGra.ZwrocID()));


                            if (model.EdytujGreZBazy(Nazwa_gry, id_typu, BiezacaGra.ZwrocID()))
                            {
                                CzyscFormularz();
                                index_gry = Gra.IndexOf(BiezacaGra);
                                Gra[index_gry] = gra;
                                index_gry = -1;
                                System.Windows.MessageBox.Show("Pomyslnie edytowales gre");
                            }
                        }
                        ,
                        arg => (BiezacaGra != null) && model.JestGraNazwa(Nazwa_gry, BiezacaGra.Nazwa_gry) && (model.CzyZmienionoNazweGry(Nazwa_gry, BiezacaGra) || model.CzyZmieninoIdGry(Nazwa_gracza,BiezacaGra))
                        );


                return edytuj;
            }

        }
        public ICommand Zaladuj_Gre
        {
            get
            {
                if (zaladuj_gre == null)
                {
                    zaladuj_gre = new RelayCommand(
                        arg =>
                        {
                            if (BiezacaGra != null)
                            {
                                Nazwa_gry = BiezacaGra.ZwrocNazwe_Gry();
                                Id_typu = int.Parse(BiezacaGra.ZwrocIDTypu());
                                Nazwa_gracza = model.ZnajdzTypPoId(Id_typu);
                            }

                        }
                        ,

                        arg => true);
                }
                return zaladuj_gre;

            }
        }
        public string Filtr
        {
            get
            {
                return filtr;
            }
            set
            {
                filtr = value;
                OnPropertyChanged(nameof(Filtr));
                FiltrujGry.Refresh();
            }
        }
        public string Nazwa_gry
        {
            get { return nazwa_gry; }
            set
            {
                nazwa_gry = value;
                OnPropertyChanged(nameof(nazwa_gry));
            }

        }
        public string Nazwa_gracza
        {
            get { return nazwa_gracza; }
            set
            {
                nazwa_gracza = value;
                OnPropertyChanged(nameof(nazwa_gracza));
            }
        }
        public int Id_typu
        {
            get { return id_typu; }
            set
            {
                id_typu = value;
                OnPropertyChanged(nameof(id_typu));
            }

        }

        public GryViewModel(Model model)
        {
            this.model = model;
            gra = model.Gry;
            combo = model.Combo;
            comboid = model.Comboid;
            CzyscFormularz();
            FiltrujGry= CollectionViewSource.GetDefaultView(gra);
            FiltrujGry.Filter = FiltrGier;
        }
        public Gra BiezacaGra { get; set; }
        public ObservableCollection<Gra> Gra
        {
            get { return gra; }
            set
            {
                gra = value;
                OnPropertyChanged(nameof(Gra));
            }
        }

        public ObservableCollection<string> Combo
        {
            get { return combo; }
            set
            {
                combo = value;
                OnPropertyChanged(nameof(Combo));
            }
        }
        public ObservableCollection<int> Comboid
        {
            get { return comboid; }
            set
            {
                comboid = value;
                OnPropertyChanged(nameof(Comboid));
            }
        }
        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                OnPropertyChanged(nameof(IdZaznaczenia));
            }
        }
        private void CzyscFormularz()
        {
            IdZaznaczenia = -1;
            Nazwa_gry = "";
        }
        public void OdswiezGry() => Gra = model.Gry;

        private bool FiltrGier(object obj)
        {
            if (obj is Gra gra)
            {
                return gra.Nazwa_gry.ToLower().Contains(Filtr.ToLower());
            }
            return false;
        }
    }
}
