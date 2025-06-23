using PizzariaDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PizzariaDesktop.Models
{
    class Customer: ObservableObject
    {
        #region fields
        private string _name = string.Empty;
        private string _adres = string.Empty;
        private string _city = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _email = string.Empty;
        #endregion
        #region properties
        [Key]
        public int Id { get; set; }
        [StringLength(45), Column("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        [StringLength(45), Column("adres")]
        public string Adres
        {
            get { return _adres; }
            set { _adres = value; OnPropertyChanged(); }
        }
        [StringLength(45), Column("city")]
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
            
        }
        #endregion
    }
}
