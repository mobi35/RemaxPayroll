using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using Remax2019.ViewModel;

namespace Remax2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
        
            InitializeComponent();
            ControlCenter.UpdateBirthdays();
          var d = DateTime.Now.AddYears(-20);
            ControlCenter.GiveBirthday(d);
         
            try
            {
                texting.Text = "Welcome, "  +   Application.Current.Properties["fullName"].ToString();
            } 
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Timer.Tick += new EventHandler(Database_Update);

            Timer.Interval = new TimeSpan(0, 0, 3);
            Timer.Start();

            GridContent.Children.Clear();
            GridContent.Children.Add(new Dashboard());

            if (Application.Current.Properties["position"].ToString() == "Admin")
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
            else if (Application.Current.Properties["position"].ToString() == "HR Staff")
            {
                HRPanel.Visibility = Visibility.Visible;
            }
           
        }
        private void Database_Update(object sender, EventArgs e)
        {
           
            var payroll = DatabaseConnection.database1.tbl_payroll.Count();
            if (payroll == 0)
            {
                if (DateTime.Now.Day <= 12 || DateTime.Now.Day >= 26)
                {
                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 26);
                    DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 12);
                    var payRoll = new tbl_payroll();
                    payRoll.start_date = startDate;
                    payRoll.end_date = endDate;
                    DatabaseConnection.database1.tbl_payroll.Add(payRoll);
                    DatabaseConnection.database1.SaveChanges();
                }else if (DateTime.Now.Day >= 13 && DateTime.Now.Day <= 25)
                {
                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13);
                    DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                    var payRoll = new tbl_payroll();
                    payRoll.start_date = startDate;
                    payRoll.end_date = endDate;
                    DatabaseConnection.database1.tbl_payroll.Add(payRoll);
                    DatabaseConnection.database1.SaveChanges();
                }
            }

            //CHECK CUT OFFS
            DateTime cutoff1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 26);
            var dateNow = DateTime.Now.Date;

            if (cutoff1.Date == dateNow)
            {

                var cutofc = DatabaseConnection.database1.tbl_payroll.FirstOrDefault(a => a.processed == null &&
                 EntityFunctions.TruncateTime(a.end_date) < EntityFunctions.TruncateTime(dateNow));
                if (cutofc != null)
                {
                    cutofc.processed = "processed";
                    var attendance = DatabaseConnection.database1.tbl_attendance
                        .Where(a => EntityFunctions.TruncateTime(a.date) <= EntityFunctions.TruncateTime(cutoff1) && 
                         EntityFunctions.TruncateTime(a.date) >= EntityFunctions.TruncateTime(cutofc.start_date)).ToList();


                    var user = DatabaseConnection.database1.tbl_accounts.ToList();
                    foreach (var us in user)
                    {
                        var jobTitle = us.job_title;
                        var selectSalary = DatabaseConnection.database1.tbl_job_title.Where(a => a.job_title == jobTitle).Select(a => a.salary)
                            .FirstOrDefault();
                        double? employeeBasicSalary = selectSalary;
                        double? tardy;
                        double? holidayBonus = 0;
                        double? sss;
                        double? accumulatedSalary = 0;
                        double? government_tax = ControlCenter.Ph_Taxation(employeeBasicSalary);
                        int totalDaysOfPresent = 0;
                        double? totalSalary ;
                        TimeSpan ts = TimeSpan.Zero;
                        TimeSpan timeIn = TimeSpan.Zero;
                        TimeSpan timeOut = TimeSpan.Zero;
                        double? fullDailySalary = 0;
                        TimeSpan difference = cutofc.end_date.Value.Date - cutofc.start_date.Value.Date;
                        var totalDay = (int)difference.TotalDays;
                        DateTime? date = DateTime.Now;
                   
                        double? earnedPerMinute = 0;
                        for (int x = 0; x <= totalDay; x++)
                        {
                          
                            foreach (var a in attendance)
                            {
                                    if (us.employeeId == a.username &&
                                        a.date.Value.Date == cutofc.start_date.Value.Date.AddDays(x))
                                    {

                                        totalDaysOfPresent++;
                                        if (a.time_in != null)
                                        {
                                            timeIn = a.time_in.Value.TimeOfDay;
                                        }

                                        if (a.time_out != null)
                                        {
                                            timeOut = a.time_out.Value.TimeOfDay;
                                        }

                                        if (timeIn != TimeSpan.Zero && timeOut != TimeSpan.Zero)
                                        {
                                            ts += timeOut - timeIn;
                                            timeIn = TimeSpan.Zero;
                                            timeOut = TimeSpan.Zero;
                                        }

                                        date = a.date;
                                    }
                                
                            }
                            double? workingHours = DatabaseConnection.config().working_hours.Value.TotalHours;
                            var whatMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                          
                            fullDailySalary = selectSalary / 30;
                            Console.WriteLine("this is a fucking ful ldaily " + fullDailySalary);
                            earnedPerMinute = (fullDailySalary / workingHours ) / 60.0;
                                earnedPerMinute *= ts.TotalMinutes;
                            accumulatedSalary += earnedPerMinute;
                                if (earnedPerMinute != 0)
                                {
                                    var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = date.Value.Date;
                                employeePayroll.earned = earnedPerMinute;
                                    totalSalary = earnedPerMinute;
                                    employeePayroll.username = us.employeeId;
                                    DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                    DatabaseConnection.database1.SaveChanges();
                                }

                            // CHECK if there's a holiday
                            var checkHoliday = cutofc.start_date.Value.Date.AddDays(x).Date;
                            var holiday = DatabaseConnection.database1.tbl_holidays.FirstOrDefault(a => a.datetime == checkHoliday);


                            if (cutofc.start_date.Value.Date.AddDays(x).DayOfWeek == System.DayOfWeek.Sunday
                                || cutofc.start_date.Value.Date.AddDays(x).DayOfWeek == System.DayOfWeek.Saturday)
                            {
                                totalDaysOfPresent++;
                                var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = cutofc.start_date.Value.Date.AddDays(x).Date;
                                employeePayroll.earned = fullDailySalary;
                                totalSalary = fullDailySalary;
                                accumulatedSalary += fullDailySalary;
                                employeePayroll.username = us.employeeId;
                                DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                DatabaseConnection.database1.SaveChanges();

                            }
                            else if (holiday != null)
                            {
                                totalDaysOfPresent++;
                                var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = cutofc.start_date.Value.Date.AddDays(x).Date;
                                employeePayroll.earned = fullDailySalary;
                                totalSalary = fullDailySalary;
                                holidayBonus += fullDailySalary;
                                accumulatedSalary += fullDailySalary;
                                employeePayroll.username = us.employeeId;
                                DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                DatabaseConnection.database1.SaveChanges();
                            }

                            ts = TimeSpan.Zero;
                           

                        }
                        // Start Deductions

                        var deductions = new tbl_deductions();
                        int? absences = totalDay - totalDaysOfPresent;
                        double? total = 0;
                        Console.WriteLine("totalDay BES " + totalDay);
                        Console.WriteLine("totalDaysOfPresent BES " + totalDaysOfPresent);
                        Console.WriteLine("ABSENT BES " + absences);
                        double? totalAbsent = 0;
                        if (absences != 0)
                        {
                            totalAbsent = absences * fullDailySalary;
                            deductions.absent = totalAbsent;
                            Console.WriteLine("absences BES " + totalDay);
                            Console.WriteLine("fullDailySalary BES " + totalDaysOfPresent);
                          
                        }
                        total = fullDailySalary * 12;
                        deductions.government_tax = government_tax;
                        deductions.pagibig_tax = 100;
                        tardy =  ( (employeeBasicSalary / 30) * 12 ) - accumulatedSalary;


                        deductions.tardy = tardy;
                        deductions.employee_id = us.employeeId;
                        deductions.covered_date = DateTime.Now.AddDays(-1).Date;
                        accumulatedSalary -= 100;
                        accumulatedSalary -= government_tax;
                      
                        deductions.holiday_bonus = holidayBonus;
                        deductions.cutoff_total_salary = total;

                        //CHECK IF THERE'S A LOAN

                        var loanTable = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a =>
                            a.employee_id == us.employeeId && a.status == "accepted");
                        if(loanTable != null && loanTable.remaining_cut_off != 0) {  
                        if (loanTable.issued_date.Value.Date < cutofc.start_date)
                        {
                            loanTable.remaining_cut_off -= 1;

                            deductions.loan = loanTable.cut_off_payment;
                            accumulatedSalary -= loanTable.cut_off_payment;
                        }
                        }else if (loanTable != null && loanTable.remaining_cut_off == 0)
                        {
                            loanTable.status = "completed";
                            
                        }
                        deductions.total_salary = accumulatedSalary;
                        DatabaseConnection.database1.tbl_deductions.Add(deductions);
                        DatabaseConnection.database1.SaveChanges();

                    }

                    DatabaseConnection.database1.SaveChanges();

                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 26);
                    var payRoll = new tbl_payroll();
                    if (DateTime.Now.Month == 12) { 
                    DateTime endDate = new DateTime(DateTime.Now.AddYears(1).Year, DateTime.Now.AddMonths(1).Month, 12);
                        payRoll.end_date = endDate;
                    }
                    else
                    {

                        DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 12);
                        payRoll.end_date = endDate;
                    }
                  
                    payRoll.start_date = startDate;
                  
                    DatabaseConnection.database1.tbl_payroll.Add(payRoll);
                    DatabaseConnection.database1.SaveChanges();

                }
            }
            DateTime cutoff2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13);

            if (cutoff2.Date == dateNow)
            {
                var cutoffs = DatabaseConnection.database1.tbl_payroll.FirstOrDefault
                    (a => a.processed == null && EntityFunctions.TruncateTime(a.end_date)
                          < EntityFunctions.TruncateTime(dateNow));
                    if(cutoffs != null) {  
                    cutoffs.processed = "processed";
                        var attendance = DatabaseConnection.database1.tbl_attendance
                            .Where(a => EntityFunctions.TruncateTime(a.date) <= EntityFunctions.TruncateTime(cutoff2) && EntityFunctions.TruncateTime(a.date) >= EntityFunctions.TruncateTime(cutoffs.start_date)).ToList();
                        
                      
                       
                        var user = DatabaseConnection.database1.tbl_accounts.ToList();
                        foreach (var us in user)
                        {

                        var jobTitle = us.job_title;
                            var selectSalary = DatabaseConnection.database1.tbl_job_title.Where(a => a.job_title == jobTitle).Select(a => a.salary)
                                .FirstOrDefault();
                            double? employeeBasicSalary = selectSalary;
                            double? tardy;
                            double? holidayBonus = 0;
                            double? sss;
                            double? accumulatedSalary = 0;
                            double? government_tax = ControlCenter.Ph_Taxation(employeeBasicSalary);
                            int totalDaysOfPresent = 0;
                            double? totalSalary;
                            TimeSpan ts = TimeSpan.Zero;
                            TimeSpan timeIn = TimeSpan.Zero;
                            TimeSpan timeOut = TimeSpan.Zero;
                            double? fullDailySalary = 0;
                            TimeSpan difference = cutoffs.end_date.Value.Date - cutoffs.start_date.Value.Date;
                            var totalDay = (int)difference.TotalDays;
                            DateTime? date = DateTime.Now;

                            double? earnedPerMinute = 0;
                        for (int x = 0; x <= totalDay; x++)
                        {
                            foreach (var a in attendance)
                            {
                                if (us.employeeId == a.username && a.date.Value.Date == cutoffs.start_date.Value.Date.AddDays(x))
                                {
                                    if (a.time_in != null)
                                    {
                                        timeIn = a.time_in.Value.TimeOfDay;
                                    }
                                    if (a.time_out != null)
                                    {
                                        timeOut = a.time_out.Value.TimeOfDay;
                                    }

                                    if (timeIn != TimeSpan.Zero && timeOut != TimeSpan.Zero)
                                    {
                                        
                                            ts += timeOut - timeIn;
                                        timeIn = TimeSpan.Zero;
                                        timeOut = TimeSpan.Zero;
                                    }
                                    date = a.date;
                                }
                                                      
                            }

                            double? workingHours = DatabaseConnection.config().working_hours.Value.TotalHours;
                            var whatMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                            fullDailySalary = selectSalary / 30;
                            Console.WriteLine("this is a fucking ful ldaily " + fullDailySalary);
                            earnedPerMinute = (fullDailySalary / workingHours) / 60.0;
                            earnedPerMinute *= ts.TotalMinutes;
                            accumulatedSalary += earnedPerMinute;
                            if (earnedPerMinute != 0)
                            {
                                var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = date.Value.Date;
                                employeePayroll.earned = earnedPerMinute;
                                totalSalary = earnedPerMinute;
                                employeePayroll.username = us.employeeId;
                                DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                DatabaseConnection.database1.SaveChanges();
                            }

                            // CHECK if there's a cutoffs
                            var checkHoliday = cutoffs.start_date.Value.Date.AddDays(x).Date;
                            var holiday = DatabaseConnection.database1.tbl_holidays.FirstOrDefault(a => a.datetime == checkHoliday);


                            if (cutoffs.start_date.Value.Date.AddDays(x).DayOfWeek == System.DayOfWeek.Sunday
                                || cutoffs.start_date.Value.Date.AddDays(x).DayOfWeek == System.DayOfWeek.Saturday)
                            {
                                totalDaysOfPresent++;
                                var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = cutoffs.start_date.Value.Date.AddDays(x).Date;
                                employeePayroll.earned = fullDailySalary;
                                totalSalary = fullDailySalary;
                                accumulatedSalary += fullDailySalary;
                                employeePayroll.username = us.employeeId;
                                DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                DatabaseConnection.database1.SaveChanges();

                            }
                            else if (holiday != null)
                            {
                                totalDaysOfPresent++;
                                var employeePayroll = new tbl_employee_payroll();
                                employeePayroll.day = cutoffs.start_date.Value.Date.AddDays(x).Date;
                                employeePayroll.earned = fullDailySalary;
                                totalSalary = fullDailySalary;
                                holidayBonus += fullDailySalary;
                                accumulatedSalary += fullDailySalary;
                                employeePayroll.username = us.employeeId;
                                DatabaseConnection.database1.tbl_employee_payroll.Add(employeePayroll);
                                DatabaseConnection.database1.SaveChanges();
                            }

                            ts = TimeSpan.Zero;


                        }
                        // Start Deductions

                        var deductions = new tbl_deductions();
                        int? absences = totalDay - totalDaysOfPresent;
                        double? total = 0;
                       
                        double? totalAbsent = 0;
                        if (absences != 0)
                        {
                            totalAbsent = absences * fullDailySalary;
                            deductions.absent = totalAbsent;
                           
                        }
                        total = fullDailySalary * 18;
                        deductions.government_tax = 0;
                        deductions.pagibig_tax = 0;
                        tardy = ((employeeBasicSalary / 30) * 18) - accumulatedSalary;


                        deductions.tardy = tardy;
                        deductions.employee_id = us.employeeId;
                        deductions.covered_date = DateTime.Now.AddDays(-1).Date;
             
                      
                        deductions.holiday_bonus = holidayBonus;
                        deductions.cutoff_total_salary = total;

                            //CHECK IF THERE'S A LOAN
                        
                            var loanTable = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a =>
                                a.employee_id == us.employeeId && a.status == "accepted");
                        if(loanTable != null && loanTable.remaining_cut_off != 0) { 
                            if (loanTable.issued_date.Value.Date < cutoffs.start_date)
                            {
                                loanTable.remaining_cut_off -= 1;

                                deductions.loan = loanTable.cut_off_payment;
                                accumulatedSalary -= loanTable.cut_off_payment;
                            }
                        }
                        else if (loanTable != null && loanTable.remaining_cut_off == 0)
                        {
                            loanTable.status = "completed";

                        }


                        deductions.total_salary = accumulatedSalary;
                        DatabaseConnection.database1.tbl_deductions.Add(deductions);
                        DatabaseConnection.database1.SaveChanges();


                    }

                    DatabaseConnection.database1.SaveChanges();
                   
                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13);
                        DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
                        var payRoll = new tbl_payroll();
                        payRoll.start_date = startDate;
                        payRoll.end_date = endDate;

                        DatabaseConnection.database1.tbl_payroll.Add(payRoll);
                        DatabaseConnection.database1.SaveChanges();


                }
            }



        }

        private void ProcessPayroll()
        {
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
            GridContent.Children.Add( new Dashboard() );
        }

        private void Loan(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AdminLoanControl());
        }

        private void CreateMemo(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new Memo());
        }

        private void Accounts(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AddUser());
        }

        private void Leave(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AdminLeaveControl());
        }

        private void Employee(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new EmployeeList());
        }

        private void Overtime(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AdminReviewOvertime());
        }

        private void Payroll(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new Payroll());
        }

        private void JobTitle(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new AddJobTitle());

        }
        private void Holiday(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new Holidays());

        }

        private void Draggables(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }
    }
}
