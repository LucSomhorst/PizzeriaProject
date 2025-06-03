using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using PizzariaDesktop.Helpers;

namespace PizzariaDesktop.Models
{
    internal class UserMessage : ObservableObject
    {
        #region fields
        private string _text = string.Empty;
        private DispatcherTimer _dispatcherTimer;
        #endregion

        #region properties
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); _dispatcherTimer.Start(); }
        }
        #endregion

        public UserMessage()
        {
            _dispatcherTimer = new();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            _dispatcherTimer.Stop();
            Text = string.Empty;
        }
    }
}
