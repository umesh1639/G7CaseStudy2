using DataBindind_Basics.Entities;
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

namespace DataBindind_Basics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Product product = new Product
        {
            Id = 1,
            Name = "dell xps",
            Price = 67000,
            Description = "new laptop from dell"
        };
        public MainWindow()
        {
            InitializeComponent();

            

            //directiomn of data flow: from code (Model)--> control (View)
            //txtValue.Text = product.Name;
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"old name: {product.Name}");
            //product.Name = txtValue.Text;
            //MessageBox.Show($"new name: {product.Name}");
        }
    }
}
