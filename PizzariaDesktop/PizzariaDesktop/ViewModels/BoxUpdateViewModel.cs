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
    internal class BoxUpdateViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public BoxUpdateViewModel(IAppNavigation appNavigation, UserMessage userMessage, Box box)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CancelCommand = new RelayCommand(ExecuteCancel);
            StoreCommand = new RelayCommand(ExecuteStore, CanExecuteStore);
            VoegToeAanBoxCommand = new RelayCommand(ExecuteVoegToeAanBox);
            VerwijderUitBoxCommand = new RelayCommand(ExecuteVerwijderUitBox);

            Box = box;

            using AppDbContext db = new();
            Rooms = new(db.Rooms.OrderBy(x => x.Name));
            List<BoxItem> boxItems = new(db.BoxItems.Include(x => x.Item).Where(x => x.BoxId == Box.Id));

            ItemsVanBox = [];
            foreach (var item in boxItems.OrderBy(x => x.Item.Name))
            {
                ItemsVanBox.Add(item.Item);
            }

            ItemsNietVanBox = new(db.Items.OrderBy(x => x.Name));
            foreach (var item in ItemsVanBox)
            {
                Item? x = ItemsNietVanBox.FirstOrDefault(x => x.Id == item.Id);
                if (x != null)
                {
                    ItemsNietVanBox.Remove(x);
                }
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BoxUpdateViewModel()
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
            Box? boxInDb = db.Boxes.FirstOrDefault(x => x.Id == Box.Id);
            if (boxInDb == null)
            {
                _userMessage.Text = "Box bestaat niet meer en wordt niet bijgewerkt";
                _appNavigation.ActiveViewModel = new BoxIndexViewModel(_appNavigation, _userMessage);
                return;
            }

            if (boxInDb.Name != Box.Name)
            {
                boxInDb.Name = Box.Name;
                db.SaveChanges();
            }

            if (boxInDb.CurrentRoomId != Box.CurrentRoomId)
            {
                boxInDb.CurrentRoomId = Box.CurrentRoomId;
                db.SaveChanges();
            }

            if (boxInDb.DestinationRoomId != Box.DestinationRoomId)
            {
                boxInDb.DestinationRoomId = Box.DestinationRoomId;
                db.SaveChanges();
            }

            List<BoxItem> boxItemsInDb = db.BoxItems.Where(x => x.BoxId == Box.Id).ToList();

            foreach (var boxItemInDb in boxItemsInDb)
            {
                if (ItemsVanBox.FirstOrDefault(x => x.Id == boxItemInDb.ItemId) == null)
                {
                    db.BoxItems.Remove(boxItemInDb);
                    db.SaveChanges();
                }
            }

            foreach (var item in ItemsVanBox)
            {
                if (boxItemsInDb.FirstOrDefault(x => x.ItemId == item.Id) == null)
                {
                    db.BoxItems.Add(new()
                    {
                        ItemId = item.Id,
                        BoxId = Box.Id
                    });
                    db.SaveChanges();
                }
            }

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
