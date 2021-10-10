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
    public partial class AdminWindow : Window
    {
        Label[] userData = new Label[Core.DB.Users.Count()];
        Label[] userName = new Label[Core.DB.Users.Count()];
        StackPanel[] stackPanel = new StackPanel[Core.DB.Users.Count()];
        Button[] editBTN = new Button[Core.DB.Users.Count()];
        Button[] deleteBTN = new Button[Core.DB.Users.Count()];
        StackPanel[] userPanel = new StackPanel[Core.DB.Users.Count()];

        public AdminWindow()
        {
            InitializeComponent();

            UpdateUsers();
        }

        void UpdateUsers()
        {
            UsersScrollViewer.Children.Clear();

            int iCorrect = 0;

            for (int i = 0; i < Core.DB.Users.Count(); i++)
            {
                if (Core.DB.Users.Where(s => s.Id == iCorrect).FirstOrDefault() != null)
                {
                    Users user = Core.DB.Users.Where(s => s.Id == iCorrect).FirstOrDefault();

                    userData[i] = new Label();
                    userData[i].Foreground = Brushes.White;
                    userData[i].Content = user.LastName + " " + user.FirstName + " " + user.Phone;

                    userName[i] = new Label();
                    userName[i].FontWeight = FontWeights.SemiBold;
                    userName[i].Foreground = Brushes.White;
                    userName[i].Content = user.Login + ":" + user.Password + " Доступ: " + user.IsAdmin.ToString();

                    stackPanel[i] = new StackPanel();
                    stackPanel[i].Width = 300;
                    stackPanel[i].Margin = new Thickness(5);
                    stackPanel[i].Children.Add(userData[i]);
                    stackPanel[i].Children.Add(userName[i]);

                    editBTN[i] = new Button();
                    editBTN[i].Content = "Изменить";
                    editBTN[i].Margin = new Thickness(5);
                    editBTN[i].Click += EditBTNClick;
                    editBTN[i].Width = 65;
                    editBTN[i].Tag = iCorrect;

                    deleteBTN[i] = new Button();
                    deleteBTN[i].Content = "Удалить";
                    deleteBTN[i].Margin = new Thickness(5);
                    deleteBTN[i].Click += DeleteBTNClick;
                    deleteBTN[i].Width = 65;
                    deleteBTN[i].Tag = iCorrect;

                    userPanel[i] = new StackPanel();
                    userPanel[i].Height = 70;
                    userPanel[i].Orientation = Orientation.Horizontal;
                    userPanel[i].Children.Add(stackPanel[i]);
                    userPanel[i].Children.Add(editBTN[i]);
                    userPanel[i].Children.Add(deleteBTN[i]);

                    UsersScrollViewer.Children.Add(userPanel[i]);
                }
                else
                    i--;
                iCorrect++;
            }
        }

        public void EditBTNClick(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32((sender as Button).Tag);
            Users user = Core.DB.Users.Where(s => s.Id == userId).FirstOrDefault();

            EditUserWindow editWindow = new EditUserWindow(0, user);
            editWindow.NameBox.Text = user.FirstName;
            editWindow.LastNameBox.Text = user.LastName;
            editWindow.LoginBox.Text = user.Login;
            editWindow.PasswordBox.Password = user.Password;
            editWindow.PhoneBox.Text = user.Phone;
            editWindow.IsAdminCheck.IsChecked = user.IsAdmin;
            editWindow.Show();
        }

        public void DeleteBTNClick(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32((sender as Button).Tag);
            Users user = Core.DB.Users.Where(s => s.Id == userId).FirstOrDefault();

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить данного пользователя(" + user.LastName + " " + user.FirstName + ")?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Stop);

            if (result == MessageBoxResult.Yes)
            {
                Core.DB.Users.Remove(user);
                Core.DB.SaveChanges();
                UpdateUsers();
            }
        }

        private void CreateUserBTN_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow createWindow = new EditUserWindow(1, null);
            createWindow.Show();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminChooseWindow acw = new AdminChooseWindow();
            acw.Show();
            this.Close();
        }
    }
}
