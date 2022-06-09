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

            Console.Clear();

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
            Console.WriteLine("                                                     Welkom, admin         ");
            Console.WriteLine("                               ");
            Console.WriteLine("                                                      |Hoofdmenu|          ");
            Console.WriteLine("                                                   [1] Reserveringen       ");
            Console.WriteLine("                                                   [2] Menu               ");
            Console.WriteLine("                                                   [3] Medewerkers        ");
            Console.WriteLine("                                                   [4] Omzet              ");
            Console.WriteLine("                                                   [5] Uitloggen          ");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D1)
            {
                Personeelsleden.reserverenMain("admin");
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                Personeelsleden.menuMain("admin", "admin");
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                adminMedewerkers();
            }
            else if (ckey.Key == ConsoleKey.D4)
            {
                adminOmzet();
            }
            else if (ckey.Key == ConsoleKey.D5)
            {
                Medewerkers.Uitloggen();
            }
            else
            {
                adminMain();
            }
        }
        public static void adminMedewerkers()
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
            Console.WriteLine("                                                     |Medewerkers|             ");
            Console.WriteLine("                                               [1] medewerkers list zien\n                                               [2] medewerker toevoegen\n                                               [3] medewerker verwijderen\n                                               [4] medewerker wijzigen\n\n                                                     [0] terug");

            Console.CursorLeft = (Console.WindowWidth / 2) - 4; 
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
            {
                Console.Clear();
                string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

                var JsonData = File.ReadAllText(MedewerkerPath);
                var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘            ");
                Console.WriteLine(" ");
                Console.WriteLine("                                                     |Medewerkers|             ");
                foreach (MedewerkerINFO person in MedewerkersList)
                {
                    Console.WriteLine($"                                               Name: {person.naam}\n                                               Voornaamwoorden: {person.pronouns}\n                                               Telefoonnummer: {person.telefoonnummer}\n                                               E-Mail: {person.eMail}\n                                               Functie: {person.functie}\n                                               Gebruikersnaam: *****\n                                               Wachtwoord: ******\n\n");
                }
                Console.WriteLine("                                                    Scroll (met de muis) voor meer\n                                                    [1] doorgaan");

                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo doorgaan = Console.ReadKey();

                if (doorgaan.Key == ConsoleKey.D1)
                {
                    adminMedewerkers();
                }
            }
            else if (keuze.Key == ConsoleKey.D2)
            {
                Medewerkers.AddMederwerker();
            }
            else if(keuze.Key == ConsoleKey.D3)
            {
                Medewerkers.verwijderMedewerker();
            }
            else if(keuze.Key== ConsoleKey.D4)
            {
                Medewerkers.wijzigMedewerkers();
            }
            else if (keuze.Key == ConsoleKey.D0)
            {
                adminMain();
            }
            else
            {
                adminMedewerkers();
            }
        }

        public static void adminOmzet()
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
            Console.WriteLine("                                                        |Omzet|    ");
            Console.WriteLine("                                                   [1] Omzet bekijken\n                                                   [2] Omzet aanpassen \n\n                                                       [0] Terug");
            Console.CursorLeft = (Console.WindowWidth / 2); 
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
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
                Console.WriteLine("                                                        |Omzet|    \n");
                string Omzetpath = Path.GetFullPath(@"Omzet.json");
                bool fileExist = File.Exists(Omzetpath);
                if (!fileExist)
                {
                    using (File.Create(Omzetpath)) ;
                }
                var JsonData = File.ReadAllText(Omzetpath);
                var OmzetList = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData) ?? new List<OmzetDag>();
                Console.WriteLine("                                                         Datum(DD-MM-JJJ): ");
                Console.CursorLeft = (Console.WindowWidth / 2)-5;
                string zoekDatum = Console.ReadLine();
                string opslaanDatum = "";
                foreach (OmzetDag omzetdag in OmzetList)
                {
                    if (omzetdag.Datum == zoekDatum)
                    {
                        opslaanDatum = omzetdag.Datum;
                    }
                }
                if (opslaanDatum == "")
                {
                    Console.WriteLine("                                            Er is geen omzet beschikbaar voor deze datum. \n                                                 [1] Probeer opnieuw.\n                                                   [0] Terug\n");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4; 
                    ConsoleKeyInfo rkey = Console.ReadKey();
                    if (rkey.Key == ConsoleKey.D1)
                    {
                        adminOmzet();
                    }
                    else if (rkey.Key == ConsoleKey.D0)
                    {
                        adminMain();
                    }
                }
                double omzet = 0.0;
                foreach (OmzetDag omzetdag in OmzetList)
                {
                    if (omzetdag.Datum == zoekDatum)
                    {
                        omzet = omzetdag.Omzet;
                    }
                }
                Console.WriteLine("                                                          ");
                Console.WriteLine($"                                              De omzet op {zoekDatum} is:           ");
                Console.WriteLine($"                                                      {omzet} euro        ");
                Console.WriteLine("                                                          ");
                Console.WriteLine("                                                       [0] Terug                          ");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.D0)
                {
                    adminOmzet();
                }
            }
            else if (keuze.Key == ConsoleKey.D2)
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
                Console.WriteLine("                                                        |Omzet|    ");
                string Omzetpath = Path.GetFullPath(@"Omzet.json");
                bool fileExist = File.Exists(Omzetpath);
                if (!fileExist)
                {
                    using (File.Create(Omzetpath)) ;
                }
                var JsonData = File.ReadAllText(Omzetpath);
                var OmzetList = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData) ?? new List<OmzetDag>();
                Console.WriteLine("                                      Datum waarvan omzet aangepast moet worden: ");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                string zoekDatum = Console.ReadLine();
                string opslaanDatum = "";
                foreach (OmzetDag omzetdag in OmzetList)
                {
                    if (omzetdag.Datum == zoekDatum)
                    {
                        opslaanDatum = omzetdag.Datum;
                    }
                }
                if (opslaanDatum == "")
                {
                    Console.WriteLine("                                    Er is geen omzet beschikbaar voor deze datum. \n                                                   [1] Probeer opnieuw.\n                                                       [0] Terug\n");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4; 
                    ConsoleKeyInfo rkey = Console.ReadKey();
                    if (rkey.Key == ConsoleKey.D1)
                    {
                        adminOmzet();
                    }
                    else if (rkey.Key == ConsoleKey.D0)
                    {
                        adminMain();
                    }
                }
               
                double omzet = 0.0;
                foreach (OmzetDag omzetdag in OmzetList)
                {
                    if (omzetdag.Datum == zoekDatum)
                    {
                        omzet = omzetdag.Omzet;
                    }
                }
                Console.WriteLine($"                                                De huidige omzet = {omzet}");
                Console.WriteLine("                                              Vul het nieuwe omzet bedrag in: ");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                double nieuwBedrag = Convert.ToDouble(Console.ReadLine());
                foreach (OmzetDag omzetdag in OmzetList)
                {
                    if (omzetdag.Datum == zoekDatum)
                    {
                        omzetdag.Omzet = nieuwBedrag;
                    }

                }
                JsonData = JsonConvert.SerializeObject(OmzetList);
                System.IO.File.WriteAllText(Omzetpath, JsonData);
                Console.WriteLine("                                              Omzet is succesvol gewijzigd\n                                                     [1] Doorgaan");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4; 
                ConsoleKeyInfo rrkey = Console.ReadKey();
                if (rrkey.Key == ConsoleKey.D1)
                {
                    adminMain();
                }
                
            }
            else
            {
                adminMain();
            }
        }
    }
}
