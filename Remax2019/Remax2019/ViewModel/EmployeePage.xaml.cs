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
using System.Windows.Shapes;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
     


        public EmployeePage()
        {
            //Application.Current.Properties["stuff"] = "Adrian Radores";
            InitializeComponent();
            var xx = Convert.ToInt32(Application.Current.Properties["userId"].ToString());
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == xx);
            overTimeNotif.Text = "(" + account.memo_notification + ")";
            leaveNotif.Text = "(" + account.leave_notification + " )";

            if (account.memo_notification == 0)
            {
                overTimeNotif.Background = Brushes.DarkRed;
            }
            else
            {
                overTimeNotif.Background = Brushes.Gray;
            }

            if (account.leave_notification == 0)
            {
                leaveNotif.Background = Brushes.DarkRed;
            }
            else
            {
                leaveNotif.Background = Brushes.Gray;
            }

            try
            {
                user.Text = "Welcome, " + Application.Current.Properties["userName"].ToString();
            }
            catch (Exception v)
            {
                
            }
        }

        private void Power(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["userId"] = null;
            Close();
            Login log = new Login();
            log.ShowDialog();
        }

        private void Draggable(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Dashboard(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new EmployeeDashboard());
        }

        private void Accounts(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AddUser());
        }
        private void EmployeeLoan(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new EmployeeLoan());
        }
        
        private void EmployeeAttendance(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new EmployeeAttendance());
        }

        private void Leave(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new Leave());
            var xx = Convert.ToInt32(Application.Current.Properties["userId"].ToString());
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == xx);
            account.leave_notification = 0;
            leaveNotif.Background = Brushes.DarkRed;


        
            overTimeNotif.Text = "(" + account.memo_notification + ")";
            leaveNotif.Text = "(" + account.leave_notification + " )";

            if (account.memo_notification == 0)
            {
                overTimeNotif.Background = Brushes.DarkRed;
            }
            else
            {
                overTimeNotif.Background = Brushes.Gray;
            }

            if (account.leave_notification == 0)
            {
                leaveNotif.Background = Brushes.DarkRed;
            }
            else
            {
                leaveNotif.Background = Brushes.Gray;
            }
            DatabaseConnection.database1.SaveChanges();
        }

        private void Overtime(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new EmployeeOvertime());
            var xx = Convert.ToInt32(Application.Current.Properties["userId"].ToString());
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == xx);
            account.memo_notification = 0;

            overTimeNotif.Text = "(" + account.memo_notification + ")";
            leaveNotif.Text = "(" + account.leave_notification + " )";

            if (account.memo_notification == 0)
            {
                overTimeNotif.Background = Brushes.DarkRed;
            }
            else
            {
                overTimeNotif.Background = Brushes.Gray;
            }

            if (account.leave_notification == 0)
            {
                leaveNotif.Background = Brushes.DarkRed;
            }
            else
            {
                leaveNotif.Background = Brushes.Gray;
            }

            DatabaseConnection.database1.SaveChanges();
        }

     
    }


}
