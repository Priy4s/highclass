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
            _ = Console.ReadKey();
            Console.SetCursorPosition(0, Console.CursorTop);
            ClearCurrentConsoleLine();
            string functieIN = "";
            if (ckey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
            {
                pronounsIN = "hij/hem";
            }
            else if (ckey.Key == ConsoleKey.D2)
            {
                pronounsIN = "zij/haar";
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
            Console.WriteLine("Opgeslagen!");
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
            Console.WriteLine("╒════════════════════╕");
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

            foreach (MedewerkerINFO accountList in MederwerkerList)
            {
                if (gebruikersnaamCheck == accountList.gebruikersnaam)
                {
                    if (wachtwoordCheck == accountList.wachtwoord)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("    Ingelogd");
                        Console.WriteLine("[0] Terug");
                        Console.WriteLine("╘════════════════════╛");

                        ConsoleKeyInfo terug = Console.ReadKey();
                        if (ConsoleKey.D0 == terug.Key)
                        {
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("   Fout Wachtwoord");
                        Console.WriteLine("   [0] Terug ");
                        Console.WriteLine("╘════════════════════╛");
                        ConsoleKeyInfo terug = Console.ReadKey();
                        if (ConsoleKey.D0 == terug.Key)
                        {
                            Console.WriteLine("hallo");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("   Fout gebruikersnaam");
                    Console.WriteLine("[0] Terug");
                    Console.WriteLine("╘════════════════════╛");
                    ConsoleKeyInfo terug = Console.ReadKey();
                    if (ConsoleKey.D0 == terug.Key)
                    {
                        Console.WriteLine("hallo");
                    }
                }
            }
            Console.WriteLine("Er is een fout ontstaan. ");
            Console.WriteLine("Ga terug en probeer opnieuw in te loggen ");
            Console.WriteLine("[0] Terug ");
            Console.WriteLine("╘═══════════════════════════════╛");
            ConsoleKeyInfo hallo = Console.ReadKey();
            if (ConsoleKey.D0 == hallo.Key)
            {
                Console.WriteLine("hallo");
            }
        }
        public static void Aanmelden()
        {
            Console.Clear();
            string gebruikersnaam; string wachtwoord;
            Console.WriteLine("╒═══════════════════════════════╕");
            Console.WriteLine("HC   ");
            Console.WriteLine("Gebruikersnaam: ");
            gebruikersnaam = Console.ReadLine();
            Globals.gebruikersnamen.Add(gebruikersnaam); // Voegt de ingevulde gebruikersnaam toe aan de lijst 
            Console.WriteLine("Wachtwoord: ");
            wachtwoord = Console.ReadLine();
            Globals.wachtwoorden.Add(wachtwoord); // Voegt het ingevulde wachtwoord toe aan de lijst op dezelfde plek als de gebruikersnaam (maar in een andere lijst).
            Console.WriteLine("╘═══════════════════════════════╛");
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Account is succesvol aangemaakt.\n\nKlik op 'Enter' om in te loggen.");
                ConsoleKeyInfo done = Console.ReadKey();
                Console.WriteLine("╘═══════════════════════════════╛");
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Inloggen();
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
            string doen = "[1] Inloggen\n[2] Aanmelden\n[3] Uitloggen";
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
            else if (Globals.ingelogd == true && (cakey.Key == ConsoleKey.D3))
            {
                Globals.ingelogd = Uitloggen();
            }
        }
    }
}
