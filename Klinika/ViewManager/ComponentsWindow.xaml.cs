using klinika.Model;
using System.Windows;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for ComponentsWindow.xaml
    /// </summary>
    public partial class ComponentsWindow : Window
    {

        public Medicine selectedMedicine = new Medicine();

        public ComponentsWindow(klinika.Model.Medicine selectedMedicin)
        {
            InitializeComponent();
            selectedMedicine = selectedMedicin;


            dataGridComponents.ItemsSource = selectedMedicine.components.Values;

            medicineName.Content = "Sastojci leka : " + selectedMedicin.name;



        }
    }
}
