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

namespace DataBindind_Basics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //Binding b = new Binding();
            //b.ElementName = "slider1";
            //b.Path = new PropertyPath("Value");
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.Mode = BindingMode.TwoWay;
            //txtBlock1.SetBinding(TextBlock.TextProperty, b);

        }

        //private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (txtBlock1 != null)
        //        txtBlock1.Text = slider1.Value.ToString();
        //}
    }
}
