﻿using Microsoft.EntityFrameworkCore;
using ProjectForGym.Classes;
using ProjectForGym.ClassHelper;
using ProjectForGym.Database;
using ProjectForGym.Models;
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

namespace ProjectForGym.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        private readonly ProductContext _context = new ProductContext();

        private CollectionViewSource categoryViewSource;

        public ListPage()
        {
            InitializeComponent();

            categoryViewSource =
                (CollectionViewSource)FindResource(nameof(categoryViewSource));

            //UpdateList();
        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }


        private void UpdateList()
        {
            var currentList = UserDB.GetUsers();

            if (cmbSearch.SelectedIndex == 0)
            {
                currentList = currentList.Where(c => (c.Surname + " " + c.Name + " " + c.Patronymic).ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

                listViewUsers.ItemsSource = currentList.OrderBy(p => p.Surname).ToList();
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                currentList = currentList.Where(c => c.Name.ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

                listViewUsers.ItemsSource = currentList.OrderBy(p => p.Name).ToList();
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                currentList = currentList.Where(c => c.Surname.ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

                listViewUsers.ItemsSource = currentList.OrderBy(p => p.Surname).ToList();
            }
            else
            {
                currentList = currentList.Where(c => c.LastPayment.Date.ToString().ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

                listViewUsers.ItemsSource = currentList.OrderBy(p => p.LastPayment).ToList();
            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var boundData = (User)((Button)sender).DataContext;

            EditOrDeleteClientPage editOrDeleteClientPage = new EditOrDeleteClientPage(boundData);

            NavigateClass.frmNavigate.Navigate(editOrDeleteClientPage);
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddClientPage addClientPage = new AddClientPage();

            NavigateClass.frmNavigate.Navigate(addClientPage);
        }

        private void TbxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TbkSearchText.Visibility = Visibility.Hidden;
        }

        private void TbxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearch.Text == string.Empty)
            {
                TbkSearchText.Visibility = Visibility.Visible;
            }
        }

        private void BtnMark_Click(object sender, RoutedEventArgs e)
        {
            var boundData = (User)((Button)sender).DataContext;

            MarkClientPage markClientPage = new MarkClientPage(boundData);

            NavigateClass.frmNavigate.Navigate(markClientPage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Tariffs.Load();

            // bind to the source
            categoryViewSource.Source =
                _context.Tariffs.Local.ToObservableCollection();

            //UpdateList();
        }
    }
}
