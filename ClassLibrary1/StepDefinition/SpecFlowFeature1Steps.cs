using ClassLibrary1.Pages;
using ClassLibrary1.Utility;
using OpenQA.Selenium.Chrome;
using System;
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

    }
}
