using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Main // Namespace moet dezelfde naam hebben, anders kan je de code niet gebruiken (error).
{
    public class Reserveringenjson
    {
        public string Naam { get; set; }
        public string Voornaamwoorden { get; set; }
        public int Groepsgrote { get; set; }
        public string Starttijd { get; set; }
        public string Datum { get; set; }
        public double Prijs { get; set; }
    }

    public class Reserveringen
    {
        public static void AddReservering()
        {
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json"); 
            bool fileExist = File.Exists(ReserveringPath); 
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }

            var JsonData = File.ReadAllText(ReserveringPath); 
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            Console.Clear();
            Console.WriteLine("╒═════════════════════════════════════════════════════╕");
            Console.WriteLine(" HC\n");
            Console.WriteLine("Volledige naam: ");
            string naamIN = Console.ReadLine();
            Console.WriteLine("\nWat zijn uw persoonlijke voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
            ConsoleKeyInfo ckey = Console.ReadKey();
            // Console.SetCursorPosition(0, Console.CursorTop);
            // ClearCurrentConsoleLine();
            string pronounsIN = "";
            if (ckey.Key == ConsoleKey.D1) 
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
            Console.WriteLine("\n\nGroepsgrote: ");
            int aantalIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDatum van reservering (vb. 04-05-2022): ");
            string datumIN = Console.ReadLine();
            Console.WriteLine("\nStarttijd van reservering: ");
            string tijdIN = Console.ReadLine();

            ReserveringenList.Add(new Reserveringenjson()
            {
                Naam = naamIN,
                Voornaamwoorden = pronounsIN,
                Groepsgrote = aantalIN,
                Datum = datumIN,
                Starttijd = tijdIN,
                Prijs = 0.00
            });
            
            Dictionary<string, int> dagen = new Dictionary<string, int>();
            bool keyexists = dagen.ContainsKey(datumIN);
            if (!keyexists)
            {
                dagen.Add(datumIN, 200 - aantalIN);
                if (dagen[datumIN] > 200)
                {
                    Console.WriteLine("U kunt geen reservering voor meer dan 200 personen maken.\n");
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                }
                else
                {
                    JsonData = JsonConvert.SerializeObject(ReserveringenList);
                    System.IO.File.WriteAllText(ReserveringPath, JsonData);
                    Console.WriteLine("\nUw reservering is succesvol opgeslagen.\n");
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                }
            }
            else
            {
                dagen[datumIN] = dagen[datumIN] - aantalIN;
                if (dagen[datumIN] < 0)
                {
                    Console.WriteLine($"Er zijn niet genoeg plekken beschikbaar op {datumIN} voor een reservering voor {aantalIN} personen.\n")
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                }
                else
                {
                    JsonData = JsonConvert.SerializeObject(ReserveringenList);
                    System.IO.File.WriteAllText(ReserveringPath, JsonData);
                    Console.WriteLine("\nUw reservering is succesvol opgeslagen.\n");
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                }
            }

            Console.WriteLine("\nUw reservering is succesvol opgeslagen.");

            Console.WriteLine("╘═════════════════════════════════════════════════════╛");

            Globals.available_seats -= aantalIN;
            Globals.taken_seats += aantalIN;
        }

        public static void WijzigReservering()
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
                Console.WriteLine($"\nEen reservering onder de naam '{zoekNaam}' bestaat niet. \n[1] Probeer opnieuw.\n[2] Maak nieuwe reservering aan.\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    WijzigReservering();
                }
                else if (rkey.Key == ConsoleKey.D2)
                {
                    AddReservering();
                }
            }
            Console.WriteLine("\nWat wilt u wijzigen? \n\t[1] Naam\n\t[2] Persoonlijk voornaamwoorden\n\t[3] Groepsgrote\n\t[4] Datum\n\t[5] Starttijd\n");
            Console.WriteLine("╘════════════════════════════════════════════════════════╛");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("╒══════════════════════════════════════════════════════════════════════════════════════════════╕");
                Console.WriteLine(" HC\n");
                Console.WriteLine("Nieuwe volledige naam: ");
                string new_naam = Console.ReadLine();

                while (i < len)
                {
                    Console.WriteLine(ReserveringenList[i].Naam);
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList[i].Naam = new_naam;
                        Console.WriteLine($"\n\nDe naam waaronder de reservering is opgeslagen is gewijzigd naar: {new_naam}\n");
                        Console.WriteLine("[1] Doorgaan\n");
                        Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════════════════════════╛");
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            Program.Main();
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("╒══════════════════════════════════════════════════════════════════════════╕");
                Console.WriteLine(" HC\n");
                Console.WriteLine("Nieuwe persoonlijk voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
                ConsoleKeyInfo AKey = Console.ReadKey();
                string pronounsIN = "";
                if (AKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                {
                    pronounsIN = "hij/hem";
                }
                else if (AKey.Key == ConsoleKey.D2)
                {
                    pronounsIN = "zij/haar";
                }
                else if (AKey.Key == ConsoleKey.D3)
                {
                    pronounsIN = "hen/hun";
                }

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList[i].Voornaamwoorden = pronounsIN;
                        Console.WriteLine($"\n\nUw persoonlijk voornaamwoorden zijn gewijzigd naar: {pronounsIN}\n");
                        Console.WriteLine("[1] Doorgaan\n");
                        Console.WriteLine("╘══════════════════════════════════════════════════════════════════════════╛");
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            Program.Main();
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Console.WriteLine("╒══════════════════════════════════════════════════════════════╕");
                Console.WriteLine(" HC\n");
                Console.WriteLine("Nieuwe groepsgrote: ");
                int new_groepsgrote = Convert.ToInt32(Console.ReadLine());

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList[i].Groepsgrote = new_groepsgrote;
                        Console.WriteLine($"\n\nDe groepsgrote van uw reservering is gewijzigd naar: {new_groepsgrote}\n");
                        Console.WriteLine("[1] Doorgaan\n");
                        Console.WriteLine("╘══════════════════════════════════════════════════════════════╛");
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            Program.Main();
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D4)
            {
                Console.Clear();
                Console.WriteLine("╒════════════════════════════════════════════════════════════════╕");
                Console.WriteLine(" HC\n");
                Console.WriteLine("Nieuwe datum: ");
                string new_Datum = Console.ReadLine();

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList[i].Datum = new_Datum;
                        Console.WriteLine($"De datum van uw reservering is gewijzigd naar: {new_Datum}\n");
                        Console.WriteLine("[1] Doorgaan\n");
                        Console.WriteLine("╘════════════════════════════════════════════════════════════════╛");
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            Program.Main();
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D5)
            {
                Console.Clear();
                Console.WriteLine("╒════════════════════════════════════════════════════════════════╕");
                Console.WriteLine(" HC\n");
                Console.WriteLine("Nieuwe starttijd: ");
                string new_Tijd = Console.ReadLine();

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList[i].Starttijd = new_Tijd;
                        Console.WriteLine($"De starttijd van uw reservering is gewijzigd naar: {new_Tijd}\n");
                        Console.WriteLine("[1] Doorgaan\n");
                        Console.WriteLine("╘════════════════════════════════════════════════════════════════╛");
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            Program.Main();
                        }
                        break;
                    }
                    i++;
                }
            }
        }
        public static void verwijderReservering()
        {
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }

            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();
            
            Console.Clear();
            Console.WriteLine("╒════════════════════════════════════════════════════════════════════════════════════════╕");
            Console.WriteLine(" HC\n");
            Console.WriteLine("Volledige naam: ");
            string zoekNaam = Console.ReadLine();

            int len = ReserveringenList.Count;
            int i = 0;
            int count = 0;
            string reserveringNaam = "";
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    reserveringNaam = reservering.Naam;
                }
            }
            if (reserveringNaam == "")
            {
                Console.WriteLine("\nEen reservering onder de gegeven naam bestaat niet. \n[1] Probeer opnieuw.\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    verwijderReservering();
                }
            }

            Console.WriteLine($"\nWeet u zeker dat u de reservering onder de naam, '{reserveringNaam}', wilt verwijderen?");
            Console.WriteLine("[1]Ja\n[2]Nee\n");
            Console.WriteLine("╘════════════════════════════════════════════════════════════════════════════════════════╛");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        ReserveringenList.RemoveAt(i);
                        Console.Clear();
                        Console.WriteLine("╒════════════════════════════════════════════════════════════════════════════╕");
                        Console.WriteLine(" HC\n");
                        Console.WriteLine($"De reservering onder de naam, '{zoekNaam}', is verwijderd");

                        count++;
                        break;
                    }
                    i++;
                }

            }
            /* else
            {
                Admin.adminMain();
            }*/

            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);

            Console.WriteLine("\n [1] Doorgaan");
            Console.WriteLine("╘════════════════════════════════════════════════════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Program.Main();
            }
        }
    }


    public class Reserveringenoud
    {
        public static void Reserveren()
        {
            Console.Clear();

            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine(); // De input van de gebruiker wordt toegevoegd aan de variabel.

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();
            string naam = voornaam + achternaam; // Naam van reservering (komt later terug)

            Console.WriteLine("\nEr zijn nog " + Globals.available_seats + " plekken beschikbaar.");
            int aantal;
            Console.WriteLine("Aantal personen: ");
            aantal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Starttijd reservering: ");
            string tijd;
            tijd = Console.ReadLine();
            Globals.reservering_personen.Add(naam, aantal); // Dictionary met de naam van de reservering als key en de value is het aantal personen.
            Globals.reservering_tijd.Add(naam, tijd); // Dictionary met de naam van de reservering als key en de value het tijdstip.
            Globals.available_seats -= aantal;
            Globals.taken_seats += aantal;
            //JsonConvert.SerializeObject(Globals.reservering_personen);
            //JsonConvert.SerializeObject(Globals.reservering_tijd);
            Console.Clear();
            while (true) // Deze while-loop zorgt ervoor dat de tekst in de console blijft staan, totdat de gebruiker op 'Enter' klikt.
            {
                Console.WriteLine("Uw reservering is succesvol opgeslagen.");
                Console.WriteLine("U heeft nu een reservering voor " + aantal + " personen om " + tijd + ".\n" +
                    "\nKlik op 'Enter' om terug te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void Wijzigen()
        {
            Console.Clear();
            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine();

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();

            string naam = voornaam + achternaam;

            Console.Clear();
            Console.WriteLine("Wilt u de tijd of het aantal personen wijzigen?");
            string vraag = "[1] Tijd\n[2] Aantal personen";
            Console.WriteLine(vraag);
            ConsoleKeyInfo cwkey = Console.ReadKey();

            if (cwkey.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Er zijn nog " + Globals.available_seats + " plekken beschikbaar.");
                Console.WriteLine("Nieuw aantal personen: ");
                int wijziging = Convert.ToInt32(Console.ReadLine());
                Globals.available_seats += Globals.reservering_personen[naam]; // Globals.reservering_personen[naam] zoekt naar de value die bj de key "naam" hoort.
                Globals.taken_seats -= Globals.reservering_personen[naam];
                Globals.available_seats -= wijziging;
                Globals.taken_seats += wijziging;
                Globals.reservering_personen[naam] = wijziging; // Verandert de value die bij de key "naam" hoort.
            }
            else if (cwkey.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Nieuwe tijd: ");
                string wijziging = Console.ReadLine();
                Globals.reservering_tijd[naam] = wijziging;
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nUw reservering is succesvol gewijzigd.");
                Console.WriteLine("U heeft nu een reservering voor " + Globals.reservering_personen[naam] + " personen om " + Globals.reservering_tijd[naam] + ".\n\n");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void Annuleren()
        {
            Console.Clear();
            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine();

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();

            string naam = voornaam + achternaam;

            Globals.available_seats += Globals.reservering_personen[naam];
            Globals.taken_seats -= Globals.reservering_personen[naam];
            Globals.reservering_personen.Remove(naam); // Verwijdert de key (+ value) die bij "naam" hoort.
            Globals.reservering_tijd.Remove(naam);

            while (true)
            {
                Console.WriteLine("\nUw reservering is succesvol geannuleerd.");
                Console.WriteLine("Er zijn nu " + Globals.available_seats + " plekken beschikbaar.");
                Console.WriteLine("\nKlik op 'Enter' om terug te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void Plekken()
        {
            Console.Clear();
            Console.WriteLine("Er zijn " + Globals.available_seats + " plekken beschikbaar.");

            Console.WriteLine("Zijn er meer of minder stoelen beschikbaar?");
            string meerofminder = "[1] Meer beschikbare stoelen\n[2] Minder beschikbare stoelen";
            Console.WriteLine(meerofminder);
            ConsoleKeyInfo cpkey = Console.ReadKey();
            Console.WriteLine("\n\nMet hoeveel?");
            int wijziging = Convert.ToInt32(Console.ReadLine());

            if (cpkey.Key == ConsoleKey.D2)
            {
                Globals.taken_seats += wijziging;
                Globals.available_seats -= wijziging;
            }
            else if (cpkey.Key == ConsoleKey.D1)
            {
                Globals.taken_seats -= wijziging;
                Globals.available_seats += wijziging;
            }
            while (true)
            {
                Console.WriteLine($"Er zijn nu {Globals.available_seats} plekken beschikbaar.");
                Console.WriteLine("\nKlik op 'Enter' om terug te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
