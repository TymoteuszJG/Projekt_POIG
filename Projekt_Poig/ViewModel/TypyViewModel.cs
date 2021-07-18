using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        private string nazwa_gracza=null,opis=null;
        private ICommand wyswietl=null;
        private ICommand dodaj = null;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var osoba = new Typ(Nazwa_gracza,Opis);

                            if (model.DodajTyp_GraczaDoBazy(osoba))
                            {
                                
                                System.Windows.MessageBox.Show("Pomyslnie dodales typ gracza");
                            }
                        }
                        ,
                        arg => (Nazwa_gracza != "") && (Opis != "") 
                        );


                return dodaj;
            }

        }
        public ICommand Wyswietl
        {
            get
            {
                if (wyswietl == null)
                {
                    wyswietl = new RelayCommand(arg =>
                      {
                          Console.WriteLine(Opis);
                          Console.WriteLine(Nazwa_gracza);
                      },
                    arg => true);
                }
                return wyswietl;
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
        }
        public Typ BiezacyTyp { get; set; }
        public ObservableCollection<Typ> Typ
        {
            get { return typ; }
            set
            {
                typ = value;
                OnPropertyChanged(nameof(Typ));
            }
        }
        public void OdswiezTypy() => Typ = model.Typy;

    }
}