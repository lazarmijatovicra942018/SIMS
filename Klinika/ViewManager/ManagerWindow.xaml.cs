using Klinika.Controller;
using System.Windows;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private UserController _userController;

        public ManagerWindow()
        {
            InitializeComponent();

            Content.NavigationService.Navigate(new UserPage());
            var app = Application.Current as App;
            _userController = app.UserController;

            ActiveUserLabel.Text = _userController.GetActiveUser.ToString() ?? " ";



        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _userController.LogOut();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new UserPage());
        }

        private void RegistrateUserButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new RegisterUserPage());

        }

        private void AllUsersButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new UserListPage());

        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            Content.NavigationService.Navigate(new RegisterMedicinePage());
        }
    }
}
