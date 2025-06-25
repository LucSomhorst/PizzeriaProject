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
    internal class BoxIndexViewModel
    {
        #region fields
        private IAppNavigation _appNavigation;
        private UserMessage _userMessage;
        #endregion

        #region constructors
        public BoxIndexViewModel(IAppNavigation appNavigation, UserMessage userMessage)
        {
            _appNavigation = appNavigation;
            _userMessage = userMessage;

            CreateBoxCommand = new RelayCommand(ExecuteCreateBox);
            UpdateBoxCommand = new RelayCommand(ExecuteUpdateBox, CanExecuteUpdateBox);
            DeleteBoxCommand = new RelayCommand(ExecuteDeleteBox, CanExecuteDeleteBox);

            using AppDbContext db = new();
            Boxes = new(db.Boxes.OrderBy(x => x.Name).Include(x => x.CurrentRoom));
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public BoxIndexViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }
        #endregion

        #region properties
        public ObservableCollection<Box> Boxes { get; set; }
        #endregion

        #region commands
        public ICommand CreateBoxCommand { get; }
        public ICommand UpdateBoxCommand { get; }
        public ICommand DeleteBoxCommand { get; }
        #endregion

        #region methods
        private void ExecuteCreateBox(object? obj)
        {
            _appNavigation.ActiveViewModel = new BoxCreateViewModel(_appNavigation, _userMessage);
        }

        private bool CanExecuteUpdateBox(object? obj)
        {
            return obj is Box;
        }

        private void ExecuteUpdateBox(object? obj)
        {
            if (obj is Box box)
            {
                _appNavigation.ActiveViewModel =
                    new BoxUpdateViewModel(_appNavigation, _userMessage, box);
            }
        }

        private bool CanExecuteDeleteBox(object? obj)
        {
            return obj is Box;
        }

        private void ExecuteDeleteBox(object? obj)
        {
            if (obj is Box box)
            {
                using AppDbContext db = new();
                Box? boxInDb = db.Boxes.FirstOrDefault(x => x.Id == box.Id);
                if (boxInDb != null)
                {
                    db.Boxes.Remove(boxInDb);
                    db.SaveChanges();
                }
                Boxes.Remove(box);
            }
        }
        #endregion
    }
}
