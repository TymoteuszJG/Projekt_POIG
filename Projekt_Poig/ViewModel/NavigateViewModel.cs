using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_Poig.ViewModel.BaseClass;
using System.Windows.Input;
using Projekt_Poig.Commands;

namespace Projekt_Poig.ViewModel
{
    using Projekt_Poig.Model;
    class NavigateViewModel : ViewModelBase
    {
        public ICommand NavigateGryCommand { get; }
        public ICommand NavigateAtrybutyCommand { get; }
        public ICommand NavigateTypyCommand { get; }
        public ICommand NavigateTypyGierCommand { get; }

        private readonly Navigation _navigation;

        private Model model = new Model();

        public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;
        public NavigateViewModel(Navigation navigation)
        {
            NavigateGryCommand = new NavigateCommand<GryViewModel>(navigation, () => new GryViewModel(model));
            NavigateAtrybutyCommand = new NavigateCommand<AtrybutViewModel>(navigation, () => new AtrybutViewModel(model));
            NavigateTypyCommand = new NavigateCommand<TypyViewModel>(navigation, () => new TypyViewModel(model));
            NavigateTypyGierCommand = new NavigateCommand<TypyGierViewModel>(navigation, () => new TypyGierViewModel(model));
            _navigation = navigation;
            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged()
        {
            
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}