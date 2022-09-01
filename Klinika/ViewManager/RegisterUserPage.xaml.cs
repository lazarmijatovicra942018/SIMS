using Klinika.Controller;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for RegisterUserPage.xaml
    /// </summary>
    public partial class RegisterUserPage : Page
    {

        private UserController _userController;

        private bool clearFunctionActive;



        public RegisterUserPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _userController = app.UserController;

        }

        #region RegistrationButton

        private void Registration_Click(object sender, RoutedEventArgs e)
        {

            if (comboUserType.SelectedIndex == 0)
            {
                _userController.SaveNewUser(name.Text, lastName.Text, password.Text, jmbg.Text, email.Text, phoneNumber.Text, klinika.Enum.UserType.Doctor);

            }
            else if (comboUserType.SelectedIndex == 1)
            {
                _userController.SaveNewUser(name.Text, lastName.Text, password.Text, jmbg.Text, email.Text, phoneNumber.Text, klinika.Enum.UserType.Pharmacist);

            }


            textBoxesClear();


        }
        #endregion

        #region Clear

        private void textBoxesClear()
        {
            clearFunctionActive = true;
            jmbg.Clear();
            email.Clear();
            name.Clear();
            lastName.Clear();
            password.Clear();
            jmbg.Clear();
            phoneNumber.Clear();
            comboUserType.SelectedIndex = 0;
            clearFunctionActive = false;

        }

        #endregion

        #region TextBoxChanged

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!clearFunctionActive)
            {
                EmptyTextBoxCheck();
                JmbgValidationCheck();
                EmailValidationCheck();
                PhoneNumberCheck();
            }

        }

        #endregion

        #region Check

        private void EmptyTextBoxCheck()
        {


            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(lastName.Text) || string.IsNullOrEmpty(jmbg.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(phoneNumber.Text))
            {
                registrationButton.IsEnabled = false;
            }
            else
            {
                registrationButton.IsEnabled = true;


            }

        }

        private void PhoneNumberCheck()
        {


            if (string.IsNullOrEmpty(phoneNumber.Text))
            {
                registrationButton.IsEnabled = false;

            }
            else if (!Regex.IsMatch(phoneNumber.Text.ToString(), @"^\d+$"))
            {
                registrationButton.IsEnabled = false;
                MessageBox.Show("Broj telefona mora biti broj .");
            }

        }

        private void EmailValidationCheck()
        {

            if (string.IsNullOrEmpty(email.Text))
            {
                registrationButton.IsEnabled = true;


            }
            else if (_userController.GetUserByEmail(email.Text.ToString()) != null)
            {
                registrationButton.IsEnabled = false;
                MessageBox.Show("E-mail adresa mora biti jedinstvena !!!");

            }



        }

        private void JmbgValidationCheck()
        {



            if (string.IsNullOrEmpty(jmbg.Text))
            {
                return;
            }
            else if (_userController.GetUserByJmbg(jmbg.Text.ToString()) != null)
            {
                registrationButton.IsEnabled = false;
                MessageBox.Show("Jmbg adresa mora biti jedinstvena !!!");

            }


        }
        #endregion
    }
}
