using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.IO;
using PizzariaDesktop.Helpers;
using PizzariaDesktop.Models;

namespace PizzariaDesktop.ViewModels
{
    internal class ContactInfoViewModel : ObservableObject
    {
        #region fields
        private string _naam;
        private string _telefoon;
        private UserMessage _userMessage;
        private string _email;
        #endregion
        #region properties
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; OnPropertyChanged(); }
        }
        public string Telefoon
        {
            get { return _telefoon; }
            set { _telefoon = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        #endregion
        #region constructors
#pragma warning disable CS8618
        public ContactInfoViewModel()
#pragma warning restore CS8618
        {

        }
        public ContactInfoViewModel(UserMessage userMessage)
        {
            _userMessage = userMessage;
            _naam = "Luc van der Putten";
            _telefoon = "+3106123456789";
            _email = "PS267850@summacollege.nl";
        }
        #endregion
        #region commands
        #endregion
        #region methods

        #endregion
    }
}
