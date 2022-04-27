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
        public int Groepsgrootte { get; set; }
        public string Starttijd { get; set; }
        public string Datum { get; set; }
    }

    public class Reserveringen
    {
        public static void AddReserveringen()
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
            Console.WriteLine("\n\nAantal personen: ");
            int aantalIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDatum van reservering: ");
            string datumIN = Console.ReadLine();
            Console.WriteLine("\nStarttijd van reservering: ");
            string tijdIN = Console.ReadLine();

            ReserveringenList.Add(new Reserveringenjson()
            {
                Naam = naamIN,
                Voornaamwoorden = pronounsIN,
                Groepsgrootte = aantalIN,
                Datum = datumIN,
                Starttijd = tijdIN
            });

            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);
            Console.WriteLine("\nUw reservering is succesvol opgeslagen.");
            Console.WriteLine("╘═════════════════════════════════════════════════════╛");

            Globals.available_seats -= aantalIN;
            Globals.taken_seats += aantalIN;
        }

        public static void WijzigReservering() //NIET GOED
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
            Console.WriteLine("╒════════════════════════════════════════════════════════════════════════╕");
            Console.WriteLine(" Volledige naam:");
            string naam = Console.ReadLine();
            Console.WriteLine(" Wilt u de datum of het aantal personen van uw reservering wijzigen?");
            string vraag = " [1] Datum\n [2] Aantal personen";
            Console.WriteLine(vraag);
            ConsoleKeyInfo cwkey = Console.ReadKey();

            if (cwkey.Key == ConsoleKey.D2)
            {
                Console.WriteLine(" Nieuw aantal personen: ");
                int wijzigingen = Convert.ToInt32(Console.ReadLine());
                foreach (Reserveringenjson welkenaam in ReserveringenList)
                {
                    if (welkenaam.Naam == naam)
                    {
                        Globals.available_seats += welkenaam.Groepsgrootte;
                        Globals.taken_seats -= welkenaam.Groepsgrootte;
                        welkenaam.Groepsgrootte = wijzigingen;
                        Globals.available_seats -= welkenaam.Groepsgrootte;
                        Globals.taken_seats += welkenaam.Groepsgrootte;

                        while (true)
                        {
                            Console.WriteLine("\n Uw reservering is succesvol gewijzigd.");
                            Console.WriteLine($" U heeft nu een reservering voor {welkenaam.Groepsgrootte} personen.\n\n");
                            Console.WriteLine("\n Klik op 'Enter' om verder te gaan naar het hoofdmenu.");
                            Console.WriteLine("╘════════════════════════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo done = Console.ReadKey();
                            if (done.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    }
                }
                Console.Clear();
            }
            else if (cwkey.Key == ConsoleKey.D1)
            {
                Console.WriteLine(" Nieuwe Datum: ");
                string wijziging = Console.ReadLine();
                Console.WriteLine(" Starttijd: ");
                string tijdwijziging = Console.ReadLine();

                foreach (Reserveringenjson welkenaam in ReserveringenList)
                {
                    if (welkenaam.Naam == naam)
                    {
                        welkenaam.Datum = wijziging;
                        welkenaam.Starttijd = tijdwijziging;

                        while (true)
                        {
                            Console.WriteLine("\n Uw reservering is succesvol gewijzigd.");
                            Console.WriteLine($" U heeft nu een reservering op {welkenaam.Datum} om {welkenaam.Starttijd}.\n\n");
                            Console.WriteLine("\n Klik op 'Enter' om verder te gaan naar het hoofdmenu.");
                            Console.WriteLine("╘════════════════════════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo done = Console.ReadKey();
                            if (done.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    }

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
                Console.WriteLine("\nEen reservering onder de gegeven naam bestaat niet. \n[1] Probeer opnieuw.");
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
