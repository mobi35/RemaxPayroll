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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Remax2019.Model;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for AdminReviewOvertime.xaml
    /// </summary>
    public partial class AdminReviewOvertime : UserControl
    {
        public AdminReviewOvertime()
        {
            InitializeComponent();
            var loadOvertime = DatabaseConnection.database1.tbl_overtime.Where(a => a.status == "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertime.ItemsSource = loadOvertime;

            var loadOvertimeHistory = DatabaseConnection.database1.tbl_overtime.Where(a => a.status != null && a.status != "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertimeHistory.ItemsSource = loadOvertimeHistory;
        }


     

      

        private void DeclineGetId(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            declineOvertime.Tag = myValue;
      
        }

        private void AcceptGetId(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            acceptOvertime.Tag = myValue;
          
        }

 
        private void AcceptOvertime_OnClick(object sender, RoutedEventArgs e)
        {
            int overTimeId = (int)((Button)sender).Tag;
          
            var overtime = DatabaseConnection.database1.tbl_overtime.FirstOrDefault(a => a.id == overTimeId);

            overtime.status = "accepted";
            DatabaseConnection.database1.SaveChanges();
        
            overtime.accepted_by = Application.Current.Properties["fullName"].ToString();
            var loadOvertime = DatabaseConnection.database1.tbl_overtime.Where(a => a.status == "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertime.ItemsSource = loadOvertime;

            var loadOvertimeHistory = DatabaseConnection.database1.tbl_overtime.Where(a => a.status != null && a.status != "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertimeHistory.ItemsSource = loadOvertimeHistory;
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == overtime.employee_Id );
            account.memo_notification += 1;
        }
        private void DeclineOvertime_OnClick(object sender, RoutedEventArgs e)
        {
            int overTimeId = (int)((Button)sender).Tag;
            var overtime = DatabaseConnection.database1.tbl_overtime.FirstOrDefault(a => a.id == overTimeId);
            overtime.status = "declined";
            overtime.accepted_by = Application.Current.Properties["fullName"].ToString();
            DatabaseConnection.database1.SaveChanges();
            var loadOvertime = DatabaseConnection.database1.tbl_overtime.Where(a => a.status == "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertime.ItemsSource = loadOvertime;

            var loadOvertimeHistory = DatabaseConnection.database1.tbl_overtime.Where(a => a.status != null && a.status != "pending").OrderByDescending(a => a.id).ToList();
            AdminOvertimeHistory.ItemsSource = loadOvertimeHistory;

            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == overtime.employee_Id);
            account.memo_notification += 1;
        }
    }
}
