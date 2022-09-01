using klinika.Enum;
using Klinika.Controller;
using Klinika.ViewManager;
using System;
using System.Windows;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UserController _userController;

        public MainWindow()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _userController = app.UserController;
        }



        public void LoginFunction()
        {
            bool returnMessage = _userController.LoginValidationByEmailAndPassword(email.Text, password.Text);
            if (returnMessage)
            {

                LoggedIn();


            }
            else if (_userController.GetShutDownCounter == 3)
            {
                Environment.Exit(0);

            }


        }



        public void LoggedIn()
        {
            MessageBox.Show("Logovali ste se uspesno");
            if (_userController.GetActiveUser.userType == UserType.Manager)
            {
                ManagerWindow managerView = new ManagerWindow();
                managerView.Show();
                this.Hide();

            }
            else if (_userController.GetActiveUser.userType == UserType.Doctor)
            {

                DoctorWindow doctorView = new DoctorWindow();
                doctorView.Show();
                this.Hide();

            }
            else if (_userController.GetActiveUser.userType == UserType.Pharmacist)
            {
                PharmacistWindow pharmacistView = new PharmacistWindow();
                pharmacistView.Show();
                this.Hide();


            }


        }

        private void ButtonLogin(object sender, RoutedEventArgs e)
        {


            LoginFunction();

        }


    }
}

