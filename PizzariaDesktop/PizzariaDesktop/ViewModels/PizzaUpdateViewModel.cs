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
    internal class PizzaUpdateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public PizzaUpdateViewModel(IAppNavigation appNavigation, UserMessage userMessage, Pizza pizza)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);
            VoegToeAanPizzaCommand = new RelayCommand(ExecuteVoegToeAanPizza);
            VerwijderVanPizzaCommand = new RelayCommand(ExecuteVerwijderVanPizza);

            Pizza = pizza;

            using AppDbContext db = new();
            List<PizzaIngredient> PizzaIngredients = new(db.PizzaIngredients.Include(x => x.Ingredient).Where(x => x.PizzaId == Pizza.Id));

            IngredientsOpPizza = [];
            foreach (var ingredient in PizzaIngredients.OrderBy(x => x.Ingredient.Name))
            {
                IngredientsOpPizza.Add(ingredient.Ingredient);
            }

            IngredientsNietOpPizza = new(db.Ingredients.OrderBy(x => x.Name));
            foreach (var ingredient in IngredientsOpPizza)
            {
                Ingredient? x = IngredientsNietOpPizza.FirstOrDefault(x => x.Id == ingredient.Id);
                if (x != null)
                {
                    IngredientsNietOpPizza.Remove(x);
                }
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public PizzaUpdateViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public Pizza Pizza { get; }
        public ObservableCollection<Ingredient> IngredientsOpPizza { get; }
        public ObservableCollection<Ingredient> IngredientsNietOpPizza { get; }
        #endregion

        #region commands
        public ICommand CancelCommand { get; }
        public ICommand StoreCommand { get; }
        public ICommand VoegToeAanPizzaCommand { get; }
        public ICommand VerwijderVanPizzaCommand { get; }
        #endregion

        #region methods
        private void ExecuteCancel(object? obj)
        {
            _appNavigation.ActiveViewModel = new PizzaIndexViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteStore(object? obj)
        {
            return string.IsNullOrEmpty(Pizza.Name) == false;
        }

        private void ExecuteStore(object? obj)
        {
            using AppDbContext db = new();
            Pizza? PizzaInDb = db.Pizzas.FirstOrDefault(x => x.Id == Pizza.Id);
            if (PizzaInDb == null)
            {
                _userMessage.Text = "Pizza bestaat niet meer en wordt niet bijgewerkt";
                _appNavigation.ActiveViewModel = new PizzaIndexViewModel(_appNavigation, _userMessage);
                return;
            }

            if (PizzaInDb.Name != Pizza.Name)
            {
                PizzaInDb.Name = Pizza.Name;
                db.SaveChanges();
            }

            List<PizzaIngredient> PizzaIngredientsInDb = db.PizzaIngredients.Where(x => x.PizzaId == Pizza.Id).ToList();

            foreach (var PizzaIngredientInDb in PizzaIngredientsInDb)
            {
                if (IngredientsOpPizza.FirstOrDefault(x => x.Id == PizzaIngredientInDb.IngredientId) == null)
                {
                    db.PizzaIngredients.Remove(PizzaIngredientInDb);
                    db.SaveChanges();
                }
            }

            foreach (var ingredient in IngredientsOpPizza)
            {
                if (PizzaIngredientsInDb.FirstOrDefault(x => x.IngredientId == ingredient.Id) == null)
                {
                    db.PizzaIngredients.Add(new()
                    {
                        IngredientId = ingredient.Id,
                        PizzaId = Pizza.Id
                    });
                    db.SaveChanges();
                }
            }

            _appNavigation.ActiveViewModel = new PizzaIndexViewModel(_appNavigation, _userMessage);
        }

        private void ExecuteVoegToeAanPizza(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                IngredientsNietOpPizza.Remove(ingredient);
                IngredientsOpPizza.Add(ingredient);
            }
        }

        private void ExecuteVerwijderVanPizza(object? obj)
        {
            if (obj is Ingredient ingredient)
            {
                IngredientsOpPizza.Remove(ingredient);
                IngredientsNietOpPizza.Add(ingredient);
            }
        }
        #endregion
    }
}
