using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDesktop.Models
{
    [Table("orders")]
    class Order:ObservableObject
    {
        #region fields
        private DateTime _date;
        private OrderStatus _status;
        #endregion

        #region properties
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        [Column("status")]
        public OrderStatus Status 
        { 
            get { return _status; } 
            set { _status = value; OnPropertyChanged(); }
        }

        public ICollection<OrderLine> OrderLines { get; set; }
        #endregion
    }
}
