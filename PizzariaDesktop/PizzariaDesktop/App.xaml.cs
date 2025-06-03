using System.Configuration;
using System.Data;
using System.Windows;
using PizzariaDesktop.Models;
using PizzariaDesktop.ViewModels;
using PizzariaDesktop.Views;

namespace PizzariaDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UserMessage userMessage = new();
            MainWindow = new MainView()
            {
                DataContext = new MainViewModel(userMessage)
            };
            MainWindow.Show();
        }
    }

}
