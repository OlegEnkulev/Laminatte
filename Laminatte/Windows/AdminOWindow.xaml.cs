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
    public partial class AdminOWindow : Window
    {
        Label[] userData = new Label[Core.DB.Orders.Count()];
        Label[] userName = new Label[Core.DB.Orders.Count()];
        StackPanel[] stackPanel = new StackPanel[Core.DB.Orders.Count()];
        Button[] editBTN = new Button[Core.DB.Orders.Count()];
        StackPanel[] userPanel = new StackPanel[Core.DB.Orders.Count()];

        public AdminOWindow()
        {
            InitializeComponent();

            UpdateUsers();
        }

        void UpdateUsers()
        {
            UsersScrollViewer.Children.Clear();

            int iCorrect = 0;

            for (int i = 0; i < Core.DB.Orders.Count(); i++)
            {
                if (Core.DB.Orders.Where(s => s.Id == iCorrect).FirstOrDefault() != null)
                {
                    Orders user = Core.DB.Orders.Where(s => s.Id == iCorrect).FirstOrDefault();

                    userData[i] = new Label();
                    userData[i].Foreground = Brushes.White;
                    string status = "Статуса нет, что-то сломалось";
                    switch (user.Status)
                    {
                        case (0):
                            status = "Открыт";
                            break;
                        case (1):
                            status = "Готов";
                            break;
                        case (2):
                            status = "Закрыт";
                            break;
                    }
                    userData[i].Content = "Колличество: " + user.Count + " Цена: " + user.Price + " Статус: " + status;

                    userName[i] = new Label();
                    userName[i].FontWeight = FontWeights.SemiBold;
                    userName[i].Foreground = Brushes.White;
                    userName[i].Content = "Id Продукции: " + user.ProductId + " Id Пользователя: " + user.UserId;

                    stackPanel[i] = new StackPanel();
                    stackPanel[i].Width = 300;
                    stackPanel[i].Margin = new Thickness(5);
                    stackPanel[i].Children.Add(userData[i]);
                    stackPanel[i].Children.Add(userName[i]);

                    editBTN[i] = new Button();
                    editBTN[i].Content = "Изменить";
                    editBTN[i].Margin = new Thickness(5);
                    editBTN[i].Click += EditBTNClick;
                    editBTN[i].Width = 130;
                    editBTN[i].Tag = iCorrect;

                    userPanel[i] = new StackPanel();
                    userPanel[i].Height = 70;
                    userPanel[i].Orientation = Orientation.Horizontal;
                    userPanel[i].Children.Add(stackPanel[i]);
                    userPanel[i].Children.Add(editBTN[i]);

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
            Orders user = Core.DB.Orders.Where(s => s.Id == userId).FirstOrDefault();

            EditStatusWindow esw = new EditStatusWindow(user);
            esw.AccessBox.SelectedIndex = user.Status;
            esw.Show();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminChooseWindow acw = new AdminChooseWindow();
            acw.Show();
            this.Close();
        }
    }
}
