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
            users = _userController.GetAllUsersInObservableCollection();
            dataGridMedicine.ItemsSource = users;

        }

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangedFilter(object sender, SelectionChangedEventArgs e)
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

            dataGridMedicine.ItemsSource = users;

        }


    }
}
