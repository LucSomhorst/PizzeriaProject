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


            ShowIngredientsIndexCommand = new RelayCommand(ExecuteShowIngredientsIndex);
            ShowOrdersIndexCommand = new RelayCommand(ExecuteShowOrdersIndex);
            ShowPizzasIndexCommand = new RelayCommand(ExecuteShowPizzasIndex);
            ShowContactInfoCommand = new RelayCommand(ExecuteShowContactInfo);
        }
        #endregion

        #region commands
        public ICommand ShowIngredientsIndexCommand { get; }
        public ICommand ShowOrdersIndexCommand { get; }
        public ICommand ShowPizzasIndexCommand { get; }
        public ICommand ShowContactInfoCommand { get; }
        #endregion

        #region methods

        private void ExecuteShowIngredientsIndex(object? obj)
        {
            ActiveViewModel = new IngredientIndexViewModel(this, UserMessage);
        }

        private void ExecuteShowOrdersIndex(object? obj)
        {
            ActiveViewModel = new OrderIndexViewModel(this, UserMessage);
        }

        private void ExecuteShowPizzasIndex(object? obj)
        {
            ActiveViewModel = new PizzaIndexViewModel(this, UserMessage);
        }

        private void ExecuteShowContactInfo(object? obj)
        {
            ActiveViewModel = new ContactInfoViewModel();
        }
        #endregion
    }
}
