using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace PizzariaDesktop.Models
{
    [Table("ingredients")]
    internal class Ingredient : ObservableObject
    {
        #region fields
        private string _name = string.Empty;
        private double _price;
        private int _amount;
        private string _unit = string.Empty;
        #endregion

        #region properties
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        [Column("price")]
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        [Column("amount")]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }

        [Column("unit")]
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; OnPropertyChanged(); }
        }


        public ICollection<PizzaIngredient>? PizzaIngredients { get; set; }

        [NotMapped]
        public string FullIngredientLine => $"{Amount} {Unit} {Name}";

        #endregion
    }
}
