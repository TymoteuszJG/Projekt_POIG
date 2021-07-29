using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_Poig.ViewModel.BaseClass;
using Projekt_Poig.Commands;
using System.Windows.Input;

namespace Projekt_Poig.ViewModel
{
    using Projekt_Poig.Model;
    using DAL;
    class MainViewModel : ViewModelBase
    {
        private Model model = new Model();
        private Navigation navigation = new Navigation();

        public AtrybutViewModel AtrybutVM { get; set; }
        public GryViewModel GraVM { get; set; }
        public TypyViewModel TypVM { get; set; }
        public TypyGierViewModel TypyGierVM { get; set; }
        public NavigateViewModel NavigateVM { get; set; }
        public MainViewModel()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            AtrybutVM = new AtrybutViewModel(model);
            GraVM = new GryViewModel(model);
            TypVM = new TypyViewModel(model);
            TypyGierVM = new TypyGierViewModel(model);
            NavigateVM = new NavigateViewModel(navigation);
        }
    }
}
