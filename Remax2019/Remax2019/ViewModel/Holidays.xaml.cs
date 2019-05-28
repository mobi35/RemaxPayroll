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
    /// Interaction logic for Holidays.xaml
    /// </summary>
    public partial class Holidays : UserControl
    {
        public Holidays()
        {
            InitializeComponent();
            var db = DatabaseConnection.database1.tbl_holidays.ToList();
            HolidayGrid.ItemsSource = db;
        }



        private void SubmitHoliday(object sender, RoutedEventArgs e)
        {

            if (HolidayTextbox.Text == "" || DatepickerTextbox.SelectedDate == null)
            {
                MessageBox.Show("Hey please complete the form");
                return;
            }
            var holiday = new tbl_holidays();
            holiday.holiday_title = HolidayTextbox.Text;
            holiday.datetime = DatepickerTextbox.SelectedDate;
            DatabaseConnection.database1.tbl_holidays.Add(holiday);
            DatabaseConnection.database1.SaveChanges();
        }

        private void DeleteHolidayClick(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            DeleteHolidayName.Tag = myValue;
        }

        private void EditHolidayClick(object sender, RoutedEventArgs e)
        {
        
            if (sender != null)
            {
                int holidayId = (int)((Button)sender).Tag;
                ControlCenter controlCenter = new ControlCenter();
                var datas = controlCenter.Holiday(holidayId);
                DataContext = datas;

            }
        }

        private void ConfirmDelete(object sender, RoutedEventArgs e)
        {
            int holidayId = (int)((Button)sender).Tag;

            var holiday = DatabaseConnection.database1.tbl_holidays.FirstOrDefault(a => a.id == holidayId);
            DatabaseConnection.database1.tbl_holidays.Remove(holiday);
            DatabaseConnection.database1.SaveChanges();

            var db = DatabaseConnection.database1.tbl_holidays.ToList();
            HolidayGrid.ItemsSource = db;
        }

        private void ConfirmUpdate(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(HolidayId.Text);
            var holiday = DatabaseConnection.database1.tbl_holidays.FirstOrDefault(a => a.id == Id);
            holiday.holiday_title = HolidayTitle.Text;
            holiday.datetime = UpdatePicker.SelectedDate;
            DatabaseConnection.database1.SaveChanges();

            var db = DatabaseConnection.database1.tbl_holidays.ToList();
            HolidayGrid.ItemsSource = db;
        }


    }
}
