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
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘           \n");
            string str = "|Reserveren|";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.WriteLine();
            str = "Reserveringsnaam:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            string naamIN = Console.ReadLine();

            bool IsAlleenLetters = char.IsLetter(naamIN, 0);
            bool isSpace = char.IsWhiteSpace(naamIN, 0);
            bool isSpaceBackUp = true;
            for (int i = 0; i < naamIN.Length; i++)
            {
                IsAlleenLetters = char.IsLetter(naamIN, i);
                if (IsAlleenLetters == false)
                {
                    isSpace = char.IsWhiteSpace(naamIN, i);
                    if (isSpace == false)
                    {
                        isSpaceBackUp = false;
                        break;
                    }
                }
            }

            while (!IsAlleenLetters || !isSpaceBackUp)
            {
                Console.WriteLine(); Console.WriteLine();
                str = "Reserveringsnaam kan alleen uit letters en spaties bestaan.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Reserveringsnaam:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
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
                            isSpaceBackUp = false;
                            break;
                        }
                        else
                        {
                            isSpaceBackUp = true;
                        }
                    }
                    else
                    {
                        isSpaceBackUp = true;
                    }
                }
            }

            for (int i = 0; i < ReserveringenList.Count; i++)
            {
                if (ReserveringenList[i].Naam == naamIN)
                {
                    Console.WriteLine();
                    str = "Er bestaat al een reservering onder deze naam.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] Probeer opnieuw";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.WriteLine();
                    str = "[0] Terug";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keuze = Console.ReadKey();
                    if (keuze.Key == ConsoleKey.D1)
                    {
                        AddReservering();
                    }
                    else
                    {
                        Program.Main();
                    }
                }
            }

            Console.WriteLine();
            str = "Wat zijn uw persoonlijke voornaamwoorden?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[1] hij/hem";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[2] zij/haar";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[3] hen/hun";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey = Console.ReadKey();
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
                pronounsIN = "die/hen";
            }
            while (pronounsIN == "")
            {
                Console.WriteLine();
                str = "Wat zijn uw persoonlijke voornaamwoorden?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] hij/hem";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] zij/haar";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] hen/hun";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ckey = Console.ReadKey();
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
                    pronounsIN = "die/hen";
                }
            }


            Console.WriteLine();
            Console.WriteLine();
            str = "Groepsgrote:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            string straantalIN = Console.ReadLine();
            bool isAantalAlleenNummers = char.IsDigit(straantalIN, 0);
            for (int i = 0; i < straantalIN.Length; i++)
            {
                isAantalAlleenNummers = char.IsDigit(straantalIN, i);
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                if (isAantalAlleenNummers == false)
                {
                    break;
                }
            }
            while (!isAantalAlleenNummers)
            {
                Console.WriteLine();
                str = "Groepsgrote bestaat alleen uit cijfer";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Groepsgrote:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                straantalIN = Console.ReadLine();

                for (int i = 0; i < straantalIN.Length; i++)
                {
                    isAantalAlleenNummers = char.IsDigit(straantalIN, i);
                    if (isAantalAlleenNummers == false)
                    {
                        break;
                    }
                }
            }
            int aantalIN = Convert.ToInt32(straantalIN);
            if (aantalIN > 200)
            {
                Console.WriteLine();
                str = "Niet mogelijk om een reservering te maken voor meer";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "dan 200 personen.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Opnieuw proberen";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "[0] Terug";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo keuze = Console.ReadKey();
                if (keuze.Key == ConsoleKey.D0)
                {
                    Program.Main();
                }
                else if (keuze.Key == ConsoleKey.D1)
                {
                    AddReservering();
                }
                else
                {
                    Program.Main();
                }
            }
            
            Console.Clear();
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘           \n");
            str = "|Reserveren|";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.WriteLine();
            str = "Datum van reservering";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "Dag (1 t/m 31):";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            string strDag = Console.ReadLine();
            bool IsDagNummers = char.IsDigit(strDag, 0);
            for (int i = 0; i < strDag.Length; i++)
            {
                IsDagNummers = char.IsDigit(strDag, i);
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                if (IsDagNummers == false)
                {
                    break;
                }
            }
            while (!IsDagNummers)
            {
                Console.WriteLine();
                str = "Datum bestaat alleen uit cijfers. Dag van de week is niet nodig.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Dag (1 t/m 31):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                strDag = Console.ReadLine();

                for (int i = 0; i < strDag.Length; i++)
                {
                    IsDagNummers = char.IsDigit(strDag, i);
                    if (IsDagNummers == false)
                    {
                        break;
                    }
                }
            }
            int dag = Convert.ToInt32(strDag);

            while (dag <= 0 || dag > 31)
            {
                str = "Foute input. Probeer opnieuw.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Dag (1 t/m 31):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                dag = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            str = "Maand (1 t/m 12):";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;

            string strMaand = Console.ReadLine();
            bool IsMaandNummers = char.IsDigit(strMaand, 0);
            for (int i = 0; i < strMaand.Length; i++)
            {
                IsMaandNummers = char.IsDigit(strMaand, i);
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                if (IsMaandNummers == false)
                {
                    break;
                }
            }
            while (!IsMaandNummers)
            {
                Console.WriteLine();
                str = "Datum bestaat alleen uit cijfers.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Maand (1 t/m 12):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                strMaand = Console.ReadLine();

                for (int i = 0; i < strMaand.Length; i++)
                {
                    IsMaandNummers = char.IsDigit(strDag, i);
                    if (IsMaandNummers == false)
                    {
                        break;
                    }
                }
            }
            int maand = Convert.ToInt32(strMaand);

            while (maand <= 0 || maand > 12)
            {
                str = "Foute input. Probeer opnieuw.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Maand (1 t/m 12):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                maand = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            str = "Jaar:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2; 
            string strJaar = Console.ReadLine();
            bool IsJaarNummer = char.IsDigit(strJaar, 0);
            for (int i = 0; i < strJaar.Length; i++)
            {
                IsJaarNummer = char.IsDigit(strJaar, i);
                Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                if (IsJaarNummer == false)
                {
                    break;
                }
            }
            while (!IsJaarNummer)
            {
                Console.WriteLine();
                str = "Datum bestaat alleen uit cijfers.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Jaar:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                strJaar = Console.ReadLine();

                for (int i = 0; i < strJaar.Length; i++)
                {
                    IsJaarNummer = char.IsDigit(strJaar, i);
                    if (IsJaarNummer == false)
                    {
                        break;
                    }
                }
            }
            int jaar = Convert.ToInt32(strJaar);
            while (jaar < 2022)
            {
                str = "Foute input. Probeer opnieuw.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Jaar:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                jaar = Convert.ToInt32(Console.ReadLine());
            }
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
                    Console.WriteLine();
                    str = "U kunt helaas niet reserveren voor deze datum.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Deze datum bestaat niet of is langer dan twee weken";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "verwijderd van vandaag.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] Ja";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[2] Nee";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo ckey3 = Console.ReadKey();
                    if (ckey3.Key == ConsoleKey.D1)
                    {
                        // in json
                        AddReservering();
                    }
                    else
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
                    Console.WriteLine();
                    str = "U kunt helaas niet reserveren voor deze datum.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Deze datum bestaat niet of is langer dan twee weken";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "verwijderd van vandaag.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Wilt u opnieuw proberen een reservering aan te maken?";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] Ja";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[2] Nee";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo ckey3 = Console.ReadKey();
                    if (ckey3.Key == ConsoleKey.D1)
                    {
                        AddReservering();
                    }
                    else
                    {
                        Program.Main();
                    }
                }
            }
            else
            {
                Console.WriteLine();
                str = "U kunt helaas niet reserveren voor deze datum.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Deze datum bestaat niet of is langer dan twee weken";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "verwijderd van vandaag.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Wilt u opnieuw proberen een reservering aan te maken?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Ja";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Nee";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo ckey3 = Console.ReadKey();
                if (ckey3.Key == ConsoleKey.D1)
                {
                    AddReservering();
                }
                else
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

            Console.WriteLine();
            string str = "Kies een tijdslot:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[1] 11:00-15:00";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[2] 15:00-19:00";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[3] 19:00-22:00";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[4] 22:00-23:00";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "Let op! Tijdslot 4 heeft een tijdsduur van een uur, ipv. 4 uur.";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo ckey2 = Console.ReadKey();
            string tijdslotIN = "";
            if (ckey2.Key == ConsoleKey.D1)
            {
                tijdslotIN = "11:00-15:00";
            }
            else if (ckey2.Key == ConsoleKey.D2)
            {
                tijdslotIN = "15:00 - 19:00";
            }
            else if (ckey2.Key == ConsoleKey.D3)
            {
                tijdslotIN = "19:00 - 22:00";
            }
            else if (ckey2.Key == ConsoleKey.D4)
            {
                tijdslotIN = "22:00-23:00";
            }

            while (tijdslotIN == "")
            {
                Console.WriteLine();
                str = "Kies een tijdslot:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] 11:00-15:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] 15:00-19:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] 19:00-22:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[4] 22:00-23:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Let op! Tijdslot 4 heeft een tijdsduur van een uur, ipv. 4 uur.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ckey2 = Console.ReadKey();
                if (ckey2.Key == ConsoleKey.D1)
                {
                    tijdslotIN = "11:00-15:00";
                }
                else if (ckey2.Key == ConsoleKey.D2)
                {
                    tijdslotIN = "15:00 - 19:00";
                }
                else if (ckey2.Key == ConsoleKey.D3)
                {
                    tijdslotIN = "19:00 - 22:00";
                }
                else if (ckey2.Key == ConsoleKey.D4)
                {
                    tijdslotIN = "22:00-23:00";
                }
            }
            string datumIN = $"{dag}-{maand}-{jaar}";

            int plekken = 0;
            for (int i = 0; i < ReserveringenList.Count; i++)
            {
                if (ReserveringenList[i].Datum == datumIN)
                {
                    if (ReserveringenList[i].Tijdslot == tijdslotIN)
                    {
                        if (ReserveringenList[i].Eindtijd == "")
                        {
                            plekken += ReserveringenList[i].Groepsgrote;
                        }
                    }
                }
            }
            if (plekken + aantalIN <= 200)
            {
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

                Console.WriteLine();
                Console.WriteLine();
                str = "Uw reservering is succesvol opgeslagen.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Doorgaan";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo keus = Console.ReadKey();
                if (keus.Key == ConsoleKey.D1)
                {
                    Program.Main();
                }
                else
                {
                    Program.Main();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                str = $"Er zijn niet genoeg plekken beschikbaar";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = $"tussen {tijdslotIN} op {datumIN}.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Wilt u opnieuw proberen een reservering aan te maken?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Ja";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Nee";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo ckey4 = Console.ReadKey();
                if (ckey4.Key == ConsoleKey.D1)
                {
                    AddReservering();
                }
                else
                {
                    Program.Main();
                }
            }
        }

        /*
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
            JsonData2 = JsonConvert.SerializeObject(BeschikbaarheidList);
            System.IO.File.WriteAllText(BeschikbaarheidPath, JsonData2);

            BeschikbaarheidPath = Path.GetFullPath(@"Beschikbaarheid.json");
            fileExist2 = File.Exists(BeschikbaarheidPath);
            if (!fileExist)
            {
                using (File.Create(ReserveringPath)) ;
            }
            JsonData2 = File.ReadAllText(ReserveringPath);
            BeschikbaarheidList = JsonConvert.DeserializeObject<List<Beschikbaarheidjson>>(JsonData2) ?? new List<Beschikbaarheidjson>();
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
                    Console.WriteLine("in if statement");
                    Console.ReadKey();
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
                j++;
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
                j++;
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
                j++;
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
                j++;
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
    }*/

        public static void WijzigReservering(string gebruikerNaam, string gebruiker = "niet ingelogd")
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

            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘           \n");
            string str = "|Reservering wijzigen|";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.WriteLine();
            str = "Reserveringsnaam:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
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
                Console.WriteLine();
                str = $"Een reservering onder de naam '{zoekNaam}' bestaat niet.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Probeer opnieuw.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Maak nieuwe reservering aan.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "[0] Terug";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    WijzigReservering(gebruikerNaam);
                }
                else if (rkey.Key == ConsoleKey.D2)
                {
                    AddReservering();
                }
                else
                {
                    if (gebruiker == "admin")
                    {
                        Admin.adminMain();
                    }
                    else if (gebruiker == "personeel")
                    {
                        Personeelsleden.personeelMain(gebruikerNaam);
                    }
                    else
                    {
                        Program.Main();
                    }
                }
            }
            if (gebruiker == "admin" || gebruiker == "personeel")
            {
                Console.WriteLine();
                str = "Wat wilt u wijzigen?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Naam";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Persoonlijk voornaamwoorden";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] Groepsgrote";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[4] Datum";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[5] Tijdslot";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[6] Eindtijd";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            }
            else
            {
                Console.WriteLine();
                str = "Wat wilt u wijzigen?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Naam";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Persoonlijk voornaamwoorden";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] Groepsgrote";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[4] Datum";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[5] Tijdslot";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            }
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘           \n");
                str = "|Reservering wijzigen|";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "Nieuwe reserveringsnaam:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
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
                    Console.WriteLine(); Console.WriteLine();
                    str = "Reserveringsnaam kan alleen uit letters en spaties bestaan.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Reserveringsnaam:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
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
                for (int j = 0; j < ReserveringenList.Count; j++)
                {
                    if (ReserveringenList[j].Naam == new_naam)
                    {
                        Console.WriteLine();
                        str = "Er bestaat al een reservering onder deze naam.";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        str = "[1] Probeer opnieuw";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        Console.WriteLine();
                        str = "[0] Terug";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        Console.CursorLeft = Console.WindowWidth / 2;
                        ConsoleKeyInfo keuze = Console.ReadKey();
                        if (keuze.Key == ConsoleKey.D1)
                        {
                            AddReservering();
                        }
                        else if (keuze.Key == ConsoleKey.D0 && gebruiker == "admin")
                        {
                            Admin.adminMain();
                        }
                        else if (keuze.Key == ConsoleKey.D0 && gebruiker == "personeel")
                        {
                            Personeelsleden.personeelMain(gebruikerNaam);
                        }
                        else
                        {
                            Program.Main();
                        }
                    }
                }

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        Console.WriteLine();
                        ReserveringenList[i].Naam = new_naam;
                        str = $"De naam waaronder de reservering is opgeslagen is gewijzigd naar: {new_naam}";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        str = "[1] Doorgaan";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        Console.CursorLeft = Console.WindowWidth / 2;
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);
                            if (gebruiker == "admin" || gebruiker == "personeel")
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                            break;
                        }
                        else
                        {
                            str = $"Er is een fout, probeer opnieuw.";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = $"[0] Terug";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            ConsoleKeyInfo teruglkey = Console.ReadKey();
                            if (teruglkey.Key == ConsoleKey.D0)
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                            else
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘           \n");
                str = "|Reservering wijzigen|";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "Nieuwe persoonlijk voornaamwoorden?";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] hij/hem";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] zij/haar";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] hen/hun";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo AKey = Console.ReadKey();
                string pronounsIN = "";
                if (AKey.Key == ConsoleKey.D1) //check welke voornaamwoorden user heeft gekozen
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
                    Console.WriteLine();
                    str = "Wat zijn uw persoonlijke voornaamwoorden?";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] hij/hem";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[2] zij/haar";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[3] hen/hun";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    AKey = Console.ReadKey();
                    if (AKey.Key == ConsoleKey.D1)
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
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        ReserveringenList[i].Voornaamwoorden = pronounsIN;
                        str = $"Uw persoonlijk voornaamwoorden zijn gewijzigd naar: {pronounsIN}";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        str = "[1] Doorgaan";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                        Console.CursorLeft = Console.WindowWidth / 2;
                        ConsoleKeyInfo keus = Console.ReadKey();
                        if (keus.Key == ConsoleKey.D1)
                        {
                            JsonData = JsonConvert.SerializeObject(ReserveringenList);
                            System.IO.File.WriteAllText(ReserveringPath, JsonData);

                            if (gebruiker == "admin")
                            {
                                Admin.adminMain();
                            }
                            else if (gebruiker == "personeel")
                            {
                                Personeelsleden.personeelMain(gebruikerNaam);
                            }
                            else
                            {
                                Program.Main();
                            }
                        }
                        else
                        {
                            str = $"Er is een fout, probeer opnieuw.";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = $"[0] Terug";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            ConsoleKeyInfo teruglkey = Console.ReadKey();
                            if (teruglkey.Key == ConsoleKey.D0)
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                            else
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                        }
                        break;
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘           \n");
                str = "|Reservering wijzigen|";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "Nieuwe groepsgrote:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                string strNew_groepsgrote = Console.ReadLine();
                bool isAantalAlleenNummers = char.IsDigit(strNew_groepsgrote, 0);
                for (int Ii = 0; Ii < strNew_groepsgrote.Length; Ii++)
                {
                    isAantalAlleenNummers = char.IsDigit(strNew_groepsgrote, Ii);
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    if (isAantalAlleenNummers == false)
                    {
                        break;
                    }
                }
                while (!isAantalAlleenNummers)
                {
                    Console.WriteLine();
                    str = "Groepsgrote bestaat alleen uit cijfer";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Groepsgrote:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    strNew_groepsgrote = Console.ReadLine();

                    for (int Ii = 0; Ii < strNew_groepsgrote.Length; Ii++)
                    {
                        isAantalAlleenNummers = char.IsDigit(strNew_groepsgrote, Ii);
                        if (isAantalAlleenNummers == false)
                        {
                            break;
                        }
                    }
                }

                int new_groepsgrote = Convert.ToInt32(strNew_groepsgrote);
                if (new_groepsgrote > 200)
                {
                    Console.WriteLine();
                    str = "Niet mogelijk om een reservering te maken voor meer";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "dan 200 personen.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] Opnieuw proberen";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.WriteLine();
                    str = "[0] Terug";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keuze = Console.ReadKey();
                    if (keuze.Key == ConsoleKey.D0)
                    {
                        Program.Main();
                    }
                    else if (keuze.Key == ConsoleKey.D1)
                    {
                        WijzigReservering(gebruikerNaam);
                    }
                    else
                    {
                        Program.Main();
                    }
                }
                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        int plekken = 0;
                        for (int j = 0; j < ReserveringenList.Count; j++)
                        {
                            if (ReserveringenList[j].Datum == ReserveringenList[i].Datum)
                            {
                                if (ReserveringenList[j].Tijdslot == ReserveringenList[i].Tijdslot)
                                {
                                    if (ReserveringenList[j].Eindtijd == "")
                                    {
                                        plekken += ReserveringenList[j].Groepsgrote;
                                    }
                                }
                            }
                        }
                        if (plekken + ReserveringenList[i].Groepsgrote <= 200)
                        {
                            Console.WriteLine();
                            ReserveringenList[i].Groepsgrote = new_groepsgrote;
                            str = $"De groepsgrote van uw reservering is gewijzigd naar: {new_groepsgrote}";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[1] Doorgaan";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo keus = Console.ReadKey();
                            if (keus.Key == ConsoleKey.D1)
                            {
                                JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                System.IO.File.WriteAllText(ReserveringPath, JsonData);

                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                            else
                            {
                                str = $"Er is een fout, probeer opnieuw.";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = $"[0] Terug";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                ConsoleKeyInfo teruglkey = Console.ReadKey();
                                if (teruglkey.Key == ConsoleKey.D0)
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                                else
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            str = "Er zijn niet genoeg plekken beschikbaar";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "Wilt u opnieuw proberen om de reservering te wijzigen?";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[1] Ja";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[2] Nee";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo ckey4 = Console.ReadKey();
                            if (ckey4.Key == ConsoleKey.D1)
                            {
                                WijzigReservering(gebruikerNaam);
                            }
                            else
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D4)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘           \n");
                str = "|Reservering wijzigen|";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str  = "Nieuwe reserveringsdatum";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Dag (1 t/m 31):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                string strDag = Console.ReadLine();
                bool IsDagNummers = char.IsDigit(strDag, 0);
                for (int index = 0; index < strDag.Length; index++)
                {
                    IsDagNummers = char.IsDigit(strDag, index);
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    if (IsDagNummers == false)
                    {
                        break;
                    }
                }
                while (!IsDagNummers)
                {
                    Console.WriteLine();
                    str = "Datum bestaat alleen uit cijfers. Dag van de week is niet nodig.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Dag (1 t/m 31):";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    strDag = Console.ReadLine();

                    for (int index = 0; index < strDag.Length; index++)
                    {
                        IsDagNummers = char.IsDigit(strDag, index);
                        if (IsDagNummers == false)
                        {
                            break;
                        }
                    }
                }
                int newdag = Convert.ToInt32(strDag);

                while (newdag <= 0 || newdag > 31)
                {
                    str = "Foute input. Probeer opnieuw.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Dag (1 t/m 31):";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    newdag = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                str = "Maand (1 t/m 12):";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;

                string strMaand = Console.ReadLine();
                bool IsMaandNummers = char.IsDigit(strMaand, 0);
                for (int index2 = 0; index2 < strMaand.Length; index2++)
                {
                    IsMaandNummers = char.IsDigit(strMaand, index2);
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    if (IsMaandNummers == false)
                    {
                        break;
                    }
                }
                while (!IsMaandNummers)
                {
                    Console.WriteLine();
                    str = "Datum bestaat alleen uit cijfers.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Maand (1 t/m 12):";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    strMaand = Console.ReadLine();

                    for (int index2 = 0; index2 < strMaand.Length; index2++)
                    {
                        IsMaandNummers = char.IsDigit(strDag, index2);
                        if (IsMaandNummers == false)
                        {
                            break;
                        }
                    }
                }
                int newmaand = Convert.ToInt32(strMaand);

                while (newmaand <= 0 || newmaand > 12)
                {
                    str = "Foute input. Probeer opnieuw.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Maand (1 t/m 12):";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    newmaand = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                str = "Jaar:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                string strJaar = Console.ReadLine();
                bool IsJaarNummer = char.IsDigit(strJaar, 0);
                for (int index3 = 0; index3 < strJaar.Length; index3++)
                {
                    IsJaarNummer = char.IsDigit(strJaar, index3);
                    Console.CursorLeft = (Console.WindowWidth / 2) - 4;
                    if (IsJaarNummer == false)
                    {
                        break;
                    }
                }
                while (!IsJaarNummer)
                {
                    Console.WriteLine();
                    str = "Datum bestaat alleen uit cijfers.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Jaar:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    strJaar = Console.ReadLine();

                    for (int index3 = 0; index3 < strJaar.Length; index3++)
                    {
                        IsJaarNummer = char.IsDigit(strJaar, index3);
                        if (IsJaarNummer == false)
                        {
                            break;
                        }
                    }
                }
                int newjaar = Convert.ToInt32(strJaar);
                while (newjaar < 2022)
                {
                    str = "Foute input. Probeer opnieuw.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Jaar:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    newjaar = Convert.ToInt32(Console.ReadLine());
                }
                string new_Datum = $"{newdag}-{newmaand}-{newjaar}";

                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        int today = DateTime.Now.Day; // dag van vandaag (bijv. 7)
                        int days_in_month = DateTime.DaysInMonth(newjaar, newmaand); // hoeveel maanden in aangegeven maand
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

                        if (newmaand == maxmaand && newjaar == DateTime.Now.Year)
                        {
                            if (newdag <= maxdag)
                            {
                                int plekken = 0;
                                for (int j = 0; j < ReserveringenList.Count; j++)
                                {
                                    if (ReserveringenList[j].Datum == new_Datum)
                                    {
                                        if (ReserveringenList[j].Tijdslot == ReserveringenList[i].Tijdslot)
                                        {
                                            if (ReserveringenList[j].Eindtijd == "")
                                            {
                                                plekken += ReserveringenList[j].Groepsgrote;
                                            }
                                        }
                                    }
                                }
                                if (plekken + ReserveringenList[i].Groepsgrote <= 200)
                                {
                                    Console.WriteLine();
                                    ReserveringenList[i].Datum = new_Datum;
                                    str = $"De datum van uw reservering is gewijzigd naar: {new_Datum}";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[1] Doorgaan";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    Console.CursorLeft = Console.WindowWidth / 2;
                                    ConsoleKeyInfo keus = Console.ReadKey();
                                    if (keus.Key == ConsoleKey.D1)
                                    {
                                        JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                        System.IO.File.WriteAllText(ReserveringPath, JsonData);

                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    str = "Er zijn niet genoeg plekken beschikbaar";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[1] Ja";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[2] Nee";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    Console.CursorLeft = Console.WindowWidth / 2;
                                    ConsoleKeyInfo ckey4 = Console.ReadKey();
                                    if (ckey4.Key == ConsoleKey.D1)
                                    {
                                        WijzigReservering(gebruikerNaam);
                                    }
                                    else
                                    {
                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                }
                                i++;
                            }
                            else
                            {
                                Console.WriteLine();
                                str = "Er zijn niet genoeg plekken beschikbaar";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[1] Ja";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[2] Nee";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                Console.CursorLeft = Console.WindowWidth / 2;
                                ConsoleKeyInfo ckey4 = Console.ReadKey();
                                if (ckey4.Key == ConsoleKey.D1)
                                {
                                    WijzigReservering(gebruikerNaam);
                                }
                                else
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                            }
                        }
                        else if (newmaand == DateTime.Now.Month && newjaar == DateTime.Now.Year)
                        {
                            if (newdag <= days_in_month && newdag >= DateTime.Now.Day)
                            {
                                int plekken = 0;
                                for (int j = 0; j < ReserveringenList.Count; j++)
                                {
                                    if (ReserveringenList[j].Datum == new_Datum)
                                    {
                                        if (ReserveringenList[j].Tijdslot == ReserveringenList[i].Tijdslot)
                                        {
                                            if (ReserveringenList[j].Eindtijd == "")
                                            {
                                                plekken += ReserveringenList[j].Groepsgrote;
                                            }
                                        }
                                    }
                                }
                                if (plekken + ReserveringenList[i].Groepsgrote <= 200)
                                {
                                    Console.WriteLine();
                                    ReserveringenList[i].Datum = new_Datum;
                                    str = $"De datum van uw reservering is gewijzigd naar: {new_Datum}";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[1] Doorgaan";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    Console.CursorLeft = Console.WindowWidth / 2;
                                    ConsoleKeyInfo keus = Console.ReadKey();
                                    if (keus.Key == ConsoleKey.D1)
                                    {
                                        JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                        System.IO.File.WriteAllText(ReserveringPath, JsonData);

                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    str = "Er zijn niet genoeg plekken beschikbaar";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[1] Ja";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = "[2] Nee";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    Console.CursorLeft = Console.WindowWidth / 2;
                                    ConsoleKeyInfo ckey4 = Console.ReadKey();
                                    if (ckey4.Key == ConsoleKey.D1)
                                    {
                                        WijzigReservering(gebruikerNaam);
                                    }
                                    else
                                    {
                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                }
                                i++;
                            }
                            else
                            {
                                Console.WriteLine();
                                str = "Er zijn niet genoeg plekken beschikbaar";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[1] Ja";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[2] Nee";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                Console.CursorLeft = Console.WindowWidth / 2;
                                ConsoleKeyInfo ckey4 = Console.ReadKey();
                                if (ckey4.Key == ConsoleKey.D1)
                                {
                                    WijzigReservering(gebruikerNaam);
                                }
                                else
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            str = "U kunt niet reserveren voor deze datum.";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "Wilt u opnieuw proberen de reservering te wijzigen?";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[1] Ja";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[2] Nee";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo ckey4 = Console.ReadKey();
                            if (ckey4.Key == ConsoleKey.D1)
                            {
                                WijzigReservering(gebruikerNaam);
                            }
                            else
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D5)
            {
                Console.Clear();
                Console.WriteLine("                                                    ┌─────────────┐            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $$$$$ $     │            ");
                Console.WriteLine("                                                    │ $   $ $     │            ");
                Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                Console.WriteLine("                                                    └─────────────┘           \n");
                str = "|Reservering wijzigen|";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "Kies een tijdslot:";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] 11:00-15:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] 15:00-19:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[3] 19:00-22:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[4] 22:00-23:00";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "Let op! Tijdslot 4 heeft een tijdsduur van een uur, ipv. 4 uur.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo ckey = Console.ReadKey();
                string new_Tijdslot = "";
                if (ckey.Key == ConsoleKey.D1)
                {
                    new_Tijdslot = "11:00-15:00";
                }
                else if (ckey.Key == ConsoleKey.D2)
                {
                    new_Tijdslot = "15:00-19:00";
                }
                else if (ckey.Key == ConsoleKey.D3)
                {
                    new_Tijdslot = "19:00-22:00";
                }
                else if (ckey.Key == ConsoleKey.D4)
                {
                    new_Tijdslot = "22:00-23:00";
                }

                while (new_Tijdslot == "")
                {
                    Console.WriteLine();
                    str = "Kies een tijdslot:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[1] 11:00-15:00";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[2] 15:00-19:00";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[3] 19:00-22:00";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "[4] 22:00-23:00";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = "Let op! Tijdslot 4 heeft een tijdsduur van een uur, ipv. 4 uur.";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ckey = Console.ReadKey();
                    if (ckey.Key == ConsoleKey.D1)
                    {
                        new_Tijdslot = "11:00-15:00";
                    }
                    else if (ckey.Key == ConsoleKey.D2)
                    {
                        new_Tijdslot = "15:00 - 19:00";
                    }
                    else if (ckey.Key == ConsoleKey.D3)
                    {
                        new_Tijdslot = "19:00 - 22:00";
                    }
                    else if (ckey.Key == ConsoleKey.D4)
                    {
                        new_Tijdslot = "22:00-23:00";
                    }
                }
                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        int plekken = 0;
                        for (int j = 0; j < ReserveringenList.Count; j++)
                        {
                            if (ReserveringenList[j].Datum == ReserveringenList[i].Datum)
                            {
                                if (ReserveringenList[j].Tijdslot == new_Tijdslot)
                                {
                                    if (ReserveringenList[j].Eindtijd == "")
                                    {
                                        plekken += ReserveringenList[j].Groepsgrote;
                                    }
                                }
                            }
                        }
                        if (plekken + ReserveringenList[i].Groepsgrote <= 200)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            ReserveringenList[i].Tijdslot = new_Tijdslot;
                            str = $"Het tijdslot van uw reservering is gewijzigd naar: {new_Tijdslot}";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[1] Doorgaan";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo keus = Console.ReadKey();
                            if (keus.Key == ConsoleKey.D1)
                            {
                                JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                System.IO.File.WriteAllText(ReserveringPath, JsonData);

                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                            else
                            {
                                str = $"Er is een fout, probeer opnieuw.";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = $"[0] Terug";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                ConsoleKeyInfo teruglkey = Console.ReadKey();
                                if (teruglkey.Key == ConsoleKey.D0)
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                                else
                                {
                                    if (gebruiker == "admin")
                                    {
                                        Admin.adminMain();
                                    }
                                    else if (gebruiker == "personeel")
                                    {
                                        Personeelsleden.personeelMain(gebruikerNaam);
                                    }
                                    else
                                    {
                                        Program.Main();
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            str = "Er zijn niet genoeg plekken beschikbaar";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = $"tussen {ReserveringenList[i].Tijdslot} op {ReserveringenList[i].Datum}.";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "Wilt u opnieuw proberen de reservering te maken wijzigen?";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[1] Ja";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            str = "[2] Nee";
                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                            Console.CursorLeft = Console.WindowWidth / 2;
                            ConsoleKeyInfo ckey4 = Console.ReadKey();
                            if (ckey4.Key == ConsoleKey.D1)
                            {
                                WijzigReservering(gebruikerNaam);
                            }
                            else
                            {
                                if (gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    Program.Main();
                                }
                            }
                        }
                    }
                    i++;
                }
            }
            else if (readkey.Key == ConsoleKey.D6)
            {
                Console.Clear();
                if (gebruiker == "admin" || gebruiker == "personeel")
                {
                    Console.Clear();
                    Console.WriteLine("                                                    ┌─────────────┐            ");
                    Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                    Console.WriteLine("                                                    │ $   $ $     │            ");
                    Console.WriteLine("                                                    │ $$$$$ $     │            ");
                    Console.WriteLine("                                                    │ $   $ $     │            ");
                    Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
                    Console.WriteLine("                                                    └─────────────┘           \n");
                    str = "|Reservering wijzigen|";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.WriteLine();
                    str = $"Eindtijd {reserveringsNaam}:";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    string new_EindTijd = Console.ReadLine();

                    while (i < len)
                    {
                        if (ReserveringenList[i].Naam == zoekNaam)
                        {
                            int hour = Convert.ToInt32(new_EindTijd[0] + new_EindTijd[1]);
                            int minutes = Convert.ToInt32(new_EindTijd[3] + new_EindTijd[4]);
                            int min_hour = Convert.ToInt32(ReserveringenList[1].Tijdslot[0] + ReserveringenList[1].Tijdslot[1]);
                            int max_hour = Convert.ToInt32(ReserveringenList[1].Tijdslot[6] + ReserveringenList[1].Tijdslot[7]);

                            if (hour < max_hour && hour >= min_hour && minutes < 60)
                            {
                                Console.WriteLine();
                                ReserveringenList[i].Eindtijd = new_EindTijd;
                                str = $"{reserveringsNaam} is vertrokken om {new_EindTijd} uur.";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[1] Doorgaan";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                Console.CursorLeft = Console.WindowWidth / 2;
                                ConsoleKeyInfo keus = Console.ReadKey();
                                if (keus.Key == ConsoleKey.D1)
                                {
                                    JsonData = JsonConvert.SerializeObject(ReserveringenList);
                                    System.IO.File.WriteAllText(ReserveringPath, JsonData);
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                                else
                                {
                                    str = $"Er is een fout, probeer opnieuw.";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    str = $"[0] Terug";
                                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                    ConsoleKeyInfo teruglkey = Console.ReadKey();
                                    if (teruglkey.Key == ConsoleKey.D0)
                                    {
                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                    else
                                    {
                                        if (gebruiker == "admin")
                                        {
                                            Admin.adminMain();
                                        }
                                        else if (gebruiker == "personeel")
                                        {
                                            Personeelsleden.personeelMain(gebruikerNaam);
                                        }
                                        else
                                        {
                                            Program.Main();
                                        }
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                                str = $"Ingevulde tijd is geen echte tijd of valt buiten {ReserveringenList[i].Naam}'s";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "gereserveerde tijdslot";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                str = "[1] Opnieuw proberen";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                Console.WriteLine();
                                str = "[0] Terug";
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                                Console.CursorLeft = Console.WindowWidth / 2;
                                ConsoleKeyInfo keus = Console.ReadKey();
                                if (keus.Key == ConsoleKey.D1)
                                {
                                    WijzigReservering(gebruikerNaam);
                                }
                                else if (keus.Key == ConsoleKey.D0 && gebruiker == "admin")
                                {
                                    Admin.adminMain();
                                }
                                else if (keus.Key == ConsoleKey.D0 && gebruiker == "personeel")
                                {
                                    Personeelsleden.personeelMain(gebruikerNaam);
                                }
                            }
                        }
                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                str = "Verkeerde input.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));

                Console.WriteLine("");
                str = "[0] Terug.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.ReadKey();
                if (gebruiker == "admin")
                {
                    Admin.adminMain();
                }
                else if ( gebruiker == "personeel")
                {
                    Personeelsleden.personeelMain(gebruikerNaam);
                }
                else
                {
                    WijzigReservering(gebruikerNaam);
                }
            }
        }

        public static void verwijderReservering(string gebruikerNaam, string gebruiker = "niet ingelogd")
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
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘           \n");
            string str = "|Reservering annuleren|";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.WriteLine();
            str = "Reserveringsnaam:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
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
                Console.WriteLine();
                str = "Een reservering onder de gegeven naam bestaat niet.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Probeer opnieuw";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.WriteLine();
                str = "[0] Terug";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                Console.WriteLine(gebruiker);
                if (rkey.Key == ConsoleKey.D1 && gebruiker == "niet ingelogd")
                {
                    Program.Main();
                }
                else if (rkey.Key == ConsoleKey.D0 && gebruiker == "admin")
                {
                    Admin.adminMain();
                }
                else if (rkey.Key == ConsoleKey.D0 && gebruiker == "personeel")
                {
                    Personeelsleden.personeelMain(gebruikerNaam);
                }
            }
           
            Console.WriteLine();
            str = $"Weet u zeker dat u de reservering onder de naam, '{reserveringNaam}', wilt annuleren?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[1] Ja";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            str = "[2] Nee";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (ReserveringenList[i].Naam == zoekNaam)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        ReserveringenList.RemoveAt(i);
                        str = $"De reservering onder de naam, '{zoekNaam}', is geannuleerd.";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));

                        count++;
                        break;
                    }
                    i++;
                }
            }

            JsonData = JsonConvert.SerializeObject(ReserveringenList);
            System.IO.File.WriteAllText(ReserveringPath, JsonData);

            str = "[1] Doorgaan";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            ConsoleKeyInfo keus = Console.ReadKey();
            Console.CursorLeft = Console.WindowWidth / 2;
            if (keus.Key == ConsoleKey.D1 && gebruiker == "niet ingelogd")
            {
                Program.Main();
            }
            else if (keus.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                Admin.adminMain();
            }
            else if (keus.Key == ConsoleKey.D1  && gebruiker == "personeel")
            {
                Personeelsleden.personeelMain(gebruikerNaam);
            }
        }

        public static void bekijkReservering(string gebruikerNaam)
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
            Console.WriteLine("                                                    ┌─────────────┐            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $$$$$ $     │            ");
            Console.WriteLine("                                                    │ $   $ $     │            ");
            Console.WriteLine("                                                    │ $   $ $$$$$ │            ");
            Console.WriteLine("                                                    └─────────────┘           \n");
            string str = "|Reservering bekijken|";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.WriteLine();
            str = "Reserveringsnaam:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
            Console.CursorLeft = Console.WindowWidth / 2;
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
                Console.WriteLine();
                str = $"Een reservering onder de naam '{zoekNaam}' bestaat niet.";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[1] Probeer opnieuw";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                str = "[2] Maak nieuwe reservering aan";
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                Console.CursorLeft = Console.WindowWidth / 2;
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    bekijkReservering(gebruikerNaam);
                }
                else if (rkey.Key == ConsoleKey.D2)
                {
                    AddReservering();
                }
                else
                {
                    bekijkReservering(gebruikerNaam);
                }
            }
            foreach (Reserveringenjson reservering in ReserveringenList)
            {
                if (reservering.Naam == zoekNaam)
                {
                    Console.WriteLine();
                    str = $"Voornaamwoorden: {reservering.Voornaamwoorden}";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = $"Groepsgrote: {reservering.Groepsgrote}";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = $"Tijdslot: {reservering.Tijdslot}";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    str = $"Datum: {reservering.Datum}";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.WriteLine();
                    Console.WriteLine();
                    str = "[1] Opnieuw een reservering bekijken";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.WriteLine();
                    str = "[0] Terug naar menu";
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (str.Length / 2)) + "}", str));
                    Console.CursorLeft = Console.WindowWidth / 2;
                    ConsoleKeyInfo keus = Console.ReadKey();
                    if (keus.Key == ConsoleKey.D1)
                    {
                        bekijkReservering(gebruikerNaam);
                    }
                    else
                    {
                        Personeelsleden.reserverenMain(gebruikerNaam);
                    }
                }

            }

        }
    }
}