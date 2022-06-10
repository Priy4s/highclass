using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Main.Reserveringen; // Opent de file (achter de punt) waarvan je code/methods gaat gebruiken.
using static Main.Medewerkers;
using static Main.Menu;
using static Main.Personeelsleden;
using static Main.Admin;

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
        public static void Main()
        {
            while (true)
            /*
            Deze while-loop zorgt ervoor dat de applicatie blijft runnen. Deze eindigt pas wanneer er op het kruisje wordt geklikt OF
            bij het HOOFDMENU op de cijfer 0 wordt geklikt.
             */
            {
                // Console.BackgroundColor = ConsoleColor.White; verandert de gehele console kleur op tekst na
                Console.ForegroundColor = ConsoleColor.DarkYellow; // verandert alle tekst naar donkerrood
                Console.Clear(); // Maakt de console leeg, zodat het lijkt alsof er een nieuw scherm is geopend.
                Console.WriteLine("                            ┌──────────────────────────────────────────────────────────┐");
                Console.WriteLine("                            │  $    $  $  $$$$$  $   $ $$$$$ $     $$$$$$  $$$$  $$$$  │");
                Console.WriteLine("                            │  $    $  $  $      $   $ $     $     $    $  $     $     │");
                Console.WriteLine("                            │  $    $  $  $      $   $ $     $     $    $  $     $     │");
                Console.WriteLine("                            │  $$$$$$  $  $ $$$  $$$$$ $     $     $$$$$$  $$$$  $$$$  │");
                Console.WriteLine("                            │  $    $  $  $   $  $   $ $     $     $    $     $     $  │");
                Console.WriteLine("                            │  $    $  $  $   $  $   $ $     $     $    $     $     $  │");
                Console.WriteLine("                            │  $    $  $  $$$$$  $   $ $$$$$ $$$$$ $    $  $$$$  $$$$  │");
                Console.WriteLine("                            └──────────────────────────────────────────────────────────┘");
                Console.WriteLine("                                                            ");
                Console.WriteLine("                                                Welkom bij HighClass     ");
                Console.WriteLine("                                                                         ");
                Console.WriteLine("                                                    |Hoofdmenu|          ");
                Console.WriteLine("                                                                         ");
                Console.WriteLine("                                                  [1] Reserveren         ");
                Console.WriteLine("                                                  [2] Menu               ");
                Console.WriteLine("                                                  [3] Inloggen           ");
                Console.WriteLine("                                                  [4] Contact            ");
                Console.WriteLine("                                                            ");

                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo ckey = Console.ReadKey(); // Deze variabele krijgt als input de toets die de gebruiker op het toetsenbord heeft aangeklikt.
                if (ckey.Key == ConsoleKey.D1) // Checkt of de aangeklikte toets overeenkomt met het cijfer die aan de knop is gekoppeld (D1, D2, etc zijn de cijfers).
                {
                    bool no = false;
                    if (Globals.ingelogd) // Checkt of een medewerker is ingelogd, om een functie uit te voeren.
                    {
                        Console.Clear();
                        Console.WriteLine("                                                    ┌─────────────┐            ");
                        Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                        Console.WriteLine("                                                    │ $   $ $     │            ");
                        Console.WriteLine("                                                    │ $$$$$ $     │            ");
                        Console.WriteLine("                                                    │ $   $ $     │            ");
                        Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                        Console.WriteLine("                                                    └─────────────┘            ");
                        Console.WriteLine("                                         ");
                        Console.WriteLine("                                                     |Reserveren|               ");
                        Console.WriteLine("                                         ");
                        Console.WriteLine("                                        Wilt u de beschikbare plekken wijzigen? ");
                        Console.WriteLine("                                         ");
                        Console.WriteLine("                                                       [1] Ja                   ");
                        Console.WriteLine("                                                       [2] Nee                  ");
                        Console.CursorLeft = Console.WindowWidth / 2;
                        ConsoleKeyInfo cvjkey = Console.ReadKey();
                        if (cvjkey.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine("Functie komt z.s.m."); // Roept de method (achter de punt) van de file (voor de punt) op.
                        }
                        else if (cvjkey.Key == ConsoleKey.D2)
                        {
                            no = true;
                        }
                    }
                    else if (Globals.ingelogd == false || no == false)
                    {
                        Console.Clear();
                        Console.WriteLine("                                                    ┌─────────────┐            ");
                        Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                        Console.WriteLine("                                                    │ $   $ $     │            ");
                        Console.WriteLine("                                                    │ $$$$$ $     │            ");
                        Console.WriteLine("                                                    │ $   $ $     │            ");
                        Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                        Console.WriteLine("                                                    └─────────────┘            ");
                        Console.WriteLine("                             ");
                        Console.WriteLine("                                                     |Reserveren|        ");
                        Console.WriteLine("                             ");
                        Console.WriteLine("                                              Heeft u al een reservering? ");
                        Console.WriteLine("                             ");
                        Console.WriteLine("                                                       [1] Ja            ");
                        Console.WriteLine("                                                       [2] Nee           ");
                        Console.WriteLine("                             ");
                        Console.WriteLine("                                                       [0] Terug         ");
                        Console.WriteLine("                             ");
                        Console.CursorLeft = Console.WindowWidth / 2;
                        ConsoleKeyInfo cvkey = Console.ReadKey();
                        if (cvkey.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("                                                    ┌─────────────┐            ");
                            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                            Console.WriteLine("                                                    │ $   $ $     │            ");
                            Console.WriteLine("                                                    │ $$$$$ $     │            ");
                            Console.WriteLine("                                                    │ $   $ $     │            ");
                            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                            Console.WriteLine("                                                    └─────────────┘            ");
                            Console.WriteLine(" ");
                            Console.WriteLine("                                                      |Reserveren|            ");
                            Console.WriteLine("                                    ");
                            Console.WriteLine("                                            Wilt u deze wijzigen of annuleren? ");
                            Console.WriteLine("                                    ");
                            Console.WriteLine("                                                      [1] Wijzigen            ");
                            Console.WriteLine("                                                      [2] Annuleren           ");
                            Console.WriteLine("                                    ");
                            Console.WriteLine("                                                      [0] Terug               ");
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo cv2key = Console.ReadKey();
                            if (cv2key.Key == ConsoleKey.D1)
                            {
                                Reserveringen.WijzigReservering("niet ingelogd");
                            }
                            else if (cv2key.Key == ConsoleKey.D2)
                            {
                                Reserveringen.verwijderReservering("niet ingelogd");
                            }
                            else if (cv2key.Key == ConsoleKey.D0)
                            {
                                Program.Main();
                            }

                        }
                        else if (cvkey.Key == ConsoleKey.D2)
                        {
                            Reserveringen.AddReservering("niet ingelogd", "niet ingelogd");
                        }
                        else if (cvkey.Key == ConsoleKey.D0)
                        {
                            Main();
                        }
                    }
                }
                else if (ckey.Key == ConsoleKey.D2)
                {
                    getMenu.gettingMenu("niet ingelogd");
                }
                else if (ckey.Key == ConsoleKey.D3)
                {
                    Medewerkers.Inloggen();
                }
                else if (ckey.Key == ConsoleKey.D4)
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘            ");
                Console.WriteLine("                                ");
                Console.WriteLine("                                                   |Contactgegevens|       ");
                Console.WriteLine("                                ");
                Console.WriteLine("                                ");
                Console.WriteLine("                                                Tel. : 010 794 4000            ");
                Console.WriteLine("                                                E-mail: highclass@info.com     ");
                Console.WriteLine("                                                Straatnaam: Wijnhaven 107      ");
                Console.WriteLine("                                                Postcode: 3011 WN, Rotterdam   ");
                Console.WriteLine("                                                Openingstijden:                ");
                Console.WriteLine("                                                     ma t/m zo - 11:00 t/m 23:00");
                Console.WriteLine("                                ");
                Console.WriteLine("                                                     [0] Terug            ");
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (done.Key == ConsoleKey.D0)
                {
                    Main();
                }
            }
        }
    }
}
