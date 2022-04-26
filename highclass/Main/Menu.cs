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
        public static void gettingMenu(string gebruiker = "nietIngelogd") //default is niet ingelogd, bij oproepen parameter opgeven zoals "admin" of "personeel"
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
                        Personeelsleden.menuMain("personeel");
                    }
                    else if (mainMenu.Key == ConsoleKey.D0 && gebruiker == "admin")
                    {
                        Personeelsleden.menuMain("admin");
                    }
                }

            }
        }
    }
    public class MenuAanpassen
    {
        public static void mainAanpassen()
        {
            Console.Clear();
            Console.WriteLine("[1] Menu Item verwijderen \n[2] Menu Item toevoegen\n");
            ConsoleKeyInfo readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.D1)
            {
                verwijderen();
            }
            if (readkey.Key == ConsoleKey.D2)
            {
                toevoegen();
            }
        }
        public static void verwijderen()
        {
            Console.Clear();
            string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

            var JsonData = File.ReadAllText(menuPath);
            var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();

            Console.WriteLine("Wat is Menu Item ID?");
            int zoekID = Convert.ToInt32(Console.ReadLine());

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
                        Console.WriteLine($"Menu Item met ID { zoekID} is verwijderd");

                        count++;
                        break;
                    }
                    i++;
                }

            }
            else
            {
                mainAanpassen();
            }


            if (count == 0)
            {
                Console.WriteLine("Menu Item ID bestaat niet. Probeer opnieuw.");
                verwijderen();
            }

            JsonData = JsonConvert.SerializeObject(menuList);
            System.IO.File.WriteAllText(menuPath, JsonData);

            Console.WriteLine("Succesvol verwijderd!");
            Console.WriteLine("[1] Doorgaan");
            ConsoleKeyInfo keus = Console.ReadKey();
            if (keus.Key == ConsoleKey.D1)
            {
                Personeelsleden.menuMain();
            }

        }
        public static void toevoegen()
        {
            Console.Clear();
            string menuPath = Path.GetFullPath(@"Menu.json"); // find path to files

            var JsonData = File.ReadAllText(menuPath);
            var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();

            Console.WriteLine("Welke ID heeft het nieuwe Menu Item?");
            int ID_IN = Convert.ToInt32(Console.ReadLine());
            foreach (Menu menuItem in menuList)
            {
                if (menuItem.ID == ID_IN)
                {
                    Console.WriteLine($"Menu Item met ID {ID_IN} bestaat al probeer opnieuw druk op [0]");
                    ConsoleKeyInfo readkey = Console.ReadKey();
                    if (readkey.Key == ConsoleKey.D0)
                    {
                        toevoegen();
                    }
                }
            }
            Console.WriteLine("Wat is de naam van het neiuwe Menu Item?");
            string NaamIN = Console.ReadLine();
            Console.WriteLine("Wat is de prijs van het nieuwe Menu Item?");
            double PrijsIN = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Welke allergenen komen er in het nieuwe Menu Item voor?");
            string allorgieIN = Console.ReadLine();
            Console.WriteLine("Wat is de catogorie van het nieuwe Menu Item?");
            string catogorieIN = Console.ReadLine();

            bool IDloop = true;
            while (IDloop)
            {



            }

            menuList.Add(new Menu()
            {
                Naam = NaamIN,
                Prijs = PrijsIN,
                Allergie = allorgieIN,
                Categorie = catogorieIN,
                ID = ID_IN,
            });
            Console.WriteLine($"Het nieuwe Menu Item met de naam {NaamIN} is toegevoegd aan Menu?");
        }
    }
}
