using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : Window
    {
        public AccountDetails()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void GetId(string id)
        {


           var user =  DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.employeeId == id);


            if(user.picture != null){  
            Bitmap x = (Bitmap)((new ImageConverter()).ConvertFrom(user.picture));
            Image.Source = ConvertBitmap(x);
            }
            Username.Text ="Username:   " + user.username;
            FullName.Text = "Full Name:   " + user.name;
            Bdate.Text = "Birthdate:   "+ user.birthdate;
            Email.Text = "Email:   " + user.email;
            Age.Text = "Age:   " + user.age ;
            Position.Text = "Position:   " + user.position;
            Jobtitle.Text = "Job:   " + user.job_title ;
            Salary.Text = "Basic Salary:   " + user.basic_salary;
                                                         
        }

        public BitmapImage ConvertBitmap(System.Drawing.Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }


        private void Close(object sender, RoutedEventArgs e)
        {

            Close();
     
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
