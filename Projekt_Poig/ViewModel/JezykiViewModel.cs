using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_Poig.Properties.Lang;

namespace Projekt_Poig.ViewModel
{
    using BaseClass;
    using System.Windows.Input;
    class JezykiViewModel : ViewModelBase
    {
        
        private List<string> zdjecie = new List<string> { "/Projekt_Poig;component/Images/pol.jpg", "/Projekt_Poig;component/Images/usa.jpg" };
        private int index = -1;
        public string jezyk = "pl-PL";
        private string flaga = Lang.Flag;
        private ICommand zmien = null;
        public ICommand Zmien
        {

            get
            {
                if (zmien == null)
                    zmien = new RelayCommand(
                        arg =>
                        {
                            
                            Jezyk(index);
                            App.ChangeCulture(jezyk);
                            
                           

                        }
                        ,
                        arg => true
                        );


                return zmien;
            }

        }
        public string Jezyk(int id)
        {
            if (id == 0) jezyk = "pl-PL";
            if (id == 1) jezyk = "en-US";
            return jezyk;
        }


        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
            }

        }
        public List<string> Zdjecie
        {
            get { return zdjecie; }
            set
            {
                zdjecie = value;
                OnPropertyChanged(nameof(Zdjecie));
            }
        }

        public int FlagChange(string change)
        {
            if(change == "flaga")
            {
                index = 0;
                return 0;
            }

            if (change == "flag")
            {
                index = 1;
                return 1;
            }
            return -1;

        }
        public JezykiViewModel() { FlagChange(flaga); }
    }
}
