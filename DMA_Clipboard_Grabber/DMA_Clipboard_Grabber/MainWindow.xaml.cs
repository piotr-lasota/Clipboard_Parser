﻿using System;
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

namespace DMA_Clipboard_Grabber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            //DMAClassifierModel model = new DMAClassifierModel(Clipboard.GetText());
            //MessageBox.Show("Definitn: " + model.DefinitnMatches.Count());
            //MessageBox.Show("Design: " + model.DesignMatches.Count());
            //MessageBox.Show("Commerce: " + model.CommerceMatches.Count());
        }
    }
}