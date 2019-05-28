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
    /// Interaction logic for AdminLeaveControl.xaml
    /// </summary>
    public partial class AdminLeaveControl : UserControl
    {
        public AdminLeaveControl()
        {
            InitializeComponent();

            JoinLeaveUser();
        }

        public void JoinLeaveUser()
        {


            var JoinLeaveAndUser = DatabaseConnection.database1.tbl_leaves.Join(
                DatabaseConnection.database1.tbl_accounts, id => id.employeeid, forId => forId.id, (id, forId) =>
                    new { leaves = id, account = forId }).OrderByDescending(a => a.leaves.id).Where(a => a.leaves.status == "pending").Select(a => new
                {
                    Id = a.leaves.id,
                    TypeOfLeave = a.leaves.type_of_leave,
                    StartDate = a.leaves.start_of_leave,
                    EndDate = a.leaves.end_of_leave,
                    Message = a.leaves.message,
                    Status = a.leaves.status,
                    User = a.account.name,
                    Position = a.account.job_title

                }


            ).ToList();


            var JoinLeaveAndUserHistory = DatabaseConnection.database1.tbl_leaves.Join(
                DatabaseConnection.database1.tbl_accounts, id => id.employeeid, forId => forId.id, (id, forId) =>
                    new { leaves = id, account = forId }).OrderByDescending(a => a.leaves.id).Where(a => a.leaves.status != null && a.leaves.status != "pending").Select(a => new
                {
                    Id = a.leaves.id,
                    TypeOfLeave = a.leaves.type_of_leave,
                    StartDate = a.leaves.start_of_leave,
                    EndDate = a.leaves.end_of_leave,
                    Message = a.leaves.message,
                    Status = a.leaves.status,
                    User = a.account.name,
                    Position = a.account.job_title

                }


            ).ToList();

            LeaveControl.ItemsSource = JoinLeaveAndUser;
            LeaveControlHistory.ItemsSource = JoinLeaveAndUserHistory;

        }

        private void AcceptLeave(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            accept.Tag = myValue;

        }

        private void DeclineLeave(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            decline.Tag = myValue;
        }

        private void confirmAccept(object sender, RoutedEventArgs e)
        {
            int leaveId = (int)((Button)sender).Tag;
            var leave = DatabaseConnection.database1.tbl_leaves.FirstOrDefault(a => a.id == leaveId);
            leave.status = "accepted";
            leave.accepted_by = Application.Current.Properties["fullName"].ToString();
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == leave.employeeid);
            account.leaveRequest = 0;
            account.leave_notification += 1;
    
            
            TimeSpan difference = leave.end_of_leave.Value.Date - leave.start_of_leave.Value.Date;
            account.allowable_leaves -= difference.Days;
            DatabaseConnection.database1.SaveChanges();
            for (int a = 0; a <= difference.Days;a++)
            {
                var attendance = new tbl_attendance();
                DateTime startDate = new DateTime();
                startDate = leave.start_of_leave.Value.Date.AddDays(a);
                DateTime startDate2 = new DateTime();
                startDate2 = startDate.AddHours(config().working_start.Value.Hours);


                var attendance2 = new tbl_attendance();
                DateTime endDate = new DateTime();
                endDate = leave.start_of_leave.Value.Date.AddDays(a);
                DateTime endDate2 = new DateTime();
                endDate2 = endDate.AddHours(config().working_end.Value.Hours);
                attendance.isLeave = "Leave";
                attendance2.isLeave = "Leave";
                attendance.time_in = startDate2;
                attendance2.time_out = endDate2;
                attendance.username = account.username;
                attendance2.username = account.username;
                DatabaseConnection.database1.tbl_attendance.Add(attendance);
                DatabaseConnection.database1.tbl_attendance.Add(attendance2);
                DatabaseConnection.database1.SaveChanges();

            }
            
      
            JoinLeaveUser();
        }



        private void ViewMessage(object sender, RoutedEventArgs e)
        {
            int leaveId = (int)((Button)sender).Tag;
            var leaveObject = DatabaseConnection.database1.tbl_leaves.FirstOrDefault(a => a.id == leaveId);
            MessageBox.Show(leaveObject.message);
        }

        public tbl_payroll_configuration config()
        {
            return DatabaseConnection.database1.tbl_payroll_configuration.FirstOrDefault();
        }

        private void confirmDecline(object sender, RoutedEventArgs e)
        {
            int leaveId = (int)((Button)sender).Tag;
            var leave = DatabaseConnection.database1.tbl_leaves.FirstOrDefault(a => a.id == leaveId);
            leave.status = "declined";
            leave.accepted_by = Application.Current.Properties["fullName"].ToString();
            var checkAccount = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == leave.employeeid);
            checkAccount.leaveRequest = 0;
            var account = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == leave.employeeid);
            account.leave_notification += 1;
            DatabaseConnection.database1.SaveChanges();
            JoinLeaveUser();
        }


    }
}
