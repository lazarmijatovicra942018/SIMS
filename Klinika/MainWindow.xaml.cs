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
            string returnMessage = _userController.LoginValidationByEmailAndPassword(email.Text, password.Text);
            if (returnMessage == "logged")
            {

                LoggedIn();


            }
            else if (_userController.GetShutDownCounter == 3)
            {
                Environment.Exit(0);

            }
            else
            {
                MessagesNotLoggedInCorrectly(returnMessage);
            }

        }

        private void MessagesNotLoggedInCorrectly(string returnMessage)
        {
            if (returnMessage == "notExist")
            {
                MessageBox.Show("Email  nije validan .");
            }
            else if (returnMessage == "wrongPassword")
            {
                MessageBox.Show("Sifra  nije pravilno napisana .");

            }
            else if (returnMessage == "baned")
            {
                MessageBox.Show("Korisnik je blokiran .");

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

