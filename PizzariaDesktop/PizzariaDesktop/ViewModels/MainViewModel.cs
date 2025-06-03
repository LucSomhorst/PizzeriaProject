using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzariaDesktop.Helpers;
using PizzariaDesktop.Models;

namespace PizzariaDesktop.ViewModels
{
    internal class MainViewModel : ObservableObject, IAppNavigation
    {
        #region fields
        private object _activeViewModel;
        #endregion
        #region properties
        public UserMessage UserMessage
        {
            get;
        }
        public object ActiveViewModel
        {
            get { return _activeViewModel; }
            set { _activeViewModel = value; OnPropertyChanged(); }
        }
        #endregion
        #region constructors
#pragma warning disable CS8618
        public MainViewModel()
#pragma warning restore CS8618
        {

        }
        public MainViewModel(UserMessage userMessage)
        {
            UserMessage = userMessage;
            _activeViewModel = new ContactInfoViewModel(userMessage);
            ShowContactInfoCommand = new RelayCommand(ExecuteShowContactInfo);
        }
        #endregion
        #region commands
        public ICommand ShowContactInfoCommand { get; }
        #endregion
        #region methods
        private void ExecuteShowContactInfo(object? obj)
        {
            ActiveViewModel = new ContactInfoViewModel();
        }
        #endregion
    }
}
