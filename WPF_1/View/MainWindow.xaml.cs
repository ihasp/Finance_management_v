using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WPF_1.View;
using WPF_1.ViewModel;

namespace WPF_1
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

        private void ButtonChangeText(object sender, RoutedEventArgs e)
        {
            /*         if(Przycisk.Content == "Jakiś tekst")
                     {
                         Przycisk.Content = "tekst2";
                     } else
                     {
                         Przycisk.Content = "Jakiś tekst";
                     }*/

            var view1 = new View1();
            view1.Show();




            this.Close();



        }
    }
}
