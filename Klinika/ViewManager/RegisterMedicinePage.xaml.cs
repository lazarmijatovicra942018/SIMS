using klinika.Model;
using Klinika.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Klinika.ViewManager
{
    /// <summary>
    /// Interaction logic for RegisterMedicinePage.xaml
    /// </summary>
    public partial class RegisterMedicinePage : Page
    {
        public static ObservableCollection<Component> components = new ObservableCollection<Component>();


        private static MedicineController _medicineController;
        private static ComponentController _componentController;

        public bool clearFunctionActive = false;


        public RegisterMedicinePage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _medicineController = app.MedicineController;
            _componentController = app.ComponentController;


            this.DataContext = this;
            dataGridComponents.ItemsSource = components;



        }

        #region AddMedicine

        private void addMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddComponent();
            _medicineController.AddNewMedicine(idTextBox.Text.ToString(), nameTextBox.Text.ToString(), manufacturTextBox.Text.ToString(), components, Int32.Parse(quantityTextBox.Text.ToString()), Double.Parse(priceTextBox.Text.ToString()));
            ClearAllTextFieldsAndList();




        }

        #endregion

        #region ComponentsAddDelete
        private void componentDelete_Click(object sender, RoutedEventArgs e)
        {
            Component component = (Component)dataGridComponents.SelectedItem;

            components = _componentController.DeleteComponent(component, components);

            componentDelete.IsEnabled = false;

            AddMedicineButtonVisibility();

        }


        private void addCompoentnt_Click(object sender, RoutedEventArgs e)
        {
            AddComponent();

        }

        public void AddComponent()
        {
            if (componentAdd.IsEnabled)
            {

                components = _componentController.AddComponent(componentNameTextBox.Text.ToString(), componentDescriptionTextBox.Text.ToString(), components);
                ClearComponentTextBoxes();
                componentDelete.IsEnabled = false;
                componentAdd.IsEnabled = false;


            }

        }


        #endregion

        #region TextBoxChanged
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

        #endregion

        #region EnableDisableVisibleClear


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
            clearFunctionActive = false;

        }
        private void AddMedicineButtonVisibility()
        {

            if ((componentAdd.IsEnabled || components.Count > 0) && !string.IsNullOrEmpty(manufacturTextBox.Text) && !string.IsNullOrEmpty(quantityTextBox.Text) && !string.IsNullOrEmpty(idTextBox.Text) && !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(priceTextBox.Text))
            {
                addMedicine.IsEnabled = true;
            }
            else
            {
                addMedicine.IsEnabled = false;
            }

        }




        public void AddComponentButtonVisibility()
        {
            if (!string.IsNullOrEmpty(componentNameTextBox.Text) && !string.IsNullOrEmpty(componentDescriptionTextBox.Text))
            {
                componentAdd.IsEnabled = true;

            }
            else
            {

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


        #endregion

        #region DataGridComponents
        private void dataGridComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridComponents.SelectedItem != null)
            {
                componentDelete.IsEnabled = true;
            }
            else
            {
                componentDelete.IsEnabled = false;

            }

        }
        #endregion

        #region Check 
        private void PriceCheck()
        {
            if (string.IsNullOrEmpty(priceTextBox.Text))
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
            foreach (Component component in components)
            {
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



        #endregion


    }
}
