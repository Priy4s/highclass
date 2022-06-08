using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static Main.Program;

namespace Main
{
    public class OmzetDag
    {
        public string Datum { get; set; }
        public double Omzet { get; set; }
    }
    public class Personeelsleden
    {
        public static void personeelMain(string gebruikerNaam)
        {
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
            Console.WriteLine($"                                              Welkom, {gebruikerNaam}  ");
            Console.WriteLine("                              ");
            Console.WriteLine("                                                 |Hoofdmenu|          ");
            Console.WriteLine("                                               [1] Reserveringen      ");
            Console.WriteLine("                                               [2] Menu               ");
            Console.WriteLine("                                               [3] Bestellingen       ");
            Console.WriteLine("                                               [4] Eigen gegevens     ");
            Console.WriteLine("                                               [5] Uitloggen          ");
            Console.WriteLine("                              ");
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D1)
            {
                reserverenMain(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                menuMain(gebruikerNaam, "personeel");
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                bestellingenMain(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D5)
            {
                Program.Main();
            }
            else if (ckey.Key == ConsoleKey.D4)
            {
                persoonlijkeInfo(gebruikerNaam);
            }
        }
        public static void reserverenMain(string gebruikerNaam, string gebruiker = "personeel")
        {
            Console.Clear();
            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine("                                                 |Reserveren|");
            Console.WriteLine("                                               [1] Reserveringen bekijken            ");
            Console.WriteLine("                                               [2] Reserveringen wijzigen            ");
            Console.WriteLine("                                               [3] Reserveringen annuleren\n            ");
            Console.WriteLine("                                               [0] Terug           ");
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0 && gebruiker == "personeel")
            {
                personeelMain(gebruikerNaam);
            }
            if (ckey.Key == ConsoleKey.D0 && gebruiker == "admin")
            {
                Admin.adminMain();
            }
            if (ckey.Key == ConsoleKey.D0)
            {
                personeelMain(gebruikerNaam);
            }
            if (ckey.Key == ConsoleKey.D1 && gebruiker == "personeel")
            {
                Reserveringen.bekijkReservering(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                Reserveringen.bekijkReservering("admin");
            }
            if (ckey.Key == ConsoleKey.D2 && gebruiker == "personeel")
            {
                Reserveringen.WijzigReservering("personeel");
            }
            if (ckey.Key == ConsoleKey.D2 && gebruiker == "admin")
            {
                Reserveringen.WijzigReservering("admin");
            }
            else if (ckey.Key == ConsoleKey.D3 && gebruiker == "personeel")
            {
                Reserveringen.verwijderReservering(gebruikerNaam, "personeel");
            }
            else if (ckey.Key == ConsoleKey.D3 && gebruiker == "admin")
            {
                Reserveringen.verwijderReservering(gebruikerNaam, "admin");
            }
        }
        public static void persoonlijkeInfo(string gebruikerNaam)
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                           |Persoonlijke gegevens| \n");

            string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

            var JsonData = File.ReadAllText(MedewerkerPath);
            var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();


            foreach (MedewerkerINFO person in MedewerkersList)
            {
                if (gebruikerNaam == person.naam)
                    Console.WriteLine($"                                             Name: {person.naam}\n                                             Voornaamwoorden: {person.pronouns}\n                                             Telefoonnummer: {person.telefoonnummer}\n                                             E-Mail: {person.eMail}\n                                             Functie: {person.functie}\n                                             Gebruikersnaam: {person.gebruikersnaam}\n\n");
            }
            Console.WriteLine("                                             [1] Doorgaan");
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo doorgaan = Console.ReadKey();
            if (doorgaan.Key == ConsoleKey.D1)
            {
                personeelMain(gebruikerNaam);
            }



        }

        public static void menuMain(string gebruikerNaam, string gebruiker)
        {
            Console.Clear();
            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                                |Menu menu| ");
            Console.WriteLine("                                               [1] Bekijk menu           ");
            Console.WriteLine("                                               [2] Aanpassen menu           ");
            Console.WriteLine("                                               [0] Terug            ");
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0 && gebruiker == "personeel")
            {

                personeelMain(gebruikerNaam);
            }

            else if (ckey.Key == ConsoleKey.D0 && gebruiker == "admin")
            {

                Admin.adminMain();
            }
            else if (ckey.Key == ConsoleKey.D1 && gebruiker == "personeel")
            {
                getMenu.gettingMenu(gebruikerNaam, "personeel");
            }
            else if (ckey.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                getMenu.gettingMenu(gebruikerNaam, "admin");
            }
            else if (ckey.Key == ConsoleKey.D2 && gebruiker == "personeel")
            {
                MenuAanpassen.mainAanpassen(gebruikerNaam, "personeel");
            }
            else if (ckey.Key == ConsoleKey.D2 && gebruiker == "admin")
            {
                MenuAanpassen.mainAanpassen(gebruikerNaam, "admin");
            }
        }
        public static void bestellingenMain(string gebruikerNaam)
        {
            Console.Clear();
            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                                |Bestellingen| \n");
            Console.WriteLine("                                               [1] Bestelling bedrag weergeven        ");
            Console.WriteLine("                                               [2] Totaal Bestelling bedrag aanpassen        ");
            Console.WriteLine("                                               [3] Bestelling toevoegen \n         ");
            Console.WriteLine("                                               [0] Terug            ");
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.D0)
            {
                personeelMain(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D1)
            {
                bestellingenWeergeven(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                bestellingenAanpassen(gebruikerNaam);
            }
            else if (ckey.Key == ConsoleKey.D3)
            {
                bestellingenToevoegen(gebruikerNaam);
            }

        }
        public static void bestellingenAanpassen(string gebruikerNaam)
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

            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                          |Bestelling aanpassen| \n");
            Console.WriteLine("                                          Volledige naam: ");
            Console.CursorLeft = Console.WindowWidth / 2;
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
                Console.WriteLine($"\n                                          Een reservering onder de naam '{zoekNaam}' bestaat niet. \n                                          [1] Probeer opnieuw.\n                                          [0] Terug\n");

                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenAanpassen(gebruikerNaam);
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain(gebruikerNaam);
                }
            }
            double reserveringsPrijs = 0.00;
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsPrijs = reservering.Prijs;
                    Console.WriteLine("\n                                          Huidige bedrag onder deze naam is: " + reserveringsPrijs + " euro");
                }
            }
            Console.WriteLine("                                          Voer het nieuwe bedrag in: ");
            Console.CursorLeft = Console.WindowWidth / 2;
            double nieuwBedrag = Convert.ToDouble(Console.ReadLine());

            while (i < len)
            {
                if (ReserveringenList[i].Naam == zoekNaam)
                {
                    ReserveringenList[i].Prijs = nieuwBedrag;
                    Console.WriteLine($"\n                                          Het bedrag is aangepast naar " + nieuwBedrag + " euro");
                    Console.WriteLine("                                          [1] Doorgaan\n");
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        JsonData = JsonConvert.SerializeObject(ReserveringenList);
                        System.IO.File.WriteAllText(ReserveringPath, JsonData);
                        bestellingenMain(gebruikerNaam);
                    }
                    break;
                }
                i++;
            }


        }
        public static void bestellingenToevoegen(string gebruikerNaam)
        {
            Console.Clear();
            string omzetPath = Path.GetFullPath(@"Omzet.json"); // find path to file
            bool fileExist1 = File.Exists(omzetPath); // checks if the file exists, if so does nothing, else creates it
            if (!fileExist1)
            {
                using (File.Create(omzetPath)) ;
            }
            var JsonData1 = File.ReadAllText(omzetPath);
            var OmzetList = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData1) ?? new List<OmzetDag>();

            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();


            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                          |Bestelling Toevoegen| \n");

            Console.WriteLine("                                          Volledige naam: ");
            Console.CursorLeft = Console.WindowWidth / 2;
            string zoekNaam = Console.ReadLine();

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
                Console.WriteLine($"\n                                          Een reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug\n");
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenToevoegen(gebruikerNaam);
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain(gebruikerNaam);
                }
            }
            double reserveringsPrijs = 0.00;
            // Console.WriteLine("Voer de datum in: (D-M-JJJJ)");
            // string inputDatum = Console.ReadLine();
            DateTime thisDay = DateTime.Today;
            string inputDatum = thisDay.ToString("d"); //hieruit krijg  je bijv. "5/3/2022"
            Console.WriteLine("                                          Voer het bedrag in dat u wil toevoegen: ");
            Console.CursorLeft = Console.WindowWidth / 2;
            double toevoegBedrag = Convert.ToDouble(Console.ReadLine());
            double nieuwBedrag = toevoegBedrag + reserveringsPrijs;

            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reservering.Prijs = reservering.Prijs + nieuwBedrag;
                }
            }
            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);


            string datum = "";
            foreach (OmzetDag dagJson in OmzetList)
            {
                if (dagJson.Datum == inputDatum)
                {
                    datum = dagJson.Datum;
                }
            }
            if (datum == "")
            {
                OmzetList.Add(new OmzetDag()
                {
                    Datum = inputDatum,
                    Omzet = 0.00

                });
                JsonData1 = JsonConvert.SerializeObject(OmzetList);
                System.IO.File.WriteAllText(omzetPath, JsonData1);
            }

            var JsonData3 = File.ReadAllText(omzetPath);
            var OmzetList2 = JsonConvert.DeserializeObject<List<OmzetDag>>(JsonData3) ?? new List<OmzetDag>();

            int length = OmzetList2.Count;
            int y = 0;



            while (y < length)
            {

                if (OmzetList2[y].Datum == inputDatum)
                {
                    OmzetList2[y].Omzet = OmzetList2[y].Omzet + nieuwBedrag;
                    Console.WriteLine($"\n                                          De omzet op " + inputDatum + " is verhoogd met " + nieuwBedrag + " euro");
                    Console.WriteLine($"                                          [1] Reservering van {zoekNaam} verwijderen\n                                          [2] Doorgaan zonder te verwijderen");
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D2)
                    {
                        JsonData3 = JsonConvert.SerializeObject(OmzetList2);
                        System.IO.File.WriteAllText(omzetPath, JsonData3);
                        bestellingenMain(gebruikerNaam);
                    }
                    else if (keus.Key == ConsoleKey.D1)
                    {
                        int i = 0;
                        int len = ReserveringenList.Count;
                        while (i < len)
                        {
                            if (ReserveringenList[i].Naam == zoekNaam)
                            {
                                ReserveringenList.RemoveAt(i);
                                Console.Clear();

                                Console.WriteLine($"                                          De reservering onder de naam, '{zoekNaam}', is verwijderd");
                                JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                System.IO.File.WriteAllText(ReserveringPath, JsonData);

                                Console.WriteLine("\n                                          [1] Doorgaan");
                                Console.CursorLeft = Console.WindowWidth / 2;
                                ConsoleKeyInfo keus2 = Console.ReadKey();
                                if (keus2.Key == ConsoleKey.D1)
                                {
                                    bestellingenMain(gebruikerNaam);
                                }

                                break;
                            }
                            i++;

                        }
                    }
                }
                y++;
            }
        }


        public static void bestellingenWeergeven(string gebruikerNaam)
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

            Console.WriteLine("                                               ┌─────────────┐            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $$$$$ $     │            ");
            Console.WriteLine("                                               │ $   $ $     │            ");
            Console.WriteLine("                                               │ $   $ $$$$$ │            ");
            Console.WriteLine("                                               └─────────────┘            \n");
            Console.WriteLine($"                                          |Bestelling weergeven| \n");
            Console.WriteLine("                                          Volledige naam: ");
            Console.CursorLeft = Console.WindowWidth / 2;
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
                Console.WriteLine($"\n                                          Een reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug\n");
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bestellingenWeergeven(gebruikerNaam);
                }
                else if (rkey.Key == ConsoleKey.D0)
                {
                    bestellingenMain(gebruikerNaam);
                }
            }
            double reserveringsPrijs = 0.00;
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringsPrijs = reservering.Prijs;
                    Console.WriteLine("\n                                          Huidige bedrag onder deze naam is: " + reserveringsPrijs + " euro");
                    Console.WriteLine("\n                                          [1] Opnieuw een bedrag bekijken\n                                          [0] Terug naar menu");
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        bestellingenWeergeven(gebruikerNaam);
                    }
                    else if (keus.Key == ConsoleKey.D0)
                    {
                        bestellingenMain(gebruikerNaam);
                    }
                }
            }
        }

    }
}