using System;
using System.Reflection;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new(url, UriKind.Relative);
            BitmapImage image = new(uri);

            Billede.Source = image;

        }

        private string FindBillede(int kortnummer)
        {

            string suit = "";
            string kort = "";
            string kortnavn = "";
            bool fejl = false;

            // kort pr.kulør
            int sæt = 13;

            // Finder kulør
            if (1 <= kortnummer && kortnummer <= sæt)
            {
                suit = "Spar";
            }
            else if (sæt + 1 <= kortnummer && kortnummer <= 2 * sæt)
            {
                suit = "Ruder";
                kortnummer -= sæt;
            }
            else if (2 * sæt + 1 <= kortnummer && kortnummer <= 3 * sæt)
            {
                suit = "Klør";
                kortnummer -= 2 * sæt;
            }
            else if (3 * sæt + 1 <= kortnummer && kortnummer <= 4 * sæt)
            {
                suit = "Hjerter";
                kortnummer -= 3 * sæt;
            }
            else
            {
                fejl = true;

            }

            // Finder kort
            if (kortnummer == 1)
            {
                kort = "Es";
            }
            else if (kortnummer == 11)
            {
                kort = "Knægt";
            }
            else if (kortnummer == 12)
            {
                kort = "Dame";
            }
            else if (kortnummer == 13)
            {
                kort = "Konge";
            }
            else if (kortnummer >= 2 && kortnummer <= 9)
            {
                kort = Convert.ToString(kortnummer);
            }
            else
            {
                fejl = true;
            }

            // Tjekker for fejl
            if (fejl == true)
            {
                // jeg ved fra google, at man ikke logger sådan i VS, men jeg prøvede at tænke det ind...
                Console.WriteLine("Der skete en fejl. Husk at indtaste et helt tal i intervallet 1 - 52");
            }
            else
            {
                // Sammensætter filnavnet hvis der ikke er fejl
                kortnavn += kort;
                kortnavn += "-";
                kortnavn += suit;
                kortnavn += ".jpg";

                
            }
// returnerer kortet
                return kortnavn;


        }
    }
}
