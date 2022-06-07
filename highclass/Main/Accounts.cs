using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Main.Admin;
using System.Text.RegularExpressions;

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
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘            ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                      |Aanmelden|");
            Console.WriteLine(" ");
            string medewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to file
            bool fileExist = File.Exists(medewerkerPath); // checks if the file exists, if so does nothing, else creates it
            if (!fileExist)
            {
                using (File.Create(medewerkerPath)) ;
            }
            var JsonData = File.ReadAllText(medewerkerPath); // file can be found in the bin => just keep clicking until you find all extra files
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

            Console.WriteLine("                                                Wat is uw voornaam naam?");
            Console.CursorLeft = Console.WindowWidth / 2;
            string naamIN = Console.ReadLine();
            bool IsAlleenLetters = char.IsLetter(naamIN, 0);
            bool isSpace = char.IsWhiteSpace(naamIN, 0);
            for (int i = 0; i < naamIN.Length; i++)
            {
                IsAlleenLetters = char.IsLetter(naamIN, i);
                if (IsAlleenLetters == false)
                {
                    isSpace = char.IsWhiteSpace(naamIN, i);
                    if (isSpace == false)
                    {
                        break;
                    }
                }
            }

            while (!IsAlleenLetters || !isSpace)
            {
                Console.WriteLine("                                     Naam kan alleen uit letter bestaan probeer opnieuw.");
                Console.WriteLine("                                                Wat is uw voornaam naam?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                naamIN = Console.ReadLine();
                for (int i = 0; i < naamIN.Length; i++)
                {
                    IsAlleenLetters = char.IsLetter(naamIN, i);
                    if (IsAlleenLetters == false)
                    {
                        isSpace = char.IsWhiteSpace(naamIN, i);
                        if (isSpace == false)
                        {
                            break;
                        }
                    }
                }
            }
            string pronounsIN = "";
            Console.WriteLine("                                               Wat zijn uw voornaamwoorden?");
            Console.WriteLine("                                                       [1] hij/hem");
            Console.WriteLine("                                                       [2] zij/haar");
            Console.WriteLine("                                                       [3] die/hen");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo ckey = Console.ReadKey();
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
                pronounsIN = "die/hen";
            }

            while (pronounsIN == "")
            {
                Console.WriteLine("\n                                                          Probeer opnieuw.");
                Console.WriteLine("                                                  Wat zijn uw voornaamwoorden?");
                Console.WriteLine("                                                       [1] hij/hem");
                Console.WriteLine("                                                       [2] zij/haar");
                Console.WriteLine("                                                       [3] die/hen");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ckey = Console.ReadKey();
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
                    pronounsIN = "die/hen";
                }
            }
            Console.WriteLine("\n                                                Wat is uw telefoonnummber?\n                                                     +31");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string telefoonnummerIN = Console.ReadLine();

            bool isAlleenNummers = char.IsDigit(telefoonnummerIN, 0);
            for (int i = 0; i < telefoonnummerIN.Length; i++)
            {
                isAlleenNummers = char.IsDigit(telefoonnummerIN, i);
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                if (isAlleenNummers == false)
                {
                    break;
                }
            }

            bool isLengte10 = telefoonnummerIN.Length != 10 ? true : false;
            while (isLengte10 || !isAlleenNummers)
            {
                Console.WriteLine("\n                                        Onjuist telefoonnummer. Probeer telefoonnummer opnieuw intevoeren");
                Console.WriteLine("\n                                                     Wat is uw telefoonnummber?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                telefoonnummerIN = Console.ReadLine();

                for (int i = 0; i < telefoonnummerIN.Length; i++)
                {
                    isAlleenNummers = char.IsDigit(telefoonnummerIN, i);
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    if (isAlleenNummers == false)
                    {
                        break;
                    }
                }
                isLengte10 = telefoonnummerIN.Length != 10 ? true : false;
            }
            Console.WriteLine("\n                                                     Wat is uw e-mail?");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string eMailIN = Console.ReadLine();
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValedMail = regex.IsMatch(eMailIN);
            while (!isValedMail)
            {
                Console.WriteLine("\n                                            Incoreccte email. Probeer opnieuw.");
                Console.WriteLine("\n                                                 Wat is uw e-mail?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                eMailIN = Console.ReadLine();
                regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                isValedMail = regex.IsMatch(eMailIN);
            }


            Console.WriteLine("                                                     Wat is uw functie?");
            Console.WriteLine("                                                         [1]Admin");
            Console.WriteLine("                                                         [2]Mederwerker");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo ABCKey = Console.ReadKey();
            string functieIN = "";
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            if (ABCKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
            {
                functieIN = "Admin";
            }
            else if (ABCKey.Key == ConsoleKey.D2)
            {
                functieIN = "Mederwerker";
            }
            else
            {
                while (functieIN == "")
                {
                    Console.WriteLine("\n                                                     Probeer opnieuw");
                    Console.WriteLine("                                                     Wat is uw functie?");
                    Console.WriteLine("                                                         [1]Admin");
                    Console.WriteLine("                                                         [2]Mederwerker");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    ABCKey = Console.ReadKey();
                    if (ABCKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                    {
                        functieIN = "Admin";
                    }
                    else if (ABCKey.Key == ConsoleKey.D2)
                    {
                        functieIN = "Mederwerker";
                    }
                }
            }


            Console.WriteLine("\n                                                      Voer uw gebruikersnaam in:");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string gebruikersnaamIN = Console.ReadLine();
            Console.WriteLine("                                                        Voer uw wachtwoord in:");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string wachtwoordIN = Console.ReadLine();

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

            Console.WriteLine($"                                             {functieIN} is met succes toegevoegd aan database.");
            Console.WriteLine("                                                         [1] doorgaan");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo doorKey = Console.ReadKey();
            if (doorKey.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
        }
        public static void verwijderMedewerker()
        {
            Console.Clear();
            string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

            var JsonData = File.ReadAllText(MedewerkerPath);
            var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘            ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                     |Verwijderen|          ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                            Wat is naam van de medewerker?      ");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string zoekNaam = Console.ReadLine();

            int len = MedewerkersList.Count;
            int i = 0;
            string medewerkerNaam = "";
            foreach (MedewerkerINFO person in MedewerkersList)
            {
                if (person.naam == zoekNaam)
                {
                    medewerkerNaam = person.naam;
                }
            }
            if (medewerkerNaam == "")
            {
                Console.WriteLine("                                        Medewerker met die naam bestaat niet.");
                Console.WriteLine("                                                     [1] Probeer opnieuw.");
                Console.WriteLine("                                                     [0] Terug");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    verwijderMedewerker();
                }
                else
                {
                    Admin.adminMedewerkers();
                }
            }

            Console.WriteLine("\n                                      Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
            Console.WriteLine("                                                       [1] Ja\n                                                       [2] Nee");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo readkey = Console.ReadKey();
            while (readkey.Key != ConsoleKey.D1 && readkey.Key != ConsoleKey.D2)
            {

                Console.WriteLine("\n                                      Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
                Console.WriteLine("                                                       [1] Ja\n                                                       [2] Nee");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                readkey = Console.ReadKey();
            }
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList.RemoveAt(i);
                        Console.WriteLine($"\n                                       Medewerker met naam: {zoekNaam} is verwijderd");
                        break;
                    }
                    i++;
                }

            }
            else if (readkey.Key == ConsoleKey.D2)
            {
                Admin.adminMedewerkers();
            }

            JsonData = JsonConvert.SerializeObject(MedewerkersList);
            System.IO.File.WriteAllText(MedewerkerPath, JsonData);

            Console.WriteLine("n                                                 Succesvol verwijderd!");
            Console.WriteLine("                                                       [1] Doorgaan");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
        }
        public static void wijzigMedewerkers()
        {
            Console.Clear();
            string MedewerkerPath = Path.GetFullPath(@"Medewerker.json"); // find path to files

            var JsonData = File.ReadAllText(MedewerkerPath);
            var MedewerkersList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();

            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘            ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                      |Wijzigen|          ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                            Wat is naam van de medewerker?");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string zoekNaam = Console.ReadLine();

            int len = MedewerkersList.Count;
            int i = 0;
            string medewerkerNaam = "";
            foreach (MedewerkerINFO person in MedewerkersList)
            {
                if (person.naam == zoekNaam)
                {
                    medewerkerNaam = person.naam;
                }
            }
            if (medewerkerNaam == "")
            {
                Console.WriteLine("                                            Medewerker met die naam bestaat niet. \n                                                 [1] Probeer opnieuw.");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    wijzigMedewerkers();
                }
                else
                {
                    wijzigMedewerkers();
                }
            }
            Console.WriteLine("                                                 Wat wil je wijzigen? \n                                                 [1] Naam\n                                                 [2] voornaamwoorden\n                                                 [3] telefoonnummer\n                                                 [4] eMail\n                                                 [5] functie\n                                                 [6] gebruikersnaam\n                                                 [7] wachtwoord\n");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\n                                         Wat wordt medewerkers nieuwe naam?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4; 
                string new_naam = Console.ReadLine();

                bool IsAlleenLetters = char.IsLetter(new_naam, 0);
                bool isSpace = char.IsWhiteSpace(new_naam, 0);
                for (int ii = 0; ii < new_naam.Length; ii++)
                {
                    IsAlleenLetters = char.IsLetter(new_naam, ii);
                    if (IsAlleenLetters == false)
                    {
                        isSpace = char.IsWhiteSpace(new_naam, ii);
                        if (isSpace == false)
                        {
                            break;
                        }
                    }
                }

                while (!IsAlleenLetters || !isSpace)
                {
                    Console.WriteLine("                                Naam kan alleen uit letter bestaan probeer opnieuw.");
                    Console.WriteLine("                                            Wat is uw volledige naam?");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    new_naam = Console.ReadLine();
                    for (int ii = 0; ii < new_naam.Length; ii++)
                    {
                        IsAlleenLetters = char.IsLetter(new_naam, ii);
                        if (IsAlleenLetters == false)
                        {
                            isSpace = char.IsWhiteSpace(new_naam, ii);
                            if (isSpace == false)
                            {
                                break;
                            }
                        }
                    }
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].naam = new_naam;
                        Console.WriteLine($"                                   Medewerkers naam is gewijzigd naar {new_naam}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\n                                                 Wat zijn uw voornaamwoorden?\n                                                 [1] hij/hem\n                                                 [2] zij/haar\n                                                 [3] die/hen");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
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
                    pronounsIN = "die/hen";
                }

                while (pronounsIN == "")
                {
                    Console.WriteLine("\n                                                 Probeer opnieuw");
                    Console.WriteLine("                                                 Wat zijn uw voornaamwoorden?\n                                                 [1] hij/hem\n                                                 [2] zij/haar\n                                                 [3] die/hen");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    AKey = Console.ReadKey();
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
                        pronounsIN = "die/hen";
                    }
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].pronouns = pronounsIN;
                        Console.WriteLine($"\n                                   Medewerkers naam is gewijzigd naar {pronounsIN}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D3)
            {
                Console.WriteLine("\n                                   Wat wordt medewerkers nieuwe telefoonnummer?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                string new_telefoonnummer = Console.ReadLine();

                bool isAlleenNummers = char.IsNumber(new_telefoonnummer, 0);
                for (int k = 0; k < new_telefoonnummer.Length; k++)
                {

                    isAlleenNummers = char.IsNumber(new_telefoonnummer, k);
                    if (isAlleenNummers == false)
                    {
                        break;
                    }
                }

                bool isLengte10 = new_telefoonnummer.Length != 10 ? true : false;
                while (isLengte10 || !isAlleenNummers)
                {
                    Console.WriteLine("                       Onjuist telefoonnummer. Probeer telefoonnummer opnieuw intevoeren");
                    Console.WriteLine("                                             Wat is uw telefoonnummber?");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    new_telefoonnummer = Console.ReadLine();

                    for (int k = 0; k < new_telefoonnummer.Length; k++)
                    {
                        isAlleenNummers = char.IsNumber(new_telefoonnummer, k);
                        if (isAlleenNummers == false)
                        {
                            break;
                        }
                    }
                    isLengte10 = new_telefoonnummer.Length != 10 ? true : false;
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].telefoonnummer = new_telefoonnummer;
                        Console.WriteLine($"                              Medewerkers telefoonnummer is gewijzigd naar {new_telefoonnummer}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D4)
            {
                Console.WriteLine("\n                                        Wat wordt medewerkers nieuwe eMail?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 8;
                string new_eMail = Console.ReadLine();

                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValedMail = regex.IsMatch(new_eMail);
                while (!isValedMail)
                {
                    Console.WriteLine("                                         Incoreccte email. Probeer opnieuw.");
                    Console.WriteLine("                                                Wat is uw e-mail?");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    new_eMail = Console.ReadLine();
                    regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    isValedMail = regex.IsMatch(new_eMail);
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].eMail = new_eMail;
                        Console.WriteLine($"                                   Medewerkers e-mail is gewijzigd naar {new_eMail}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D5)
            {
                Console.WriteLine("\n                                                 Wat is uw functie?\n                                                 [1]Admin\n                                                 [2]Mederwerker");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo BKey = Console.ReadKey();
                string new_functie = "";
                if (BKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                {
                    new_functie = "Admin";
                }
                else if (BKey.Key == ConsoleKey.D2)
                {
                    new_functie = "Mederwerker";
                }

                while (new_functie == "")
                {
                    Console.WriteLine("\n                                                 Probeer opnieuw");
                    Console.WriteLine("                                                 Wat is uw functie?\n                                                 [1]Admin\n                                                 [2]Mederwerker");
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    BKey = Console.ReadKey();
                    if (BKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                    {
                        new_functie = "Admin";
                    }
                    else if (BKey.Key == ConsoleKey.D2)
                    {
                        new_functie = "Mederwerker";
                    }
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].functie = new_functie;
                        Console.WriteLine($"\n                                   Medewerkers functie is gewijzigd naar {new_functie}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D6)
            {
                Console.WriteLine("\n                                    Wat wordt medewerkers nieuwe gebruikersnaam?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                string new_gebruikersnaam = Console.ReadLine();

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].gebruikersnaam = new_gebruikersnaam;
                        Console.WriteLine($"                                   Medewerkers gebruikersnaam is gewijzigd naar {new_gebruikersnaam}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D7)
            {
                Console.WriteLine("\n                                       Wat wordt medewerkers nieuwe wachtwoord?");
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                string new_wachtword = Console.ReadLine();

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].wachtwoord = new_wachtword;
                        Console.WriteLine($"                                   Medewerkers wachtwoord is gewijzigd naar {new_wachtword}");
                        break;
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\n                                                 Verkeerde input. \n                                                 Probeer opnieuw.");
                Console.WriteLine("                                                 [0] Opnieuw");

                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                ConsoleKeyInfo opnieuw = Console.ReadKey();
                if (opnieuw.Key == ConsoleKey.D0)
                {
                    wijzigMedewerkers();
                }
            }
            JsonData = JsonConvert.SerializeObject(MedewerkersList);
            System.IO.File.WriteAllText(MedewerkerPath, JsonData);

            Console.WriteLine("                                                 [1] Doorgaan");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
        }
        public static void Inloggen()
        {
            Console.Clear();
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘            ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                      |Inloggen|             ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                      [0] Terug       ");
            Console.WriteLine(" ");
            Console.WriteLine("                                                   Gebruikersnaam: ");
            Console.CursorLeft = (Console.WindowWidth / 2) - 4;
            string gebruikersnaamCheck = Console.ReadLine();

            if (gebruikersnaamCheck == "0")
            {
                Program.Main();
            }
            Console.WriteLine("                                                    Wachtwoord: ");
            Console.CursorLeft = (Console.WindowWidth / 2) - 5;
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
                    Console.WriteLine("                                                      Ingelogd");
                    Console.WriteLine("                                                    [1] Doorgaan");
                    count++;
                    ConsoleKeyInfo terug = Console.ReadKey();
                    if (ConsoleKey.D1 == terug.Key && accountList.functie == "personeel")
                    {
                        Personeelsleden.personeelMain(accountList.naam);
                    }
                    else if (ConsoleKey.D1 == terug.Key && accountList.functie == "admin")
                    {
                        Admin.adminMain();
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("                                ");
                Console.WriteLine("                                       Gebruikersnaam en of wachtwoord is verkeerd");
                Console.WriteLine("                                                   [1] Probeer opnieuw");
                Console.WriteLine("                                ");
                Console.WriteLine("                                                        [0] Terug            ");
                ConsoleKeyInfo begin = Console.ReadKey();
                if (ConsoleKey.D0 == begin.Key)
                {
                    Program.Main();
                }
                else if (ConsoleKey.D1 == begin.Key)
                {
                    Inloggen();
                }
            }
        }
        public static bool Uitloggen()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("                                               ┌─────────────┐            ");
                Console.WriteLine("                                               │ $   $ $$$$$ │            ");
                Console.WriteLine("                                               │ $   $ $     │            ");
                Console.WriteLine("                                               │ $$$$$ $     │            ");
                Console.WriteLine("                                               │ $   $ $     │            ");
                Console.WriteLine("                                               │ $   $ $$$$$ │            ");
                Console.WriteLine("                                               └─────────────┘            ");
                Console.WriteLine(" ");
                Console.WriteLine("                                                 |Uitloggen|             ");
                Console.WriteLine(" ");
                Console.WriteLine("                                       U bent succesvol uitgelogd.");
                Console.WriteLine("\n                          Klik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    Program.Main();
                }
            } // Zet de boolean "ingelogd" op false, MAAR de accounts bestaand nog! 
        }
    }
}
