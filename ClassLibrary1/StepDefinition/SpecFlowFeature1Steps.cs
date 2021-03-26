using ClassLibrary1.Models;
using ClassLibrary1.Pages;
using ClassLibrary1.Utility;
using LumenWorks.Framework.IO.Csv;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace ClassLibrary1.StepDefinition
{
    [Binding]
     class SpecFlowFeature1Steps: CommonDriver
    {
        [Given(@"User has logged in")]
        public void GivenUserHasLoggedIn()
        {          
            Login loginObj = new Login();
            loginObj.loginpage(driver);
        }
        
        [Given(@"on Time and Material page")]
        public void GivenOnTimeAndMaterialPage()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateTnM(driver);
           
        }
        
        [Then(@"User should be able to add new time record with valid data")]
        public void ThenUserShouldBeAbleToAddNewTimeRecordWithValidData()
        {
            TnM tmObj = new TnM();
            tmObj.CreateTM(driver);
        }

        [Then(@"User should be able to edit time record")]
        public void ThenUserShouldBeAbleToEditTimeRecord()
        {
            TnM tmObj1 = new TnM();
            tmObj1.EditTM(driver);
        }

        [Then(@"User should be able to Delete time record")]
        public void ThenUserShouldBeAbleToDeleteTimeRecord()
        {
            TnM tmObj2 = new TnM();
            tmObj2.DeleteTM(driver);
        }

        [Given(@"Customer page")]
        public void GivenCustomerPage()
        {
            HomePage homeObj1 = new HomePage();
            homeObj1.NavigateCustomer(driver);
        }

        [Then(@"User should be able to Create new Customer record with valid data")]
        public void ThenUserShouldBeAbleToCreateNewCustomerRecordWithValidData()
        {
            
            Customer CustObj = new Customer();
            CustObj.CustomerPage(driver);


            string filePath = "Models\\Data.csv";
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    TestData Data = new TestData(csv[0], csv["Lastname"], "fdssd", "1234567896", "2525252552", "ette@ggg.com", "123456", "Test address", "52", "auckland", "123122", "New Zealand");
                    CustObj.EditContactDetails(driver, Data);
                }
            }
        }

        [Then(@"User should be able to Delete Customer record with valid data")]
        public void ThenUserShouldBeAbleToDeleteCustomerRecordWithValidData()
        {
            Customer CustObj1 = new Customer();
            CustObj1.DeleteCustomer(driver);
        }


    }
}
