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

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {

            if(comboUserType.SelectedIndex == 0)
            {
                _userController.SaveNewUser(new Model.User(name.Text, lastName.Text, password.Text, jmbg.Text, email.Text, phoneNumber.Text, klinika.Enum.UserType.Doctor));
            
            }
            else if (comboUserType.SelectedIndex == 1)
            {
                _userController.SaveNewUser(new Model.User(name.Text, lastName.Text, password.Text, jmbg.Text, email.Text, phoneNumber.Text, klinika.Enum.UserType.Pharmacist));

            }


            textBoxesClear();


        }

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!clearFunctionActive)
            {
                EmptyTextBoxCheck();
                JmbgValidationCheck();
                EmailValidationCheck();
            }

        }

        private void EmptyTextBoxCheck()
        {
            
            if(string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(lastName.Text) || string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(jmbg.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(phoneNumber.Text))
            {
                registration.IsEnabled = false;
            }else
            {
                registration.IsEnabled = true;
            }

        }

        private void EmailValidationCheck()
        {

            if (!string.IsNullOrEmpty(email.Text)){

                if (_userController.GetUserByEmail(email.Text.ToString()) != null)
                {
                    registration.IsEnabled = false;


                    MessageBox.Show("E-mail adresa mora biti jedinstvena !!!");

                }


            }
        }

        private void JmbgValidationCheck()
        {

            if (!string.IsNullOrEmpty(jmbg.Text))
            {
                if (_userController.GetUserByJmbg(jmbg.Text.ToString()) != null)
                {
                    registration.IsEnabled = false;
                    MessageBox.Show("Jmbg  mora biti jedinstvena !!!");

                }
                


            }
        }
    }
}
