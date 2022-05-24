using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MenuItemToevoegen
{
    public class Menu
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public string Allergie { get; set; }
        public string Categorie { get; set; }
        public int ID { get; set; }

    }

    public class Menu_Item_toevoegen_Test
    {
        [Fact]
        public void Menu_Item_With_Valid_Entries()
        {
            //ARange
            string naam = "Patat";
            double prijs = 2.34;
            string allergie = "G";
            string categorie = "Brunch";
            int ID = 250;

            bool isValid = checkMenuItem(naam,prijs,allergie,categorie,ID);
            Assert.True(isValid, "Menu item is niet op het menu gekomen");
        }
        public bool checkMenuItem(string naam, double prijs, string allergie, string categorie, int ID)
        {
            {
                string menuPath = "Menu.json"; // find path to file
                var JsonData = File.ReadAllText(menuPath);
                var menuList = JsonConvert.DeserializeObject<List<Menu>>(JsonData) ?? new List<Menu>();

                menuList.Add(new Menu()
                {
                    Naam = naam,
                    Prijs = prijs,
                    Allergie = allergie,
                    Categorie = categorie,
                    ID = ID,
                });

                JsonData = JsonConvert.SerializeObject(menuList);
                System.IO.File.WriteAllText(menuPath, JsonData);


                foreach (Menu menuitem in menuList)
                {
                    if (naam == menuitem.Naam && prijs == menuitem.Prijs && allergie == menuitem.Allergie && categorie == menuitem.Categorie && ID == menuitem.ID)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
