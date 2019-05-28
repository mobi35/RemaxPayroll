﻿#pragma checksum "..\..\..\ViewModel\Holidays.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1A22DD6AD7A69F34E9948F2ED1AAE5961D2C8826"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Remax2019.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Remax2019.ViewModel {
    
    
    /// <summary>
    /// Holidays
    /// </summary>
    public partial class Holidays : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HolidayTextbox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatepickerTextbox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Holiday;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid HolidayGrid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost isDelete;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteHolidayName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost editHolidayDialog;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HolidayId;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HolidayTitle;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker UpdatePicker;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\ViewModel\Holidays.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmUpdateClick;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Remax2019;component/viewmodel/holidays.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewModel\Holidays.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HolidayTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DatepickerTextbox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Holiday = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\ViewModel\Holidays.xaml"
            this.Holiday.Click += new System.Windows.RoutedEventHandler(this.SubmitHoliday);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HolidayGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.isDelete = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 8:
            this.DeleteHolidayName = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\ViewModel\Holidays.xaml"
            this.DeleteHolidayName.Click += new System.Windows.RoutedEventHandler(this.ConfirmDelete);
            
            #line default
            #line hidden
            return;
            case 9:
            this.editHolidayDialog = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 10:
            this.HolidayId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.HolidayTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.UpdatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.ConfirmUpdateClick = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\ViewModel\Holidays.xaml"
            this.ConfirmUpdateClick.Click += new System.Windows.RoutedEventHandler(this.ConfirmUpdate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 28 "..\..\..\ViewModel\Holidays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteHolidayClick);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 30 "..\..\..\ViewModel\Holidays.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditHolidayClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

