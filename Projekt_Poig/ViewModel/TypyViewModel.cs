using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;


namespace Projekt_Poig.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;
    class TypyViewModel : ViewModelBase
    {
        private Model model = null;
        private ObservableCollection<Typ> typ = null;
        private string nazwa_gracza="",opis="";
        private ICommand dodaj = null;
        private ICommand usun = null;
        private ICommand edytuj = null;
        private ICommand zaladuj_typ = null;
        public ICollectionView FiltrujTypy { get; }
        private string filtr=string.Empty;
        private int index_typu=-1;
        public Typ BiezacyTyp { get; set; }
        public int Index_typu
        {
            get { return Index_typu; }
            set
            {
                index_typu = value;
                OnPropertyChanged(nameof(Index_typu));

            }
        }
        public ObservableCollection<Typ> Typ
        {
            get { return typ; }
            set
            {
                typ = value;
                OnPropertyChanged(nameof(Typ));
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
                            var osoba = new Typ(Nazwa_gracza, Opis,BiezacyTyp.ZwrocID_Int());


                            if (model.EdytujTyp_GraczaZBazy(Opis,Nazwa_gracza,BiezacyTyp.ZwrocID()))
                            {
                                CzyscFormularz();
                                index_typu = Typ.IndexOf(BiezacyTyp);
                                Typ[index_typu] = osoba;
                                index_typu = -1;
                                System.Windows.MessageBox.Show("Pomyslnie edytowales typ gracza");
                            }
                        }
                        ,
                        arg => (BiezacyTyp != null) && model.JestTypNazwa(Nazwa_gracza,BiezacyTyp.Nazwa_gracza) && model.CzyZmieniono(Nazwa_gracza,Opis,BiezacyTyp)
                        );


                return edytuj;
            }

        }
        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var osoba = new Typ(Nazwa_gracza, Opis);

                            if (model.DodajTyp_GraczaDoBazy(osoba))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pomyslnie dodales typ gracza");
                            }
                        }
                        ,
                        arg => (Nazwa_gracza != "") && (Opis != "") && model.JestTypDodaj(Nazwa_gracza, Opis) && index_typu ==-1
                        ); ;


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
                            var osoba = new Typ(Nazwa_gracza, Opis);
                           

                            if (model.UsunTyp_GraczaZBazy(BiezacyTyp))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pomyslnie Usunales typ gracza");
                            }
                        }
                        ,
                        arg => (BiezacyTyp != null)
                        );


                return usun;
            }

        }
        public ICommand Zaladuj_Typ
        {
            get
            {
                if (zaladuj_typ == null)
                {
                    zaladuj_typ = new RelayCommand(
                        arg =>
                        {
                            if (BiezacyTyp != null)
                            {
                                Opis = BiezacyTyp.ZwrocOpis();
                                Nazwa_gracza = BiezacyTyp.ZwrocNazwe_Gracza();
                            }

                        }
                        ,

                        arg => true);
                }
                return zaladuj_typ;

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
                FiltrujTypy.Refresh();
            }
        }
        public string Nazwa_gracza
        {
            get { return nazwa_gracza; }
            set
            {
                nazwa_gracza = value;
                OnPropertyChanged(nameof(Nazwa_gracza));
            }

        }
        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged(nameof(Opis));
            }

        }
        public TypyViewModel(Model model)
        {
            this.model = model;
            typ = model.Typy;
            FiltrujTypy = CollectionViewSource.GetDefaultView(typ);
            FiltrujTypy.Filter = FiltrTypow;
        }

        private bool FiltrTypow(object obj)
        {
            if(obj is Typ typ)
            {
                return typ.Nazwa_gracza.ToLower().Contains(Filtr.ToLower()) || typ.Opis.ToLower().Contains(Filtr.ToLower());
            }
            return false;
        }

        public void CzyscFormularz()
        {
            Nazwa_gracza = "";
            Opis = "";
        }
        public void Formularz()
        {
            Nazwa_gracza = nazwa_gracza;
            Opis = opis;
        }
        public void OdswiezTypy() => Typ = model.Typy;

    }
}