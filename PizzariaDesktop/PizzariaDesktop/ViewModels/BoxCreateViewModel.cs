using Eindopdracht.Databases;
using Eindopdracht.Helpers;
using Eindopdracht.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eindopdracht.ViewModels
{
    internal class BoxCreateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public BoxCreateViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);
            VoegToeAanBoxCommand = new RelayCommand(ExecuteVoegToeAanBox);
            VerwijderUitBoxCommand = new RelayCommand(ExecuteVerwijderUitBox);

            Box = new();
            ItemsVanBox = [];

            using AppDbContext db = new();
            ItemsNietVanBox = new(db.Items.OrderBy(x => x.Name));
            Rooms = new(db.Rooms.OrderBy(x => x.Name));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BoxCreateViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public Box Box { get; }
        public ObservableCollection<Room> Rooms { get; }
        public ObservableCollection<Item> ItemsVanBox { get; }
        public ObservableCollection<Item> ItemsNietVanBox { get; }
        #endregion

        #region commands
        public ICommand CancelCommand { get; }
        public ICommand StoreCommand { get; }
        public ICommand VoegToeAanBoxCommand { get; }
        public ICommand VerwijderUitBoxCommand { get; }
        #endregion

        #region methods
        private void ExecuteCancel(object? obj)
        {
            _appNavigation.ActiveViewModel = new BoxIndexViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteStore(object? obj)
        {
            return string.IsNullOrEmpty(Box.Name) == false && Box.CurrentRoomId != 0 && Box.DestinationRoomId != 0;
        }

        private void ExecuteStore(object? obj)
        {
            using AppDbContext db = new();
            db.Boxes.Add(Box);
            db.SaveChanges();

            foreach (var item in ItemsVanBox)
            {
                db.BoxItems.Add(new() { ItemId = item.Id, BoxId = Box.Id });
            }
            db.SaveChanges();

            _appNavigation.ActiveViewModel = new BoxIndexViewModel(_appNavigation, _userMessage);
        }

        private void ExecuteVoegToeAanBox(object? obj)
        {
            if (obj is Item item)
            {
                ItemsNietVanBox.Remove(item);
                ItemsVanBox.Add(item);
            }
        }

        private void ExecuteVerwijderUitBox(object? obj)
        {
            if (obj is Item item)
            {
                ItemsVanBox.Remove(item);
                ItemsNietVanBox.Add(item);
            }
        }
        #endregion
    }
}
