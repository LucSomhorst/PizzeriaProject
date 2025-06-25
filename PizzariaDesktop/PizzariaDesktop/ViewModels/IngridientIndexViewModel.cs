using PizzariaDesktop.Database;
using PizzariaDesktop.Helpers;
using PizzariaDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzariaDesktop.ViewModels
{
    internal class IngridientIndexViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public IngridientIndexViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CreateIngridientCommand = new RelayCommand(ExecuteCreateIngridient);
            UpdateIngridientCommand = new RelayCommand(ExecuteUpdateIngridient, CanExecuteUpdateIngridient);
            DeleteIngridientCommand = new RelayCommand(ExecuteDeleteIngridient, CanExecuteDeleteIngridient);

            using AppDbContext db = new();
            Ingridients = new(db.Ingridients.OrderBy(x => x.Name));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IngridientIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Ingridient> Ingridients { get; set; }
        #endregion

        #region commands
        public ICommand CreateIngridientCommand { get; }
        public ICommand UpdateIngridientCommand { get; }
        public ICommand DeleteIngridientCommand { get; }
        #endregion

        #region methods
        private void ExecuteCreateIngridient(object? obj)
        {
            //_appNavigation.ActiveViewModel = new IngridientCreateViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteUpdateIngridient(object? obj)
        {
            return obj is Ingridient;
        }

        private void ExecuteUpdateIngridient(object? obj)
        {
            if (obj is Ingridient ingridient)
            {
                //_appNavigation.ActiveViewModel = new IngridientUpdateViewModel(_appNavigation, _userMessage, ingridient);
            }
        }

        private bool CanExecuteDeleteIngridient(object? obj)
        {
            return obj is Ingridient;
        }

        private void ExecuteDeleteIngridient(object? obj)
        {
            if (obj is Ingridient ingridient)
            {
                using AppDbContext db = new();
                Ingridient? ingridientInDb = db.Ingridients.FirstOrDefault(x => x.Id == ingridient.Id);
                if (ingridientInDb != null)
                {
                    db.Ingridients.Remove(ingridientInDb);
                    db.SaveChanges();
                }
                Ingridients.Remove(ingridient);
            }
        }
        #endregion
    }
}
