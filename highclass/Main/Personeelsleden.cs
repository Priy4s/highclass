﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static Main.Program;

namespace Main
{
    public class Personeelsleden
    {
        public static void personeelMain()
        {
            Console.Clear(); 

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("│                              │");
            Console.WriteLine("│       Welkom, personeel      │");
            Console.WriteLine("│                              │");
            Console.WriteLine("│         |Hoofdmenu|          │");
            Console.WriteLine("│       [1] Reserveringen      │");
            Console.WriteLine("│       [2] Menu               │");
            Console.WriteLine("│       [3] Bestellingen       │");
            Console.WriteLine("│       [4] Uitloggen          │");
            Console.WriteLine("│                              │");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D1)
            {
                reserverenMain();
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                menuMain();
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                bestellingenMain();
            }
            else if (ckey.Key == ConsoleKey.D4)
            {
                Program.Main();
            }
        }
        public static void reserverenMain(string gebruiker = "personeel")
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
        public static void menuMain(string gebruiker = "personeel")
        {
            Console.Clear();
            Console.WriteLine("       Menu menu - personeel");
            Console.WriteLine("         [1] Bekijk menu           ");
            Console.WriteLine("         [2] Aanpassen menu           ");
            Console.WriteLine("         [0] Terug            ");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0 && gebruiker == "personeel")
            {
                personeelMain();
            }
            else if (ckey.Key == ConsoleKey.D0 && gebruiker == "admin")
            {
                Admin.adminMain();
            }
            else if (ckey.Key == ConsoleKey.D1 && gebruiker == "personeel") {
                getMenu.gettingMenu("personeel");
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                MenuAanpassen.mainAanpassen();
            }
            else if (ckey.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                getMenu.gettingMenu("admin");
            }
        }
        public static void bestellingenMain()
        {
            Console.Clear();
            Console.WriteLine("       Bestellingen Main Menu       ");
            Console.WriteLine("   [1] Bestelling bedrag weergeven         ");
            Console.WriteLine("   [2] Totaal bedrag aanpassen          ");
            Console.WriteLine("   [3] Bestelling toevoegen          ");
            Console.WriteLine("   [0] Terug            ");
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0)
            {
                personeelMain();
            }
            else if (ckey.Key == ConsoleKey.D1)
            {
                bestellingenWeergeven();
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                bestellingenAanpassen();
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                bestellingenToevoegen();
            }

        }
        public static void bestellingenAanpassen()
        {
            Console.Clear();
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            Console.WriteLine("╒════════════════════════════════════════════════════════╕");
            Console.WriteLine(" HC\n");
            Console.WriteLine("Volledige naam: ");
            string zoekNaam = Console.ReadLine();

            int len = ReserveringenList.Count;
            int i = 0;
            string reserveringsNaam = "";
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsNaam = reservering.Naam;
                }
            }
            if (reserveringsNaam == "")
            {
                Console.WriteLine($"\nEen reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenAanpassen();
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain();
                }
            }
            double reserveringsPrijs = 0.00;
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsPrijs = reservering.Prijs;
                    Console.WriteLine("\nHuidige bedrag onder deze naam is: " + reserveringsPrijs + " euro");
                }
            }
            Console.WriteLine("Voer het nieuwe bedrag in: ");
            double nieuwBedrag = Convert.ToDouble(Console.ReadLine());

            while (i < len)
            {
                if (ReserveringenList[i].Naam == zoekNaam)
                {
                    ReserveringenList[i].Prijs = nieuwBedrag;
                    Console.WriteLine($"\nHet bedrag is aangepast naar " + nieuwBedrag + " euro");
                    Console.WriteLine("[1] Doorgaan\n");
                    Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        JsonData = JsonConvert.SerializeObject(ReserveringenList);
                        System.IO.File.WriteAllText(ReserveringPath, JsonData);
                        bestellingenMain();
                    }
                    break;
                }
                i++;
            }


        }
        public static void bestellingenToevoegen()
        {
            Console.Clear();
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            Console.WriteLine("╒════════════════════════════════════════════════════════╕");
            Console.WriteLine(" HC\n");
            Console.WriteLine("Volledige naam: ");
            string zoekNaam = Console.ReadLine();

            int len = ReserveringenList.Count;
            int i = 0;
            string reserveringsNaam = "";
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsNaam = reservering.Naam;
                }
            }
            if (reserveringsNaam == "")
            {
                Console.WriteLine($"\nEen reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenToevoegen();
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain();
                }
            }
            double reserveringsPrijs = 0.00;
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsPrijs = reservering.Prijs;
                    Console.WriteLine("\nHuidige bedrag onder deze naam is: " + reserveringsPrijs + " euro");
                }
            }
            Console.WriteLine("Voer het bedrag in dat u wil toevoegen: ");
            double toevoegBedrag = Convert.ToDouble(Console.ReadLine());
            double nieuwBedrag = toevoegBedrag + reserveringsPrijs;
            while (i < len)
            {
                if (ReserveringenList[i].Naam == zoekNaam)
                {
                    ReserveringenList[i].Prijs = nieuwBedrag;
                    Console.WriteLine($"\n Het bedrag is aangepast naar " + nieuwBedrag + "euro");
                    Console.WriteLine("[1] Doorgaan\n");
                    Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        JsonData = JsonConvert.SerializeObject(ReserveringenList);
                        System.IO.File.WriteAllText(ReserveringPath, JsonData);
                        bestellingenMain();
                    }
                    break;
                }
                i++;
            }
        }
        public static void bestellingenWeergeven()
        {
            Console.Clear();
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            Console.WriteLine("╒════════════════════════════════════════════════════════╕");
            Console.WriteLine(" HC\n");
            Console.WriteLine("Volledige naam: ");
            string zoekNaam = Console.ReadLine();

            int len = ReserveringenList.Count;
            int i = 0;
            string reserveringsNaam = "";
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsNaam = reservering.Naam;
                }
            }
            if (reserveringsNaam == "")
            {
                Console.WriteLine($"\nEen reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenWeergeven();
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain();
                }
            }
            double reserveringsPrijs = 0.00;
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsPrijs = reservering.Prijs;
                    Console.WriteLine("\nHuidige bedrag onder deze naam is: " + reserveringsPrijs + " euro");
                    Console.WriteLine("\n[1] Opnieuw een bedrag bekijken\n[0] Terug naar menu");
                    Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        bestellingenWeergeven();
                    }
                    else if (keus.Key == ConsoleKey.D0)
                    {
                        bestellingenMain();
                    }
                }
            }
        }

    }
}