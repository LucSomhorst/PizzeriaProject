using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaDesktop.Models
{
    class OrderLine:ObservableObject
    {
        #region fields
        private int _amount;
        private PizzaSize _size;
        #endregion
        #region properties
        [Key]
        public int Id { get; set; }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }

        public PizzaSize Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged(); }
        }
        

        #endregion
    }
}
