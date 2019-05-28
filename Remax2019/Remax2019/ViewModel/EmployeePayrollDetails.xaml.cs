using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Reporting.WinForms;
using Remax2019.Model;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for EmployeePayrollDetails.xaml
    /// </summary>
    ///



    public partial class EmployeePayrollDetails : Window
    {

        public EmployeePayrollDetails(dynamic emp)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            EmpGrid.ItemsSource = emp;
            ReportViewerDemo.Reset();
        


            DataTable dt = Payroll.ToDataTable(emp);
            ReportDataSource ds = new ReportDataSource("SingleEmployee", dt);
            ReportViewerDemo.LocalReport.DataSources.Add(ds);
            ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Remax2019.Reports.SingleEmployee.rdlc";
            ReportViewerDemo.RefreshReport();

        }

        private void Close(object sender, RoutedEventArgs e)
        {

            Close();

        }

   
    }
}
