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

namespace Remax2019
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            DateToday.Text = DateTime.Now.ToLongDateString();
            Dashing();
            GetLastMonthSpent();
            ShowUserDetails();
        }

        public void Dashing()
        {

            var getAllUser = DatabaseConnection.database1.tbl_accounts.ToList().Count;
            NumberOfUser.Text = getAllUser.ToString();

        }

        public void GetLastMonthSpent()
        {
            try
            {
                var getLastPayroll = DatabaseConnection.database1.tbl_payroll.OrderByDescending(a => a.start_date)
                    .FirstOrDefault(a => a.processed == "complete");


                var getSalaries = DatabaseConnection.database1.tbl_employee_payroll.Where(a =>
                        EntityFunctions.TruncateTime(a.day) >= EntityFunctions.TruncateTime(getLastPayroll.start_date)
                        && EntityFunctions.TruncateTime(a.day) <= EntityFunctions.TruncateTime(getLastPayroll.end_date))
                    ;

                double? totalSalary = 0;
                foreach (var a in getSalaries)
                {
                    totalSalary += a.earned;
                }

                string money = String.Format("{0:N2}", totalSalary);
                TotalAmountSpent.Text = "P" + money;
            }
            catch (Exception c)
            {
                Console.WriteLine(c);
            }
        }

        public void ShowUserDetails()
        {
            var id = Int32.Parse(Application.Current.Properties["userId"].ToString() );
            var user = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == id);
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(user.picture);
            UserImage.Source = bitmap;
            Position.Text = user.job_title;
            EmployeeId.Text = user.employeeId;
        }
    }
}
