using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using Projekt_Poig.Properties.Lang;

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
        private int nazwaatrybutu = -1;
        private List<string> nazwyatrybutow = new List<string> { "Singleplayer", "Multiplayer", "FPS", "Open World", "Fabularna", "Strategia", "RPG", "RogueLike", "Akcja", "Puzzle", "Symulacja", "Horror", "Przygodowa" };
        private int id_gry = -1, idZaznaczenia = -1, index_atrybutu;
        private int singleplayer=0, multiplayer = 0, fps = 0, openworld = 0, fabularna = 0, strategia = 0, rpg = 0, roguelike = 0, akcja = 0, puzzle = 0, symulacja = 0, horror = 0, przygodowa = 0;

        private ICommand dodaj = null;
        private ICommand usun = null;
        private ICommand edytuj = null;
        private ICommand zaladuj_atrybut = null;
        private ICommand reset = null;
        public ICollectionView FiltrujTypyAtrybuty { get; }
        private int filtr = 0, filtr2 = 100;

        static string edit = Lang.Atr_Edit;
        static string add = Lang.Atr_Add;
        static string del = Lang.Atr_Del;


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
                            add = Lang.Atr_Add;

                            if (model.DodajAtrybutyDoBazy(atrybut))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show(add);
                            }
                        }
                        ,
                        arg => (IdZaznaczenia!=-1)
                        );


                return dodaj;
            }

        }
    public ICommand Reset
        {

            get
            {
                if (reset == null)
                    reset = new RelayCommand(
                        arg =>
                        {
                            Nazwaatrybutu = -1;
                            Filtr = 0;
                            Filtr2 = 100;
                        }
                        ,
                        arg => true
                        );


                return reset;
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
                            var atrybuty = new Atrybut(id_gry);
                            del = Lang.Atr_Del;


                            if (model.UsunAtrybutZBazy(BiezacyAtrybut))
                            {
                                Nazwa_gry = model.ZnajdzGrepoId(id_gry);
                                CzyscFormularzEdit();
                                System.Windows.MessageBox.Show(del);
                            }
                        }
                        ,
                        arg => BiezacyAtrybut != null && idZaznaczenia == -1
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
                            var atrybut = new Atrybut(int.Parse(BiezacyAtrybut.ZwrocID()), singleplayer, multiplayer, fps, openworld, fabularna, strategia, rpg, roguelike, akcja, puzzle, symulacja, horror, przygodowa);
                            edit = Lang.Atr_Edit;


                            if (model.EdytujAtrybutyZBazy(singleplayer, multiplayer, fps, openworld, fabularna, strategia, rpg, roguelike, akcja, puzzle, symulacja, horror, przygodowa, BiezacyAtrybut.ZwrocID()))
                            {
                                CzyscFormularz();
                                index_atrybutu = Atrybut.IndexOf(BiezacyAtrybut);
                                Atrybut[index_atrybutu] = atrybut;
                                index_atrybutu = -1;
                                System.Windows.MessageBox.Show(edit);
                            }
                        }
                        ,
                        arg => (BiezacyAtrybut != null&&idZaznaczenia==-1)
                        );


                return edytuj;
            }
        }
        public ICommand Zaladuj_Atrybut
        {
            get
            {
                if (zaladuj_atrybut == null)
                {
                    zaladuj_atrybut = new RelayCommand(
                        arg =>
                        {
                            if (BiezacyAtrybut != null)
                            {
                                IdZaznaczenia = -1;
                                id_gry = int.Parse(BiezacyAtrybut.ZwrocID());
                                Singleplayer = int.Parse(BiezacyAtrybut.ZwrocSingleplayer());
                                Multiplayer = int.Parse(BiezacyAtrybut.ZwrocMultiplayer());
                                Fps = int.Parse(BiezacyAtrybut.ZwrocFPS());
                                Openworld = int.Parse(BiezacyAtrybut.ZwrocOpenWorld());
                                Fabularna = int.Parse(BiezacyAtrybut.ZwrocFabularna());
                                Strategia = int.Parse(BiezacyAtrybut.ZwrocStrategia());
                                Rpg = int.Parse(BiezacyAtrybut.ZwrocRPG());
                                Roguelike = int.Parse(BiezacyAtrybut.ZwrocRogueLike());
                                Akcja = int.Parse(BiezacyAtrybut.ZwrocAkcja());
                                Puzzle = int.Parse(BiezacyAtrybut.ZwrocPuzzle());
                                Symulacja = int.Parse(BiezacyAtrybut.ZwrocSymulacja());
                                Horror = int.Parse(BiezacyAtrybut.ZwrocHorror());
                                Przygodowa = int.Parse(BiezacyAtrybut.ZwrocPrzygodowa());
                            }

                        }
                        ,

                        arg => true);
                }
                return zaladuj_atrybut;

            }
        }
        public List<string> NazwaAtrybutow
        {
            get { return nazwyatrybutow; }
        }
        public int Nazwaatrybutu
        {
            get { return nazwaatrybutu; }
            set
            {
                nazwaatrybutu = value;
                Filtr = 0;
                Filtr2 = 100;
                OnPropertyChanged(nameof(Nazwaatrybutu));
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
            FiltrujTypyAtrybuty = CollectionViewSource.GetDefaultView(atrybut);
            FiltrujTypyAtrybuty.Filter = FiltrAtrybuty;
        }
        public Atrybut BiezacyAtrybut{ get; set; }

        public int Filtr
        {
            get
            {
                return filtr;
            }
            set
            {
                filtr = value;
                OnPropertyChanged(nameof(Filtr));
                FiltrujTypyAtrybuty.Refresh();
            }
        }
        public int Filtr2
        {
            get
            {
                return filtr2;
            }
            set
            {
                filtr2 = value;
                OnPropertyChanged(nameof(Filtr2));
                FiltrujTypyAtrybuty.Refresh();
            }
        }
        private bool FiltrAtrybuty(object obj)
        {
            if (obj is Atrybut atrybut)
            {
                if (nazwaatrybutu == -1) return true;
                if (nazwaatrybutu == 0) if (atrybut.Single_Player >= filtr && atrybut.Single_Player <= filtr2) return true;
                if (nazwaatrybutu == 1) if (atrybut.Multiplayer >= filtr && atrybut.Multiplayer <= filtr2) return true;
                if (nazwaatrybutu == 2) if (atrybut.FPS >= filtr && atrybut.FPS <= filtr2) return true;
                if (nazwaatrybutu == 3) if (atrybut.Open_World >= filtr && atrybut.Open_World <= filtr2) return true;
                if (nazwaatrybutu == 4) if (atrybut.Fabularna >= filtr && atrybut.Fabularna <= filtr2) return true;
                if (nazwaatrybutu == 5) if (atrybut.Strategia >= filtr && atrybut.Strategia <= filtr2) return true;
                if (nazwaatrybutu == 6) if (atrybut.RPG >= filtr && atrybut.RPG <= filtr2) return true;
                if (nazwaatrybutu == 7) if (atrybut.RogueLike >= filtr && atrybut.RogueLike <= filtr2) return true;
                if (nazwaatrybutu == 8) if (atrybut.Akcja >= filtr && atrybut.Akcja <= filtr2) return true;
                if (nazwaatrybutu == 9) if (atrybut.Puzzle >= filtr && atrybut.Puzzle <= filtr2) return true;
                if (nazwaatrybutu == 10) if (atrybut.Symulacja >= filtr && atrybut.Symulacja <= filtr2) return true;
                if (nazwaatrybutu == 11) if (atrybut.Horror >= filtr && atrybut.Horror <= filtr2) return true;
                if (nazwaatrybutu == 12) if (atrybut.Przygodowa >= filtr && atrybut.Przygodowa <= filtr2) return true;
                return false;
            }
            return false;
        }
        private void CzyscFormularz()
        {
            idZaznaczenia = -1;
            niemaidnazwa.Remove(nazwa_gry);
            Singleplayer = 0;
            Multiplayer = 0;
            Fps = 0;
            Openworld = 0;
            Fabularna = 0;
            Strategia = 0;
            Rpg = 0;
            Roguelike = 0;
            Akcja = 0;
            Puzzle = 0;
            Symulacja = 0;
            Horror = 0;
            Przygodowa = 0;
        }
        private void WyczyszczonyFormularz()
        {
            Singleplayer = 0;
            Multiplayer = 0;
            Fps = 0;
            Openworld = 0;
            Fabularna = 0;
            Strategia = 0;
            Rpg = 0;
            Roguelike = 0;
            Akcja = 0;
            Puzzle = 0;
            Symulacja = 0;
            Horror = 0;
            Przygodowa = 0;
        }
        private void CzyscFormularzEdit()
        {
            niemaidnazwa.Add(nazwa_gry);
            IdZaznaczenia = -1;
            Singleplayer = 0;
            Multiplayer = 0;
            Fps = 0;
            Openworld = 0;
            Fabularna = 0;
            Strategia = 0;
            Rpg = 0;
            Roguelike = 0;
            Akcja = 0;
            Puzzle = 0;
            Symulacja = 0;
            Horror = 0;
            Przygodowa = 0;
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
                WyczyszczonyFormularz();
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
