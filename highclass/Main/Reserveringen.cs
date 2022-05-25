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
        public string Tijdslot { get; set; }
        public string Datum { get; set; }
        public string Eindtijd { get; set; }
        public double Prijs { get; set; }
    }
    public class Beschikbaarheidjson
    {
        public string Datum { get; set; }
        public string Tijdslot1 { get; set; }
        public int Tijdslot1_Beschikbaarheid { get; set; }
        public string Tijdslot2 { get; set; }
        public int Tijdslot2_Beschikbaarheid { get; set; }
        public string Tijdslot3 { get; set; }
        public int Tijdslot3_Beschikbaarheid { get; set; }
        public string Tijdslot4 { get; set; }
        public int Tijdslot4_Beschikbaarheid { get; set; }
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

            string BeschikbaarheidPath = Path.GetFullPath(@"Beschikbaarheid.json");
            bool fileExist2 = File.Exists(BeschikbaarheidPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData2 = File.ReadAllText(ReserveringPath);
            var BeschikbaarheidList = JsonConvert.DeserializeObject<List<Beschikbaarheidjson>>(JsonData) ?? new List<Beschikbaarheidjson>();

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
            if (aantalIN > 200)
            {
                Console.WriteLine("Niet mogelijk om een reservering te maken voor meer\ndan 200 personen.");
                Console.WriteLine("[1] Doorgaan\n");
                Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                ConsoleKeyInfo keuze = Console.ReadKey();
                if (keuze.Key == ConsoleKey.D1)
                {
                    Program.Main();
                }
            }

            Console.WriteLine("\nDatum van reservering\nDag (1 t/m 31): ");
            int dag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maand: ");
            int maand = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Jaar: ");
            int jaar = Convert.ToInt32(Console.ReadLine());

            int today = DateTime.Now.Day; // dag van vandaag (bijv. 7)
            int days_in_month = DateTime.DaysInMonth(jaar, maand); // hoeveel maanden in aangegeven maand
            int maxdag = today;
            int maxdag2 = today;
            int maxmaand = DateTime.Now.Month;
            if (today + 14 > days_in_month)
            {
                for (int j = 14; j != 0; j--)
                {
                    if (maxdag == days_in_month + 1)
                    {
                        maxdag = 1;
                        maxmaand += 1;
                    }
                    maxdag++;
                    maxdag2++;
                }
            }
            else
            {
                maxdag = today + 14;
                maxdag2 = today + 14;
                maxmaand = DateTime.Now.Month;
            }

            // checkt of datum wel toegestaan is/klopt.
            if (maand == maxmaand && jaar == DateTime.Now.Year)
            {
                if (dag <= maxdag)
                {
                    AddReservering2(dag, maand, jaar, naamIN, pronounsIN, aantalIN);
                }
                else
                {
                    Console.WriteLine("\nU kunt helaas niet reserveren voor deze datum.\n" +
                    "Deze datum bestaat niet of is langer dan twee weken\nverwijderd van vandaag.");
                    Console.WriteLine("Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo ckey3 = Console.ReadKey();
                    if (ckey3.Key == ConsoleKey.D1)
                    {
                        AddReservering();
                    }
                    else if (ckey3.Key == ConsoleKey.D2)
                    {
                        Program.Main();
                    }
                }
            }
            else if (maand == DateTime.Now.Month && jaar == DateTime.Now.Year)
            {
                if (dag <= days_in_month && dag >= DateTime.Now.Day)
                {
                    AddReservering2(dag, maand, jaar, naamIN, pronounsIN, aantalIN);
                }
                else
                {
                    Console.WriteLine("\nU kunt helaas niet reserveren voor deze datum.\n" +
                    "Deze datum bestaat niet of is langer dan twee weken\nverwijderd van vandaag.");
                    Console.WriteLine("Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                    Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                    ConsoleKeyInfo ckey3 = Console.ReadKey();
                    if (ckey3.Key == ConsoleKey.D1)
                    {
                        AddReservering();
                    }
                    else if (ckey3.Key == ConsoleKey.D2)
                    {
                        Program.Main();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nU kunt helaas niet reserveren voor deze datum.\n" +
                    "Deze datum bestaat niet of is langer dan twee weken\nverwijderd van vandaag.");
                Console.WriteLine("Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                ConsoleKeyInfo ckey3 = Console.ReadKey();
                if (ckey3.Key == ConsoleKey.D1)
                {
                    AddReservering();
                }
                else if (ckey3.Key == ConsoleKey.D2)
                {
                    Program.Main();
                }
            }
        }
        private static void AddReservering2(int dag, int maand, int jaar, string naamIN, string pronounsIN, int aantalIN)
        {
            string ReserveringPath = Path.GetFullPath(@"Reserveringen.json");
            bool fileExist = File.Exists(ReserveringPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            string BeschikbaarheidPath = Path.GetFullPath(@"Beschikbaarheid.json");
            bool fileExist2 = File.Exists(BeschikbaarheidPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData2 = File.ReadAllText(ReserveringPath);
            var BeschikbaarheidList = JsonConvert.DeserializeObject<List<Beschikbaarheidjson>>(JsonData) ?? new List<Beschikbaarheidjson>();

            string datumIN = $"{dag}-{maand}-{jaar}";
            int i = 0;
            string check = "x";
            while (i < BeschikbaarheidList.Count)
            {
                if (BeschikbaarheidList[i].Datum == datumIN)
                {
                    check = "v";
                    break;
                }
                i++;
            }
            if (check == "x")
            {
                BeschikbaarheidList.Add(new Beschikbaarheidjson()
                {
                    Datum = datumIN,
                    Tijdslot1 = "11:00-15:00",
                    Tijdslot1_Beschikbaarheid = 200,
                    Tijdslot2 = "15:00-19:00",
                    Tijdslot2_Beschikbaarheid = 200,
                    Tijdslot3 = "19:00-22:00",
                    Tijdslot3_Beschikbaarheid = 200,
                    Tijdslot4 = "22:00-23:00",
                    Tijdslot4_Beschikbaarheid = 200,
                });
            }

            Console.WriteLine($"\nKies een tijdslot:\n\t[1] 11:00-15:00\n\t[2] 15:00-19:00\n\t[3] 19:00-22:00\n\t[4] 22:00-23:00" +
                $"\nLet op! Tijdslot 4 heeft een tijdsduur van een uur, ipv. 4 uur.");
            ConsoleKeyInfo ckey2 = Console.ReadKey();
            string tijdslotIN = "";
            if (ckey2.Key == ConsoleKey.D1)
            {
                tijdslotIN = "11:00-15:00";
                int j = 0;
                while (j < BeschikbaarheidList.Count)
                {
                    if (BeschikbaarheidList[j].Datum == datumIN)
                    {
                        if (BeschikbaarheidList[j].Tijdslot1_Beschikbaarheid - aantalIN >= 0)
                        {
                            BeschikbaarheidList[j].Tijdslot1_Beschikbaarheid -= aantalIN;
                            JsonData2 = JsonConvert.SerializeObject(BeschikbaarheidList);
                            System.IO.File.WriteAllText(BeschikbaarheidPath, JsonData2);
                        }
                        else
                        {
                            Console.WriteLine($"Er zijn niet genoeg plekken beschikbaar tussen {tijdslotIN} op {datumIN}.\n" +
                                "Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo ckey4 = Console.ReadKey();
                            if (ckey4.Key == ConsoleKey.D1)
                            {
                                AddReservering();
                            }
                            else if (ckey4.Key == ConsoleKey.D2)
                            {
                                Program.Main();
                            }
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (ckey2.Key == ConsoleKey.D2)
            {
                tijdslotIN = "15:00-19:00";
                int j = 0;
                while (j < BeschikbaarheidList.Count)
                {
                    if (BeschikbaarheidList[j].Datum == datumIN)
                    {
                        if (BeschikbaarheidList[j].Tijdslot2_Beschikbaarheid - aantalIN >= 0)
                        {
                            BeschikbaarheidList[j].Tijdslot2_Beschikbaarheid -= aantalIN;
                            JsonData2 = JsonConvert.SerializeObject(BeschikbaarheidList);
                            System.IO.File.WriteAllText(BeschikbaarheidPath, JsonData2);
                        }
                        else
                        {
                            Console.WriteLine($"Er zijn niet genoeg plekken beschikbaar tussen {tijdslotIN} op {datumIN}.\n" +
                                "Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo ckey5 = Console.ReadKey();
                            if (ckey5.Key == ConsoleKey.D1)
                            {
                                AddReservering();
                            }
                            else if (ckey5.Key == ConsoleKey.D2)
                            {
                                Program.Main();
                            }
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (ckey2.Key == ConsoleKey.D3)
            {
                tijdslotIN = "19:00-22:00";
                int j = 0;
                while (j < BeschikbaarheidList.Count)
                {
                    if (BeschikbaarheidList[j].Datum == datumIN)
                    {
                        if (BeschikbaarheidList[j].Tijdslot3_Beschikbaarheid - aantalIN >= 0)
                        {
                            BeschikbaarheidList[j].Tijdslot3_Beschikbaarheid -= aantalIN;
                            JsonData2 = JsonConvert.SerializeObject(BeschikbaarheidList);
                            System.IO.File.WriteAllText(BeschikbaarheidPath, JsonData2);
                        }
                        else
                        {
                            Console.WriteLine($"Er zijn niet genoeg plekken beschikbaar tussen {tijdslotIN} op {datumIN}.\n" +
                                "Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo ckey6 = Console.ReadKey();
                            if (ckey6.Key == ConsoleKey.D1)
                            {
                                AddReservering();
                            }
                            else if (ckey6.Key == ConsoleKey.D2)
                            {
                                Program.Main();
                            }
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (ckey2.Key == ConsoleKey.D4)
            {
                tijdslotIN = "22:00-23:00";
                int j = 0;
                while (j < BeschikbaarheidList.Count)
                {
                    if (BeschikbaarheidList[j].Datum == datumIN)
                    {
                        if (BeschikbaarheidList[j].Tijdslot4_Beschikbaarheid - aantalIN >= 0)
                        {
                            BeschikbaarheidList[j].Tijdslot4_Beschikbaarheid -= aantalIN;
                            JsonData2 = JsonConvert.SerializeObject(BeschikbaarheidList);
                            System.IO.File.WriteAllText(BeschikbaarheidPath, JsonData2);
                        }
                        else
                        {
                            Console.WriteLine($"Er zijn niet genoeg plekken beschikbaar tussen {tijdslotIN} op {datumIN}.\n" +
                                "Wilt u opnieuw proberen een reservering aan te maken?\n\t[1] Ja\n\t[2] Nee");
                            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo ckey7 = Console.ReadKey();
                            if (ckey7.Key == ConsoleKey.D1)
                            {
                                AddReservering();
                            }
                            else if (ckey7.Key == ConsoleKey.D2)
                            {
                                Program.Main();
                            }
                        }
                        break;
                    }
                    i++;
                }
            }

            ReserveringenList.Add(new Reserveringenjson()
            {
                Naam = naamIN,
                Voornaamwoorden = pronounsIN,
                Groepsgrote = aantalIN,
                Datum = datumIN,
                Tijdslot = tijdslotIN,
                Eindtijd = "",
                Prijs = 0.00
            });

            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);

            Console.WriteLine("\nUw reservering is succesvol opgeslagen.");
            Console.WriteLine("[1] Doorgaan\n");
            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Program.Main();
            }
        }

        public static void WijzigReservering(string gebruiker = "niet ingelogd")
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

            string BeschikbaarheidPath = Path.GetFullPath(@"Beschikbaarheid.json");
            bool fileExist2 = File.Exists(BeschikbaarheidPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            var JsonData2 = File.ReadAllText(ReserveringPath);
            var BeschikbaarheidList = JsonConvert.DeserializeObject<List<Beschikbaarheidjson>>(JsonData) ?? new List<Beschikbaarheidjson>();

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
            if (gebruiker == "ingelogd")
            {
                Console.WriteLine("\nWat wilt u wijzigen? \n\t[1] Naam\n\t[2] Persoonlijk voornaamwoorden\n\t[3] Groepsgrote\n\t[4] Datum\n\t[5] Starttijd\n[6] Eindtijd  ");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
            }
            else
            {
                Console.WriteLine("\nWat wilt u wijzigen? \n\t[1] Naam\n\t[2] Persoonlijk voornaamwoorden\n\t[3] Groepsgrote\n\t[4] Datum\n\t[5] Starttijd\n");
                Console.WriteLine("╘════════════════════════════════════════════════════════╛");
            }

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

                Console.WriteLine("\nKies een tijdslot:\n\t[1] 11:00-15:00\n\t[2] 15:00-19:00\n\t[3] 19:00-22:00\n\t[4] 22:00-23:00");
                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.D1)
                {
                    string new_Tijdslot = "11:00-15:00";
                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            ReserveringenList[i].Tijdslot = new_Tijdslot;
                            Console.WriteLine($"Het tijdslot van uw reservering is gewijzigd naar: {new_Tijdslot}\n");
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
                else if (ckey.Key == ConsoleKey.D2)
                {
                    string new_Tijdslot = "15:00-19:00";
                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            ReserveringenList[i].Tijdslot = new_Tijdslot;
                            Console.WriteLine($"Het tijdslot van uw reservering is gewijzigd naar: {new_Tijdslot}\n");
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
                else if (ckey.Key == ConsoleKey.D3)
                {
                    string new_Tijdslot = "19:00-22:00";
                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            ReserveringenList[i].Tijdslot = new_Tijdslot;
                            Console.WriteLine($"Het tijdslot van uw reservering is gewijzigd naar: {new_Tijdslot}\n");
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
                else if (ckey.Key == ConsoleKey.D4)
                {
                    string new_Tijdslot = "22:00-23:00";
                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            ReserveringenList[i].Tijdslot = new_Tijdslot;
                            Console.WriteLine($"Het tijdslot van uw reservering is gewijzigd naar: {new_Tijdslot}\n");
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
            else if (readkey.Key == ConsoleKey.D6)
            {
                Console.Clear();
                if (gebruiker == "ingelogd")
                {
                    Console.WriteLine("╒════════════════════════════════════════════════════════════════╕");
                    Console.WriteLine(" HC\n");
                    Console.WriteLine($"Eindtijd {reserveringsNaam}: ");
                    string new_EindTijd = Console.ReadLine();

                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            ReserveringenList[i].Eindtijd = new_EindTijd;
                            Console.WriteLine($"{reserveringsNaam} is vertrokken om {new_EindTijd} uur.");
                            Console.WriteLine("[1] Doorgaan\n");
                            Console.WriteLine("╘════════════════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo keus = Console.ReadKey();
                            if (keus.Key == ConsoleKey.D1)
                            {
                                JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                System.IO.File.WriteAllText(ReserveringPath, JsonData);
                                Personeelsleden.personeelMain();
                            }
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        public static void verwijderReservering(string gebruiker = "niet ingelogd")
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

            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);

            Console.WriteLine("\n [1] Doorgaan");
            Console.WriteLine("╘════════════════════════════════════════════════════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1 && gebruiker == "niet ingelogd")
            {
                Program.Main();
            }
            else
            {
                Personeelsleden.personeelMain();
            }
        }
    }
}