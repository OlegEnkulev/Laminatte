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
    public partial class EditUserWindow : Window
    {
        int action;
        Users editableUser;

        public EditUserWindow(int _action, Users _editableUser)
        {
            InitializeComponent();

            action = _action;
            editableUser = _editableUser;
        }

        private void NameBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void LastNameBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void LoginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            switch (action)
            {
                case 0:
                    if (NameBox.Text.Length >= 2 || LastNameBox.Text.Length >= 3 || LoginBox.Text.Length >= 4 || PasswordBox.Password.Length >= 4)
                    {
                        editableUser.FirstName = NameBox.Text;
                        editableUser.LastName = LastNameBox.Text;
                        editableUser.Login = LoginBox.Text;
                        editableUser.Password = PasswordBox.Password;
                        editableUser.Phone = PhoneBox.Text;
                        editableUser.IsAdmin = IsAdminCheck.IsChecked.Value;

                        Core.DB.SaveChanges();

                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Введены неудовлетворяющие данные", "Невозможно выполнить действие", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 1:
                    if (NameBox.Text.Length >= 2 || LastNameBox.Text.Length >= 3 || LoginBox.Text.Length >= 4 || PasswordBox.Password.Length >= 4)
                    {
                        Users user = new Users() { FirstName = NameBox.Text, LastName = LastNameBox.Text, Login = LoginBox.Text, Password = PasswordBox.Password, Phone = PhoneBox.Text, IsAdmin = IsAdminCheck.IsChecked.Value };
                        Core.DB.Users.Add(user);

                        Core.DB.SaveChanges();

                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Введены неудовлетворяющие данные", "Невозможно выполнить действие", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Close();
        }
    }
}
