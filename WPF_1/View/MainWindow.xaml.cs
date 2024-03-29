﻿using Microsoft.EntityFrameworkCore;
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
using WPF_1.ViewModel;


namespace WPF_1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
          
        }

        private bool isWindowOpen = false;

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
           

            if (!isWindowOpen)
            {
             
                ModifyDatabase modifyDatabase = new ModifyDatabase();
                modifyDatabase.Show();

       
                isWindowOpen = true;
                
                modifyDatabase.Closed += (s, args) => { isWindowOpen = false; };
             
            }
       

        }



    }
}
