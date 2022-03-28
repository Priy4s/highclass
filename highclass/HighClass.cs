using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Main.Reserveringen; // Opent de file (achter de punt) waarvan je code/methods gaat gebruiken.
using static Main.Accounts;
using static Main.Menu;

namespace Main
{
    public static class Globals
    {
        // Alle variabelen, die als globals gebruikt worden, moeten hier gedefiniëerd worden.
        public static int seats = 200;
        public static int available_seats = 200;
        public static int taken_seats = 0;
        public static Dictionary<string, int> reservering_personen = new Dictionary<string, int>();
        public static Dictionary<string, string> reservering_tijd = new Dictionary<string, string>();
        public static List<string> gebruikersnamen = new List<string>();
        public static List<string> wachtwoorden = new List<string>();
        public static bool ingelogd = false;
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            /*
            Deze while-loop zorgt ervoor dat de applicatie blijft runnen. Deze eindigt pas wanneer er op het kruisje wordt geklikt OF
            bij het HOOFDMENU op de cijfer 0 wordt geklikt.
             */
            {
                Console.Clear(); // Maakt de console leeg, zodat het lijkt alsof er een nieuw scherm is geopend.
                Console.WriteLine("Welkom bij HighClass!\n");
                Console.WriteLine("Hoofdmenu");
                string scherm = "[1] Reserveren\n[2] Menu\n[3] Account\n[4] Omzet"; // De "knoppen"
                Console.WriteLine(scherm);
                ConsoleKeyInfo ckey = Console.ReadKey(); // Deze variabele krijgt als input de toets die de gebruiker op het toetsenbord heeft aangeklikt.
                if (ckey.Key == ConsoleKey.D1) // Checkt of de aangeklikte toets overeenkomt met het cijfer die aan de knop is gekoppeld (D1, D2, etc zijn de cijfers).
                {
                    bool no = false;
                    if (Globals.ingelogd) // Checkt of een medewerker is ingelogd, om een functie uit te voeren.
                    {
                        Console.Clear();
                        Console.WriteLine("Wilt u de beschikbare plekken wijzigen?");
                        string vraagje = "[1] Ja\n[2] Nee";
                        Console.WriteLine(vraagje);
                        ConsoleKeyInfo cvjkey = Console.ReadKey();
                        if (cvjkey.Key == ConsoleKey.D1)
                        {
                            Reserveringen.Plekken(); // Roept de method (achter de punt) van de file (voor de punt) op.
                        }
                        else if (cvjkey.Key == ConsoleKey.D2)
                        {
                            no = true;
                        }
                    }
                    else if (Globals.ingelogd == false || no == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Heeft u al een reservering?");
                        string vraag = "[1] Ja\n[2] Nee";
                        Console.WriteLine(vraag);
                        ConsoleKeyInfo cvkey = Console.ReadKey();
                        if (cvkey.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wilt u deze wijzigen of annuleren?");
                            string vraag2 = "[1] Wijzigen\n[2] Annuleren";
                            Console.WriteLine(vraag2);
                            ConsoleKeyInfo cv2key = Console.ReadKey();
                            if (cv2key.Key == ConsoleKey.D1)
                            {
                                Reserveringen.Wijzigen();
                            }
                            else if (cv2key.Key == ConsoleKey.D2)
                            {
                                Reserveringen.Annuleren();
                            }
                        }
                        else if (cvkey.Key == ConsoleKey.D2)
                        {
                            Reserveringen.Reserveren();
                        }
                    }
                }
                else if (ckey.Key == ConsoleKey.D2)
                {
                    getMenu.gettingMenu();
                }
                else if (ckey.Key == ConsoleKey.D3)
                {
                    Accounts.Account();
                }
                else if (ckey.Key == ConsoleKey.D4)
                {
                    Omzet();
                }
                else if (ckey.Key == ConsoleKey.D0)
                {
                    break;
                }
            }
        }

        static void Omzet()
        {
            Console.Clear();
            if (Globals.ingelogd == true)
            {
                double omzet = 50 * Globals.taken_seats;
                while (true)
                {
                    Console.WriteLine($"Als we ervan uitgaan dat een klant 50 euro zal uitgeven, wordt uw omzet van vandaag: {omzet} euro.");
                    Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Alleen medewerkers kunnen de omzet bekijken.\nKlik op 'Enter' om in te loggen en probeer het opnieuw.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Accounts.Account();
            }
        }
    }
}