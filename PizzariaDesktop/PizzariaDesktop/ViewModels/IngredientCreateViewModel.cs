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
    internal class IngredientCreateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public ingredientCreateViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);

            ingredient = new();
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ingredientCreateViewModel()
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
            db.Ingredients.Add(Ingredient);
            db.SaveChanges();

            _appNavigation.ActiveViewModel = new IngredientIndexViewModel(_appNavigation, _userMessage);
        }
        #endregion
    }
}
