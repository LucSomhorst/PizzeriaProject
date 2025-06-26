using PizzariaDesktop.Database;
using PizzariaDesktop.Helpers;
using PizzariaDesktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzariaDesktop.ViewModels
{
    internal class PizzaIndexViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public PizzaIndexViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CreatePizzaCommand = new RelayCommand(ExecuteCreatePizza);
            UpdatePizzaCommand = new RelayCommand(ExecuteUpdatePizza, CanExecuteUpdatePizza);
            DeletePizzaCommand = new RelayCommand(ExecuteDeletePizza, CanExecuteDeletePizza);

            using AppDbContext db = new();
            Pizzas = new(db.Pizzas.OrderBy(x => x.Name).Include(x => x.Ingredients));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public PizzaIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Pizza> Pizzas { get; set; }
        #endregion

        #region commands
        public ICommand CreatePizzaCommand { get; }
        public ICommand UpdatePizzaCommand { get; }
        public ICommand DeletePizzaCommand { get; }
        #endregion

        #region methods
        private void ExecuteCreatePizza(object? obj)
        {
            _appNavigation.ActiveViewModel = new PizzaCreateViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteUpdatePizza(object? obj)
        {
            return obj is Pizza;
        }

        private void ExecuteUpdatePizza(object? obj)
        {
            if (obj is Pizza Pizza)
            {
                _appNavigation.ActiveViewModel =
                    new PizzaUpdateViewModel(_appNavigation, _userMessage, Pizza);
            }
        }

        private bool CanExecuteDeletePizza(object? obj)
        {
            return obj is Pizza;
        }

        private void ExecuteDeletePizza(object? obj)
        {
            if (obj is Pizza Pizza)
            {
                using AppDbContext db = new();
                Pizza? PizzaInDb = db.Pizzas.FirstOrDefault(x => x.Id == Pizza.Id);
                if (PizzaInDb != null)
                {
                    db.Pizzas.Remove(PizzaInDb);
                    db.SaveChanges();
                }
                Pizzas.Remove(Pizza);
            }
        }
        #endregion
    }
}
