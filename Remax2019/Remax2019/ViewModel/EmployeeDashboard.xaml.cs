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

namespace Remax2019
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : UserControl
    {
        public EmployeeDashboard()
        {
            InitializeComponent();

            var MemoList = DatabaseConnection.database1.tbl_memo.Where(a => a.archived == null).Take(6).ToList();
            MemoGrid.ItemsSource = MemoList;

        }

   
    }
}
