using Klinika.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        private UserController _userController;

        public DoctorWindow()
        {
            InitializeComponent();
            Sadrzaj.NavigationService.Navigate(new UserPage());

            var app = Application.Current as App;
            _userController = app.UserController;
            ActiveUserLabel.Text = _userController.GetActiveUser.ToString();

        }

        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            _userController.LogOut();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Validacija_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new ValidationMedicinePage());


        }


        private void SviLekovi_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new UserPage());

        }
    }
}

