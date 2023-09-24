using ProjectForGym.Classes;
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
    /// Логика взаимодействия для MarkWindow.xaml
    /// </summary>
    public partial class MarkWindow : Window
    {
        private User currentUser;

        public MarkWindow()
        {
            InitializeComponent();
        }

        public MarkWindow(User user)
        {
            currentUser = user;

            InitializeComponent();

            foreach (DateTime date in currentUser.MarkDates)
            {
                CldrMark.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (DateTime date in CldrMark.SelectedDates)
            {
                currentUser.MarkDates.Add(date);
            }

            MessageBox.Show("Выделенные даты занесены в базу.", "Успех!");

            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var date in CldrMark.SelectedDates)
            {
                if (currentUser.MarkDates.Contains(date))
                {
                    currentUser.MarkDates.Remove(date);
                }
            }

            Close();
        }
    }
}
