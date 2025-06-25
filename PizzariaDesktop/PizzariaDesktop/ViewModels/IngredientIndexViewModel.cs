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
    internal class IngredientIndexViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public IngredientIndexViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CreateingredientCommand = new RelayCommand(ExecuteCreateingredient);
            UpdateingredientCommand = new RelayCommand(ExecuteUpdateingredient, CanExecuteUpdateingredient);
            DeleteingredientCommand = new RelayCommand(ExecuteDeleteingredient, CanExecuteDeleteingredient);

            using AppDbContext db = new();
            ingredients = new(db.ingredients.OrderBy(x => x.Name));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IngredientIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Ingredient> ingredients { get; set; }
        #endregion

        #region commands
        public ICommand CreateingredientCommand { get; }
        public ICommand UpdateingredientCommand { get; }
        public ICommand DeleteingredientCommand { get; }
        #endregion

        #region methods
        private void ExecuteCreateingredient(object? obj)
        {
            //_appNavigation.ActiveViewModel = new ingredientCreateViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteUpdateingredient(object? obj)
        {
            return obj is Ingredient;
        }

        private void ExecuteUpdateingredient(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                //_appNavigation.ActiveViewModel = new ingredientUpdateViewModel(_appNavigation, _userMessage, ingredient);
            }
        }

        private bool CanExecuteDeleteingredient(object? obj)
        {
            return obj is Ingredient;
        }

        private void ExecuteDeleteingredient(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                using AppDbContext db = new();
                Ingredient? ingredientInDb = db.ingredients.FirstOrDefault(x => x.Id == ingredient.Id);
                if (ingredientInDb != null)
                {
                    db.ingredients.Remove(ingredientInDb);
                    db.SaveChanges();
                }
                ingredients.Remove(ingredient);
            }
        }
        #endregion
    }
}
