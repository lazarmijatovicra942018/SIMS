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
            Sadrzaj.NavigationService.Navigate(new AllMedicinePage());

        }

        private void OdobreniLekovi_Click(object sender, RoutedEventArgs e)
        {
            Sadrzaj.NavigationService.Navigate(new UserPage());
        }
    }
}
