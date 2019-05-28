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

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for EmployeeAttendance.xaml
    /// </summary>
    public partial class EmployeeAttendance : UserControl
    {
        public EmployeeAttendance()
        {
            InitializeComponent();

            var user = Application.Current.Properties["employeeId"].ToString();
            var attendance = DatabaseConnection.database1.tbl_attendance.OrderByDescending(a => a.id).Where(a => a.username == user).ToList();
            AttendanceGrid.ItemsSource = attendance;
        }
    }
}
