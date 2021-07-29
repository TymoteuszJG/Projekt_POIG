using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Resources;

namespace Projekt_Poig.ViewModel
{
    using BaseClass;
    using Model;
    using System.Globalization;

    class LangViewModel : ViewModelBase
    {

        private ICommand m_pushMeCommand;
        private SynchronizationContext syncCtx;


        public LangViewModel()
        {
            syncCtx = SynchronizationContext.Current;

            if (Language == null)
            {
                Language = new ObservableCollection<string>();
            }
            Language.Clear();
            Language.Add("PL");
        }

        public ObservableCollection<string> Language { get; set; }

        public string SelectedLanguage
        {
            get { return Language[0].ToString(); }
        }

        public ICommand PushMe
        {
            get
            {
                if (m_pushMeCommand == null)
                {
                    m_pushMeCommand = new RelayCommand(
                        (g) => ChangeLanguage(g)
                    );
                }

                SendPropertyChanged("ChangeLanguage");

                return m_pushMeCommand;
            }
        }

        private void SendPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangeLanguage(object param)
        {
            var language = param as string;
            CultureInfo culture = null;

            if (Language == null)
            {
                Language = new ObservableCollection<string>();
            }

            Language.Clear();

            switch (language)
            {
                case "PL":
                    Language.Add("PL");
                    culture = new CultureInfo("pl-PL");
                    break;
                case "EN":
                    Language.Add("EN");
                    culture = new CultureInfo("en-EN");
                    break;
                default:
                    break;
            }

            if (culture != null)
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            SendPropertyChanged("SelectedLanguage");
        }

    }
}
