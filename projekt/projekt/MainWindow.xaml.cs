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
using System.Windows.Controls.Primitives;
using System.Threading;

namespace projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<ObiektDanych> Kolekcja { get; set; }

        public static ObiektDanych WybranyObiekt { get; set; }

//        public static List<ObiektDanych> Kolekcja2 { get; set; }

        //public String SearchTag { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
           // Czas.Content = "Start";
            Thread zegar = new Thread(Licz);
            zegar.Start();

        }
        public void aktualizuj(int i)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Czas.Content = "Liczba sekund od startu: " + i;
                }));
            }
            catch(TaskCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public void Licz()
        {
            var licznik = 0;
            while (true)
            {
                Thread.Sleep(1000);
                licznik=licznik+1;
                aktualizuj(licznik);
            }
        } 
        private void SzukajWiadomosci(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(SearchTag.Text)){
              //  MessageBox.Show(SearchTag.Text);
                var connector = new Connector();
                connector.MakeRequest(SearchTag.Text);
                ///
            } 
            else
                MessageBox.Show("Nie wpisano tagu!");
         
        }
    }
}
