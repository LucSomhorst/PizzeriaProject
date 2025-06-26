using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDesktop.Models
{
    [Table("pizzas")]
    class Pizza:ObservableObject
    {
        #region fields
        private string _name= string.Empty;
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

        public ICollection<PizzaIngredient>? PizzaIngredients { get; set; }

        public ICollection<OrderLine>? OrderLines { get; set; }
        #endregion
    }
}
