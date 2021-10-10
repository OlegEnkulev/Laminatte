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
using Laminatte.Resources;

namespace Laminatte.Windows
{
    public partial class EditStatusWindow : Window
    {
        Orders order;
        public EditStatusWindow(Orders _order)
        {
            InitializeComponent();

            order = _order;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (AccessBox.SelectedItem != null)
            {
                order.Status = AccessBox.SelectedIndex;

                Core.DB.SaveChanges();

                this.Close();
            }
            else
                MessageBox.Show("Введены неудовлетворяющие данные", "Невозможно выполнить действие", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
