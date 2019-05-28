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
    /// Interaction logic for Memo.xaml
    /// </summary>
    public partial class Memo : UserControl
    {
        public Memo()
        {
            InitializeComponent();

            var memoList = DatabaseConnection.database1.tbl_memo.Where(a => a.archived == null).ToList();
            MemoList.ItemsSource = memoList;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "" || Message.Text == "")
            {
                MessageBox.Show("Please fill the fields.");
                return;
            }

           tbl_memo memo = new tbl_memo();
            memo.memo_title = Title.Text;
            memo.memo_message = Message.Text;
            memo.date = DateTime.Now;
            DatabaseConnection.database1.tbl_memo.Add(memo);
            DatabaseConnection.database1.SaveChanges();
            Title.Text = "";
            Message.Text = "";
            MessageBox.Show("Memo already published");


            var memoList = DatabaseConnection.database1.tbl_memo.Where(a => a.archived == null).ToList();
            MemoList.ItemsSource = memoList;
          

        }

        private void Archived(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            deleteMember.Tag = myValue;
        }

        private void confirmArchived(object sender, RoutedEventArgs e)
        {
            int memoId = (int)((Button)sender).Tag;
            var memo = DatabaseConnection.database1.tbl_memo.FirstOrDefault(a => a.id == memoId);
            memo.archived = "yes";
            DatabaseConnection.database1.SaveChanges();
            var memoList = DatabaseConnection.database1.tbl_memo.Where(a => a.archived == null).ToList();
            MemoList.ItemsSource = memoList;
        }


        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
      
            var xx = (tbl_memo)MemoList.SelectedItem;

            MessageBox.Show("Messages: "+xx.memo_message);
        }

        private void EditMemberClick_OnClick(object sender, RoutedEventArgs e)
        {


            if (sender != null)
            {
                int memoId = (int)((Button)sender).Tag;
                ControlCenter controlCenter = new ControlCenter();
                var datas = controlCenter.Memo(memoId);
                DataContext = datas;
            }


        }

        private void ConfirmUpdate_OnClick(object sender, RoutedEventArgs e)
        {

            int Id = Convert.ToInt32(MemoId.Text);
            var memo = DatabaseConnection.database1.tbl_memo.FirstOrDefault(a => a.id == Id);
            memo.memo_title = ETitle.Text;
            memo.memo_message = EMessage.Text;
            memo.date = DateTime.Now;
            DatabaseConnection.database1.SaveChanges();

            var memoList = DatabaseConnection.database1.tbl_memo.Where(a => a.archived == null).ToList();
            MemoList.ItemsSource = memoList;

        }
    }
}
