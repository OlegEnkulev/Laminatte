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
    public partial class AdminProductsWindow : Window
    {
        Label[] userData = new Label[Core.DB.Products.Count()];
        Label[] userName = new Label[Core.DB.Products.Count()];
        StackPanel[] stackPanel = new StackPanel[Core.DB.Products.Count()];
        Button[] editBTN = new Button[Core.DB.Products.Count()];
        StackPanel[] userPanel = new StackPanel[Core.DB.Products.Count()];

        public AdminProductsWindow()
        {
            InitializeComponent();

            UpdateUsers();
        }

        void UpdateUsers()
        {
            UsersScrollViewer.Children.Clear();

            int iCorrect = 0;

            for (int i = 0; i < Core.DB.Products.Count(); i++)
            {
                if (Core.DB.Products.Where(s => s.Id == iCorrect).FirstOrDefault() != null)
                {
                    Products user = Core.DB.Products.Where(s => s.Id == iCorrect).FirstOrDefault();

                    userData[i] = new Label();
                    userData[i].Foreground = Brushes.White;
                    userData[i].Content = user.Price;

                    userName[i] = new Label();
                    userName[i].FontWeight = FontWeights.SemiBold;
                    userName[i].Foreground = Brushes.White;
                    userName[i].Content = user.Name;

                    stackPanel[i] = new StackPanel();
                    stackPanel[i].Width = 365;
                    stackPanel[i].Margin = new Thickness(5);
                    stackPanel[i].Children.Add(userData[i]);
                    stackPanel[i].Children.Add(userName[i]);

                    editBTN[i] = new Button();
                    editBTN[i].Content = "Изменить";
                    editBTN[i].Margin = new Thickness(5);
                    editBTN[i].Click += EditBTNClick;
                    editBTN[i].Width = 65;
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
            Products user = Core.DB.Products.Where(s => s.Id == userId).FirstOrDefault();

            EditCostWindow ecw = new EditCostWindow(userId);
            ecw.Name.Content = user.Name;
            ecw.CostBox.Text = Convert.ToString(user.Price);
            ecw.Show();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            AdminChooseWindow acw = new AdminChooseWindow();
            acw.Show();
            this.Close();
        }
    }
}
