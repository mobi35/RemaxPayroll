﻿#pragma checksum "..\..\..\ViewModel\EmployeePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E74A47B8E366DD9DDEB517F13F423DFF614457ED"
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
using Remax2019;
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
    /// EmployeePage
    /// </summary>
    public partial class EmployeePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GridContent;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock user;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock leaveNotif;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock leaveText;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock overTimeNotif;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ViewModel\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock overTimeText;
        
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
            System.Uri resourceLocater = new System.Uri("/Remax2019;component/viewmodel/employeepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewModel\EmployeePage.xaml"
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
            this.GridContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            
            #line 24 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Draggable);
            
            #line default
            #line hidden
            return;
            case 3:
            this.user = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 36 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Power);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 65 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dashboard);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 67 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmployeeAttendance);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 69 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmployeeLoan);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 72 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Leave);
            
            #line default
            #line hidden
            return;
            case 9:
            this.leaveNotif = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.leaveText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 83 "..\..\..\ViewModel\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Overtime);
            
            #line default
            #line hidden
            return;
            case 12:
            this.overTimeNotif = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.overTimeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

