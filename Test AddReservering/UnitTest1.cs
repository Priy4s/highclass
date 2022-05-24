using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_AddReservering
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
    public class AddReservering_Unit_Test
    {
        [Fact]
        public void User_met_juiste_ingevulde_gegevens_moet_een_reservering_krijgen()
        {
            //Arrange
            string naamIN = "Gerda Rietman";
            string pronounsIN = "zij/haar";
            int aantalIN = 4;
            string datumIN = "25-06-2022";
            string tijdslotIN = "19:00-22:00";


            //Act
            bool isValid = checkreservering(naamIN, pronounsIN, aantalIN, datumIN, tijdslotIN);

            //Assert
            Assert.True(isValid, "Ingevulde gegevens zijn niet juist.");
        }
        public bool checkreservering(string naam, string pronouns, int aantal, string datum, string tijdslot)
        {
            string ReserveringPath = "Reserveringen.json";
            var JsonData = File.ReadAllText(ReserveringPath);
            var ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();
            if (aantal <= 200)
            {
                ReserveringenList.Add(new Reserveringenjson()
                {
                    Naam = naam,
                    Voornaamwoorden = pronouns,
                    Groepsgrote = aantal,
                    Tijdslot = tijdslot,
                    Datum = datum,
                    Eindtijd = "",
                    Prijs = 0.00
                });
                JsonData = JsonConvert.SerializeObject(ReserveringenList);
                System.IO.File.WriteAllText(ReserveringPath, JsonData);
            }
            else
            {
                return false;
            }

            ReserveringPath = "Reserveringen.json";
            JsonData = File.ReadAllText(ReserveringPath);
            ReserveringenList = JsonConvert.DeserializeObject<List<Reserveringenjson>>(JsonData) ?? new List<Reserveringenjson>();

            int i = 0;
            while (i < ReserveringenList.Count)
            {
                if (ReserveringenList[i].Naam == naam && ReserveringenList[i].Voornaamwoorden == pronouns &&
                    ReserveringenList[i].Groepsgrote == aantal && ReserveringenList[i].Tijdslot == tijdslot &&
                    ReserveringenList[i].Datum == datum)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        [Fact]
        public void User_met_onjuiste_ingevulde_gegevens_moet_geen_reservering_krijgen()
        {
            //Arrange
            string naamIN = "Bert Usberg";
            string pronounsIN = "hij/hem";
            int aantalIN = 210;
            string datumIN = "22-05-2022";
            string tijdslotIN = "19:00-22:00";

            //Act
            bool isFalse = checkreservering(naamIN, pronounsIN, aantalIN, datumIN, tijdslotIN);

            //Assert
            Assert.False(isFalse, "Ingevulde gegevens zijn juist.");

        }
    }
}
