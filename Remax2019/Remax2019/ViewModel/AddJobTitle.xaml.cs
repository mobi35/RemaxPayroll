using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddJobTitle.xaml
    /// </summary>
    public partial class AddJobTitle : UserControl
    {
        public AddJobTitle()
        {
            InitializeComponent();
            var jobTitles = DatabaseConnection.database1.tbl_job_title.ToList();
            JobTitleGrid.ItemsSource = jobTitles;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void AddJobTitleSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            var jobTitle = new tbl_job_title();
            jobTitle.job_title = AddJob.Text;
            jobTitle.salary = Double.Parse(AddSalary.Text);
            DatabaseConnection.database1.tbl_job_title.Add(jobTitle);
            DatabaseConnection.database1.SaveChanges();
            var jobTitles = DatabaseConnection.database1.tbl_job_title.ToList();
            JobTitleGrid.ItemsSource = jobTitles;
        }

        private void DeleteJobTitle_OnClick(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            DeleteJobTitle.Tag = myValue;
        }

        private void EditJobTitle_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                int jobTitleId = (int)((Button)sender).Tag;
                ControlCenter controlCenter = new ControlCenter();
                var datas = controlCenter.JobTitle(jobTitleId);
                DataContext = datas;

            }
        }
        
        private void ConfirmUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var jobId = Int32.Parse(JobId.Text);

            var jobTitle = DatabaseConnection.database1.tbl_job_title.FirstOrDefault(a => a.id == jobId);
            jobTitle.job_title = JobTitle.Text;
            jobTitle.salary = Double.Parse(Salary.Text);
            DatabaseConnection.database1.SaveChanges();
            var jobTitles = DatabaseConnection.database1.tbl_job_title.ToList();
            JobTitleGrid.ItemsSource = jobTitles;
        }
        private void ConfirmDeleteJob(object sender, RoutedEventArgs e)
        {
            int jobTitleId = (int)((Button)sender).Tag;
        
          var jobTitle =  DatabaseConnection.database1.tbl_job_title.FirstOrDefault(a => a.id == jobTitleId);
            DatabaseConnection.database1.tbl_job_title.Remove(jobTitle);
            DatabaseConnection.database1.SaveChanges();
            var jobTitles = DatabaseConnection.database1.tbl_job_title.ToList();
            JobTitleGrid.ItemsSource = jobTitles;
        }
    }
}
