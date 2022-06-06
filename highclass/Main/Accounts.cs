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

            Console.WriteLine("Wat is uw voornaam naam?");
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
                Console.WriteLine("Naam kan alleen uit letter bestaan probeer opnieuw.");
                Console.WriteLine("Wat is uw volledige naam?");
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
            Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] die/hen");
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
                Console.WriteLine("\nProbeer opnieuw");
                Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] die/hen");
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
            Console.WriteLine("Wat is uw telefoonnummber?\n+31");
            string telefoonnummerIN = Console.ReadLine();

            bool isAlleenNummers = char.IsNumber(telefoonnummerIN, 0);
            for (int i = 0; i < telefoonnummerIN.Length; i++)
            {
                isAlleenNummers = char.IsNumber(telefoonnummerIN, i);
                Console.WriteLine(isAlleenNummers);
                Console.ReadKey();
                if (isAlleenNummers == false)
                {
                    break;
                }
            }

            bool isLengte10 = telefoonnummerIN.Length != 10 ? true : false;
            while (isLengte10 || !isAlleenNummers)
            {
                Console.WriteLine("Onjuist telefoonnummer. Probeer telefoonnummer opnieuw intevoeren");
                Console.WriteLine("Wat is uw telefoonnummber?");
                telefoonnummerIN = Console.ReadLine();

                for (int i = 0; i < telefoonnummerIN.Length; i++)
                {
                    isAlleenNummers = char.IsNumber(telefoonnummerIN, i);
                    Console.WriteLine(isAlleenNummers);
                    Console.ReadKey();
                    if (isAlleenNummers == false)
                    {
                        break;
                    }
                }
                isLengte10 = telefoonnummerIN.Length != 10 ? true : false;
            }
            Console.WriteLine("Wat is uw e-mail?");
            string eMailIN = Console.ReadLine();
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValedMail = regex.IsMatch(eMailIN);
            while (!isValedMail)
            {
                Console.WriteLine("Incoreccte email. Probeer opnieuw.");
                Console.WriteLine("Wat is uw e-mail?");
                eMailIN = Console.ReadLine();
                regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                isValedMail = regex.IsMatch(eMailIN);
            }


            Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
            ConsoleKeyInfo ABCKey = Console.ReadKey();
            string functieIN = "";
            ABCKey = Console.ReadKey();
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
                    Console.WriteLine("\nProbeer opnieuw");
                    Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
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


            Console.WriteLine("Voer uw gebruikersnaam in:");
            string gebruikersnaamIN = Console.ReadLine();
            Console.WriteLine("Voer uw wachtwoord in:");
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

            Console.WriteLine($"{functieIN} is met succes toegevoegd aan database.\n[1] doorgaan");
            ConsoleKeyInfo doorKey = Console.ReadKey();
            if (doorKey.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
            Console.WriteLine("╘══════════════════════╛");
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
                Console.WriteLine("Medewerker met die naam bestaat niet. \n[1] Probeer opnieuw.\n[0] Terug");
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

            Console.WriteLine("Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
            Console.WriteLine("[1] Ja\n[2] Nee");
            ConsoleKeyInfo readkey = Console.ReadKey();
            while (readkey.Key != ConsoleKey.D1 && readkey.Key != ConsoleKey.D2)
            {

                Console.WriteLine("Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
                Console.WriteLine("\t[1] Ja\n\t[2] Nee");
                readkey = Console.ReadKey();
            }
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList.RemoveAt(i);
                        Console.WriteLine($"Medewerker met naam: {zoekNaam} is verwijderd");
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

            Console.WriteLine("Succesvol verwijderd!");
            Console.WriteLine("[1] Doorgaan");
            Console.WriteLine("╘══════════════════════════════╛");
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

            Console.WriteLine("Wat is naam van de medewerker?");
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
                Console.WriteLine("Medewerker met die naam bestaat niet. \n[1] Probeer opnieuw.");
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
            Console.WriteLine("Wat wil je wijzigen? \n\t[1] Naam\n\t[2] voornaamwoorden\n\t[3] telefoonnummer\n\t[4] eMail\n\t[5] functie\n\t[6] gebruikersnaam\n\t[7] wachtwoord\n");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe naam?");
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
                    Console.WriteLine("Naam kan alleen uit letter bestaan probeer opnieuw.");
                    Console.WriteLine("Wat is uw volledige naam?");
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
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_naam}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] die/hen");
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
                    Console.WriteLine("\nProbeer opnieuw");
                    Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] die/hen");
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
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {pronounsIN}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D3)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe telefoonnummer?");
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
                    Console.WriteLine("Onjuist telefoonnummer. Probeer telefoonnummer opnieuw intevoeren");
                    Console.WriteLine("Wat is uw telefoonnummber?");
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
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_telefoonnummer}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D4)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe eMail?");
                string new_eMail = Console.ReadLine();

                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValedMail = regex.IsMatch(new_eMail);
                while (!isValedMail)
                {
                    Console.WriteLine("Incoreccte email. Probeer opnieuw.");
                    Console.WriteLine("Wat is uw e-mail?");
                    new_eMail = Console.ReadLine();
                    regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                    isValedMail = regex.IsMatch(new_eMail);
                }

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].eMail = new_eMail;
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_eMail}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D5)
            {
                Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
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
                    Console.WriteLine("\nProbeer opnieuw");
                    Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
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
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_functie}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D6)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe gebruikersnaam?");
                string new_gebruikersnaam = Console.ReadLine();

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].gebruikersnaam = new_gebruikersnaam;
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_gebruikersnaam}");
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D7)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe wachtwoord?");
                string new_wachtword = Console.ReadLine();

                while (i < len)
                {
                    if (MedewerkersList[i].naam == zoekNaam)
                    {
                        MedewerkersList[i].wachtwoord = new_wachtword;
                        Console.WriteLine($"Medewerkers naam is gewijzigd naar {new_wachtword}");
                        break;
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Verkeerde input. \nProbeer opnieuw.");
                Console.WriteLine("[0] Opnieuw");

                ConsoleKeyInfo opnieuw = Console.ReadKey();
                if (opnieuw.Key == ConsoleKey.D0)
                {
                    wijzigMedewerkers();
                }
            }
            JsonData = JsonConvert.SerializeObject(MedewerkersList);
            System.IO.File.WriteAllText(MedewerkerPath, JsonData);

            Console.WriteLine("[1] Doorgaan");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Admin.adminMain();
            }
        }
        public static void Inloggen()
        {
            Console.Clear();
            Console.WriteLine("╒══════════════════════════╕");
            Console.WriteLine("HC   ");
            Console.WriteLine(" ");
            Console.WriteLine("     |Inloggen|");
            Console.WriteLine(" ");
            Console.WriteLine("     [0] Terug ");
            Console.WriteLine(" ");
            Console.WriteLine("Gebruikersnaam: ");
            string gebruikersnaamCheck = Console.ReadLine();

            if (gebruikersnaamCheck == "0")
            {
                Program.Main();
            }
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
                Console.WriteLine("Gebruikersnaam en of wachtwoord is verkeerd");
                Console.WriteLine("[0] Terug");
                Console.WriteLine("[1] Probeer opnieuw");
                Console.WriteLine("╘══════════════════════════╛");
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

                Console.WriteLine("╒════════════════════════════════════════════════════════╕");
                Console.WriteLine("HC   ");
                Console.WriteLine("U bent succesvol uitgelogd.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    Program.Main();
                }
            } // Zet de boolean "ingelogd" op false, MAAR de accounts bestaand nog! 
        }
    }
}
