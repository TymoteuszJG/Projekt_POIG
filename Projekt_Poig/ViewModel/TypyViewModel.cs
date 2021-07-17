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

        public TypyViewModel(Model model)
        {
            this.model = model;
            typ = model.Typy;
        }
        public Atrybut BiezacyTyp { get; set; }
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