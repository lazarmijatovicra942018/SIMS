﻿#pragma checksum "..\..\..\..\ViewManager\UserPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E5288B6CEEBDE54FD60B4C18668B026A35700648"
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
    /// UserPage
    /// </summary>
    public partial class UserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMedicine;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchMaxTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchMinTextBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sorterCombo;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filterCombo;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock searchMaxTextBlock;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock searchMinTextBlock;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button componentsButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addQuantityButton;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\ViewManager\UserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
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
            System.Uri resourceLocater = new System.Uri("/Klinika;component/viewmanager/userpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewManager\UserPage.xaml"
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
            this.dataGridMedicine = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\..\..\ViewManager\UserPage.xaml"
            this.dataGridMedicine.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridSMedicine_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.searchMaxTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\ViewManager\UserPage.xaml"
            this.searchMaxTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.searchMinTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\ViewManager\UserPage.xaml"
            this.searchMinTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sorterCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 50 "..\..\..\..\ViewManager\UserPage.xaml"
            this.sorterCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\ViewManager\UserPage.xaml"
            this.searchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.filterCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\..\..\ViewManager\UserPage.xaml"
            this.filterCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.searchMaxTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.searchMinTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.componentsButton = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\..\ViewManager\UserPage.xaml"
            this.componentsButton.Click += new System.Windows.RoutedEventHandler(this.ComponentsButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.addQuantityButton = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\ViewManager\UserPage.xaml"
            this.addQuantityButton.Click += new System.Windows.RoutedEventHandler(this.addQuantityButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.quantityTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 93 "..\..\..\..\ViewManager\UserPage.xaml"
            this.quantityTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.quantityTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

