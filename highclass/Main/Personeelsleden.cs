using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Main

{
    public class Personeelsleden
    {
        public static void personeelMain()
        {
            Console.Clear(); 

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("│                              │");
            Console.WriteLine("│       Welkom, 'naam '        │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│         |Hoofdmenu|          │");
            Console.WriteLine("│       [1] Reserveringen      │");
            Console.WriteLine("│       [2] Menu               │");
            Console.WriteLine("│       [3] Uitloggen          │");
            Console.WriteLine("│                              │");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo ckey = Console.ReadKey(); 
            if (ckey.Key == ConsoleKey.D1)
            {
                reserverenMain(); 
            }
            else if (ckey.Key == ConsoleKey.D2) {
                menuMain();
            }
            else if(ckey.Key == ConsoleKey.D3)
            {
                Program.Main();
            }
        }
        public static void reserverenMain()
        {
            Console.Clear();
            Console.WriteLine("Reserveren menu - personeel");
            Console.WriteLine("         [0] Terug            ");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0)
            {
                personeelMain();
            }
        }
        public static void menuMain()
        {
            Console.Clear();
            Console.WriteLine("       Menu menu - personeel");
            Console.WriteLine("         [1] Bekijk menu           ");
            Console.WriteLine("         [2] Pas menu aan            ");
            Console.WriteLine("         [0] Terug            ");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0)
            {
                personeelMain();
            }
            else if (ckey.Key == ConsoleKey.D1) { 
                getMenu.gettingMenu("personeel");
            }
        }
    }
}