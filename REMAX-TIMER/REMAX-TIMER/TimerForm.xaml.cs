using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading;
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
using REMAX_TIMER.Model;

namespace REMAX_TIMER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimerForm : Window
    {
      
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public TimerForm()
        {
            InitializeComponent();
            Dates.Content = DateTime.Now.Date.ToLongDateString();
            var account = Application.Current.Properties["username"].ToString();
            var selectAccount = database.tbl_accounts.FirstOrDefault(a => a.username == account);
            try
            {
                texting.Text = "Welcome, " + selectAccount.name;
                Name.Text = selectAccount.name;
                Position.Text = selectAccount.position;
                Username.Text = selectAccount.username;
                EmpId.Text = selectAccount.employeeId;
                var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(selectAccount.picture);
                AlreadyImage.Source = bitmap;
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
            DateNow();
          
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

         

        }

        

        private void Timer_Click(object sender, EventArgs e)

        {
            DateTime d;
            d = DateTime.Now;
            label1.Content =    d.Hour + " : " + d.Minute + " : " + d.Second;

        }
       
        RemaxDatabase database = new RemaxDatabase();

      
        public void TimeIn()
        {


            string userName = Application.Current.Properties["username"].ToString();
            var selectAttendance = database.tbl_attendance.FirstOrDefault(a => a.username == userName && EntityFunctions.TruncateTime(a.time_in) == EntityFunctions.TruncateTime(DateTime.Now) && a.isLeave == "Leave" );



            if (selectAttendance != null)
            {
                MessageBox.Show("You can't time in !! It's your leave today");
                return;
            }

            var selectInDb = database.tbl_attendance.OrderByDescending(a => a.id).Take(1).FirstOrDefault(a => a.time_in != null);
            if(selectInDb != null) {  
            if (DateTime.Now.Date == selectInDb.time_in.Value.Date)
            {
                return;
            }
            }
            tbl_attendance attendance = new tbl_attendance();
            attendance.date = DateTime.Now;
            int id = Int32.Parse(Application.Current.Properties["userId"].ToString());
            var getOvertime =
                database.tbl_overtime.FirstOrDefault(a => a.employee_Id == id && a.status == "accepted" && EntityFunctions.TruncateTime(a.date_ot) == EntityFunctions.TruncateTime(DateTime.Now));

            if (getOvertime != null && DateTime.Now.Hour >= config().working_end.Value.Hours)
            {
             
                if (DateTime.Now.TimeOfDay.TotalMilliseconds >= getOvertime.until_time.Value.TimeOfDay.TotalMilliseconds)
                {
    
                   DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, getOvertime.until_time.Value.Hour, 0, 0);
                    attendance.time_in = dt;
                }
                else
                {
                    attendance.time_in = DateTime.Now;
                }

            }else if (DateTime.Now.TimeOfDay.TotalMilliseconds >= config().working_end.Value.TotalMilliseconds)
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, config().working_end.Value.Hours, 0, 0);
                attendance.time_in = dt;
            }
            else if (DateTime.Now.TimeOfDay.TotalMilliseconds <= config().working_start.Value.TotalMilliseconds)
            {
                DateTime dt = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day, config().working_start.Value.Hours, 0,0);
                attendance.time_in = dt;
            }
            else
            {
                attendance.time_in = DateTime.Now;
            }
          
       
            attendance.username = Application.Current.Properties["employeeId"].ToString();
            database.tbl_attendance.Add(attendance);
            database.SaveChanges();
            DateNow();
           


        }
        public  tbl_payroll_configuration config()
        {
            return database.tbl_payroll_configuration.FirstOrDefault();
        }

        public void TimeOut()
        {

            string userName = Application.Current.Properties["username"].ToString();
            var selectAttendance = database.tbl_attendance.FirstOrDefault(a => a.username == userName && EntityFunctions.TruncateTime(a.time_in) == EntityFunctions.TruncateTime(DateTime.Now) && a.isLeave == "Leave");
            if (selectAttendance != null)
            {
                MessageBox.Show("You can't time in !! It's your leave today");
                return;
            }

            var selectInDb = database.tbl_attendance.OrderByDescending(a => a.id).Take(1).FirstOrDefault(a => a.time_out != null);
            if (selectInDb != null)
            {
                if (DateTime.Now.Date == selectInDb.time_in.Value.Date)
                {
                    return;
                }
            }

            int id = Int32.Parse(Application.Current.Properties["userId"].ToString());
            tbl_attendance attendance = new tbl_attendance();
            attendance.date = DateTime.Now;

            var getOvertime =
                database.tbl_overtime.FirstOrDefault(a => a.employee_Id == id && a.status == "accepted"  && EntityFunctions.TruncateTime(a.date_ot) == EntityFunctions.TruncateTime(DateTime.Now));

            Console.WriteLine("unang oras" + DateTime.Now.TimeOfDay.TotalMilliseconds);
            Console.WriteLine("pangalawang oras" + config().working_start.Value.TotalMilliseconds);
            if (getOvertime != null && DateTime.Now.Hour >= config().working_end.Value.Hours)
            {

                if (DateTime.Now.TimeOfDay.TotalMilliseconds >= getOvertime.until_time.Value.TimeOfDay.TotalMilliseconds)
                {
                    DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, getOvertime.until_time.Value.Hour, 0, 0);
                    attendance.time_out = dt;
                }else
                {
                    attendance.time_out = DateTime.Now;
                }

            }
            else if (DateTime.Now.TimeOfDay.TotalMilliseconds <= config().working_start.Value.TotalMilliseconds)
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, config().working_start.Value.Hours, 0, 0);
                attendance.time_out = dt;
            }
            else if (DateTime.Now.TimeOfDay.TotalMilliseconds >= config().working_end.Value.TotalMilliseconds)
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, config().working_end.Value.Hours, 0, 0);
                attendance.time_out = dt;
            }else
            {
                attendance.time_out = DateTime.Now;
            }
            attendance.username = Application.Current.Properties["employeeId"].ToString();
            database.tbl_attendance.Add(attendance);
            database.SaveChanges();
            DateNow();
           
        }

        public void DateNow()
        {
            string empID = Application.Current.Properties["employeeId"].ToString();
            var attendance = database.tbl_attendance.OrderByDescending(a => a.id).Where(a => a.username == empID && EntityFunctions.TruncateTime(a.date) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();
            Timing.ItemsSource = attendance;
        }

      

        private void UIElement_OnDragEnter(object sender, DragEventArgs e)
        {
         DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           TimeOut();
            Close();
            
        }

     

        private void Draggables(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            
        }
    }
}
