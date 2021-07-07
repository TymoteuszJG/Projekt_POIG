using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poig.ViewModel
{
    using Model;
    using Model.DAL;
    class AtrybutViewModel
    {
        private DataAccess dataAccess;
        public ObservableCollection<Atrybut> Atrybuty { get { return dataAccess.GetAllAtrybuty(); } }//= new [] { new Country("1", "2", 1),new Country("A","B",1) };

        public AtrybutViewModel()
        {
            dataAccess = new DataAccess();

        }
    }
}