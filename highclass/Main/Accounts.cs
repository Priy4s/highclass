using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Main.Admin;



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
            bool IsAlleenLetters = char.IsLetter(naamIN, naamIN.Length - 1);
            while (!IsAlleenLetters)
            {
                Console.WriteLine("Naam kan alleen uit letter bestaan probeer opnieuw.");
                Console.WriteLine("Wat is uw voornaam naam?");
                naamIN = Console.ReadLine();
                IsAlleenLetters = char.IsLetter(naamIN, naamIN.Length - 1);
            }
            //Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
            //ConsoleKeyInfo ckey = Console.ReadKey();
            string pronounsIN = "";
            Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
            ConsoleKeyInfo ckey = Console.ReadKey();
            while (pronounsIN == "")
            {
                Console.WriteLine("\nProbeer opnieuw");
                Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
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
                    pronounsIN = "hen/hun";
                }
            }
            Console.WriteLine("Wat is uw telefoonnummber?\n+31");
            string telefoonnummerIN = Console.ReadLine();
            bool isAlleenNummers = char.IsNumber(telefoonnummerIN, telefoonnummerIN.Length - 1);
            while (telefoonnummerIN.Length != 10 && !isAlleenNummers)
            {
                Console.WriteLine("Onjuist telefoonnummer. Probeer telefoonnummer opnieuw intevoeren");
                Console.WriteLine("Wat is uw telefoonnummber?");
                telefoonnummerIN = Console.ReadLine();
            }
            Console.WriteLine("Wat is uw e-mail?");
            string eMailIN = Console.ReadLine();
            string newemail = eMailIN.ToLower();
            for (int i = 0; i < naamIN.Length; i++)
            {
                if (newemail[i] != 'a' && newemail[i] != 'b' && newemail[i] != 'c' && newemail[i] != 'd' && newemail[i] != 'e' && newemail[i] != 'f' && newemail[i] != 'g' && newemail[i] != 'h' && newemail[i] != 'i' && newemail[i] != 'j' && newemail[i] != 'k' && newemail[i] != 'l' && newemail[i] != 'm' && newemail[i] != 'n' && newemail[i] != 'o' && newemail[i] != 'p' && newemail[i] != 'q' && newemail[i] != 'r' && newemail[i] != 's' && newemail[i] != 't' && newemail[i] != 'u' && newemail[i] != 'v' && newemail[i] != 'w' && newemail[i] != 'x' && newemail[i] != 'y' && newemail[i] != 'z' && newemail[i] != '0' && newemail[i] != '1' && newemail[i] != '2' && newemail[i] != '3' && newemail[i] != '4' && newemail[i] != '5' && newemail[i] != '6' && newemail[i] != '7' && newemail[i] != '8' && newemail[i] != '9' && newemail[i] != '@' && newemail[i] != '.')
                {
                    Console.WriteLine("email bestaat alleen uit letters, cijfers, één @ en één '.'. Probeer het opnieuw een juiste email intevoeren!");
                    Console.WriteLine("Wat is uw e-mail?");
                    eMailIN = Console.ReadLine();
                }
            }
            Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
            ConsoleKeyInfo AKey = Console.ReadKey();
            string functieIN = "";
            while (functieIN == "")
            {
                Console.WriteLine("\nProbeer opnieuw");
                Console.WriteLine("Wat is uw functie?\n\t[1]Admin\n\t[2]Mederwerker");
                AKey = Console.ReadKey();
                if (AKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                {
                    functieIN = "Admin";
                }
                else if (AKey.Key == ConsoleKey.D2)
                {
                    functieIN = "Mederwerker";
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
                Console.WriteLine("Medewerker met die naam bestaat niet. \n[1] Probeer opnieuw.");
                ConsoleKeyInfo rkey = Console.ReadKey();
                bool check = false;
                if(rkey.Key == ConsoleKey.D1)
                {
                    check = true;
                }
                while (!check)
                {
                    Console.WriteLine("\nMedewerker met die naam bestaat niet. \n[1] Probeer opnieuw.");
                    rkey = Console.ReadKey();
                    if (rkey.Key == ConsoleKey.D1)
                    {
                        check = true;
                    }
                }
                verwijderMedewerker();
            }

            Console.WriteLine("Weet je zeker dat je: " + medewerkerNaam + " wil verwijderen?");
            Console.WriteLine("[1] Ja\n[2] Nee");
            ConsoleKeyInfo readkey = Console.ReadKey();
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
            else
            {
                Admin.adminMain();
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
            }
            Console.WriteLine("Wat wil je wijzigen? \n\t[1] Naam\n\t[2] pronouns\n\t[3] telefoonnummer\n\t[4] eMail\n\t[5] functie\n\t[6] gebruikersnaam\n\t[7] wachtwoord\n");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\nWat wordt medewerkers nieuwe naam?");
                string new_naam = Console.ReadLine();

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
                Console.WriteLine("Wat zijn uw voornaamwoorden?\n\t[1] hij/hem\n\t[2] zij/haar\n\t[3] hen/hun");
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
                ConsoleKeyInfo AKey = Console.ReadKey();
                string new_functie = "";
                if (AKey.Key == ConsoleKey.D1) // check welke voornaamwoorden user heeft gekozen.
                {
                    new_functie = "Admin";
                }
                else if (AKey.Key == ConsoleKey.D2)
                {
                    new_functie = "Mederwerker";
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
            Console.WriteLine("     [0] terug ");
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
                        Personeelsleden.personeelMain();
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
                else if(ConsoleKey.D1 == begin.Key)
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
