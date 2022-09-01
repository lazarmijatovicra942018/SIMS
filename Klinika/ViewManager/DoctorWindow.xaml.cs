using Klinika.Controller;
using System.Windows;

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
    }
}

