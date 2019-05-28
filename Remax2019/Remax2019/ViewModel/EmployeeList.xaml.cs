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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Remax2019.Model;

namespace Remax2019.ViewModel
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : UserControl
    {
        private int getNumberOfFields = DatabaseConnection.database1.tbl_accounts.Count();
        public EmployeeList()
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

            dataGrid.ItemsSource = DefaultAndPageinate();
            var jobTitle = DatabaseConnection.database1.tbl_job_title.Select(a => a.job_title).ToList();
            JobTitle.ItemsSource = jobTitle;

        }

        private int numberOfSearchResult;

        public List<tbl_accounts> DefaultAndPageinate(int pageNumber = 1, string isSearched = "")
        {
            int numberOfObjectsPerPage = 8;
            string nameOfUser = ControlCenter.TitleCase(searchUser.Text);

            var queryResultPage = DatabaseConnection.database1.tbl_accounts.ToList();
            if (pageNumber == 1 && searchUser.Text == "")
                queryResultPage = queryResultPage.Take(numberOfObjectsPerPage).ToList();
            else if (pageNumber == 1 && searchUser.Text != "")
            {


                var list = DatabaseConnection.database1.tbl_accounts.ToList();
                var nameList = queryResultPage.Where(a => a.name.Contains(nameOfUser) || a.employeeId.Contains(nameOfUser)
        
                        );
                numberOfSearchResult = nameList.Count();
                queryResultPage = nameList.Take(numberOfObjectsPerPage).ToList();



            }
            else if (searchUser.Text != "")
            {

                var nameList = queryResultPage.Where(a => a.name.Contains(nameOfUser) || a.username.Contains(nameOfUser)
                || a.employeeId.Contains(nameOfUser));
                numberOfSearchResult = nameList.Count();
                --pageNumber;

                queryResultPage = nameList.Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage).ToList();
            }
            else
            {
                --pageNumber;
                queryResultPage = queryResultPage
                    .Skip(numberOfObjectsPerPage * pageNumber)
                    .Take(numberOfObjectsPerPage).ToList();
            }

            return queryResultPage.ToList();
        }


        private void nextPage(object sender, RoutedEventArgs e)
        {
            int getCurrentPage = int.Parse(currentPage.Text);

            if (searchUser.Text != "")
            {

                if (numberOfSearchResult != 0)
                {
                    getNumberOfFields = numberOfSearchResult;
                }

            }
            double ax = (getNumberOfFields / 8.0);
            if (getCurrentPage < Math.Ceiling(ax))
            {
                getCurrentPage++;
                currentPage.Text = getCurrentPage.ToString();
                dataGrid.ItemsSource = DefaultAndPageinate(getCurrentPage, searchUser.Text);
            }
        }

        private void prevPage(object sender, RoutedEventArgs e)
        {
            int getCurrentPage = int.Parse(currentPage.Text);
            if (getCurrentPage > 1)
            {
                getCurrentPage--;
                currentPage.Text = getCurrentPage.ToString();
                dataGrid.ItemsSource = DefaultAndPageinate(getCurrentPage, searchUser.Text);
            }
        }

        public void ThisIsTheCurrentPage()
        {
            int getCurrentPage = int.Parse(currentPage.Text);
            dataGrid.ItemsSource = DefaultAndPageinate(getCurrentPage, searchUser.Text);

        }

        private void pageByTextbox(object sender, TextChangedEventArgs e)
        {
            int getCurrentPage = int.Parse(currentPage.Text);
            dataGrid.ItemsSource = DefaultAndPageinate(getCurrentPage, searchUser.Text);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbl_accounts borrower = (tbl_accounts)dataGrid.SelectedItem;

        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            deleteMember.Tag = myValue;
        }
        private void confirmDelete(object sender, RoutedEventArgs e)
        {
            int memberId = (int)((Button)sender).Tag;
            var selectDeletingUser = DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == memberId);
            var deleteUser = DatabaseConnection.database1.tbl_accounts.Remove(selectDeletingUser);
            DatabaseConnection.database1.SaveChanges();
            ThisIsTheCurrentPage();
        }




        /// <summary>
        /// / EVENTS
        /// </summary>

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var xx = (tbl_accounts)dataGrid.SelectedItem;


          var newMemList = new AccountDetails();

            newMemList.GetId(xx.employeeId);
            newMemList.ShowDialog();
            // execute some code
        }

        private void SearchUser_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage.Text = "1";
            dataGrid.ItemsSource = DefaultAndPageinate(1, searchUser.Text);

        }

        // PAG PININDOT MO TO IPAPASOK MO UNG DETAILS NG ISANG MEMBER SA LOOB NG MGA TEXT BOX
        private void EditMemberClick_OnClick(object sender, RoutedEventArgs e)
        {


            if (sender != null)
            {
             int memberId = (int)((Button)sender).Tag;
        ControlCenter controlCenter = new ControlCenter();
               var datas = controlCenter.Accounts(memberId);
             DataContext = datas;

            }


        }


        // PRIMARY INSERTION
        private void ConfirmUpdate_OnClick(object sender, RoutedEventArgs e)
        {
          
            int Id = Convert.ToInt32(MemberId.Text);
            var selectUser =   DatabaseConnection.database1.tbl_accounts.FirstOrDefault(a => a.id == Id);
            selectUser.name = FirstName.Text;
            selectUser.address = Address.Text;
            selectUser.email = Area.Text;
            if(Age.Text != ""){  
            selectUser.age = Int32.Parse(Age.Text);
            }
            selectUser.position = Position.Text;

       
            var JobText = JobTitle.Text;
            var jobTitle = DatabaseConnection.database1.tbl_job_title.FirstOrDefault(a => a.job_title == JobText);
            selectUser.basic_salary = jobTitle.salary;
            try
            {
                selectUser.allowable_leaves = Int32.Parse(AllowedLeave.Text);
            }
            catch (Exception xx)
            {
                Console.WriteLine(xx);
            }
            selectUser.job_title = JobTitle.Text;
            if (ImageName.Text != "")
            {
                selectUser.picture = data;
            }

            DatabaseConnection.database1.SaveChanges();

            MessageBox.Show("Successfully Edited");
            ThisIsTheCurrentPage();


    
           


        }
      
        private void AddLoan_Click(object sender, RoutedEventArgs e)
        {
            /*
            int memberId = (int)((Button)sender).Tag;
            var xx = LoanConfiguration._database.borrowers.FirstOrDefault(a => a.id == memberId);

            LoanConfiguration._controlCenter.OpenLoans(xx);
            */


        }



        private void Remittance_Click(object sender, RoutedEventArgs e)
        {

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

 


    }
}
