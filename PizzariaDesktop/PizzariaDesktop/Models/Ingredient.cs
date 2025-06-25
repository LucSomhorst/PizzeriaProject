using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDesktop.Models
{
    internal class Ingredient : ObservableObject
    {
        #region fields
        private string _name = string.Empty;
        private double _price;
        private int _amount;
        private string _unit = string.Empty;
        #endregion

        #region properties
        [Key]
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; OnPropertyChanged(); }
        }


        public ICollection<Pizza> Pizzas { get; set; }
        #endregion
    }
}
