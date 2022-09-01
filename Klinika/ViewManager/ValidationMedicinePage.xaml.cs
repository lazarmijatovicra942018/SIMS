using klinika.Model;
using Klinika.Controller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for ValidationMedicinePage.xaml
    /// </summary>
    public partial class ValidationMedicinePage : Page
    {
        public static ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();

        private List<Medicine> medicineList { get; set; }

        private static MedicineController _medicineController;
        private static UserController _userController;

        public ValidationMedicinePage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _medicineController = app.MedicineController;
            _userController = app.UserController;


            this.DataContext = this;

            LoadMedicinesApprovalPending();




        }

        #region LoadMedicines

        public void LoadMedicinesApprovalPending()
        {
            medicines = _medicineController.GetMedicinesApprovalPending();
            FilterMedicines();

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

            MakeDisabledHiddenAmdClearded();
            dataGridMedicine.ItemsSource = medicines;
        }

        #endregion

        #region Filter

        private void FilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SerchBoxVisibility();
            ClearAllTextFileds();
            FilterMedicines();
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


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadMedicinesApprovalPending();
        }

        #endregion

        #region DataGrid

        private void dataGridSMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridMedicine.SelectedItem != null)
            {
                MakeEnabledAndVisible();
            }
            else
            {
                MakeDisabledHiddenAmdClearded();
            }


        }

        #endregion

        #region EnableDisableVisibleHiddenClear

        public void MakeEnabledAndVisible()
        {
            componentsButton.IsEnabled = true;
            acceptButton.IsEnabled = true;
            DescriptionLabel.Visibility = Visibility.Visible;
            DescriptionTextBox.Visibility = Visibility.Visible;
        }


        public void MakeDisabledHiddenAmdClearded()
        {
            componentsButton.IsEnabled = false;
            acceptButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            DescriptionLabel.Visibility = Visibility.Hidden;
            DescriptionTextBox.Visibility = Visibility.Hidden;
            dataGridMedicine.SelectedItem = null;
            DescriptionTextBox.Clear();
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

        public void ClearAllTextFileds()
        {
            searchMaxTextBox.Clear();
            searchMinTextBox.Clear();
            searchTextBox.Clear();

        }

        #endregion

        #region ViewComponents
        private void ComponentsButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            ComponentsWindow componentsWindow = new ComponentsWindow(selectedMedicine);
            componentsWindow.Show();

            MakeDisabledHiddenAmdClearded();

        }

        #endregion

        #region AcceptAndDecline
        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {


            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            _medicineController.MedicineDecline(selectedMedicine, DescriptionTextBox.Text.ToString());
            MakeDisabledHiddenAmdClearded();
            LoadMedicinesApprovalPending();


        }




        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            _medicineController.MedicineApproval(selectedMedicine);
            MakeDisabledHiddenAmdClearded();
            LoadMedicinesApprovalPending();

        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                declineButton.IsEnabled = true;
            }
            else
            {
                declineButton.IsEnabled = false;

            }
        }

        #endregion

        #region Check

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
    }
}

