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
using Newtonsoft.Json;
using PCLRacunari;


namespace WpfRacunari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient klijent = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            klijent.BaseAddress = new Uri("http://localhost:52850/");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "/api/kategorija/";

            List<Kategorija> listaKategorija = null;

            try
            {
                string jsonKategorija = await klijent.GetStringAsync(url);

                listaKategorija = JsonConvert.DeserializeObject<List<Kategorija>>(jsonKategorija);
                DataGrid1.ItemsSource = listaKategorija;    
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
