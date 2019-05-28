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
    /// Interaction logic for AdminLoanControl.xaml
    /// </summary>
    public partial class AdminLoanControl : UserControl
    {
        public AdminLoanControl()
        {
            InitializeComponent();
            PopulateData();
        }
        private void AcceptLoan(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            accept.Tag = myValue;

        }
        public void PopulateData()
        {
            var loanList = DatabaseConnection.database1.tbl_loan.OrderByDescending(a => a.id).Where(a => a.status == "pending").ToList();
            LoanControl.ItemsSource = loanList;

            var loanListHistory = DatabaseConnection.database1.tbl_loan.OrderByDescending(a => a.id).Where(a => a.status != "pending").ToList();
            LoanControlHistory.ItemsSource = loanListHistory;
        }

        private void DeclineLoan(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            decline.Tag = myValue;
        }
        private void ViewMessage(object sender, RoutedEventArgs e)
        {
            int loanId = (int)((Button)sender).Tag;
            var data = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a => a.id == loanId);
            MessageBox.Show(data.reason);

        }
        private void confirmAccept(object sender, RoutedEventArgs e)
        {
            int loanId = (int) ((Button) sender).Tag;
            var data = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a => a.id == loanId);
            data.status = "accepted";
            data.issued_date = DateTime.Now;
            data.accepted_by = Application.Current.Properties["fullName"].ToString();
            DatabaseConnection.database1.SaveChanges();
            PopulateData();
        }
        private void confirmDecline(object sender, RoutedEventArgs e)
        {
            int loanId = (int)((Button)sender).Tag;
            var data = DatabaseConnection.database1.tbl_loan.FirstOrDefault(a => a.id == loanId);
            data.status = "declined";
            DatabaseConnection.database1.SaveChanges();
            PopulateData();
        }
    }
}
