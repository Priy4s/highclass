using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Main

{
    public class Menu
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public string Allergie { get; set; }
        public string Categorie { get; set; }
        public int ID { get; set; }

    }

    public class getMenu
    {
        public static void gettingMenu(string gebruikerNaam, string gebruiker = "nietIngelogd") //default is niet ingelogd, bij oproepen parameter opgeven zoals "admin" of "personeel"
        {

            {
                string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

                var JsonData = File.ReadAllText(menuPath);
                var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();
                bool menurunnen = true;
                while (menurunnen)
                {
                    Console.Clear();
                    Console.WriteLine("╒══════════════════════════╕");
                    Console.WriteLine("\n Menukaart\n");
                    Console.WriteLine("[1] Brunch");
                    Console.WriteLine("[2] Lunch");
                    Console.WriteLine("[3] Diner");
                    Console.WriteLine("[4] Drinken");
                    Console.WriteLine("[5] Allergieën informatie");
                    Console.WriteLine("[0] Terug");
                    Console.WriteLine("╘═══════════════════════════╛");
                    ConsoleKeyInfo mainMenu = Console.ReadKey();

                    if (mainMenu.Key == ConsoleKey.D1)
                    {
                        bool brunch = true;
                        while (brunch)
                        {
                            Console.Clear();
                            Console.WriteLine("╒═════════════════════════════════════════════════════╕");
                            Console.WriteLine(" Brunch\n");

                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "Brunch")

                                    Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs} {menuItem.Allergie} ");
                                if (gebruiker == "personeel" && menuItem.Categorie == "Brunch" || gebruiker == "admin" && menuItem.Categorie == "Brunch")
                                {
                                    Console.WriteLine($" {menuItem.ID}");
                                }

                            }

                            Console.WriteLine("\n [0] Terug");
                            Console.WriteLine("╘═════════════════════════════════════════════════════╛");
                            ConsoleKeyInfo terugBrunch = Console.ReadKey();

                            if (terugBrunch.Key == ConsoleKey.D0)
                            {
                                brunch = false;
                            }

                        }
                    }
                    else if (mainMenu.Key == ConsoleKey.D2)
                    {
                        bool lunch = true;
                        while (lunch)
                        {
                            Console.Clear();
                            Console.WriteLine("╒════════════════════════════════════════════════════════╕");
                            Console.WriteLine(" Lunch\n");


                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "Lunch")
                                    Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                if (gebruiker == "personeel" && menuItem.Categorie == "Lunch" || gebruiker == "admin" && menuItem.Categorie == "Lunch")
                                {
                                    Console.WriteLine($" {menuItem.ID}");
                                }
                            }
                            Console.WriteLine("\n Soepen: ");

                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "LunchSoep")
                                    Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                if (gebruiker == "personeel" && menuItem.Categorie == "LunchSoep" || gebruiker == "admin" && menuItem.Categorie == "LunchSoep")
                                {
                                    Console.WriteLine($" {menuItem.ID}");
                                }
                            }
                            Console.WriteLine("\n [0] Terug");
                            Console.WriteLine("╘════════════════════════════════════════════════════════╛");

                            ConsoleKeyInfo lunchkey = Console.ReadKey();

                            if (lunchkey.Key == ConsoleKey.D0)
                            {
                                lunch = false;
                            }
                        }

                    }
                    else if (mainMenu.Key == ConsoleKey.D3)
                    {
                        bool dinerMenu = true;
                        while (dinerMenu)
                        {
                            Console.Clear();
                            Console.WriteLine("╒════════════════════╕");
                            Console.WriteLine(" Diner");
                            Console.WriteLine(" [1] Voorgerechten");
                            Console.WriteLine(" [2] Hoofdgerechten");
                            Console.WriteLine(" [3] Nagerechten");
                            Console.WriteLine(" [0] Terug");
                            Console.WriteLine("╘════════════════════╛");
                            ConsoleKeyInfo dinerkey = Console.ReadKey();

                            if (dinerkey.Key == ConsoleKey.D0)
                            {
                                dinerMenu = false;
                            }

                            else if (dinerkey.Key == ConsoleKey.D1)
                            {
                                bool voorgerecht = true;
                                while (voorgerecht)
                                {
                                    Console.Clear();
                                    Console.WriteLine("╒══════════════════════════════════════════╕");
                                    Console.WriteLine(" Voorgerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerVoorgerecht")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DinerVoorgerecht" || gebruiker == "admin" && menuItem.Categorie == "DinerVoorgerecht")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n Soepen: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerSoep")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DinerSoep" || gebruiker == "admin" && menuItem.Categorie == "DinerSoep")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n [0] Terug");
                                    Console.WriteLine("╘══════════════════════════════════════════╛");

                                    ConsoleKeyInfo voorgerechtterug = Console.ReadKey();

                                    if (voorgerechtterug.Key == ConsoleKey.D0)
                                    {
                                        voorgerecht = false;
                                    }
                                }
                            }
                            else if (dinerkey.Key == ConsoleKey.D2)
                            {
                                bool hoofgerecht = true;
                                while (hoofgerecht)
                                {
                                    Console.Clear();
                                    Console.WriteLine("╒══════════════════════════════════════════╕");
                                    Console.WriteLine(" Hoofdgerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerHoofdgerecht")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DinerHoofdgerecht" || gebruiker == "admin" && menuItem.Categorie == "DinerHoofdgerecht")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n Sushi: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerSushi")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DinerSushi" || gebruiker == "admin" && menuItem.Categorie == "DinerSushi")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n [0] Terug");
                                    Console.WriteLine("╘══════════════════════════════════════════╛");
                                    ConsoleKeyInfo hoofdterug = Console.ReadKey();


                                    if (hoofdterug.Key == ConsoleKey.D0)
                                    {
                                        hoofgerecht = false;
                                    }
                                }
                            }

                            else if (dinerkey.Key == ConsoleKey.D3)
                            {
                                bool nagerecht = true;
                                while (nagerecht)
                                {
                                    Console.Clear();
                                    Console.WriteLine("╒══════════════════════════════════════════╕");
                                    Console.WriteLine(" Nagerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerNagerecht")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DinerNagerecht" || gebruiker == "admin" && menuItem.Categorie == "DinerNagerecht")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n [0] Terug");
                                    Console.WriteLine("╘══════════════════════════════════════════╛");
                                    ConsoleKeyInfo nagerechtterug = Console.ReadKey();


                                    if (nagerechtterug.Key == ConsoleKey.D0)
                                    {
                                        nagerecht = false;
                                    }

                                }
                            }
                        }
                    }
                    else if (mainMenu.Key == ConsoleKey.D4)
                    {
                        Console.Clear();
                        bool drinken = true;
                        while (drinken)
                        {
                            Console.WriteLine("╒════════════════════════════════╕");
                            Console.WriteLine("\n Drinken\n");
                            Console.WriteLine(" [1] Non alcoholische dranken");
                            Console.WriteLine(" [2] Alcoholische dranken (A)");
                            Console.WriteLine(" [0] Terug");
                            Console.WriteLine("╘════════════════════════════════╛");
                            ConsoleKeyInfo drankkeus = Console.ReadKey();
                            //Warme dranken
                            if (drankkeus.Key == ConsoleKey.D0)
                            {
                                drinken = false;
                            }
                            else if (drankkeus.Key == ConsoleKey.D1)
                            {
                                bool noAlcohol = true;
                                while (noAlcohol)
                                {
                                    Console.Clear();
                                    Console.WriteLine("╒══════════════════════════════════════════╕");
                                    Console.WriteLine(" Warme drankjes: ");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenWarm")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DrinkenWarm" || gebruiker == "admin" && menuItem.Categorie == "DrinkenWarm")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n Koude drankjes: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenKoud")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DrinkenKoud" || gebruiker == "admin" && menuItem.Categorie == "DrinkenKoud")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine("\n [0] Terug");
                                    Console.WriteLine("╘══════════════════════════════════════════╛");
                                    ConsoleKeyInfo noalcoholterug = Console.ReadKey();

                                    if (noalcoholterug.Key == ConsoleKey.D0)
                                    {
                                        noAlcohol = false;
                                        Console.Clear();
                                    }

                                } //einde no alcohol loop
                            }
                            else if (drankkeus.Key == ConsoleKey.D2)
                            {

                                bool alcohol = true;
                                while (alcohol)
                                {
                                    Console.Clear();
                                    Console.WriteLine("╒══════════════════════════════════════════╕");
                                    Console.WriteLine(" Alcoholische drankjes");
                                    Console.WriteLine(" Bier:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenBier")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DrinkenBier" || gebruiker == "admin" && menuItem.Categorie == "DrinkenBier")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine(" Wijn:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenWijn")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DrinkenWijn" || gebruiker == "admin" && menuItem.Categorie == "DrinkenWijn")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }
                                    Console.WriteLine(" Cocktail:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenCocktail")
                                            Console.WriteLine($" {menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                        if (gebruiker == "personeel" && menuItem.Categorie == "DrinkenCocktail")
                                        {
                                            Console.WriteLine($" {menuItem.ID}");
                                        }
                                    }

                                    Console.WriteLine("\n [0] Terug");
                                    Console.WriteLine("╘══════════════════════════════════════════╛");
                                    ConsoleKeyInfo alcoholterug = Console.ReadKey();
                                    if (alcoholterug.Key == ConsoleKey.D0)
                                    {
                                        alcohol = false;
                                        Console.Clear();
                                    }
                                }
                            }
                        }// drinken 

                    }// einde loop drinken
                    if (mainMenu.Key == ConsoleKey.D5)
                    {
                        bool allergie = true;
                        while (allergie)
                        {

                            Console.Clear();
                            Console.WriteLine("╒═════════════════════════════════╕");
                            Console.WriteLine("   Allergieën informatie\n");
                            Console.WriteLine("         V - Vegan");
                            Console.WriteLine("         N - Bevat noten");
                            Console.WriteLine("         L - Lactose vrij");
                            Console.WriteLine("         G - Gluten vrij");
                            Console.WriteLine("         A - Bevat alocohol");
                            Console.WriteLine("\n         [0] Terug");
                            Console.WriteLine("╘════════════════════════════════╛");
                            ConsoleKeyInfo allergieterug = Console.ReadKey();
                            if (allergieterug.Key == ConsoleKey.D0)
                            {
                                allergie = false;
                                Console.Clear();
                            }
                        }
                    }
                    else if (mainMenu.Key == ConsoleKey.D0 && gebruiker == "nietIngelogd")
                    {
                        menurunnen = false;
                    }
                    else if (mainMenu.Key == ConsoleKey.D0 && gebruiker == "personeel")
                    {
                        Personeelsleden.menuMain(gebruikerNaam,"personeel");
                    }
                    else if (mainMenu.Key == ConsoleKey.D0 && gebruiker == "admin")
                    {
                        Personeelsleden.menuMain(gebruikerNaam, "admin");
                    }
                }

            }
        }
    }
    public class MenuAanpassen
    {
        public static void mainAanpassen(string gebruikerNaam, string gebruiker = "personeel")
        {
            Console.Clear();
            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("[1] Menu Item verwijderen \n[2] Menu Item toevoegen\n[3] Menu Item wijzigen\n[0] Terug");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo readkey = Console.ReadKey();

            if (readkey.Key == ConsoleKey.D1)
            {
                verwijderen(gebruikerNaam,gebruiker);
            }
            if (readkey.Key == ConsoleKey.D2)
            {
                toevoegen(gebruikerNaam, gebruiker);
            }
            if (readkey.Key == ConsoleKey.D3)
            {
                wijzigen(gebruikerNaam, gebruiker);
            }
            if (readkey.Key == ConsoleKey.D4){

            }
        }
        public static void verwijderen(string gebruikerNaam, string gebruiker = "personeel")
        {
            Console.Clear();
            string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

            var JsonData = File.ReadAllText(menuPath);
            var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();

            Console.WriteLine("╒══════════════════════════════╕");
            Console.WriteLine("Wat is Menu Item ID?");
            string strzoekID = Console.ReadLine();

            bool isIDAlleenNummers = char.IsNumber(strzoekID, 0);
            for (int j = 0; j < strzoekID.Length; j++)
            {
                isIDAlleenNummers = char.IsNumber(strzoekID, j);
                if (isIDAlleenNummers == false)
                {
                    break;
                }
            }

            while (!isIDAlleenNummers)
            {
                Console.WriteLine("\nMenu Item ID bestaat alleen uit nummer.\nProbeer opnieuw.");
                Console.WriteLine("Wat is Menu Item ID?");
                strzoekID = Console.ReadLine();

                for (int j = 0; j < strzoekID.Length; j++)
                {
                    isIDAlleenNummers = char.IsNumber(strzoekID, j);
                    if (isIDAlleenNummers == false)
                    {
                        break;
                    }
                }
            }
            int zoekID = Convert.ToInt32(strzoekID);

            int len = menuList.Count;
            int i = 0;
            int count = 0;
            string naamGerecht = "";
            foreach (Menu menuItem in menuList)
            {
                if (menuItem.ID == zoekID)
                    naamGerecht = menuItem.Naam;
            }
            Console.WriteLine("Weet je zeker dat je: " + naamGerecht +  " wil verwijderen?");
            Console.WriteLine("[1] Ja\n[2] Nee");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                while (i < len)
                {
                    if (menuList[i].ID == zoekID)
                    {
                        menuList.RemoveAt(i);
                        Console.WriteLine($"Menu Item met ID {zoekID} is verwijderd");

                        count++;
                        break;
                    }
                    i++;
                }

                if (count == 0)
                {
                    Console.WriteLine("Menu Item ID bestaat niet. Probeer opnieuw.");
                    Console.WriteLine("[1] Opnieuw proberen\n[0] Terug");
                    ConsoleKeyInfo keuzekey = Console.ReadKey();
                    if(keuzekey.Key == ConsoleKey.D1)
                    {
                        verwijderen(gebruikerNaam);
                    }
                    else
                    {
                        mainAanpassen(gebruikerNaam);
                    }
                }
            }
            else
            {
                mainAanpassen(gebruikerNaam);
            }

            JsonData = JsonConvert.SerializeObject(menuList);
            System.IO.File.WriteAllText(menuPath, JsonData);

            Console.WriteLine("Succesvol verwijderd!");
            Console.WriteLine("[1] Doorgaan");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1 && gebruiker == "personeel")
            {
                Personeelsleden.menuMain(gebruikerNaam);
            }
            else if(keus.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                Admin.adminMain();
            }

        }
        public static void toevoegen(string gebruikerNaam, string gebruiker = "personeel")
        {
            Console.Clear();
            string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

            var JsonData = File.ReadAllText(menuPath);
            var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();


            Console.WriteLine("╒══════════════════════════════════════════════════════════════╕");
            Console.WriteLine("Welke ID heeft het nieuwe Menu Item?");
            string strID_IN = Console.ReadLine();
            
            bool isIDAlleenNummers = char.IsNumber(strID_IN, 0);
            for (int i = 0; i < strID_IN.Length; i++)
            {
                isIDAlleenNummers = char.IsNumber(strID_IN, i);
                if (isIDAlleenNummers == false)
                {
                    break;
                }
            }
            
            while (!isIDAlleenNummers)
            {
                Console.WriteLine("\nMenu Item ID bestaat alleen uit nummer.\nProbeer opnieuw.");
                Console.WriteLine("\nWelke ID heeft het nieuwe Menu Item?");
                strID_IN = Console.ReadLine();

                for (int i = 0; i < strID_IN.Length; i++)
                {
                    isIDAlleenNummers = char.IsNumber(strID_IN, i);
                    if (isIDAlleenNummers == false)
                    {
                        break;
                    }
                }
            }

            int ID_IN = Convert.ToInt32(strID_IN);
            foreach (Menu menuItem in menuList)
            {
                if (menuItem.ID == ID_IN)
                {
                    Console.WriteLine($"Menu Item met ID {ID_IN} bestaat al probeer opnieuw druk op [0]");
                    ConsoleKeyInfo readkey = Console.ReadKey();
                    if (readkey.Key == ConsoleKey.D0)
                    {
                        toevoegen(gebruiker);
                    }
                    else
                    {
                        toevoegen(gebruiker);
                    }
                }
            }

            Console.WriteLine("Wat is de naam van het nieuwe Menu Item?");
            string NaamIN = Console.ReadLine();
            
            bool isNaamCijfers = char.IsNumber(NaamIN, 0);
            bool isNaamLetters =  char.IsLetter(NaamIN, 0);
            for (int i = 0; i < NaamIN.Length; i++)
            {
                isNaamCijfers = char.IsNumber(NaamIN, i);
                if (isNaamCijfers == false)
                {
                    break;
                }
                if(isNaamLetters == false)
                {
                    break;
                }
            }

            while (!isNaamCijfers && !isNaamLetters)
            {
                Console.WriteLine("\nNaam voldoet niet aan de eisen. Alleen letters en/of cijfers.\nProbeer opnieuw.");
                Console.WriteLine("\nWat is de naam van het neiuwe Menu Item?");
                NaamIN = Console.ReadLine();

                for (int i = 0; i < NaamIN.Length; i++)
                {
                    isNaamCijfers = char.IsNumber(NaamIN, i);
                    if (isNaamCijfers == false)
                    {
                        break;
                    }
                    if (isNaamLetters == false)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Wat is de prijs van het nieuwe Menu Item?");
            string strPrijsIN = Console.ReadLine();

            bool isPrijsAlleenNummers = char.IsNumber(strPrijsIN, 0);
            for (int i = 0; i < strPrijsIN.Length; i++)
            {
                isIDAlleenNummers = char.IsNumber(strPrijsIN, i);
                if (isIDAlleenNummers == false)
                {
                    break;
                }
            }

            while (!isPrijsAlleenNummers)
            {
                Console.WriteLine("\nPrijs bestaat alleen uit nummers. Probeer opnieuw.");
                Console.WriteLine("\nWat is de prijs van het nieuwe Menu Item?");
                strPrijsIN = Console.ReadLine();

                for (int i = 0; i < strPrijsIN.Length; i++)
                {
                    isIDAlleenNummers = char.IsNumber(strPrijsIN, i);
                    if (isIDAlleenNummers == false)
                    {
                        break;
                    }
                }
            }
            double PrijsIN = Convert.ToDouble(strPrijsIN);


            Console.WriteLine("Welke allergenen komen er in het nieuwe Menu Item voor?");
            Console.WriteLine("\t[V] - Vegan");
            Console.WriteLine("\t[N] - Bevat noten");
            Console.WriteLine("\t[L] - Lactose vrij");
            Console.WriteLine("\t[G] - Gluten vrij");
            Console.WriteLine("\t[A] - Bevat alocohol");
            Console.WriteLine("\t[0] geen allergenen informatie ");
            ConsoleKeyInfo allorgenenINFO = Console.ReadKey();
            string allorgieIN = "";
            if (allorgenenINFO.Key == ConsoleKey.V)
            {
                allorgieIN = "V";
            }
            else if (allorgenenINFO.Key == ConsoleKey.N)
            {
                allorgieIN = "N";
            }
            else if (allorgenenINFO.Key == ConsoleKey.L)
            {
                allorgieIN = "L";
            }
            else if (allorgenenINFO.Key == ConsoleKey.G)
            {
                allorgieIN = "G";
            }
            else if (allorgenenINFO.Key == ConsoleKey.A)
            {
                allorgieIN = "A";
            }
            else if (allorgenenINFO.Key == ConsoleKey.D0)
            {
                allorgieIN = " ";
            }

            while (allorgieIN == "")
            {
                Console.WriteLine("\nProbeer opnieuw");
                Console.WriteLine("Welke allergenen komen er in het nieuwe Menu Item voor?");
                Console.WriteLine("\t[V] - Vegan");
                Console.WriteLine("\t[N] - Bevat noten");
                Console.WriteLine("\t[L] - Lactose vrij");
                Console.WriteLine("\t[G] - Gluten vrij");
                Console.WriteLine("\t[A] - Bevat alocohol");
                Console.WriteLine("\t[0] geen allergenen informatie ");
                allorgenenINFO = Console.ReadKey();
                if (allorgenenINFO.Key == ConsoleKey.V)
                {
                    allorgieIN = "V";
                }
                else if (allorgenenINFO.Key == ConsoleKey.N)
                {
                    allorgieIN = "N";
                }
                else if (allorgenenINFO.Key == ConsoleKey.L)
                {
                    allorgieIN = "L";
                }
                else if (allorgenenINFO.Key == ConsoleKey.G)
                {
                    allorgieIN = "G";
                }
                else if (allorgenenINFO.Key == ConsoleKey.A)
                {
                    allorgieIN = "A";
                }
                else if (allorgenenINFO.Key == ConsoleKey.D0)
                {
                    allorgieIN = " ";
                }
            }


            Console.WriteLine("Wat wordt de nieuwe categorie van dit Menu Item?\n\t[1] Brunch\n\t[2] Lunch\n\t[3] LunchSoep\n\t[4] DinerVoorgerecht\n\t[5] DinerSoep\n\t[6] DinerHoofdgerecht\n\t[7] DinerSushi\n\t[8] DinerNagerecht\n\t[9] DrinkenWarm\n\t[10] DrinkenKoud\n\t[11] DrinkenBier\n\t[12] DrinkenWijn\n\t[13] DrinkenCocktail");
            string strCategorieMenu = Console.ReadLine();
            string New_Categorie = "";

            bool isCategorieAlleenNummers = char.IsNumber(strCategorieMenu, strCategorieMenu.Length - 1);
            while (!isCategorieAlleenNummers)
            {
                Console.WriteLine("Geef nummer van bijbehordende Menu categorie. Probeer opnieuw.");
                Console.WriteLine("Wat wordt de nieuwe categorie van dit Menu Item?\n\t[1] Brunch\n\t[2] Lunch\n\t[3] LunchSoep\n\t[4] DinerVoorgerecht\n\t[5] DinerSoep\n\t[6] DinerHoofdgerecht\n\t[7] DinerSushi\n\t[8] DinerNagerecht\n\t[9] DrinkenWarm\n\t[10] DrinkenKoud\n\t[11] DrinkenBier\n\t[12] DrinkenWijn\n\t[13] DrinkenCocktail");
                strCategorieMenu = Console.ReadLine();
                isCategorieAlleenNummers = char.IsNumber(strCategorieMenu, strCategorieMenu.Length - 1);
            }
            int CategorieMenu = Convert.ToInt32(strCategorieMenu);


            if (CategorieMenu == 1)
            {
                New_Categorie = "Brunch";
            }
            else if (CategorieMenu == 2)
            {
                New_Categorie = "Lunch";
            }
            else if (CategorieMenu == 3)
            {
                New_Categorie = "LunchSoep";
            }
            else if (CategorieMenu == 4)
            {
                New_Categorie = "DinerVoorgerecht";
            }
            else if (CategorieMenu == 5)
            {
                New_Categorie = "DinerSoep";
            }
            else if (CategorieMenu == 6)
            {
                New_Categorie = "DinerHoofdgerecht";
            }
            else if (CategorieMenu == 7)
            {
                New_Categorie = "DinerSushi";
            }
            else if (CategorieMenu == 8)
            {
                New_Categorie = "DinerNagerecht";
            }
            else if (CategorieMenu == 9)
            {
                New_Categorie = "DrinkenWarm";
            }
            else if (CategorieMenu == 10)
            {
                New_Categorie = "DrinkenKoud";
            }
            else if (CategorieMenu == 11)
            {
                New_Categorie = "DrinkenBier";
            }
            else if (CategorieMenu == 12)
            {
                New_Categorie = "DrinkenWijn";
            }
            else if (CategorieMenu == 13)
            {
                New_Categorie = "DrinkenCoktail";
            }
            else
            {
                New_Categorie = "";
            }

            while (New_Categorie == "")
            {
                Console.WriteLine("Geef nummer van bijbehordende Menu categorie. Probeer opnieuw");
                Console.WriteLine("Wat wordt de nieuwe categorie van dit Menu Item?\n\t[1] Brunch\n\t[2] Lunch\n\t[3] LunchSoep\n\t[4] DinerVoorgerecht\n\t[5] DinerSoep\n\t[6] DinerHoofdgerecht\n\t[7] DinerSushi\n\t[8] DinerNagerecht\n\t[9] DrinkenWarm\n\t[10] DrinkenKoud\n\t[11] DrinkenBier\n\t[12] DrinkenWijn\n\t[13] DrinkenCocktail");
                CategorieMenu = Convert.ToInt32(Console.ReadLine());
                if (CategorieMenu == 1)
                {
                    New_Categorie = "Brunch";
                }
                else if (CategorieMenu == 2)
                {
                    New_Categorie = "Lunch";
                }
                else if (CategorieMenu == 3)
                {
                    New_Categorie = "LunchSoep";
                }
                else if (CategorieMenu == 4)
                {
                    New_Categorie = "DinerVoorgerecht";
                }
                else if (CategorieMenu == 5)
                {
                    New_Categorie = "DinerSoep";
                }
                else if (CategorieMenu == 6)
                {
                    New_Categorie = "DinerHoofdgerecht";
                }
                else if (CategorieMenu == 7)
                {
                    New_Categorie = "DinerSushi";
                }
                else if (CategorieMenu == 8)
                {
                    New_Categorie = "DinerNagerecht";
                }
                else if (CategorieMenu == 9)
                {
                    New_Categorie = "DrinkenWarm";
                }
                else if (CategorieMenu == 10)
                {
                    New_Categorie = "DrinkenKoud";
                }
                else if (CategorieMenu == 11)
                {
                    New_Categorie = "DrinkenBier";
                }
                else if (CategorieMenu == 12)
                {
                    New_Categorie = "DrinkenWijn";
                }
                else if (CategorieMenu == 13)
                {
                    New_Categorie = "DrinkenCoktail";
                }
                else
                {
                    New_Categorie = "";
                }
            }

            menuList.Add(new Menu()
            {
                Naam = NaamIN,
                Prijs = PrijsIN,
                Allergie = allorgieIN,
                Categorie = New_Categorie,
                ID = ID_IN,
            });

            JsonData = JsonConvert.SerializeObject(menuList);
            System.IO.File.WriteAllText(menuPath, JsonData);

            Console.WriteLine($"Het nieuwe Menu Item met de naam {NaamIN} is toegevoegd aan Menu?\n[1] doorgaan");
            Console.WriteLine("╘══════════════════════════════════════════════════════════════════╛");
            ConsoleKeyInfo doorKey = Console.ReadKey();
            if (doorKey.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                Admin.adminMain();
            }
            else if (doorKey.Key == ConsoleKey.D1 && gebruiker == "personeel")
            {
                Personeelsleden.personeelMain(gebruikerNaam);
            }
        }

        public static void wijzigen(string gebruikerNaam, string gebruiker = "ingelogd")
        {
            Console.Clear();
            string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

            var JsonData = File.ReadAllText(menuPath);
            var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();

            Console.WriteLine("Welke ID heeft het nieuwe Menu Item?");
            string strzoekID = Console.ReadLine();

            bool isIDAlleenNummers = char.IsNumber(strzoekID, 0);
            for (int j = 0; j < strzoekID.Length; j++)
            {
                isIDAlleenNummers = char.IsNumber(strzoekID, j);
                if (isIDAlleenNummers == false)
                {
                    break;
                }
            }

            while (!isIDAlleenNummers)
            {
                Console.WriteLine("\nMenu Item ID bestaat alleen uit nummer.\nProbeer opnieuw.");
                Console.WriteLine("Wat is Menu Item ID?");
                strzoekID = Console.ReadLine();

                for (int j = 0; j < strzoekID.Length; j++)
                {
                    isIDAlleenNummers = char.IsNumber(strzoekID, j);
                    if (isIDAlleenNummers == false)
                    {
                        break;
                    }
                }
            }
            int MenuID = Convert.ToInt32(strzoekID);

            int len = menuList.Count;
            int i = 0;
            string MenuItem = "";
            foreach (Menu item in menuList)
            {
                if (item.ID == MenuID)
                {
                    MenuItem = $"{item.ID}";
                }
            }
            if (MenuItem == "")
            {
                Console.WriteLine($"Menu item met {MenuID} bestaat niet. \n[1] Probeer opnieuw.");
                ConsoleKeyInfo rkey = Console.ReadKey();
                if (rkey.Key == ConsoleKey.D1)
                {
                    wijzigen(gebruikerNaam, gebruiker);
                }
                else
                {
                    wijzigen(gebruikerNaam, gebruiker);
                }
            }

            bool menukeyCheck = false;
            while (menukeyCheck == false)
            {
                Console.WriteLine("\nWat wilt u veranderen?\n\t[1] Naam Menu Item\n\t[2] Prijs Menu Item\n\t[3] Allergie Menu Item\n\t[4] Catogorie Menu Item");
                ConsoleKeyInfo menukey = Console.ReadKey();
                if (menukey.Key == ConsoleKey.D1)
                {
                    menukeyCheck = true;
                    Console.WriteLine("Wat wordt de nieuwe naam van dit Menu Item?");
                    string New_Naam = Console.ReadLine();

                    while (i < len)
                    {
                        if (menuList[i].ID == MenuID)
                        {
                            menuList[i].Naam = New_Naam;
                            Console.WriteLine($"Menu items naam is gewijzigd naar {New_Naam}");
                            break;
                        }
                        i++;
                    }
                }
                else if (menukey.Key == ConsoleKey.D2)
                {
                    menukeyCheck = true;
                    Console.WriteLine("Wat wordt de nieuwe prijs van dit Menu Item?");
                    double New_Prijs = Convert.ToDouble(Console.ReadLine());

                    while (i < len)
                    {
                        if (menuList[i].ID == MenuID)
                        {
                            menuList[i].Prijs = New_Prijs;
                            Console.WriteLine($"Menu items naam is gewijzigd naar {New_Prijs}");
                            break;
                        }
                        i++;
                    }
                }
                else if (menukey.Key == ConsoleKey.D3)
                {
                    menukeyCheck = true;
                    Console.WriteLine("Welke allergenen komen er in het nieuwe Menu Item voor?");
                    Console.WriteLine("\t[V] - Vegan");
                    Console.WriteLine("\t[N] - Bevat noten");
                    Console.WriteLine("\t[L] - Lactose vrij");
                    Console.WriteLine("\t[G] - Gluten vrij");
                    Console.WriteLine("\t[A] - Bevat alocohol");
                    Console.WriteLine("\t[0] geen allergenen informatie ");
                    ConsoleKeyInfo allorgenenINFO = Console.ReadKey();
                    string New_allergie = "";
                    if (allorgenenINFO.Key == ConsoleKey.V)
                    {
                        New_allergie = "V";
                    }
                    else if (allorgenenINFO.Key == ConsoleKey.N)
                    {
                        New_allergie = "N";
                    }
                    else if (allorgenenINFO.Key == ConsoleKey.L)
                    {
                        New_allergie = "L";
                    }
                    else if (allorgenenINFO.Key == ConsoleKey.G)
                    {
                        New_allergie = "G";
                    }
                    else if (allorgenenINFO.Key == ConsoleKey.A)
                    {
                        New_allergie = "A";
                    }
                    else if (allorgenenINFO.Key == ConsoleKey.D0)
                    {
                        New_allergie = " ";
                    }

                    while (New_allergie == "")
                    {
                        Console.WriteLine("\nProbeer opnieuw");
                        Console.WriteLine("Welke allergenen komen er in het nieuwe Menu Item voor?");
                        Console.WriteLine("\t[V] - Vegan");
                        Console.WriteLine("\t[N] - Bevat noten");
                        Console.WriteLine("\t[L] - Lactose vrij");
                        Console.WriteLine("\t[G] - Gluten vrij");
                        Console.WriteLine("\t[A] - Bevat alocohol");
                        Console.WriteLine("\t[0] geen allergenen informatie ");
                        allorgenenINFO = Console.ReadKey();
                        if (allorgenenINFO.Key == ConsoleKey.V)
                        {
                            New_allergie = "V";
                        }
                        else if (allorgenenINFO.Key == ConsoleKey.N)
                        {
                            New_allergie = "N";
                        }
                        else if (allorgenenINFO.Key == ConsoleKey.L)
                        {
                            New_allergie = "L";
                        }
                        else if (allorgenenINFO.Key == ConsoleKey.G)
                        {
                            New_allergie = "G";
                        }
                        else if (allorgenenINFO.Key == ConsoleKey.A)
                        {
                            New_allergie = "A";
                        }
                        else if (allorgenenINFO.Key == ConsoleKey.D0)
                        {
                            New_allergie = " ";
                        }
                    }

                    while (i < len)
                    {
                        if (menuList[i].ID == MenuID)
                        {
                            menuList[i].Allergie = New_allergie;
                            Console.WriteLine($"Menu items naam is gewijzigd naar {New_allergie}");
                            break;
                        }
                        i++;
                    }
                }
                else if (menukey.Key == ConsoleKey.D4)
                {
                    menukeyCheck = true;
                    Console.WriteLine("Wat wordt de nieuwe categorie van dit Menu Item?\n\t[1] Brunch\n\t[2] Lunch\n\t[3] LunchSoep\n\t[4] DinerVoorgerecht\n\t[5] DinerSoep\n\t[6] DinerHoofdgerecht\n\t[7] DinerSushi\n\t[8] DinerNagerecht\n\t[9] DrinkenWarm\n\t[10] DrinkenKoud\n\t[11] DrinkenBier\n\t[12] DrinkenWijn\n\t[13] DrinkenCocktail");
                    int CategorieMenu = Convert.ToInt32(Console.ReadLine());
                    string New_Categorie = "";
                    if (CategorieMenu == 1)
                    {
                        New_Categorie = "Brunch";
                    }
                    else if (CategorieMenu == 2)
                    {
                        New_Categorie = "Lunch";
                    }
                    else if (CategorieMenu == 3)
                    {
                        New_Categorie = "LunchSoep";
                    }
                    else if (CategorieMenu == 4)
                    {
                        New_Categorie = "DinerVoorgerecht";
                    }
                    else if (CategorieMenu == 5)
                    {
                        New_Categorie = "DinerSoep";
                    }
                    else if (CategorieMenu == 6)
                    {
                        New_Categorie = "DinerHoofdgerecht";
                    }
                    else if (CategorieMenu == 7)
                    {
                        New_Categorie = "DinerSushi";
                    }
                    else if (CategorieMenu == 8)
                    {
                        New_Categorie = "DinerNagerecht";
                    }
                    else if (CategorieMenu == 9)
                    {
                        New_Categorie = "DrinkenWarm";
                    }
                    else if (CategorieMenu == 10)
                    {
                        New_Categorie = "DrinkenKoud";
                    }
                    else if (CategorieMenu == 11)
                    {
                        New_Categorie = "DrinkenBier";
                    }
                    else if (CategorieMenu == 12)
                    {
                        New_Categorie = "DrinkenWijn";
                    }
                    else if (CategorieMenu == 13)
                    {
                        New_Categorie = "DrinkenCoktail";
                    }

                    while (i < len)
                    {
                        if (menuList[i].ID == MenuID)
                        {
                            menuList[i].Categorie = New_Categorie;
                            Console.WriteLine($"Menu items naam is gewijzigd naar {New_Categorie}");
                            break;
                        }
                        i++;
                    }
                }
            }

            JsonData = JsonConvert.SerializeObject(menuList);
            System.IO.File.WriteAllText(menuPath, JsonData);

            Console.WriteLine("Succesvol gewijzigd!");
            Console.WriteLine("[1] Doorgaan");
            Console.WriteLine("╘══════════════════════════════╛");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1 && gebruiker == "admin")
            {
                Admin.adminMain();
            }
            else if (keus.Key == ConsoleKey.D1 && gebruiker == "personeel")
            {
                Personeelsleden.personeelMain(gebruikerNaam);
            }
        }
    }
}
