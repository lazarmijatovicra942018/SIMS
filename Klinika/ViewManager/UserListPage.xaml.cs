using klinika.Enum;
using Klinika.Controller;
using Klinika.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        private static UserController _userController;
        public static ObservableCollection<User> users { get; set; }


        public UserListPage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _userController = app.UserController;
            this.DataContext = this;
            
            LoadUsersToObservableList();
        }

       

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;
            UnBlocade.IsEnabled = true;
            Blocade.IsEnabled = true;
            if (selectedUser != null) { EnableButon(selectedUser); };

        }

        private void EnableButon(User selectedUser)
        {
            if ((UserType)selectedUser.userType == UserType.Manager)
            {
                UnBlocade.IsEnabled = false;
                Blocade.IsEnabled = false;

            }
            else
            {


                if (selectedUser.isBaned)
                {
                    UnBlocade.IsEnabled = true;
                    Blocade.IsEnabled = false; ;
                }

                if (!selectedUser.isBaned)
                {
                    Blocade.IsEnabled = true;
                    UnBlocade.IsEnabled = false;
                }

            }

        }

        public void DisableButton()
        {
            UnBlocade.IsEnabled = false;
            Blocade.IsEnabled = false;


        }

        private void ChangedFilter(object sender, SelectionChangedEventArgs e)
        {
            
            FilterUsers();

        }

        public void FilterUsers()
        {
            users = _userController.FilteringUsers((int)filterCombo.SelectedIndex);
            
            SortUsers();

        }

        private void ChangedSort(object sender, SelectionChangedEventArgs e)
        {
            SortUsers();

        }


        public void SortUsers()
        {
            users = new ObservableCollection<User>(_userController.UserSorting((int)sortCombo.SelectedIndex, users.ToList()));

            dataGridUsers.ItemsSource = users;
           
        }

        private void Blocade_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;

            _userController.BlockUser(selectedUser);
            LoadUsersToObservableList();
            DisableButton();

        }

        public void LoadUsersToObservableList()
        {
            
            if (filterCombo.SelectedIndex < 0)
            {
                users = _userController.GetAllUsersInObservableCollection();
                dataGridUsers.ItemsSource = users;
                SortUsers();
            }
            else
            {
                FilterUsers();
            }


        }

        private void UnBlocade_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;

            _userController.UnBlockUser(selectedUser);
            LoadUsersToObservableList();
            DisableButton();

        }
    }
}
