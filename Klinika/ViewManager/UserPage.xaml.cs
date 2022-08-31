using klinika.Model;
using Klinika.Controller;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {


        public static ObservableCollection<Medicine> medicines { get; set; }




        private static MedicineController _medicineController;
        private UserController _userController;

        public UserPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _medicineController = app.MedicineController;
            _userController = app.UserController;
            this.DataContext = this;
            LoadApprovedMedcineToObservableCollection();
            MenagerVisible();



        }

        #region DataGrid

        private void dataGridSMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuantityCheck();

            if (dataGridMedicine.SelectedItem != null)
            {
                MakeButtonsEnabled();
            }

        }

        #endregion


        #region LoadMedicines

        private void LoadApprovedMedcineToObservableCollection()
        {
            medicines = _medicineController.GetAllApprovedMedicines();
            FilterMedicines();
        }

        #endregion


        #region ViewComponents
        private void ComponentsButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            ComponentsWindow componentsWindow = new ComponentsWindow(selectedMedicine);
            componentsWindow.Show();

            MakeButtonsDisabledandClearFields();
        }

        #endregion

        #region AddQuantity
        private void addQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            AddQuantityToMedicine();
            MakeButtonsDisabledandClearFields();
            LoadApprovedMedcineToObservableCollection();
        }

        private void quantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuantityCheck();
            CheckIfTimeIsPassed();
        }


        private void datePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckIfTimeIsPassed();
        }

        private void AddQuantityToMedicine()
        {
            if (datePicker.SelectedDate == null)
            {


                _medicineController.AddQuantity((Medicine)dataGridMedicine.SelectedItem, int.Parse(quantityTextBox.Text));

            }
            else
            {

                _medicineController.AddQuantityWithTime((Medicine)dataGridMedicine.SelectedItem, int.Parse(quantityTextBox.Text), (DateTime)datePicker.SelectedDate);


            }
        }


        #endregion

        #region Filter
        private void FilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SerchBoxVisibility();
            ClearAllTextFileds();
            FilterMedicines();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadApprovedMedcineToObservableCollection();

        }

        public void FilterMedicines()
        {
            if (filterCombo.SelectedIndex != -1)
            {

                if (!string.IsNullOrEmpty(searchTextBox.Text))
                {
                    medicines = _medicineController.SearchBy(filterCombo.SelectedIndex, medicines.ToList(), searchTextBox.Text.ToString());
                }
                else if (PriceCheck())
                {
                    medicines = _medicineController.SearchByPrice(medicines.ToList(), searchMinTextBox.Text, searchMaxTextBox.Text);
                }
            }


            SortMedicines();
        }


        #endregion

        #region SortMedicine
        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortMedicines();
        }



        private void SortMedicines()
        {
            if (sorterCombo.SelectedIndex != -1)
            {
                medicines = new ObservableCollection<Medicine>(_medicineController.MedicineListSorter(sorterCombo.SelectedIndex, medicines.ToList()));
            }
            dataGridMedicine.ItemsSource = medicines;
        }

        #endregion

        #region Check

        public void CheckIfTimeIsPassed()
        {
            if (datePicker.SelectedDate == null)
            {

            }
            else if ((DateTime)datePicker.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Vreme koje ste izabrali je proslo .");

                addQuantityButton.IsEnabled = false;
            }
        }

        private void QuantityCheck()
        {

            if (string.IsNullOrEmpty(quantityTextBox.Text))
            {
                addQuantityButton.IsEnabled = false;
                return;

            }
            else if (!Regex.IsMatch(quantityTextBox.Text + searchMinTextBox.Text, @"^\d+$"))
            {

                addQuantityButton.IsEnabled = false;
                MessageBox.Show("Kolicina mora biti izrazena brojevima .");
            }
            else if (dataGridMedicine.SelectedItems.Count == 1)
            {
                addQuantityButton.IsEnabled = true;
            }



        }
        public bool PriceCheck()
        {
            if (string.IsNullOrEmpty(searchMaxTextBox.Text + searchMinTextBox.Text))
            {
                return false;

            }
            else if (!Regex.IsMatch(searchMaxTextBox.Text + searchMinTextBox.Text, @"^\d+$"))
            {

                MessageBox.Show("Cena mora biti izrazena brojevima .");
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

        #region EnableDisableVisibleClear
        private void MakeButtonsEnabled()
        {

            componentsButton.IsEnabled = true;
        }

        private void MakeButtonsDisabledandClearFields()
        {
            addQuantityButton.IsEnabled = false;
            componentsButton.IsEnabled = false;
            dataGridMedicine.SelectedItem = null;
            quantityTextBox.Clear();
            datePicker = new DatePicker();
        }

        public void ClearAllTextFileds()
        {
            searchMaxTextBox.Clear();
            searchMinTextBox.Clear();
            searchTextBox.Clear();


        }

        private void SerchBoxVisibility()
        {
            if (filterCombo.SelectedIndex == 0)
            {
                searchTextBox.Visibility = Visibility.Hidden;
                searchMinTextBox.Visibility = Visibility.Visible;
                searchMaxTextBox.Visibility = Visibility.Visible;
                searchMaxTextBlock.Visibility = Visibility.Visible;
                searchMinTextBlock.Visibility = Visibility.Visible;

            }
            else
            {
                searchTextBox.Visibility = Visibility.Visible;
                searchMinTextBox.Visibility = Visibility.Hidden;
                searchMaxTextBox.Visibility = Visibility.Hidden;
                searchMaxTextBlock.Visibility = Visibility.Hidden;
                searchMinTextBlock.Visibility = Visibility.Hidden;


            }
        }


        public void MenagerVisible()
        {
            if (_userController.GetActiveUser.userType == klinika.Enum.UserType.Manager)
            {
                datePicker.Visibility = Visibility.Visible;
                addQuantityButton.Visibility = Visibility.Visible;
                quantityTextBox.Visibility = Visibility.Visible;
            }

        }

        #endregion

    }
}
