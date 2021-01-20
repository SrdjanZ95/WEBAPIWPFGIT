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

namespace WpfRacunarskaOprema
{
    /// <summary>
    /// Interaction logic for PromjeniKategoriju.xaml
    /// </summary>
    public partial class PromjeniKategoriju : Window
    {
        MainWindow mw = new MainWindow();
        public PromjeniKategoriju()
        {
            InitializeComponent();
        }

        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonPromjeni_Click(object sender, RoutedEventArgs e)
        {
         

            string url = "/api/kategorija/";
        }
    }
}
