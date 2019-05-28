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
using REMAX_TIMER.Model;
using System.Drawing;
using System.IO;
using REMAX_TIMER;
using System.Windows.Navigation;

namespace REMAX_TIMER
{
   
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        RemaxDatabase db = new RemaxDatabase();

        public Login()
        {
            
            InitializeComponent();
            var Joined = db.tbl_employee_payroll.GroupJoin(
                db.tbl_accounts,
                d => d.id,
                c => c.id,

                (employee, accounts) => new
                {
                    Employee = employee,
                    Accounts = accounts,
                    Id = accounts.FirstOrDefault().id
                }
            );
            var OtherJoin = Joined.GroupJoin(
                db.tbl_deductions,
                e => e.Accounts.FirstOrDefault().employeeId,
                s => s.employee_id,
                (EmpAndAccounts, Deductions) => new
                {

                    Id = EmpAndAccounts.Accounts
                }


            );
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            var clientName = Environment.MachineName; ;
            var userAccount = db.tbl_accounts.FirstOrDefault(a => a.account_binding == clientName);
            if (userAccount != null)
            {
             

                var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(userAccount.picture);
                AlreadyImage.Source = bitmap;
                AlreadyButton.Content = "Login as " + userAccount.username;
                var userId = userAccount.id;
                Application.Current.Properties["username"] = userAccount.username;
                Application.Current.Properties["userId"] = userId;
                Application.Current.Properties["fullName"] = userAccount.name;
                Application.Current.Properties["position"] = userAccount.position;
                Application.Current.Properties["employeeId"] = userAccount.employeeId;
                TimerForm tf = new TimerForm();
                tf.TimeIn();
            }
            else
            {
                AlreadyLogin.Visibility = Visibility.Hidden;
                LoginChild.Visibility = Visibility.Visible;
            }

        }



        private void Close(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void DoLogin(object sender, RoutedEventArgs e)
        {

            //Instantiate of database.



            //kinuha ko ung lahat ng laman ng nasa database
            var accounts = db.tbl_accounts.ToList();
            //inisa isa ko ung laman dito sa foreach
            var isValidated = false;
            var userId = 0;
            foreach (var a in accounts)
            {
                //Decrypt ko lahat ng password sa loob ng accounts.. tapos
                //Cinompare ko siya sa tinype kong password sa textbox
                //Eto ung encrypted = pmBmYNvf49qy7R7Pt+OigIdIkM5WOU6R18YW3RcKKdnhHs+Gn+QEmzZBH+V8g5UI3G9a2ZUebLYT3iol
                //Pag dinecrypt ko siya = adrianadrian < yan ung tinype ko kanina.
                if (AESGCM.SimpleDecryptWithPassword(a.password, "REMAXTHESIS2019") == PassWord.Password)
                {
                    //Lahat ng nasa baba ay ieexecute pag tama ang condition.
                    //Set isValidated to true
                    isValidated = true;

                    //Pinasa ko ung id sa variable na userId.

                    userId = a.id;
                    Application.Current.Properties["username"] = a.username;
                    Application.Current.Properties["userId"] = userId;
                    Application.Current.Properties["fullName"] = a.name;
                    Application.Current.Properties["position"] = a.position;
                    Application.Current.Properties["employeeId"] = a.employeeId;
                    TimerForm tf = new TimerForm();
                    tf.TimeIn();
                }

            }

            //Ipasa ang userId and isearch siya sa database..
            var result =db.tbl_accounts.FirstOrDefault(a => a.id == userId);

            if (result != null && isValidated)
            {
                var clientName = Environment.MachineName; ;
                result.account_binding = clientName;
                db.SaveChanges();

                if (result.position == "Admin")
                {

                    MessageBox.Show("This is for Employee Only");
                }
                else if (result.position == "Employee")
                {
                    this.Hide();
                    var Dashboard = new TimerForm();
                    Dashboard.Show();
                }

            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void AlreadyButton_OnClick(object sender, RoutedEventArgs e)
        {
            var userId = Int32.Parse(Application.Current.Properties["userId"].ToString());

            var result = db.tbl_accounts.FirstOrDefault(a => a.id == userId);
            if (result.position == "Admin")
            {

                MessageBox.Show("This is for Employee Only");
            }
            else if (result.position == "Employee")
            {
                this.Hide();
                var Dashboard = new TimerForm();
                Dashboard.Show();
            }
        }

        private void AlreadyRemove_OnClick(object sender, RoutedEventArgs e)
        {
            AlreadyLogin.Visibility = Visibility.Hidden;
            LoginChild.Visibility = Visibility.Visible;
            var userId = Int32.Parse(Application.Current.Properties["userId"].ToString());

            var result = db.tbl_accounts.FirstOrDefault(a => a.id == userId);
            result.account_binding = null;
           db.SaveChanges();
            Application.Current.Properties["username"] = null;
            Application.Current.Properties["userId"] = null;
            Application.Current.Properties["fullName"] = null;
            Application.Current.Properties["position"] = null;
            Application.Current.Properties["employeeId"] = null;

        }
    }
}
