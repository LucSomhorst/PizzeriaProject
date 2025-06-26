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
    internal class OrderUpdateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public OrderUpdateViewModel(IAppNavigation appNavigation, UserMessage userMessage, Order order)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);

            Order = order;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public OrderUpdateViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public Order Order { get; }
        #endregion

        #region commands
        public ICommand CancelCommand { get; }
        public ICommand StoreCommand { get; }
        #endregion

        #region methods
        private void ExecuteCancel(object? obj)
        {
            _appNavigation.ActiveViewModel = new OrderIndexViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteStore(object? obj)
        {
            return true;
        }

        private void ExecuteStore(object? obj)
        {
            using AppDbContext db = new();
            Order? OrderInDb = db.Orders.FirstOrDefault(x => x.Id == Order.Id);
            if (OrderInDb == null)
            {
                _userMessage.Text = "Order bestaat niet meer en wordt niet bijgewerkt";
                _appNavigation.ActiveViewModel = new OrderIndexViewModel(_appNavigation, _userMessage);
                return;
            }

            if (OrderInDb.Status != Order.Status)
            {
                OrderInDb.Status = Order.Status;
                db.SaveChanges();
            }

            _appNavigation.ActiveViewModel = new OrderIndexViewModel(_appNavigation, _userMessage);
        }
        #endregion
    }
}
