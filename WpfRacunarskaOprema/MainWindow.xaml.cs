using log4net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRacunarskaOprema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //HTTP CLIENT
        private HttpClient klijent = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            //BAZNA ADRESA
            klijent.BaseAddress = new Uri("http://localhost:52850/");
        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
            ComboBox1.SelectedIndex = 0;
            PrikaziProizvode();
        }
        

        //PRIKAZI SVE KATEGORIJE U Combo Box-u
        public async void PrikaziKategorije()
        {
            string url = "/api/kategorija";
            List<Kategorija> listaKategorija = null;

            try
            {
                string jsonKategorija = await klijent.GetStringAsync(url);
                listaKategorija = JsonConvert.DeserializeObject<List<Kategorija>>(jsonKategorija);
                 DataGrid1.ItemsSource = listaKategorija;

                ComboBox1.Items.Add(new Kategorija { KategorijaId = 0, NazivKategorije = "Sve kategorije" });

                foreach (Kategorija k in listaKategorija)
                {
                    ComboBox1.Items.Add(k);
                }
            }
            catch (Exception xcp)
            {

               MessageBox.Show(xcp.Message);
            }
         
        }


        //Filtracija proizvoda po kategoriji
        private async void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kategorija k = ComboBox1.SelectedItem as Kategorija;

            string url = "/api/proizvod/kategorija/" + k.KategorijaId;
            List<Proizvod> listaProizvoda = null;

            try
            {
                string jsonKategorija = await klijent.GetStringAsync(url);
                listaProizvoda =
                    JsonConvert.DeserializeObject<List<Proizvod>>(jsonKategorija);
                DataGrid1.ItemsSource = listaProizvoda;

            }
            catch (Exception xcp)
            {

                MessageBox.Show(xcp.Message);
            }

            //StringBuilder sb = new StringBuilder();
            //foreach (Proizvod p in listaProizvoda)
            //{
            //    sb.AppendLine(p.NazivProizvoda);

            //}
            //// DataGrid1.ItemsSource = sb.ToString();
            //TextBox1.Text = sb.ToString();
        }



        //Prikaz svih proizvoda u Data Gridu
        public async void PrikaziProizvode()
        {
            string url = "/api/proizvod";

            List<Proizvod> listaProizvoda = null;

            try
            {
                    string jsonProizvodi = await klijent.GetStringAsync(url);

                    listaProizvoda = JsonConvert.DeserializeObject<List<Proizvod>>(jsonProizvodi);
                    DataGrid1.ItemsSource = listaProizvoda;
               
                
                
            }
            catch (Exception xcp)
            {

                MessageBox.Show(xcp.Message);
            }
        }


       
        //Pretraga po ID kategorije za ispis proizvoda u data gridu
        private async void TextBoxPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Proizvod k = ComboBox1.SelectedItem as Kategorija;

            string url = "/api/proizvod/kategorija/" + TextBoxPretraga.Text;
            List<Proizvod> listaProizvoda = null;

            try
            {
                
                    string jsonKategorija = await klijent.GetStringAsync(url);
                    listaProizvoda =
                        JsonConvert.DeserializeObject<List<Proizvod>>(jsonKategorija);

                
                    DataGrid1.ItemsSource = listaProizvoda;
               
                
                

            }
            catch (Exception xcp)
            {

                MessageBox.Show(xcp.Message);
            }
        }

        private void ButtonNovaKAtegorija_Click(object sender, RoutedEventArgs e)
        {
            Kategorije w1 = new Kategorije();
            w1.Show();
        }


        //BRISANJE KATEGORIJE 
        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex < 1)
            {
                MessageBox.Show("Odaberite kategoriju za brisanje!");
            }

            Kategorija k = ComboBox1.SelectedItem as Kategorija;

            string url = "/api/kategorija/"+k.KategorijaId;

            MessageBoxResult mbr = MessageBox.Show($"Brisanje kategorije: {k.NazivKategorije}", "Brisanje", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }


            var response = klijent.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Kategorija je obrisana!");
               
            }
            else
            {
                MessageBox.Show("Greska pri brisanju kategorije!");
            }
        }

        private void ButtonPromjeni_Click(object sender, RoutedEventArgs e)
        {

            //if (ComboBox1.SelectedIndex < 1)
            //{
            //    MessageBox.Show("Odaberi kategoriju!");
            //}

            //Kategorija k = ComboBox1.SelectedItem as Kategorija;
            //k.NazivKategorije = 


            //string url = "/api/kategorija/";


            PromjeniKategoriju pk = new PromjeniKategoriju();

            pk.Show();

                
            
        }

        private void ComboBox1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
