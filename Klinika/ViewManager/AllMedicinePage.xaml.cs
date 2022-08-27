using klinika.Model;
using Klinika.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            medicines = _medicineController.GetAllApprovedAndDeclinedMedicines();

            dataGridMedicine.ItemsSource = medicines;




        }

       

        private void ChangedSort(object sender, SelectionChangedEventArgs e)
        {

            medicineList = _medicineController.MedicineListSorter(sorter.SelectedIndex, medicines.ToList());
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


                dataGridMedicine.ItemsSource = _medicineController.SearchBy(filter.SelectedIndex, medicines.ToList(), searchBox.Text);


            }
            else if (((searchMinBox.Text + searchMaxBox.Text) != "") && Regex.IsMatch((searchMinBox.Text + searchMaxBox.Text), @"^\d+$"))
            {
                dataGridMedicine.ItemsSource = _medicineController.SearchByPrice(medicines.ToList(), searchMinBox.Text, searchMaxBox.Text);

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
                Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
                Sastojci.IsEnabled = true;

                if (selectedMedicine.isDeclined)
                {
                    Description.Visibility = Visibility.Visible;
                    DescriptionLabel.Visibility = Visibility.Visible;
                    Description.Text = selectedMedicine.DeclineDescription;
                    DescriptionLabel.Text = "      " + selectedMedicine.DeclinedByUsers.ToString()??"";


                }
                else
                {
                    Description.Visibility = Visibility.Hidden;
                    DescriptionLabel.Visibility = Visibility.Hidden;

                }

            }


        }



        private void Sastojci_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicine.SelectedItem;
            ComponentsWindow componentsWindow = new ComponentsWindow(selectedMedicine);
            componentsWindow.Show();



        }

        private void ShowCombo(object sender, SelectionChangedEventArgs e)
        {

            if(show.SelectedIndex == 1)
            {
               medicines = _medicineController.GetAllApprovedMedicines();
                dataGridMedicine.ItemsSource = medicines;

            }else if(show.SelectedIndex == 2)
            {
                medicines =_medicineController.GetAllADeclinedMedicines();
                dataGridMedicine.ItemsSource = medicines;

            }
            else
            {
                medicines  =_medicineController.GetAllApprovedAndDeclinedMedicines();
                dataGridMedicine.ItemsSource = medicines;


            }

        }
    }
}
