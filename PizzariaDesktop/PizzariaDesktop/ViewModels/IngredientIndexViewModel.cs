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

            CreateIngredientCommand = new RelayCommand(ExecuteCreateIngredient);
            UpdateIngredientCommand = new RelayCommand(ExecuteUpdateIngredient, CanExecuteUpdateIngredient);
            DeleteIngredientCommand = new RelayCommand(ExecuteDeleteIngredient, CanExecuteDeleteIngredient);

            using AppDbContext db = new();
            Ingredients = new(db.Ingredients.OrderBy(x => x.Name));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IngredientIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        #endregion

        #region commands
        public ICommand CreateIngredientCommand { get; }
        public ICommand UpdateIngredientCommand { get; }
        public ICommand DeleteIngredientCommand { get; }
        #endregion

        #region methods
        private void ExecuteCreateIngredient(object? obj)
        {
            _appNavigation.ActiveViewModel = new IngredientCreateViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteUpdateIngredient(object? obj)
        {
            return obj is Ingredient;
        }

        private void ExecuteUpdateIngredient(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                _appNavigation.ActiveViewModel = new IngredientUpdateViewModel(_appNavigation, _userMessage, ingredient);
            }
        }

        private bool CanExecuteDeleteIngredient(object? obj)
        {
            return obj is Ingredient;
        }

        private void ExecuteDeleteIngredient(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                using AppDbContext db = new();
                Ingredient? ingredientInDb = db.Ingredients.FirstOrDefault(x => x.Id == ingredient.Id);
                if (ingredientInDb != null)
                {
                    db.Ingredients.Remove(ingredientInDb);
                    db.SaveChanges();
                }
                Ingredients.Remove(ingredient);
            }
        }
        #endregion
    }
}
