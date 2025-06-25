using PizzariaDesktop.Database;
using PizzariaDesktop.Helpers;
using PizzariaDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using System.Windows.Input;

namespace PizzariaDesktop.ViewModels
{
    internal class IngredientUpdateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public IngredientUpdateViewModel(IAppNavigation appNavigation, UserMessage userMessage, Ingredient ingredient)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);

            Ingredient = ingredient;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IngredientUpdateViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public Ingredient Ingredient { get; }
        #endregion

        #region commands
        public ICommand CancelCommand { get; }
        public ICommand StoreCommand { get; }
        #endregion

        #region methods
        private void ExecuteCancel(object? obj)
        {
            _appNavigation.ActiveViewModel = new IngredientIndexViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteStore(object? obj)
        {
            return string.IsNullOrEmpty(Ingredient.Name) == false
                && Ingredient.Price >= 0
                && Ingredient.Amount >= 0
                && string.IsNullOrEmpty(Ingredient.Unit) == false;
        }

        private void ExecuteStore(object? obj)
        {
            using AppDbContext db = new();
            Ingredient? ingredientInDb = db.Ingredients.FirstOrDefault(x => x.Id == Ingredient.Id);
            if (ingredientInDb == null)
            {
                _userMessage.Text = "Ingredient bestaat niet meer en wordt niet bijgewerkt";
                _appNavigation.ActiveViewModel = new IngredientIndexViewModel(_appNavigation, _userMessage);
                return;
            }

            if (ingredientInDb.Name != Ingredient.Name)
            {
                ingredientInDb.Name = Ingredient.Name;
                db.SaveChanges();
            }

            if (ingredientInDb.Price != Ingredient.Price)
            {
                ingredientInDb.Price = Ingredient.Price;
                db.SaveChanges();
            }

            if (ingredientInDb.Amount != Ingredient.Amount)
            {
                ingredientInDb.Amount = Ingredient.Amount;
                db.SaveChanges();
            }

            if (ingredientInDb.Unit != Ingredient.Unit)
            {
                ingredientInDb.Unit = Ingredient.Unit;
                db.SaveChanges();
            }

            _appNavigation.ActiveViewModel = new IngredientCreateViewModel(_appNavigation, _userMessage);
        }
        #endregion
    }
}
