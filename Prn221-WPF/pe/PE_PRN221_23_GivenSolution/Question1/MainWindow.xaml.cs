﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Question1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateGridView()
        {
            Nationality.ItemsSource = new List<string>()
            {
               "USA", "UK", "Japan" , "China",
            };
            //listEmployee.ItemsSource = context.Stars.ToList();
            //listStart = context.Stars.ToList();
        }

        private void HandleBeforeLoad()
        {
            UpdateGridView();
        }

        //public Star GetEmployeeObject()
        //{
        //    try
        //    {
        //        return new Star
        //        {
        //            FullName = name.Text,
        //            Male = male.IsChecked == true ? true : false,
        //            Dob = dob.SelectedDate,
        //            Description = des.Text,
        //            Nationality = Nationality.SelectedItem.ToString(),
        //        };
        //    }
        //    catch (System.Exception)
        //    {
        //        MessageBox.Show("Can't get employee", "Get Employee");
        //    }
        //    return null;
        //}



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var star = GetEmployeeObject();
            //    if (star != null)
            //    {
            //        Nationality.ItemsSource = new List<string>()
            //        {
            //           "USA", "UK", "Japan" , "China",
            //        };
            //        var list = context.Stars.ToList();
            //        list.Insert(0, star); ;
            //        listStart = list;
            //        listEmployee.ItemsSource = list;
            //    }
            //}
            //catch (System.Exception)
            //{
            //}
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    using StreamReader reader = new(openFileDialog.FileName);
            //    var json = reader.ReadToEnd();
            //    List<Star> stars = JsonSerializer.Deserialize<List<Model.Star>>(json);
            //    listEmployee.ItemsSource = null;
            //    listEmployee.ItemsSource = stars;
            //}

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    foreach (var item in listStart)
            //    {
            //        item.Id = 0;
            //    }
            //    context.Stars.AddRangeAsync(listStart);
            //    context.SaveChanges();
            //}
            //catch (System.Exception ex)
            //{
            //}
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            //        var item = (sender as ListView).SelectedItem;
            //        if (item != null)
            //        {
            //            var gender = ((Employee)item).Gender;
            //            if (!string.IsNullOrEmpty(gender))
            //            {
            //                if (gender.ToLower() == "female")
            //                {
            //                    female.IsChecked = true;
            //                }
            //                else
            //                {
            //                    male.IsChecked = true;
            //                }
            //            }
            //        }
        }
    }
}
