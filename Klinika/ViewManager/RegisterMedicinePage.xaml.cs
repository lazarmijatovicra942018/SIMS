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
    /// Interaction logic for RegisterMedicinePage.xaml
    /// </summary>
    public partial class RegisterMedicinePage : Page
    {
        public static ObservableCollection<Component> components = new ObservableCollection<Component>();


        private static MedicineController _medicineController;

        public bool clearFunctionActive = false;


        public RegisterMedicinePage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _medicineController = app.MedicineController;
            this.DataContext = this;
            dataGridComponents.ItemsSource = components;



        }



        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddComponent();

            Medicine medicine = new Medicine(idTextBox.Text.ToString(), nameTextBox.Text.ToString() , manufacturTextBox.Text.ToString() , ConvertObservableCollectionToIDictionary() , Int32.Parse(quantityTextBox.Text.ToString()) , Double.Parse(priceTextBox.Text.ToString()));
            ClearAllTextFieldsAndList();
            _medicineController.SaveNewMedicine(medicine);



        }

        private void ClearAllTextFieldsAndList()
        {
            clearFunctionActive = true;
            idTextBox.Clear();
            nameTextBox.Clear();
            manufacturTextBox.Clear();
            quantityTextBox.Clear();
            priceTextBox.Clear();
            components.Clear();
            ClearComponentTextBoxes();
            clearFunctionActive=false;

        }

        public IDictionary<string, Component> ConvertObservableCollectionToIDictionary()
        {
            IDictionary<string, Component> componentsIDictionary = new Dictionary<string, Component>();

            foreach(Component component in components)
            {
                componentsIDictionary.Add(component.componentName, component);
            }

            return componentsIDictionary;

        }

        private void componentDelete_Click(object sender, RoutedEventArgs e)
        {
            Component component = (Component)dataGridComponents.SelectedItem;
            
            components.Remove(component);
          
            componentDelete.IsEnabled = false;
            
            AddMedicineButtonVisibility();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!clearFunctionActive)
            {
                AddComponentButtonVisibility();
                AddMedicineButtonVisibility();
                PriceCheck();
                QuantityCheck();
                ComponentNameCheck();
                MedicineIDCheck();
            }

        }

        private void PriceCheck()
        {
            if(string.IsNullOrEmpty(priceTextBox.Text))
            {
                addMedicine.IsEnabled = false;

            }
            else if (!Regex.IsMatch(priceTextBox.Text.ToString(), @"^\d+$"))
            {
                addMedicine.IsEnabled = false;
                MessageBox.Show("Cena mora biti broj.");


            }
        }

        private void QuantityCheck()
        {
            if (string.IsNullOrEmpty(quantityTextBox.Text))
            {
                addMedicine.IsEnabled = false;

            }
            else if (!Regex.IsMatch(quantityTextBox.Text.ToString(), @"^\d+$"))
            {
                addMedicine.IsEnabled = false;
                MessageBox.Show("Kolicina mora biti broj.");


            }
        }

        private void ComponentNameCheck()
        {
            foreach (Component component in components) {
                if (componentNameTextBox.Text.ToString() == component.componentName)
                {
                    addMedicine.IsEnabled = false;
                    MessageBox.Show(" Ne smeju se duplirati komponente.");


                }
            }
        }

        private void MedicineIDCheck()
        {
            
                if (_medicineController.GetMedicineById(idTextBox.Text.ToString()) != null)
                {
                    addMedicine.IsEnabled = false;
                    MessageBox.Show(" Id leka mora biti jedinstven .");


                }
            
        }

        private void AddMedicineButtonVisibility()
        {

            if (( componentAdd.IsEnabled || components.Count>0 ) && !string.IsNullOrEmpty(manufacturTextBox.Text) && !string.IsNullOrEmpty(quantityTextBox.Text) && !string.IsNullOrEmpty(idTextBox.Text) && !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(priceTextBox.Text))
            {
                addMedicine.IsEnabled = true;
            }
            else
            { 
                addMedicine.IsEnabled = false;
            }

        }

        private void addCompoentnt_Click(object sender, RoutedEventArgs e)
        {
            AddComponent();

            

        }

        public void AddComponent()
        {
            if (componentAdd.IsEnabled)
            {
                Component component = new Component(componentNameTextBox.Text.ToString(), componentDescriptionTextBox.Text.ToString());
                components.Add(component);
                ClearComponentTextBoxes();
                componentDelete.IsEnabled = false;
                componentAdd.IsEnabled = false;


            }

        }

        private void ClearComponentTextBoxes()
        {
            clearFunctionActive = true;
                componentNameTextBox.Clear();
                componentDescriptionTextBox.Clear();
            clearFunctionActive = false;

        }

        public void AddComponentButtonVisibility()
        {
            if(!string.IsNullOrEmpty(componentNameTextBox.Text) && !string.IsNullOrEmpty(componentDescriptionTextBox.Text))
            {
                componentAdd.IsEnabled = true;
            
            }
            else
            {

                componentAdd.IsEnabled = false;
            }

        }

        private void dataGridComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dataGridComponents.SelectedItem != null)
            {
                componentDelete.IsEnabled = true;
            }
            else
            {
                componentDelete.IsEnabled = false;

            }

        }
    }
}
