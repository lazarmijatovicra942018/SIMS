using klinika.Enum;
using Klinika.Controller;
using Klinika.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            LoadUsers();
        }

        #region DataGrid

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;
            if (selectedUser != null) { 
                EnableButon(selectedUser);
            }
            else
            {
                DisableButton();
            }



        }

        #endregion


        #region Filter

        private void ChangedFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilterUsers();

        }

        public void FilterUsers()
        {
            users = _userController.FilteringUsers((int)filterCombo.SelectedIndex);

            SortUsers();

        }

        #endregion

        #region Sort
        private void ChangedSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortUsers();
        }


        public void SortUsers()
        {   

            users = new ObservableCollection<User>(_userController.UserSorting((int)sortCombo.SelectedIndex, users.ToList()));
            dataGridUsers.ItemsSource = users;
            DisableButtonAndUnselectItem();

        }



        #endregion

        #region LoadUsers
        public void LoadUsers()
        {

            if (filterCombo.SelectedIndex < 0)
            {
                users = _userController.GetAllUsers();
                dataGridUsers.ItemsSource = users;
                SortUsers();
            }
            else
            {
                FilterUsers();
            }


        }

        #endregion


        #region BlockUnblock
        private void Blocade_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;

            _userController.BlockUser(selectedUser);
            LoadUsers();
            DisableButtonAndUnselectItem();

        }
        private void UnBlocade_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)dataGridUsers.SelectedItem;

            _userController.UnBlockUser(selectedUser);
            LoadUsers();
            DisableButtonAndUnselectItem();

        }

        #endregion

        #region EnableDisable
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
                }else if (!selectedUser.isBaned)
                {
                    Blocade.IsEnabled = true;
                    UnBlocade.IsEnabled = false;
                }

            }

        }

        public void DisableButtonAndUnselectItem()
        {
            DisableButton();
            dataGridUsers.SelectedItem = null;

        }


        public void DisableButton()
        {
            UnBlocade.IsEnabled = false;
            Blocade.IsEnabled = false;
            
        }


        #endregion

    }
}
