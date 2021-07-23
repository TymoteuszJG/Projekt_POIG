using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private ICommand dodaj = null;

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
                        arg => (Nazwa_gry != "" && IdZaznaczenia!=-1)
                        );


                return dodaj;
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

    }
}
