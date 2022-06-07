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

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("[1] medewerkers list zien\n[2] medewerker toevoegen\n[3] medewerker verwijderen\n[4] medewerker wijzigen\n[0] terug");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
            {
                Console.Clear();
                string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

                var JsonData = File.ReadAllText(MedewerkerPath);
                var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

                Console.WriteLine("╒══════════════════════════════╕");
                foreach(MedewerkerINFO person in MedewerkersList)
                {
                    Console.WriteLine($"Name: {person.naam}\nVoornaamwoorden: {person.pronouns}\nTelefoonnummer: {person.telefoonnummer}\nE-Mail: {person.eMail}\nFunctie: {person.functie}\nGebruikersnaam: *****\nWachtwoord: ******\n\n");
                }
                Console.WriteLine("Scroll voor meer\n[1] doorgaan");
                Console.WriteLine("╘══════════════════════════════╛");
                ConsoleKeyInfo doorgaan = Console.ReadKey();
                if(doorgaan.Key == ConsoleKey.D1)
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
        }

        public static void adminOmzet()
        {
            Console.Clear();
            Console.WriteLine("Omzet");
            Console.WriteLine(" [1] Omzet bekijken\n [2] Omzet aanpassen \n[0] Terug");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.D1)
            {
                Console.Clear();
                string Omzetpath = Path.GetFullPath(@"Omzet.json");
                bool fileExist = File.Exists(Omzetpath);
                if (!fileExist)
                {
                    using (File.Create(Omzetpath)) ;
                }
                var JsonData = File.ReadAllText(Omzetpath);
                var OmzetList = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData) ?? new List<OmzetDag>();
                Console.WriteLine("Datum: ");
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
                    Console.WriteLine("Er is geen omzet beschikbaar voor deze datum. \n[1] Probeer opnieuw.\n[0] Terug\n");
                    Console.WriteLine("╘════════════════════════════════════════════════════════╛");
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
                Console.WriteLine("╒══════════════════════════════════════════════════════════╕");
                Console.WriteLine("│HC                                                        │");
                Console.WriteLine("│                         |Omzet|                          │");
                Console.WriteLine("│                                                          │");
                Console.WriteLine($"│                   De omzet op {zoekDatum} is:             │");
                Console.WriteLine($"                         {omzet} euro        ");
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
                string Omzetpath = Path.GetFullPath(@"Omzet.json");
                bool fileExist = File.Exists(Omzetpath);
                if (!fileExist)
                {
                    using (File.Create(Omzetpath)) ;
                }
                var JsonData = File.ReadAllText(Omzetpath);
                var OmzetList = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData) ?? new List<OmzetDag>();
                Console.WriteLine("Datum waarvan omzet aangepast moet worden: ");
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
                    Console.WriteLine("Er is geen omzet beschikbaar voor deze datum. \n[1] Probeer opnieuw.\n[0] Terug\n");
                    Console.WriteLine("╘════════════════════════════════════════════════════════╛");
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
                Console.WriteLine($"De huidige omzet = {omzet}");
                Console.WriteLine("Vul het nieuwe omzet bedrag in: ");
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
                Console.WriteLine("Omzet is succesvol gewijzigd\n [1] Doorgaan");
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
