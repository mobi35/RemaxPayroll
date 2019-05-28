using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
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
using Remax2019.Model;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Data.Entity;
using System.Reflection;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for Payroll.xaml
    /// </summary>
    public partial class Payroll : UserControl
    {
        public Payroll()
        {
            InitializeComponent();

            var payroll = DatabaseConnection.database1.tbl_payroll.AsNoTracking().Where(a => a.processed != null && a.processed != "complete").ToList();
            payrollGrid.ItemsSource = payroll;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            EmployeeList.ItemsSource = "";
            var xx = (tbl_payroll)payrollGrid.SelectedItem;

            var startDate = xx.start_date.Value.Date;
            var endDate = xx.end_date.Value.AddDays(1).Date;

            

            var practiceJoin = DatabaseConnection.database1.tbl_employee_payroll.Join(
                    DatabaseConnection.database1.tbl_accounts, id => id.username, forId => forId.employeeId
                    , (id, forId) => new { Id = id, ForeignId = forId })
                .Where(a => EntityFunctions.TruncateTime(a.Id.day) >= EntityFunctions.TruncateTime(startDate) &&
                                           EntityFunctions.TruncateTime(a.Id.day) <= EntityFunctions.TruncateTime(endDate))
                .GroupBy(a => a.Id.username).Select(lg => new
                {
                    EmployeeID = lg.Key,
                    Fullname = lg.FirstOrDefault().ForeignId.name,
                    BasicSalary = lg.FirstOrDefault().ForeignId.basic_salary,
                    Position = lg.FirstOrDefault().ForeignId.position,
                    Earned = lg.Sum(a => a.Id.earned),
                    LastDay = lg.FirstOrDefault().Id.day,
                    NumberOfdays = lg.Count()
                }).ToList();


            var getdeductionAgain = practiceJoin.Join(
                    DatabaseConnection.database1.tbl_deductions,
                    id => id.EmployeeID, foreign => foreign.employee_id,
                    (primaryId, foreignId) => new {PrimaryID = primaryId, ForeignID = foreignId})
                .Where(a => a.ForeignID.covered_date >= startDate &&
                           a.ForeignID.covered_date <= endDate).GroupBy(a => a).Select(lg => new
                {
                    EmployeeID = lg.FirstOrDefault().PrimaryID.EmployeeID,
                    Fullname = lg.FirstOrDefault().PrimaryID.Fullname,
                    BasicSalary = lg.FirstOrDefault().PrimaryID.BasicSalary,
                    Position = lg.FirstOrDefault().PrimaryID.Position,
                    Earned = lg.Sum(a => a.PrimaryID.Earned),
                    LastDay = lg.FirstOrDefault().PrimaryID.LastDay,
                    NumberOfdays =  lg.FirstOrDefault().PrimaryID.NumberOfdays,
                    Government_Tax = lg.FirstOrDefault().ForeignID.government_tax,
                    pagibig_tax = lg.FirstOrDefault().ForeignID.pagibig_tax,
                    loan = lg.FirstOrDefault().ForeignID.loan,
                    cashAdvance = lg.FirstOrDefault().ForeignID.cash_advance,
                               total_salary = lg.FirstOrDefault().ForeignID.total_salary,
                    tardy = lg.FirstOrDefault().ForeignID.tardy,
                    absent = lg.FirstOrDefault().ForeignID.tardy,
                    cutoff = lg.FirstOrDefault().ForeignID.cutoff_total_salary,

                }).ToList();

 
                
            Console.WriteLine("Number of practice Join" + practiceJoin.Count);
            EmployeeList.ItemsSource = getdeductionAgain;

            ReportViewerDemo.Reset();
            DataTable dt = ToDataTable(getdeductionAgain);
            ReportDataSource ds = new ReportDataSource("dataset", dt);
            ReportViewerDemo.LocalReport.DataSources.Add(ds);
            ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Remax2019.Reports.Employee.rdlc";
            ReportViewerDemo.RefreshReport();

            //  var newMemList = new AccountDetails();

            // execute some code
        }



        private void EmployeePayroll_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            // EmployeeList.ItemsSource = "";
            var firstSelectedCellContent = this.EmployeeList.Columns[0].GetCellContent(this.EmployeeList.SelectedItem);
            var firstSelectedCell = firstSelectedCellContent != null ? firstSelectedCellContent.Parent as DataGridCell : null;
                   var employeeId = firstSelectedCell.ToString().Substring(38);
            var Day1 = this.EmployeeList.Columns[10].GetCellContent(this.EmployeeList.SelectedItem);
            var Day1Select = Day1 != null ? Day1.Parent as DataGridCell : null;
                  var days = Day1Select.ToString().Substring(38,10);
          
            var date = DateTime.Parse(days);
      
            var getMe = DatabaseConnection.database1.tbl_payroll.FirstOrDefault(a =>
                EntityFunctions.TruncateTime(a.start_date) <= EntityFunctions.TruncateTime(date)
                && EntityFunctions.TruncateTime(a.end_date) >= EntityFunctions.TruncateTime(date)
                );

            var startDate = getMe.start_date;
            var endDate = getMe.end_date;



       
            var selectAllEarning = DatabaseConnection.database1.tbl_employee_payroll.Join(
                    DatabaseConnection.database1.tbl_accounts, id => id.username, forId => forId.employeeId
                    , (id, forId) => new { Id = id, ForeignId = forId })
                .AsNoTracking().Where(a => EntityFunctions.TruncateTime(a.Id.day) >= EntityFunctions.TruncateTime(startDate)
                            && EntityFunctions.TruncateTime(a.Id.day) <= EntityFunctions.TruncateTime(endDate) &&
                                           a.Id.username == employeeId
                                           )
                .GroupBy(a => a).Select(lg => new
                {
                    Id = lg.Key,
                    EmployeeID = lg.FirstOrDefault().ForeignId.employeeId,
                    Fullname = lg.FirstOrDefault().ForeignId.name,
                    BasicSalary = lg.FirstOrDefault().ForeignId.basic_salary,
                    Position = lg.FirstOrDefault().ForeignId.position,
                    JobTitle = lg.FirstOrDefault().ForeignId.job_title,
                    Address = lg.FirstOrDefault().ForeignId.address,
                    Picture = lg.FirstOrDefault().ForeignId.picture,
                    Earned = lg.FirstOrDefault().Id.earned,
                    LastDay = lg.FirstOrDefault().Id.day
                }).OrderByDescending(a => a.LastDay).ToList();

            var JoinDeductions = selectAllEarning.Join(
                    DatabaseConnection.database1.tbl_deductions,
                    a => a.EmployeeID,
                    c => c.employee_id,
                    (employee, deduction) => new
                        {Employee = employee, Deduction = deduction})
                .Where(a => a.Deduction.covered_date >= startDate
                            && a.Deduction.covered_date <= endDate
                            )
                .GroupBy(a => a).Select(zx => new
                {
                    EmployeeID = zx.FirstOrDefault().Employee.EmployeeID,
                    Fullname = zx.FirstOrDefault().Employee.Fullname,
                    BasicSalary = zx.FirstOrDefault().Employee.BasicSalary,
                    Position = zx.FirstOrDefault().Employee.Position,
                    JobTitle = zx.FirstOrDefault().Employee.JobTitle,
                    Address = zx.FirstOrDefault().Employee.Address,
                    Picture = zx.FirstOrDefault().Employee.Picture,
                    Earned = zx.FirstOrDefault().Employee.Earned,
                    LastDay = zx.FirstOrDefault().Employee.LastDay,
                    Government_Tax = zx.FirstOrDefault().Deduction.government_tax,
                    Pagibig_Tax = zx.FirstOrDefault().Deduction.pagibig_tax,
                    Total_Salary = zx.FirstOrDefault().Deduction.total_salary,
                    Absent = zx.FirstOrDefault().Deduction.tardy,
                    CutOffTotalSalary = zx.FirstOrDefault().Deduction.cutoff_total_salary

                }).ToList();


          

    

            var PayrollDetails = new EmployeePayrollDetails(JoinDeductions);
            PayrollDetails.ShowDialog();

        }

        private void Complete(object sender, RoutedEventArgs e)
        {

        }

        private void Archived(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            deleteMember.Tag = myValue;
        }

        private void confirmArchived(object sender, RoutedEventArgs e)
        {
            int memberId = (int)((Button)sender).Tag;
            var payroll = DatabaseConnection.database1.tbl_payroll.FirstOrDefault(a => a.id == memberId);
            payroll.processed = "complete";
            DatabaseConnection.database1.SaveChanges();
            var payrollx = DatabaseConnection.database1.tbl_payroll.AsNoTracking().Where(a => a.processed != null && a.processed != "complete").ToList();
            payrollGrid.ItemsSource = payrollx;
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
          
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
