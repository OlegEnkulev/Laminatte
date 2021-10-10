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
using Laminatte.Resources;
using Laminatte.Windows;

namespace Laminatte
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Cost1.Content = Core.DB.Products.Where(s => s.Id == 1).FirstOrDefault().Price + " Руб.";
            Cost2.Content = Core.DB.Products.Where(s => s.Id == 2).FirstOrDefault().Price + " Руб.";
            Cost3.Content = Core.DB.Products.Where(s => s.Id == 3).FirstOrDefault().Price + " Руб.";
            Cost4.Content = Core.DB.Products.Where(s => s.Id == 4).FirstOrDefault().Price + " Руб.";

            if(Core.activeUser != null)
            {
                RegBTN.Visibility = Visibility.Hidden;
                UserBTN.Visibility = Visibility.Hidden;
            }
        }

        private void UserBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage regWindow = new RegisterPage();
            regWindow.Show();
            this.Close();
        }

        private void Tovar1_Click(object sender, RoutedEventArgs e)
        {
            if (Core.activeUser == null)
            {
                MessageBox.Show("Вы не авторизованы, пожалуйста авторизуйтесь или зарегистрируйтесь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                OrderWindow orderWindow = new OrderWindow(1);
                orderWindow.Show();
            }
        }

        private void Tovar2_Click(object sender, RoutedEventArgs e)
        {
            if (Core.activeUser == null)
            {
                MessageBox.Show("Вы не авторизованы, пожалуйста авторизуйтесь или зарегистрируйтесь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                OrderWindow orderWindow = new OrderWindow(2);
                orderWindow.Show();
            }
        }

        private void Tovar3_Click(object sender, RoutedEventArgs e)
        {
            if (Core.activeUser == null)
            {
                MessageBox.Show("Вы не авторизованы, пожалуйста авторизуйтесь или зарегистрируйтесь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                OrderWindow orderWindow = new OrderWindow(3);
                orderWindow.Show();
            }
        }

        private void Tovar4_Click(object sender, RoutedEventArgs e)
        {
            if (Core.activeUser == null)
            {
                MessageBox.Show("Вы не авторизованы, пожалуйста авторизуйтесь или зарегистрируйтесь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                OrderWindow orderWindow = new OrderWindow(4);
                orderWindow.Show();
            }
        }
    }
}
