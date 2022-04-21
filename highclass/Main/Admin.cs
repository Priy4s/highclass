using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Main
{
    public class Admin
    {
        public static void adminMain()
        {
            Console.Clear();

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("│                              │");
            Console.WriteLine("│       Welkom, admin          │");
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
            Console.WriteLine("Medewerkers komen hier");
        }

        public static void adminOmzet()
        {
            Console.WriteLine("Omzet komen hier");
        }
    }
}
