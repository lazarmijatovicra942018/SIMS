﻿#pragma checksum "..\..\..\..\ViewManager\RegisterMedicinePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31E2C839B9985928E55B37EC0919B82BCC0D617C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Klinika.ViewManager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Klinika.ViewManager {
    
    
    /// <summary>
    /// RegisterMedicinePage
    /// </summary>
    public partial class RegisterMedicinePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button componentAdd;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox manufacturTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox componentNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox componentDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridComponents;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button componentDelete;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addMedicine;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Klinika;component/viewmanager/registermedicinepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.componentAdd = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.componentAdd.Click += new System.Windows.RoutedEventHandler(this.addCompoentnt_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.idTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.nameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.manufacturTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.manufacturTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.quantityTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.quantityTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.priceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.priceTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.componentNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.componentNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.componentDescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.componentDescriptionTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dataGridComponents = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.dataGridComponents.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridComponents_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.componentDelete = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.componentDelete.Click += new System.Windows.RoutedEventHandler(this.componentDelete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.addMedicine = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\ViewManager\RegisterMedicinePage.xaml"
            this.addMedicine.Click += new System.Windows.RoutedEventHandler(this.addMedicine_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

