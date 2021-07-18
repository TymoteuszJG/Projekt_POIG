using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_Poig.ViewModel.BaseClass;

namespace Projekt_Poig.Commands
{
    class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly Navigation _navigation;
        private readonly Func<TViewModel> _createViewModel;
        public NavigateCommand(Navigation navigation, Func<TViewModel> createViewModel)
        {
            _navigation = navigation;
            _createViewModel = createViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = _createViewModel();
        }
    }
}