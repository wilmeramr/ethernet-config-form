﻿using Ethernet.AppWpf.Repositories.Interfaces;
using Ethernet.AppWpf.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ethernet.AppWpf.View
{
    /// <summary>
    /// Lógica de interacción para PeopleListingView.xaml
    /// </summary>
    public partial class PeopleListingView : UserControl
    {
        public PeopleListingView()
        {
            InitializeComponent();
          ///  Loaded += OnCustomButtonClick;
        }

        private void OnCustomButtonClick(object sender, RoutedEventArgs e)
        {
            
        }



    }
}
