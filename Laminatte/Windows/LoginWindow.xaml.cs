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
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length >= 4 || PassBox.Password.Length >= 4)
            {
                if (Core.DB.Users.Where(s => s.Login == TextBox.Text) != null)
                {
                    if (Core.DB.Users.Where(s => s.Login == TextBox.Text).FirstOrDefault() != null)
                    {
                        Users user = Core.DB.Users.Where(s => s.Login == TextBox.Text).FirstOrDefault();

                        if (user.Password == PassBox.Password)
                        {
                            Core.activeUser = user;
                            if(user.IsAdmin == true)
                            {
                                AdminChooseWindow main = new AdminChooseWindow();
                                main.Show();
                                this.Close();
                            }
                            else
                            {
                                MainWindow main = new MainWindow();
                                main.Show();
                                this.Close();
                            }
                        }
                        else
                            MessageBox.Show("Введены неправильные данные", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                        MessageBox.Show("Введены неправильные данные", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Введены неправильные данные", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Введены неправильные данные", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
