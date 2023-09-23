using ProjectForGym.Classes;
using ProjectForGym.Database;
using ProjectForGym.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProjectForGym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateList();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }


        private void UpdateList()
        {
            var currentList = UserDB.GetUsers();

            currentList = currentList.Where(c => (c.Surname + " " + c.Name + " " + c.Patronymic).ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

            listViewUsers.ItemsSource = currentList.OrderBy(p => p.Name).ToList();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            var boundData = (User)((Button)sender).DataContext;

            EditUserWindow editUser = new EditUserWindow(boundData);
            editUser.ShowDialog();

            UpdateList();
        }
    }
}
