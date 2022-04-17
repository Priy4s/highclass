using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main
{
    public class Accounts
    {
        public static bool Inloggen()
        {
            int tries = 3; // Aantal kansen die de gebruiker heeft om de goede inloggegevens in te vullen.
            while (tries > 0)
            {
                Console.Clear();
                Console.WriteLine("Gebruikersnaam: ");
                string gebruikersnaam = Console.ReadLine();
                Console.WriteLine("Wachtwoord: ");
                string wachtwoord = Console.ReadLine();

                for (int i = 0; i < Globals.gebruikersnamen.Count; i++) // Deze for-loop zorgt ervoor dat zo vaak loopt als dat de lijst met gebruikersnamen lang is.
                {
                    if (Globals.gebruikersnamen[i] == gebruikersnaam) // Gaat door de lijst met gebruikersnamen heen, totdat de gebruikersnaam die op plaats i staat
                                                                      // gelijk is aan de (door de gebruiker) ingevulde gebruikersnaam.
                    {
                        if (Globals.wachtwoorden[i] == wachtwoord) // Hier is i gelijk aan de plaats van het (JUIST) ingevulde gebruikersnaam en checkt of op dezelfde
                                                                   // plaats in de wachtwoorden lijst het wachtwoord overeen komt met het (door de gebruiker) ingevulde
                                                                   // wachtwoord.
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Welkom, " + gebruikersnaam + "!");
                                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                                ConsoleKeyInfo done = Console.ReadKey();
                                if (done.Key == ConsoleKey.Enter)
                                {
                                    break;
                                }
                            }
                            return true; // Zet de boolean "ingelogd" op true, waardoor het programma weet dat er succesvol is ingelogd.
                        }
                    }
                }
                while (true)
                {
                    Console.WriteLine("Gebruikersnaam en/of wachtwoord onjuist. U heeft nog " + tries + " over.\nKlik op 'Enter' om het opnieuw te proberen.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                tries--;
            }
            return false; // Wanneer er 3 keer foute inloggegevens zijn ingevuld, blijft de boolean "ingelogd" op false.
        }
        public static bool Aanmelden()
        {
            Console.Clear();
            string gebruikersnaam; string wachtwoord;
            Console.WriteLine("Gebruikersnaam: ");
            gebruikersnaam = Console.ReadLine();
            Globals.gebruikersnamen.Add(gebruikersnaam); // Voegt de ingevulde gebruikersnaam toe aan de lijst 
            Console.WriteLine("Wachtwoord: ");
            wachtwoord = Console.ReadLine();
            Globals.wachtwoorden.Add(wachtwoord); // Voegt het ingevulde wachtwoord toe aan de lijst op dezelfde plek als de gebruikersnaam (maar in een andere lijst).
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Account is succesvol aangemaakt.\n\nKlik op 'Enter' om in te loggen en verder te gaan.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            bool verder = Inloggen();
            return verder;
        }
        public static bool Uitloggen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("U bent succesvol uitgelogd.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return false; // Zet de boolean "ingelogd" op false, MAAR de accounts bestaand nog! 
        }
        public static void Account()
        {
            Console.Clear();
            string doen = "[1] Inloggen\n[2] Aanmelden\n[3] Uitloggen";
            Console.WriteLine(doen);
            ConsoleKeyInfo cakey = Console.ReadKey();

            if (cakey.Key == ConsoleKey.D1)
            {
                Globals.ingelogd = Inloggen();
            }
            else if (cakey.Key == ConsoleKey.D2)
            {
                Globals.ingelogd = Aanmelden();
            }
            else if (Globals.ingelogd == true && (cakey.Key == ConsoleKey.D3))
            {
                Globals.ingelogd = Uitloggen();
            }
        }
    }
}