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
using Laminatte.Windows;

namespace Laminatte.Windows
{
    public partial class AdminChooseWindow : Window
    {
        public AdminChooseWindow()
        {
            InitializeComponent();
        }

        private void UserBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Close();
        }

        private void ProductBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminProductsWindow admin = new AdminProductsWindow();
            admin.Show();
            this.Close();
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminOWindow admin = new AdminOWindow();
            admin.Show();
            this.Close();
        }
    }
}
