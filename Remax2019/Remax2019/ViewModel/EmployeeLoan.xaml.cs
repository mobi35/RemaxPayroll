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
    /// Interaction logic for EmployeeLoan.xaml
    /// </summary>
    public partial class EmployeeLoan : UserControl
    {
        public LoanCashAdvanceFunction obj { get; set; }
        public EmployeeLoan()
        {
            InitializeComponent();
            obj = new LoanCashAdvanceFunction();
            DataContext = obj;
            PupulateLoans();
        }

        public void PupulateLoans()
        {
            var employeeId = Application.Current.Properties["employeeId"].ToString();

            var data = DatabaseConnection.database1.tbl_loan.OrderByDescending(a => a.id).Where(a => a.employee_id == employeeId).ToList();
            LoanHistory.ItemsSource = data;
        }
        private void LoanExecute_OnClick(object sender, RoutedEventArgs e)
        {
            //Check loan table if there's an existing active loan
            var employeeId = Application.Current.Properties["employeeId"].ToString();

            var data = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a => a.employee_id == employeeId
            && a.status == "pending" || a.status == "accepted"     );

            if(data == null) {  
           tbl_loan loan = new tbl_loan();
            loan.employee_id = employeeId;
            loan.principal_loan = Double.Parse(PrincipalAmount.Text);
            loan.cut_off_terms = Int32.Parse(CutOff.Text);
            loan.remaining_cut_off = Int32.Parse(CutOff.Text);
            loan.reason = Reason.Text;
            loan.status = "pending";
            loan.maturity_value = Double.Parse(MaturityValueField.Text);
            loan.cut_off_payment = Double.Parse(CutOffField.Text);
            DatabaseConnection.database1.tbl_loan.Add(loan);
            DatabaseConnection.database1.SaveChanges();
                MessageBox.Show("Successfully Requested.");
                PupulateLoans();
            }

            else
            {
                MessageBox.Show("Sorry but there's an existing loan from your account");
            }

            //loan.maturity_value = 
        }
    }
}
