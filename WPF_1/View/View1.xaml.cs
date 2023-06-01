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

namespace WPF_1.View
{
    /// <summary>
    /// Logika interakcji dla klasy View1.xaml
    /// </summary>
    public partial class View1 : Window
    {
        public View1()
        {
            InitializeComponent();

        }
        private void CloseButton(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
    }
}
