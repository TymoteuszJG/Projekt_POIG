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
    class TypyGierViewModel:ViewModelBase
    {
        private Model model = null;
        private ObservableCollection<TypyGier> typygier= null;
        public ICollectionView FiltrujTypyGier { get; }
        private string filtr = string.Empty;

        public TypyGierViewModel(Model model)
        {
            this.model = model;
            typygier = model.TypyGry;
            FiltrujTypyGier = CollectionViewSource.GetDefaultView(typygier);
            FiltrujTypyGier.Filter = FiltrTypowGier;
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
                FiltrujTypyGier.Refresh();
            }
        }
        public ObservableCollection<TypyGier> Typypgier
        {
            get { return typygier; }
            set
            {
                typygier = value;
                OnPropertyChanged(nameof(Typypgier));
            }
        }
        private bool FiltrTypowGier(object obj)
        {
            if (obj is TypyGier typgry)
            {
                return typgry.Nazwa_gracza.ToLower().Contains(Filtr.ToLower()) || typgry.Nazwa_gry.ToLower().Contains(Filtr.ToLower());
            }
            return false;
        }
    }
}
