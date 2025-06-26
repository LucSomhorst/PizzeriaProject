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
    internal class OrderIndexViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public OrderIndexViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            UpdateOrderCommand = new RelayCommand(ExecuteUpdateOrder, CanExecuteUpdateOrder);
            DeleteOrderCommand = new RelayCommand(ExecuteDeleteOrder, CanExecuteDeleteOrder);

            using AppDbContext db = new();
            Orders = new(db.Orders.OrderBy(x => x.Id).Include(x => x.OrderLines));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public OrderIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Order> Orders { get; set; }
        #endregion

        #region commands
        public ICommand UpdateOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }
        #endregion

        #region methods
        private bool CanExecuteUpdateOrder(object? obj)
        {
            return obj is Order;
        }

        private void ExecuteUpdateOrder(object? obj)
        {
            if (obj is Order order)
            {
                _appNavigation.ActiveViewModel =
                    new OrderUpdateViewModel(_appNavigation, _userMessage, order);
            }
        }

        private bool CanExecuteDeleteOrder(object? obj)
        {
            return obj is Order;
        }

        private void ExecuteDeleteOrder(object? obj)
        {
            if (obj is Order order)
            {
                using AppDbContext db = new();
                Order? OrderInDb = db.Orders.FirstOrDefault(x => x.Id == order.Id);
                if (OrderInDb != null)
                {
                    db.Orders.Remove(OrderInDb);
                    db.SaveChanges();
                }
                Orders.Remove(order);
            }
        }
        #endregion
    }
}
