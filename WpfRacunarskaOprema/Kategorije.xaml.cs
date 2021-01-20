using Newtonsoft.Json;
using PCLRacunari;
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
using System.Windows.Shapes;

namespace WpfRacunarskaOprema
{
    /// <summary>
    /// Interaction logic for Kategorije.xaml
    /// </summary>
    public partial class Kategorije : Window
    {

        MainWindow mw = new MainWindow();
        private HttpClient klijent = new HttpClient();
        public Kategorije()
        {
            InitializeComponent();
            klijent.BaseAddress = new Uri("http://localhost:52850/");
        }

        private async void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            string url = "/api/kategorija";

            Kategorija k = new Kategorija { 
               
                NazivKategorije = TextBoxNaziv.Text,
                OpisKategorije = TextBoxOpis.Text
            };

            string jsonString = JsonConvert.SerializeObject(k);
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await klijent.PostAsync(url, data);

            

            MessageBox.Show("Nova kategorija je kreirana!");
            this.Close();

            mw.PrikaziKategorije();


        }

        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
