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
    public partial class EditCostWindow : Window
    {
        int userId;
        public EditCostWindow(int _userId)
        {
            InitializeComponent();

            userId = _userId;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            Core.DB.Products.Where(s => s.Id == userId).FirstOrDefault().Price = int.Parse(CostBox.Text);
            Core.DB.SaveChanges();
            this.Close();
        }

        private void CostBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.D1 || e.Key != Key.D2 || e.Key != Key.D3 || e.Key != Key.D4 || e.Key != Key.D5 || e.Key != Key.D6 || e.Key != Key.D7 || e.Key != Key.D8 || e.Key != Key.D9 || e.Key != Key.D0)
            {
                e.Handled = true;
            }
        }
    }
}
