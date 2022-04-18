﻿using System;
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

    }

    public class getMenu
    {
        public static void gettingMenu()
        {
            
            {
                string menuPath = Path.GetFullPath(@"json1.json"); // find path to files

                var JsonData = File.ReadAllText(menuPath);
                var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();
                bool menurunnen = true;
                while (menurunnen)
                {
                    Console.Clear();
                    Console.WriteLine("\n Menukaart\n");
                    Console.WriteLine("[1] Brunch");
                    Console.WriteLine("[2] Lunch");
                    Console.WriteLine("[3] Diner");
                    Console.WriteLine("[4] Drinken");
                    Console.WriteLine("[5] Allergieën informatie");
                    Console.WriteLine("[0] Terug");

                    ConsoleKeyInfo mainMenu = Console.ReadKey();

                    if (mainMenu.Key == ConsoleKey.D1)
                    {
                        bool brunch = true;
                        while (brunch)
                        {
                            Console.Clear();
                            Console.WriteLine("Brunch\n");

                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "Brunch")
                                    Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs} {menuItem.Allergie}");
                            }

                            Console.WriteLine("\n[0] Terug");
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
                            Console.WriteLine("Lunch\n");

                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "Lunch")
                                    Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                            }
                            Console.WriteLine("\nSoepen: ");

                            foreach (Menu menuItem in menuList)
                            {
                                if (menuItem.Categorie == "LunchSoep")
                                    Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                            }
                            Console.WriteLine("\n[0] Terug");

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
                            Console.WriteLine("Diner");
                            Console.WriteLine("[1] Voorgerechten");
                            Console.WriteLine("[2] Hoofdgerechten");
                            Console.WriteLine("[3] Nagerechten");
                            Console.WriteLine("[0] Terug");
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
                                    Console.WriteLine("Voorgerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerVoorgerecht")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\nSoepen: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerSoep")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\n[0] Terug");

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
                                    Console.WriteLine("Hoofdgerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerHoofdgerecht")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\nSushi: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerSushi")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\n[0] Terug");
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
                                    Console.WriteLine("Nagerechten\n");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DinerNagerecht")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\n[0] Terug");
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
                            Console.WriteLine("\n Drinken\n");
                            Console.WriteLine("[1] Non alcoholische dranken");
                            Console.WriteLine("[2] Alcoholische dranken (A)");
                            Console.WriteLine("[0] Terug");
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
                                    Console.WriteLine("Warme drankjes: ");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenWarm")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\nKoude drankjes: ");

                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenKoud")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("\n[0] Terug");
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
                                    Console.WriteLine("Alcoholische drankjes");
                                    Console.WriteLine("Bier:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenBier")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("Wijn:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenWijn")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }
                                    Console.WriteLine("Cocktail:\n");
                                    foreach (Menu menuItem in menuList)
                                    {
                                        if (menuItem.Categorie == "DrinkenCocktail")
                                            Console.WriteLine($"{menuItem.Naam} : {menuItem.Prijs}  {menuItem.Allergie}");
                                    }

                                    Console.WriteLine("\n[0] Terug");
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
                            Console.WriteLine("Allergieën informatie\n");
                            Console.WriteLine("V - Vegan");
                            Console.WriteLine("N - Bevat noten");
                            Console.WriteLine("L - Lactose vrij");
                            Console.WriteLine("G - Gluten vrij");
                            Console.WriteLine("A - Bevat alocohol");
                            Console.WriteLine("\n[0] Terug");
                            ConsoleKeyInfo allergieterug = Console.ReadKey();
                            if (allergieterug.Key == ConsoleKey.D0)
                            {
                                allergie = false;
                                Console.Clear();
                            }
                        }
                    }
                    else if (mainMenu.Key == ConsoleKey.D0)
                    {
                        menurunnen = false;
                    }
                } // einde if drinken

            } //einde programma
        }
    }
}