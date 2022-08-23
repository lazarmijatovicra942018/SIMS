using klinika.Enum;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {

        private UserController _userController;

        public LoginView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _userController = app.UserController;
        }



        public void LoginFunction()
        {
            if (_userController.LoginValidationByEmailAndPassword(email.Text, password.Text))
            {
                MessageBox.Show("Logovali ste se uspesno");
                if (_userController.GetActiveUser.userType == UserType.Manager)
                {
                    MainFrame.NavigationService.Navigate(new ManagerView());
                }
                else if (_userController.GetActiveUser.userType == UserType.Doctor)
                {
                    MainFrame.NavigationService.Navigate(new DoctorView());
                }
                else if (_userController.GetActiveUser.userType == UserType.Pharmacist)
                {
                    MainFrame.NavigationService.Navigate(new PharmacistView());
                }


            }
            else if (_userController.GetShutDownCounter == 3)
            {
                Environment.Exit(0);

            }

        }

        private void ButtonLogin(object sender, RoutedEventArgs e)
        {
            // PharmacistWindow pharmacistWindow = new PharmacistWindow();
            MainFrame.NavigationService.Navigate(new PharmacistView());

            // pharmacistWindow.Show();
            // this.Close();
            // LoginFunction();   
        }
    }

}