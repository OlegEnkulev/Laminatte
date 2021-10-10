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
    public partial class OrderWindow : Window
    {
        Products product;
        public OrderWindow(int id)
        {
            InitializeComponent();

            product = Core.DB.Products.Where(s => s.Id == id).FirstOrDefault();
        }

        private void Tovar1_Click(object sender, RoutedEventArgs e)
        {
            if(Number.Text.Length > 0)
            {
                Orders order = new Orders() { UserId = Core.activeUser.Id, DateTime = DateTime.Now, ProductId = product.Id, Status = 0, Count = int.Parse(Number.Text) , Price = int.Parse(Number.Text) * product.Price };
                Core.DB.Orders.Add(order);
                Core.DB.SaveChanges();
                this.Close();
            }
        }

        private void Number_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.D1 && e.Key != Key.D2 && e.Key != Key.D3 && e.Key != Key.D4 && e.Key != Key.D5 && e.Key != Key.D6 && e.Key != Key.D7 && e.Key != Key.D8 && e.Key != Key.D9 && e.Key != Key.D0)
            {
                e.Handled = true;
            }
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            AllPriceLabel.Content = Convert.ToString(int.Parse(Number.Text) * product.Price);
        }
    }
}
