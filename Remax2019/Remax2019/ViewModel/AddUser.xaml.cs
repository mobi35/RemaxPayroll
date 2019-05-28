using Remax2019.Model;
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
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.Win32;


namespace Remax2019
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl 
    {
        public AddUser()
        {
            InitializeComponent();
            if (Application.Current.Properties["position"].ToString() == "Admin")
            {
                Position.Visibility = Visibility.Visible;
            }
            else
            {
                PositionHR.Visibility = Visibility.Visible;
            }
            if (allowingLeave.IsChecked == true)
            {
                AllowedLeaves.Visibility = Visibility.Visible;
            }
            else
            {
                AllowedLeaves.Visibility = Visibility.Hidden;
            }

            var jobTitle = DatabaseConnection.database1.tbl_job_title.Select(a => a.job_title).ToList();
            JobTitle.ItemsSource = jobTitle;
        }

        byte[] data;
        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                ImageName.Text = filename;
                


                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(filename, UriKind.Relative);
                bi3.EndInit();



                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bi3));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }




            }
        }

        private  ControlCenter controlCenter = new ControlCenter();

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void RegisterUser(object sender, RoutedEventArgs e)
        {
            RemaxDatabase database = new RemaxDatabase();
            tbl_accounts account = new tbl_accounts();
        
            //CHECK username 
          var ifUsernameIsExisting =  database.tbl_accounts.FirstOrDefault(a => a.username == UserName.Text);

            if (ifUsernameIsExisting != null)
            {
                MessageBox.Show("Username already exist");
                return;
            }

            //CHECK password

            if (PassWord.Password.ToString() != ReTypePassword.Password.ToString())
            {
                MessageBox.Show("Password Doesn't Match");
                return;
            }

            //Check the length of Username

            if (UserName.Text.Length >= 20 || UserName.Text.Length < 6)
            {
                MessageBox.Show("Username minimum length is 6 and maximum length of 10");
                return;
            }

            //Check the length of Password

            if (PassWord.Password.ToString().Length > 20 || PassWord.Password.ToString().Length < 8 ||
                ReTypePassword.Password.ToString().Length > 20 || ReTypePassword.Password.ToString().Length < 8)
            {
                MessageBox.Show("Password minimum length is 8 and maximum length of 20");
                return;
            }

            //Validate Name and position

            if (Email.Text == "" || JobTitle.Text == "" || Address.Text == "" || Birthdate.SelectedDate == null )
            {
                MessageBox.Show("Please Complete the fields");
                return;
            }

            if (FullName.Text == "")
            {
                MessageBox.Show("Name field can't be empty");
                return;
            }

            if (Position.Text == "")
            {
                MessageBox.Show("Position field can't be empty");
                return;
            }

        
            account.name = ControlCenter.TitleCase(FullName.Text) ;
            account.username = UserName.Text;
            //Gumawa ako variable na passwordEncrypted .. Then pinasa ko ung value ng encrypted password 
            //So ung unang parameter which pinasa natin ung password na nakalink sa password field. then ung second parameter is 
            //User defined password nten..
            string passwordEncrypted = AESGCM.SimpleEncryptWithPassword(PassWord.Password.ToString(),"REMAXTHESIS2019");

            account.password = passwordEncrypted;
            account.position = Position.Text;
            account.email = Email.Text;
            account.job_title = JobTitle.Text;
            var JobText = JobTitle.Text;
            var jobTitle = DatabaseConnection.database1.tbl_job_title.FirstOrDefault(a => a.job_title == JobText);
            account.basic_salary = jobTitle.salary;

            account.address = Address.Text;
            account.employed_on = DateTime.Now.Date;
            account.birthdate = Birthdate.SelectedDate;
            account.account_status = "pending";
            account.age = ControlCenter.GiveBirthday(Birthdate.SelectedDate);
            account.leave_notification = 0;
            if (Male.IsChecked == true)
            {
                account.gender =  Male.Content.ToString();
            }
            else
            {
                account.gender = Female.Content.ToString();
            }
            account.memo_notification = 0;
            if (ImageName.Text != "")
            {
                account.picture = data;
            }

            if (AllowedLeaves.Visibility == Visibility.Visible)
            {
                if (AllowedLeaves.Text == "")
                {
                    MessageBox.Show("Allowable Leave field can't be empty");
                    return;
                }
                account.allowable_leaves = Convert.ToInt32(AllowedLeaves.Text);
            }


            UserName.Text = "";
             passwordEncrypted = "";
               Position.Text = "";
            Email.Text = "";
            JobTitle.Text = "";
             Address.Text = "";
       
            Birthdate.SelectedDate = DateTime.Now;
           
            PassWord.Password = "";
            ReTypePassword.Password = "";

            account.employeeId = controlCenter.NewId();
            database.tbl_accounts.Add(account);
            database.SaveChanges();
            MessageBox.Show("Successfully Registered");
        }


    

        private void AllowingLeave_OnChecked(object sender, RoutedEventArgs e)
        {
            AllowedLeaves.Visibility = Visibility.Visible;
        }

        private void AllowingLeave_OnUnchecked(object sender, RoutedEventArgs e)
        {
            AllowedLeaves.Visibility = Visibility.Hidden;
        }
    }
}
