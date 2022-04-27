﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Main.Admin;



namespace Main
{
    public class MedewerkerINFO
    {
        public string naam { get; set; }
        public string pronouns { get; set; }
        public string telefoonnummer { get; set; }
        public string eMail { get; set; }
        public string functie { get; set; }
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
    }
    public class Medewerkers
    {
        public static void AddMederwerker()
        {
            Console.Clear();
            Console.WriteLine("╒══════════════════════╕");
            Console.WriteLine("HC   ");
            Console.WriteLine(" ");
            Console.WriteLine("    |Aanmelden|");
            Console.WriteLine(" ");
            string medewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to file
            bool fileExist = File.Exists(medewerkerPath); // checks if the file exists, if so does nothing, else creates it
            if (!fileExist)
            {
                using (File.Create(medewerkerPath)) ;
            }
            var JsonData = File.ReadAllText(medewerkerPath); // file can be found in the bin => just keep clicking until you find all extra files
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("Wat is uw volledige naam?");
            string naamIN = Console.ReadLine();
            Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
            ConsoleKeyInfo ckey = Console.ReadKey();
            Console.SetCursorPosition(0, Console.CursorTop);
            ClearCurrentConsoleLine();
            string pronounsIN = "";
            if (ckey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
            {
                pronounsIN = "hij/hem";
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                pronounsIN = "zij/haar";
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                pronounsIN = "hen/hun";
            }
            Console.WriteLine("Wat is uw telefoonnummber?");
            string telefoonnummerIN = Console.ReadLine();
            Console.WriteLine("Wat is uw e-mail?");
            string eMailIN = Console.ReadLine();
            Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
            ConsoleKeyInfo AKey = Console.ReadKey();
            ClearCurrentConsoleLine();
            string functieIN = "";
            if (AKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
            {
                functieIN = "Admin";
            }
            else if (AKey.Key == ConsoleKey.D2)
            {
                functieIN = "Mederwerker";
            }
            Console.WriteLine("Voer uw gebruikersnaam in:");
            string gebruikersnaamIN = Console.ReadLine();
            Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoordIN = Console.ReadLine();
            Console.WriteLine("╘══════════════════════╛");

            MederwerkerList.Add(new MedewerkerINFO()
            {
                naam = naamIN,
                pronouns = pronounsIN,
                telefoonnummer = telefoonnummerIN,
                eMail = eMailIN,
                functie = functieIN,
                gebruikersnaam = gebruikersnaamIN,
                wachtwoord = wachtwoordIN
            });

            JsonData = JsonConvert.SerializeObject(MederwerkerList);
            System.IO.File.WriteAllText(medewerkerPath, JsonData);
        }
        public static void verwijderMedewerker()
        {
            Console.Clear();
            string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

            var JsonData = File.ReadAllText(MedewerkerPath);
            var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

            Console.WriteLine("Wat is naam van de medewerker?");
            string zoekNaam = Console.ReadLine();

            int len = MedewerkersList.Count;
            int i = 0;
            int count = 0;
            string medewerkerNaam = "";
            foreach (MedewerkerINFO person in MedewerkersList)
            {
                if(person.naam == zoekNaam)
                {
                    medewerkerNaam = person.naam;
                }
            }
            if (medewerkerNaam == "")
            {
                Console.WriteLine("Medewerker met die naam bestaat niet. \n[1] Probeer opnieuw.");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    verwijderMedewerker();
                }
            }

            Console.WriteLine("Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
            Console.WriteLine("[1] Ja\n[2] Nee");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList.RemoveAt(i);
                        Console.WriteLine($"Medewerker met naam: {zoekNaam} is verwijderd");

                        count++;
                        break;
                    }
                    i++;
                }

            }
            else
            {
                Admin.adminMain();
            }
            
            JsonData = JsonConvert.SerializeObject(MedewerkersList);
            System.IO.File.WriteAllText(MedewerkerPath, JsonData);

            Console.WriteLine("Succesvol verwijderd!");
            Console.WriteLine("[1] Doorgaan");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
        }
        private static void wijzigMedewerkers()
        {
            Console.WriteLine("deze functie komt binnekort");
        }
        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static void Inloggen()
        {
            Console.Clear();
            Console.WriteLine("╒══════════════════════════╕");
            Console.WriteLine("HC   ");
            Console.WriteLine(" ");
            Console.WriteLine("     |Inloggen|");
            Console.WriteLine(" ");
            Console.WriteLine("Gebruikersnaam: ");
            string gebruikersnaamCheck = Console.ReadLine();

            Console.WriteLine("Wachtwoord: ");
            string wachtwoordCheck = Console.ReadLine();

            string medewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to file
            var JsonData = File.ReadAllText(medewerkerPath); // file can be found in the bin => just keep clicking until you find all extra files
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();
            int count = 0;
            foreach (MedewerkerINFO accountList in MederwerkerList)
            {
                if (gebruikersnaamCheck == accountList.gebruikersnaam && wachtwoordCheck == accountList.wachtwoord)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("    Ingelogd");
                    Console.WriteLine("[1] Doorgaan");
                    Console.WriteLine("╘══════════════════════════╛");
                    count++;
                    ConsoleKeyInfo terug = Console.ReadKey();
                    if (ConsoleKey.D1 == terug.Key && accountList.functie == "personeel")
                    {
                        Personeelsleden.personeelMain();
                    }
                    else if (ConsoleKey.D1 == terug.Key && accountList.functie == "admin")
                    {
                        Admin.adminMain();
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("Gebruikersnaam en of wachtwoord is verkeerd");
                Console.WriteLine("[0] Terug");
                Console.WriteLine("[1] Maak een account aan");
                Console.WriteLine("╘══════════════════════════╛");
                ConsoleKeyInfo begin = Console.ReadKey();
                if (ConsoleKey.D0 == begin.Key)
                {
                    Program.Main();
                }
                else if (ConsoleKey.D1 == begin.Key)
                {
                    Medewerkers.AddMederwerker();
                }
            }
        }
        public static bool Uitloggen()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("╒════════════════════════════════════════════════════════╕");
                Console.WriteLine("HC   ");
                Console.WriteLine("U bent succesvol uitgelogd.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
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
            Console.WriteLine("╒══════════════╕");
            Console.WriteLine("HC   ");
            string doen = "[1] Inloggen\n[2] Aanmelden\n";
            Console.WriteLine(doen);
            Console.WriteLine("╘══════════════╛");
            ConsoleKeyInfo cakey = Console.ReadKey();

            if (cakey.Key == ConsoleKey.D1)
            {
                Inloggen();
            }
            else if (cakey.Key == ConsoleKey.D2)
            {
                AddMederwerker();
            }
        }
    }
}
