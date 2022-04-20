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

    public class Reservering
    {
        public static void AddReserveringen()
        {
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json"); // find path to file
            bool fileExist = File.Exists(ReserveringPath); // checks if the file exists, if so does nothing, else creates it
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
                Console.WriteLine("it exists now");
            }

            var JsonData = File.ReadAllText(ReserveringPath); // file can be found in the bin => just keep clicking until you find all extra files
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            Console.WriteLine("Volledige naam: ");
            string naamIN = Console.ReadLine();
            Console.WriteLine("Wat zijn uw persoonlijke voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
            ConsoleKeyInfo ckey = Console.ReadKey();
            // Console.SetCursorPosition(0, Console.CursorTop);
            // ClearCurrentConsoleLine();
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
            Console.WriteLine("Aantal personen: ");
            int aantalIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Datum van reservering: ");
            string datumIN = Console.ReadLine();
            Console.WriteLine("Starttijd van reservering: ");
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
            Console.WriteLine("Opgeslagen!");
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
