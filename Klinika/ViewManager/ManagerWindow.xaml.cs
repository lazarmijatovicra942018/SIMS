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

            Sadrzaj.NavigationService.Navigate(new UserPage());
            var app = Application.Current as App;
            _userController = app.UserController;

            ActiveUserLabel.Text = _userController.GetActiveUser.ToString() ?? " ";



        }

        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            _userController.LogOut();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }






        private void OdobreniLekovi_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new UserPage());
        }

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new RegisterUserPage());

        }

        private void AllUsers_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new UserListPage());

        }


        private void Validacija_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new ValidationMedicinePage());


        }

        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new RegisterMedicinePage());
        }
    }
}
