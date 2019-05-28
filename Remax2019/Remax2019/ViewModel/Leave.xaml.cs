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
    /// Interaction logic for Leave.xaml
    /// </summary>
    public partial class Leave : UserControl
    {
        int userId = Int32.Parse(Application.Current.Properties["userId"].ToString());
        public Leave()
        {
            InitializeComponent();
            var leaves = DatabaseConnection.database1.tbl_leaves.OrderByDescending(a => a.id).Where(a => a.employeeid == userId).ToList();

            var myLeave = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == userId);

            Leaves.Text = "Leave(s): " + myLeave.allowable_leaves.ToString();

            EmployeeLeave.ItemsSource = leaves;
        }

        private void AddLeave(object sender, RoutedEventArgs e)
        {
            tbl_leaves leave = new tbl_leaves();

          
            var user =  DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == userId);

            if(user.leaveRequest < 1 || user.leaveRequest == null) {  
            if (EndOfLeave.SelectedDate < StartOfLeave.SelectedDate)
            {
                MessageBox.Show("Date error please write the leave starting date and  ending date");
                return ;
            }

                if (StartOfLeave.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Dont add past dates");
                    return;
                }
                if (EndOfLeave.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Dont add Past Dates");
                    return;
                }

                if (StartOfLeave.SelectedDate == EndOfLeave.SelectedDate)
                {
                    MessageBox.Show("Dates can't be equal");
                    return;
                }

                if (Message.Text == "" || TypeOfLeave.Text == "")
            {
                MessageBox.Show("PLease complete the fields");
                return;
            }
                TimeSpan dateDifference = EndOfLeave.SelectedDate.Value - StartOfLeave.SelectedDate.Value;
            
                var dateDiff =  dateDifference.Days;

                if (dateDiff == 0 )
                {
                    MessageBox.Show("Please enter a valid date");
                    return;
                }

               // dateDiff++;
            
                if (user.allowable_leaves < dateDiff || user.allowable_leaves == null)
                {
                   
                    MessageBox.Show("You have insufficient leave. You only have " + user.allowable_leaves + " number of days for leave. ");

                    return;
                }

        
             leave.type_of_leave = TypeOfLeave.Text;
            leave.message = Message.Text;
            leave.start_of_leave = StartOfLeave.SelectedDate;
            leave.end_of_leave = EndOfLeave.SelectedDate;
            leave.employeeid = userId;
                leave.status = "pending";
                DatabaseConnection.database1.tbl_leaves.Add(leave);
            DatabaseConnection.database1.SaveChanges();

            TypeOfLeave.Text = "";
            Message.Text = "";
            StartOfLeave.SelectedDate = null;
           EndOfLeave.SelectedDate = null;
                var leaves = DatabaseConnection.database1.tbl_leaves.OrderByDescending(a => a.id).Where(a => a.employeeid == userId).ToList();
                EmployeeLeave.ItemsSource = leaves;

              
                MessageBox.Show("Successfully Requested");
            AddLeave(Int32.Parse(Application.Current.Properties["userId"].ToString()));

            }
            else
            {
                MessageBox.Show("You already sent a leave request please wait for the admin's response.");
            }
        }


        private void AddLeave(int userId)
        {
          var user =   DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == userId);
          user.leaveRequest = 1;
          DatabaseConnection.database1.SaveChanges();
        }


   

    }
}
