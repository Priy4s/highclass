using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main // Namespace moet dezelfde naam hebben, anders kan je de code niet gebruiken (error).
{
    public class Reserveringen
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
                    "\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
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
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
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

            Console.WriteLine("Zijn er meer of minder stoelen vrijgekomen?");
            string meerofminder = "[1] Meer\n[2] Minder";
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
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}