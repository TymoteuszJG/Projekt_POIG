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
        private ObservableCollection<Atrybut> atrybut= null;

        public AtrybutViewModel(Model model)
        {
            this.model = model;
            atrybut = model.Atrybuty;
        }
        public Atrybut BiezacyAtrybut{ get; set; }
        public ObservableCollection<Atrybut> Atrybut
        {
            get { return atrybut; }
            set
            {
                atrybut = value;
                OnPropertyChanged(nameof(Atrybut));
            }
        }
        public void OdswiezAtrybuty() => Atrybut = model.Atrybuty;
    }
}
