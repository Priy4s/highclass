using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Main.Reserveringen; // Opent de file (achter de punt) waarvan je code/methods gaat gebruiken.
using static Main.Medewerkers;
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
                // Console.BackgroundColor = ConsoleColor.Green; verandert de gehele console kleur op tekst na
                Console.ForegroundColor = ConsoleColor.DarkYellow; // verandert alle tekst naar donkerrood
                Console.Clear(); // Maakt de console leeg, zodat het lijkt alsof er een nieuw scherm is geopend.

                Console.WriteLine("╒════════════════════════╕");
                Console.WriteLine("│                        │");
                Console.WriteLine("│  Welkom bij HighClass  │");
                Console.WriteLine("│                        │");
                Console.WriteLine("│      |Hoofdmenu|       │");
                Console.WriteLine("│    [1] Reserveren      │");
                Console.WriteLine("│    [2] Menu            │");
                Console.WriteLine("│    [3] Account         │");
                Console.WriteLine("│    [4] Omzet           │");
                Console.WriteLine("│    [5] Contact         │");
                Console.WriteLine("│                        │");
                Console.WriteLine("╘════════════════════════╛");

                ConsoleKeyInfo ckey = Console.ReadKey(); // Deze variabele krijgt als input de toets die de gebruiker op het toetsenbord heeft aangeklikt.
                if (ckey.Key == ConsoleKey.D1) // Checkt of de aangeklikte toets overeenkomt met het cijfer die aan de knop is gekoppeld (D1, D2, etc zijn de cijfers).
                {
                    bool no = false;
                    if (Globals.ingelogd) // Checkt of een medewerker is ingelogd, om een functie uit te voeren.
                    {
                        Console.Clear();
                        Console.WriteLine("╒═════════════════════════════════════════╕");
                        Console.WriteLine("│HC                                       │");
                        Console.WriteLine("│              |Reserveren|               │");
                        Console.WriteLine("│                                         │");
                        Console.WriteLine("│ Wilt u de beschikbare plekken wijzigen? │");
                        Console.WriteLine("│                                         │");
                        Console.WriteLine("│                [1] Ja                   │");
                        Console.WriteLine("│                [2] Nee                  │");
                        Console.WriteLine("│                                         │");
                        Console.WriteLine("╘═════════════════════════════════════════╛");
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
                        Console.WriteLine("╒═════════════════════════════╕");
                        Console.WriteLine("│HC                           │");
                        Console.WriteLine("│         |Reserveren|        │");
                        Console.WriteLine("│                             │");
                        Console.WriteLine("│ Heeft u al een reservering? │");
                        Console.WriteLine("│                             │");
                        Console.WriteLine("│           [1] Ja            │");
                        Console.WriteLine("│           [2] Nee           │");
                        Console.WriteLine("│                             │");
                        Console.WriteLine("╘═════════════════════════════╛");
                        ConsoleKeyInfo cvkey = Console.ReadKey();
                        if (cvkey.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("╒════════════════════════════════════╕");
                            Console.WriteLine("│HC                                  │");
                            Console.WriteLine("│            |Reserveren|            │");
                            Console.WriteLine("│                                    │");
                            Console.WriteLine("│ Wilt u deze wijzigen of annuleren? │");
                            Console.WriteLine("│                                    │");
                            Console.WriteLine("│              [1] Ja                │");
                            Console.WriteLine("│              [2] Nee               │");
                            Console.WriteLine("│                                    │");
                            Console.WriteLine("╘════════════════════════════════════╛");
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
                    Medewerkers.Account();
                }
                else if (ckey.Key == ConsoleKey.D4)
                {
                    Omzet();
                }
                else if (ckey.Key == ConsoleKey.D5)
                {
                    Contactgegevens();
                }
                else if (ckey.Key == ConsoleKey.D0)
                {
                    break;
                }
            }
        }

        static void Contactgegevens()
        {
            Console.Clear();
            Console.WriteLine("╒════════════════════════╕");
            Console.WriteLine("│HC                      │");
            Console.WriteLine("│   |Contactgegevens|    │");
            Console.WriteLine("│                        │");
            Console.WriteLine("│    Naam: HighClass     │");
            Console.WriteLine("│  Adres: Wijnhaven 107  │");
            Console.WriteLine("│    Tel.: 0107940000    │");
            Console.WriteLine("│                        │");
            Console.WriteLine("╘════════════════════════╛");
        }

        static void Omzet()
        {
            Console.Clear();
            if (Globals.ingelogd == true)
            {
                double omzet = 50 * Globals.taken_seats;
                while (true)
                {
                    Console.WriteLine("╒══════════════════════════════════════════════════════════╕");
                    Console.WriteLine("│HC                                                        │");
                    Console.WriteLine("│                         |Omzet|                          │");
                    Console.WriteLine("│                                                          │");
                    Console.WriteLine("│ Als we ervan uitgaan dat een klant 50 euro zal uitgeven, │");
                    Console.WriteLine($"│        wordt de omzet van vandaag: {omzet} euro.         │");
                    Console.WriteLine("│                                                          │");
                    Console.WriteLine("╘══════════════════════════════════════════════════════════╛");
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
                    Console.WriteLine("╒══════════════════════════════════════════════════════════════════════════╕");
                    Console.WriteLine("│HC                                                                        │");
                    Console.WriteLine("│                                  |Omzet|                                 │");
                    Console.WriteLine("│                                                                          │");
                    Console.WriteLine("│              Alleen medewerkers kunnen de omzet bekijken.                │");
                    Console.WriteLine("│ Klik op 'Enter' om in te loggen en probeer opnieuw de omzet te bekijken. │");
                    Console.WriteLine("│                                                                          │");
                    Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Console.Clear();
                Medewerkers.AddMederwerker();
            }
        }
    }
}