using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Account_toevoegen_test
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
    public class account_toevoegen_unittst
    {
        [Fact]
        public void met_correcte_inloggegevens_een_nieuwe_account_aanmaken_()
        {
            string naamIN = "Yvonne Maan";
            string pronounsIN = "zij/haar";
            string telefoonnummerIN = "0640919997";
            string eMailIN = "yvonnemaan@gmail.com";
            string functieIN = "personeel";
            string gebruikersnaamIN = "yvon";
            string wachtwoordIN = "yvon123";

            string medewerkerPath = "Medewerker.json";
            var JsonData = File.ReadAllText(medewerkerPath); // file can be found in the bin => just keep clicking until you find all extra files
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();


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

            //Act
            bool isValid = ADD_Account(naamIN, pronounsIN, telefoonnummerIN, eMailIN, functieIN, gebruikersnaamIN, wachtwoordIN);

            //Assert
            Assert.True(isValid, "The person is not valid");
        }
        public bool ADD_Account(string naamIN, string pronounsIN, string telefoonnummerIN, string eMailIN, string functieIN, string gebruikersnaamIN, string wachtwoordIN)
        {
            string medewerkerPath = "Medewerker.json"; // find path to file
            var JsonData = File.ReadAllText(medewerkerPath);
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();
            foreach (MedewerkerINFO accountList in MederwerkerList)
            {
                if (accountList.naam == naamIN && accountList.pronouns == pronounsIN && accountList.telefoonnummer == telefoonnummerIN && accountList.eMail == eMailIN && accountList.functie == functieIN && accountList.gebruikersnaam == gebruikersnaamIN && accountList.wachtwoord == wachtwoordIN)
                {
                    return true;
                }
            }
            return true;
        }
    }
}