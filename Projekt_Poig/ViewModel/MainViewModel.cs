using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poig.ViewModel
{
    using Model;
    using Model.Dal;
    class MainViewModel
    {
        private DataAccess dataAccess;

        public List<Gry> Games 
        { 
            get 
            {
                return dataAccess.GetAllGames(); 
            } 
        }
        public MainViewModel()
        {
            dataAccess = new DataAccess();
        }
    }
}
