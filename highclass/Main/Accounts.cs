using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Main
{
    public class MedewerkerINFO
    {
        public string naam { get; set; }
        public string pronouns { get; set; }
        public string telefoonnummer { get; set; }
        public string eMail { get; set; }
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
    }
    public class Medewerkers
    {
        public static void AddMederwerker()
        {

            string medewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to file
            bool fileExist = File.Exists(medewerkerPath); // checks if the file exists, if so does nothing, else creates it
            if (!fileExist)
            {
                using (File.Create(medewerkerPath)) ;
                Console.WriteLine("it exists now");
            }
            var JsonData = File.ReadAllText(medewerkerPath); // file can be found in the bin => just keep clicking until you find all extra files
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

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
            Console.WriteLine("Voer uw gebruikers naam in:");
            string gebruikersnaamIN = Console.ReadLine();
            Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoordIN = Console.ReadLine();

            MederwerkerList.Add(new MedewerkerINFO()
            {
                naam = naamIN,
                pronouns = pronounsIN,
                telefoonnummer = telefoonnummerIN,
                eMail = eMailIN,
                gebruikersnaam = gebruikersnaamIN,
                wachtwoord = wachtwoordIN
            });

            JsonData = JsonConvert.SerializeObject(MederwerkerList);
            System.IO.File.WriteAllText(medewerkerPath, JsonData);
            Console.WriteLine("Opgeslagen!");
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    public static bool Inloggen()
        {
            return true;
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
                AddMederwerker();
            }
            else if (Globals.ingelogd == true && (cakey.Key == ConsoleKey.D3))
            {
                Globals.ingelogd = Uitloggen();
            }
        }
    }
}