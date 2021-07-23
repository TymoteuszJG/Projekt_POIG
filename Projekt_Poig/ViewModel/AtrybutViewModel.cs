using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projekt_Poig.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;
    class AtrybutViewModel : ViewModelBase
    {
        private Model model = null;
        private ObservableCollection<Atrybut> atrybut = null;
        private ObservableCollection<Gra> gry = null;
        private ObservableCollection<int> ida = null;
        private ObservableCollection<int> niemaid = null;
        private ObservableCollection<string> niemaidnazwa = null;
        private string nazwa_gry = null;
        private int id_gry = -1, idZaznaczenia = -1;
        private int singleplayer=0, multiplayer = 0, fps = 0, openworld = 0, fabularna = 0, strategia = 0, rpg = 0, roguelike = 0, akcja = 0, puzzle = 0, symulacja = 0, horror = 0, przygodowa = 0;

        private ICommand dodaj = null;


        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            id_gry = model.ZnajdzGrepoNazwie(Nazwa_gry);
                            var atrybut = new Atrybut(id_gry,singleplayer,multiplayer,fps,openworld,fabularna,strategia,rpg,roguelike,akcja,puzzle,symulacja,horror,przygodowa);
                            if (model.DodajAtrybutyDoBazy(atrybut))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Pomyslnie dodales atrybut");
                            }
                        }
                        ,
                        arg => (IdZaznaczenia!=-1)
                        );


                return dodaj;
            }

        }

        public AtrybutViewModel(Model model)
        {
            this.model = model;
            atrybut = model.Atrybuty;
            gry = model.Gry;
            ida = model.Ida;
            niemaid = model.Niemaid;
            niemaidnazwa = model.Niemaidnazwa;
            
        }
        public Atrybut BiezacyAtrybut{ get; set; }

        private void CzyscFormularz()
        {
            idZaznaczenia = -1;
            niemaidnazwa.Remove(nazwa_gry);
            Singleplayer = 0;
            Multiplayer = 0;
            Fps = 0;
            Openworld= 0;
            Fabularna= 0;
            Strategia= 0;
            Rpg= 0;
            Roguelike= 0;
            Akcja= 0;
            Puzzle= 0;
            Symulacja= 0;
            Horror= 0;
            Przygodowa= 0;
        }
        public ObservableCollection<Atrybut> Atrybut
        {
            get { return atrybut; }
            set
            {
                atrybut = value;
                OnPropertyChanged(nameof(Atrybut));
            }
        }
        public ObservableCollection<int> Ida
        {
            get { return ida; }
            set
            {
                ida = value;
                OnPropertyChanged(nameof(Ida));

            }
        }
        public ObservableCollection<int> Niemaid
        {
            get { return niemaid; }
            set
            {
                niemaid = value;
                OnPropertyChanged(nameof(Niemaid));

            }
        }
        public ObservableCollection<string> Niemaidnazwa
        {
            get { return niemaidnazwa; }
            set
            {
                niemaidnazwa = value;
                OnPropertyChanged(nameof(Niemaidnazwa));

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
        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                OnPropertyChanged(nameof(IdZaznaczenia));
            }
        }
        public int Singleplayer
        {
            get { return singleplayer; }
            set
            {
                singleplayer = value;
                OnPropertyChanged(nameof(Singleplayer));
            }
        }
        public int Multiplayer
        {
            get { return multiplayer; }
            set
            {
                multiplayer = value;
                OnPropertyChanged(nameof(Multiplayer));
            }
        }
        public int Fps
        {
            get { return fps; }
            set
            {
                fps = value;
                OnPropertyChanged(nameof(Fps));
            }
        }
        public int Openworld
        {
            get { return openworld; }
            set
            {
                openworld = value;
                OnPropertyChanged(nameof(Openworld));
            }
        }
        public int Fabularna
        {
            get { return fabularna; }
            set
            {
                fabularna = value;
                OnPropertyChanged(nameof(Fabularna));
            }
        }
        public int Strategia
        {
            get { return strategia; }
            set
            {
                strategia = value;
                OnPropertyChanged(nameof(Strategia));
            }
        }
        public int Rpg
        {
            get { return rpg; }
            set
            {
                rpg = value;
                OnPropertyChanged(nameof(Rpg));
            }
        }
        public int Roguelike
        {
            get { return roguelike; }
            set
            {
                roguelike = value;
                OnPropertyChanged(nameof(Roguelike));
            }
        }
        public int Akcja
        {
            get { return akcja; }
            set
            {
                akcja = value;
                OnPropertyChanged(nameof(Akcja));
            }
        }
        public int Puzzle
        {
            get { return puzzle; }
            set
            {
                puzzle = value;
                OnPropertyChanged(nameof(Puzzle));
            }
        }
        public int Symulacja
        {
            get { return symulacja; }
            set
            {
                symulacja = value;
                OnPropertyChanged(nameof(Symulacja));
            }
        }
        public int Horror
        {
            get { return horror; }
            set
            {
                horror = value;
                OnPropertyChanged(nameof(Horror));
            }
        }
        public int Przygodowa
        {
            get { return przygodowa; }
            set
            {
                przygodowa = value;
                OnPropertyChanged(nameof(Przygodowa));
            }
        }
        public void OdswiezAtrybuty() => Atrybut = model.Atrybuty;
    }
}
