using System;
using System.Collections.Generic;
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
using MaterialDesignThemes.Wpf;
using Remax2019.Model;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for EmployeeOvertime.xaml
    /// </summary>
    public partial class EmployeeOvertime : UserControl
    {
        public EmployeeOvertime()
        {
            InitializeComponent();
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            DatePick.BlackoutDates.Add(cdr);
            var id = Convert.ToInt32(Application.Current.Properties["userId"].ToString());
            var overTime = DatabaseConnection.database1.tbl_overtime.Where(a => a.employee_Id == id).OrderByDescending(a => a.id).ToList();
            Overtime.ItemsSource = overTime;


            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == id);
            account.memo_notification = 0;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
         tbl_overtime overtime = new tbl_overtime();
            var id = Convert.ToInt32(Application.Current.Properties["userId"].ToString());
            overtime.date_ot = DatePick.SelectedDate;
            overtime.employee_Id = id;
            overtime.status = "pending";
            DateTime time = DateTime.Today.Add(TimePick.SelectedTime.Value.TimeOfDay);
            overtime.until_time = time;
            var user = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == id);
            overtime.name = user.name;
            overtime.reason = Message.Text;
            //string displayTime = time.ToString("hh:mm tt");

            DatabaseConnection.database1.tbl_overtime.Add(overtime);
            DatabaseConnection.database1.SaveChanges();

         
            var overTime = DatabaseConnection.database1.tbl_overtime.Where(a => a.employee_Id == id).OrderByDescending(a => a.id).ToList();
            Overtime.ItemsSource = overTime;

           
        }


    }
}
