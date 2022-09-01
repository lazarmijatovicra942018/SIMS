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
    /// Interaction logic for AllMedicinePage.xaml
    /// </summary>
    public partial class AllMedicinePage : Page
    {
        public static ObservableCollection<Medicine> medicines { get; set; }

        private List<Medicine> medicineList { get; set; }

        private static MedicineController _medicineController;
        private static UserController _userController;

        public AllMedicinePage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _medicineController = app.MedicineController;
            _userController = app.UserController;


            this.DataContext = this;

            LoadApprovedandDeclinedMedcineToObservableCollection();


        }

        #region LoadMedicines

        private void LoadApprovedandDeclinedMedcineToObservableCollection()
        {
            ShowMedicines();
        }

        #endregion

        #region SortMedicine
        private void SortComboSelection_Changed(object sender, SelectionChangedEventArgs e)
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
            dataGridMedicine.SelectedItem = null;
            HideDeclineReason();

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

            LoadApprovedandDeclinedMedcineToObservableCollection();

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


        #endregion

        #region DataGRid

        private void dataGridSMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (dataGridMedicine.SelectedItem != null)
            {
                MakeButtonEnabled();
                DeclineDescriptionVisibility();

            }
            else
            {
                MakeButtonDisabled();

            }
        }

        #endregion

        #region DeckineReasonSHowHide

        public void DeclineDescriptionVisibility()
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;

            MakeButtonEnabled();

            if (selectedMedicine.isDeclined)
            {
                ShowDeclinedReason();
            }
            else
            {
                HideDeclineReason();
            }

            
        }



        public void ShowDeclinedReason()
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            Description.Visibility = Visibility.Visible;
            DescriptionLabel.Visibility = Visibility.Visible;
            Description.Text = selectedMedicine.DeclineDescription;
            DescriptionLabel.Text = "      " + selectedMedicine.DeclinedByUsers.ToString() ?? "";
        }


        public void HideDeclineReason()
        {
            Description.Visibility = Visibility.Hidden;
            DescriptionLabel.Visibility = Visibility.Hidden;

        }

        #endregion

        #region ViewComponents
        private void ComponentsButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            ComponentsWindow componentsWindow = new ComponentsWindow(selectedMedicine);
            componentsWindow.Show();

            MakeButtonDisabled();
        }


        private void MakeButtonEnabled()
        {

            componentsButton.IsEnabled = true;
      
        }

        private void MakeButtonDisabled()
        {

            componentsButton.IsEnabled = false;
            dataGridMedicine.SelectedItem = null;
            HideDeclineReason();

        }




        #endregion

        #region ShowMedicines


        private void ShowCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowMedicines();

        }


        public void ShowMedicines()
        {
            if (show.SelectedIndex == 1)
            {
                medicines = _medicineController.GetAllApprovedMedicines();

            }
            else if (show.SelectedIndex == 2)
            {
                medicines = _medicineController.GetAllADeclinedMedicines();
            }
            else
            {
                medicines = _medicineController.GetAllApprovedAndDeclinedMedicines();

            }
            FilterMedicines();

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
