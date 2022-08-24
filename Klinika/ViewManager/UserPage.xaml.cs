using klinika.Model;
using Klinika.Controller;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        public static ObservableCollection<Medicine> medicines { get; set;  }

        private static List<Medicine> medicineList { get; set; }

        private MedicineController _medicineController;

        public UserPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _medicineController = app.MedicineController;


            this.DataContext = this;
           
            medicineList = _medicineController.GetAllMedicines();

            if(medicineList == null)
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
            if(sorter.SelectedIndex == 0)
            {
                  medicineList.Sort((a, b) => a.name.CompareTo(b.name));
                  dataGridMedicine.ItemsSource = new ObservableCollection<Medicine>(medicineList) ;
            }else if (sorter.SelectedIndex == 1)
            {

                 medicineList.Sort((a, b) => a.price.CompareTo(b.price));
                 dataGridMedicine.ItemsSource = dataGridMedicine.ItemsSource = new ObservableCollection<Medicine>(medicineList);
            }
            else if (sorter.SelectedIndex == 2)
            {

                medicineList.Sort((a, b) => a.quantity.CompareTo(b.quantity));
                dataGridMedicine.ItemsSource = dataGridMedicine.ItemsSource = new ObservableCollection<Medicine>(medicineList);
            }


        }
    }
}
