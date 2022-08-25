using klinika.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

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
