using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Test_Login
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
    public class Login_Unit_Test
    {
        [Fact]
        public void User_With_Correct_Username_And_Pass_Should_Login_Successfully()
        {
            //Arrange
            string username = "admin";
            string password = "admin123";

            //Act
            bool isValid = login(username, password);

            //Assert
            Assert.True(isValid, $"The password {password} is not valid");

        }
        [Fact]
        public void User_With_Wrong_Username_And_Pass_Should_Not_Login()
        {
            //Arrange
            string username = "admin";
            string password = "admin123";

            //Act
            bool isFalse = login(username, password);

            //Assert
            Assert.False(isFalse, $"The password {password} is not valid");

        }
        public bool login(string username, string password)
        {
            string medewerkerPath = "Medewerker.json"; // find path to file
            var JsonData = File.ReadAllText(medewerkerPath);
            var MederwerkerList = JsonConvert.DeserializeObject<List<MedewerkerINFO>>(JsonData) ?? new List<MedewerkerINFO>();
            foreach (MedewerkerINFO accountList in MederwerkerList)
            {
                if (username == accountList.gebruikersnaam && password == accountList.wachtwoord)
                    return true;
            }
            return false;
        }
    }
}