using Klinika.Controller;
using System.Windows;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for PharmacistWindow.xaml
    /// </summary>
    public partial class PharmacistWindow : Window
    {


        private UserController _userController;

        public PharmacistWindow()
        {
            InitializeComponent();
            Content.NavigationService.Navigate(new UserPage());
            var app = Application.Current as App;
            _userController = app.UserController;
            ActiveUserLabel.Text = _userController.GetActiveUser.ToString();


        }


        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _userController.LogOut();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new ValidationMedicinePage());


        }


        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new UserPage());

        }


        private void AllMedicinesButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new AllMedicinePage());
        }
    }
}

