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
    [Table("orderlines")]
    class OrderLine:ObservableObject
    {
        #region fields
        private int _amount;
        private PizzaSize _size;
        private int _pizzaId;
        private Pizza _pizza = new();
        private int _orderId;
        private Order _order = new();
        #endregion

        #region properties
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("amount")]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }

        [Column("size")]
        public PizzaSize Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged(); }
        }

        [Column("pizza_id")]
        public int PizzaId
        {
            get { return _pizzaId; }
            set { _pizzaId = value; OnPropertyChanged(); }
        }

        public Pizza Pizza
        {
            get { return _pizza; }
            set { _pizza = value; OnPropertyChanged(); }
        }

        [Column("order_id")]
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; OnPropertyChanged(); }
        }

        public Order Order
        {
            get { return _order; }
            set { _order = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
