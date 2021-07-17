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

        public GryViewModel(Model model)
        {
            this.model = model;
            gra = model.Gry;
        }
        public Atrybut BiezacaGra { get; set; }
        public ObservableCollection<Gra> Gra
        {
            get { return gra; }
            set
            {
                gra = value;
                OnPropertyChanged(nameof(Gra));
            }
        }
        public void OdswiezGry() => Gra = model.Gry;

    }
}
