using klinika.Model;
using Klinika.Controller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<Medicine> medicines { get; set; }

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

            medicineList = _medicineController.GetAllMedicationWaitingForApproval();

            if (medicineList == null)
            {
                medicineList = new List<Medicine>();
            }

            medicines = _medicineController.PutListInObservableCollection(medicineList);
            dataGridMedicine.ItemsSource = medicines;




        }



        private void dataGridSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangedSort(object sender, SelectionChangedEventArgs e)
        {

            medicineList = _medicineController.MedicineListSorter(sorter.SelectedIndex, medicineList);
            dataGridMedicine.ItemsSource = new ObservableCollection<Medicine>(medicineList);


        }

        private void FilterCombo(object sender, SelectionChangedEventArgs e)
        {
            searchBox.Clear();
            searchMinBox.Clear();
            searchMaxBox.Clear();


            if (filter.SelectedIndex == 0)
            {
                MinTextBlock.Visibility = Visibility.Visible;
                MaxTextBlock.Visibility = Visibility.Visible;

                searchMaxBox.Visibility = Visibility.Visible;
                searchMinBox.Visibility = Visibility.Visible;


            }
            else
            {
                MinTextBlock.Visibility = Visibility.Hidden;
                MaxTextBlock.Visibility = Visibility.Hidden;

                searchMaxBox.Visibility = Visibility.Hidden;
                searchMinBox.Visibility = Visibility.Hidden;



            }

            if (filter.SelectedIndex > 0)
            {
                searchBox.Visibility = Visibility.Visible;


            }
            else
            {
                searchBox.Visibility = Visibility.Hidden;
            }





        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (searchBox.Text != "")
            {


                dataGridMedicine.ItemsSource = _medicineController.SearchBy(filter.SelectedIndex, medicineList, searchBox.Text);


            }
            else if (((searchMinBox.Text + searchMaxBox.Text) != "") && Regex.IsMatch((searchMinBox.Text + searchMaxBox.Text), @"^\d+$"))
            {
                dataGridMedicine.ItemsSource = _medicineController.SearchByPrice(medicineList, searchMinBox.Text, searchMaxBox.Text);

            }
            else
            {
                dataGridMedicine.ItemsSource = medicines;

            }
        }

        private void dataGridSMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridMedicine.SelectedItem != null)
            {
                Sastojci.IsEnabled = true;
                Odbijanje.IsEnabled = true;
                Odobravanje.IsEnabled = true;
                Description.Visibility = Visibility.Visible;
                DescriptionLabel.Visibility = Visibility.Visible;

            }


        }



        private void Sastojci_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            ComponentsWindow componentsWindow = new ComponentsWindow(selectedMedicine);
            componentsWindow.Show();



        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {

            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;

            _medicineController.MedicineDecline(selectedMedicine, _userController.GetActiveUser, Description.Text.ToString());


            _medicineController.GetObservableListApprovalPending(medicines);

            _medicineController.SaveChangedMedicine(selectedMedicine);



            dataGridMedicine.ItemsSource = medicines;

            Description.Clear();


        }




        private void Accept_Click(object sender, RoutedEventArgs e)
        {



            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;



            _medicineController.MedicineApproval(selectedMedicine);

            _medicineController.SaveChangedMedicine(selectedMedicine);


            _medicineController.GetObservableListApprovalPending(medicines);
            dataGridMedicine.ItemsSource = medicines;


        }
    }
}

