using Microsoft.EntityFrameworkCore;
using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace PizzariaDesktop.Models
{
    [Table("ingredient_pizza")]
    [Index(nameof(PizzaId), nameof(IngredientId), IsUnique = true)]
    internal class PizzaIngredient : ObservableObject
    {
        #region fields
        private int _pizzaId;
        private Pizza? _pizza;
        private int _ingredientId;
        private Ingredient? _ingredient;
        #endregion

        #region properties
        [Column("pizza_id")]
        public int PizzaId
        {
            get { return _pizzaId; }
            set { _pizzaId = value; OnPropertyChanged(); }
        }
        public Pizza? Pizza
        {
            get { return _pizza; }
            set { _pizza = value; OnPropertyChanged(); }
        }

        [Column("ingredient_id")]
        public int IngredientId
        {
            get { return _ingredientId; }
            set { _ingredientId = value; OnPropertyChanged(); }
        }
        public Ingredient? Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
