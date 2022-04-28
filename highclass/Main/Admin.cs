using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static Main.Medewerkers;


namespace Main
{
    public class Admin
    {
        public static void adminMain()
        {
            Console.Clear();

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("│                              │");
            Console.WriteLine("│        Welkom, admin         │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│         |Hoofdmenu|          │");
            Console.WriteLine("│       [1] Reserveringen      │");
            Console.WriteLine("│       [2] Menu               │");
            Console.WriteLine("│       [3] Medewerkers        │");
            Console.WriteLine("│       [4] Omzet              │");
            Console.WriteLine("│       [5] Uitloggen          │");
            Console.WriteLine("│                              │");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D1)
            {
                Personeelsleden.reserverenMain("admin");
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                Personeelsleden.menuMain("admin");
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                adminMedewerkers();
            }
            else if (ckey.Key == ConsoleKey.D4)
            {
                adminOmzet();
            }
            else
            {
                Program.Main();
            }
        }
        public static void adminMedewerkers()
        {
            Console.Clear();

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("[1] medewerkers list zien\n[2] medewerker verwijderen\n[3] medewerker wijzigen");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
            {
                Console.WriteLine("hier komen de medewerkers");
                Console.WriteLine("╘══════════════════════════════╛");
            }
            else if(keuze.Key == ConsoleKey.D2)
            {
                Medewerkers.verwijderMedewerker();
            }
            else if(keuze.Key== ConsoleKey.D3)
            {
                Medewerkers.wijzigMedewerkers();
            }
        }

        public static void adminOmzet()
        {
            Console.Clear();
            Console.WriteLine("Omzet");
            Console.WriteLine(" [1] Omzet bekijken\n [2] Besetellingen toevoegen\n [0] Terug");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("╒══════════════════════════════════════════════════════════╕");
                Console.WriteLine("│HC                                                        │");
                Console.WriteLine("│                         |Omzet|                          │");
                Console.WriteLine("│                                                          │");
                Console.WriteLine("│                   De huidige omzet is:                   │");
                Console.WriteLine("│                         - euro                           │");
                Console.WriteLine("│                       [0] Terug                          │");
                Console.WriteLine("╘══════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.D0)
                {
                    adminOmzet();
                }
            }
            else if (keuze.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Bestelling toevoegen zal hier komen\nDruk op 0 om terug te gaan.");
                ConsoleKeyInfo keuzeterug = Console.ReadKey();
                if (keuzeterug.Key == ConsoleKey.D0)
                {
                    adminOmzet();
                }
            }
            else
            {
                adminMain();
            }
        }
    }
}
