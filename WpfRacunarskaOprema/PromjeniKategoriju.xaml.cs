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
    /// Interaction logic for PromjeniKategoriju.xaml
    /// </summary>
    public partial class PromjeniKategoriju : Window
    {

        HttpClient klijent = new HttpClient();
        MainWindow mw = new MainWindow();
        public PromjeniKategoriju()
        {
            InitializeComponent();
            klijent.BaseAddress = new Uri("http://localhost:52850/");
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
        }
        public async void PrikaziKategorije()
        {
            string url = "/api/kategorija";
            List<Kategorija> listaKategorija = null;

            try
            {
                string jsonKategorija = await klijent.GetStringAsync(url);
                listaKategorija = JsonConvert.DeserializeObject<List<Kategorija>>(jsonKategorija);
                // DataGrid1.ItemsSource = listaKategorija;

                ComboBoxPromjenaKategorije.Items.Add(new Kategorija { KategorijaId = 0, NazivKategorije = "Sve kategorije" });

                foreach (Kategorija k in listaKategorija)
                {
                    ComboBoxPromjenaKategorije.Items.Add(k);
                }
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
            }

        }
        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonPromjeni_Click(object sender, RoutedEventArgs e)
        {
            Kategorija k = ComboBoxPromjenaKategorije.SelectedItem as Kategorija;
            
            k.NazivKategorije = TextBoxNaziv.Text;
            k.OpisKategorije = TextBoxOpis.Text;

            string url = "/api/kategorija/";

            var response = klijent.PutAsJsonAsync(url, k).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Promjene su sacuvane");
                this.Close();
            }
            else
            {
                MessageBox.Show("Greska pri promjeni podataka!");    
            }
        }

        private void ComboBoxPromjenaKategorije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPromjenaKategorije.SelectedIndex > 0)
            {
                Kategorija k = ComboBoxPromjenaKategorije.SelectedItem as Kategorija;
                TextBoxID.Text = k.KategorijaId.ToString();
                TextBoxNaziv.Text = k.NazivKategorije;
                TextBoxOpis.Text = k.OpisKategorije;

            }
        }
    }
}
