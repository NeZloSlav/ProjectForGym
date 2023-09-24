using ProjectForGym.Classes;
using ProjectForGym.Database;
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

namespace ProjectForGym.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private User currentUser;
        private bool IsEdit;
        public EditUserWindow()
        {
            InitializeComponent();
        }

        public EditUserWindow(User user)
        {
            InitializeComponent();

            currentUser = user;
            
            TbxSurname.Text = currentUser.Surname;
            TbxName.Text = currentUser.Name;
            TbxPatronymic.Text = currentUser.Patronymic;
            DtPickerLastPay.Text = currentUser.LastPayment.ToString();
            CmbTariff.SelectedIndex = currentUser.TariffIndex;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            IsEdit = true;

            BtnEdit.IsEnabled = false;
            TbxSurname.IsEnabled = true;
            TbxName.IsEnabled = true;
            TbxPatronymic.IsEnabled = true;
            BtnSave.IsEnabled = true;
            DtPickerLastPay.IsEnabled = true;
            CmbTariff.IsEnabled = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DisenableForms();
            UserDB.Update(currentUser.Id, TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex);
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {
                DisenableForms();
            }
            else
            {
                Close();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Вы уверены, что хотите удалить клиента из базы?", "Подтверждение", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                UserDB.Delete(currentUser.Id);
                Close();
            }

        }

        private void DisenableForms()
        {
            IsEdit = false;

            TbxSurname.IsEnabled = false;
            TbxName.IsEnabled = false;
            TbxPatronymic.IsEnabled = false;
            BtnSave.IsEnabled = false;
            BtnEdit.IsEnabled = true;
            DtPickerLastPay.IsEnabled = false;
            CmbTariff.IsEnabled = false;
        }

        
    }
}
