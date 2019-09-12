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

namespace wpf_FirstApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Grid mainGrid = new Grid();
            //mainGrid.Name = "mainGrid";
            /*
             * <Grid Name = "mainGrid">...</Grid>
             */
            //RowDefinition row1 = new RowDefinition();
            //RowDefinition row2 = new RowDefinition();
            //mainGrid.RowDefinitions.Add(row1);
            //mainGrid.RowDefinitions.Add(row2);
            //mainGrid.ShowGridLines = true;
        }
    }
}
