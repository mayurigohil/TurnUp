using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using ClassLibrary1.Utility;

namespace ClassLibrary1.Tests
{
    [TestFixture]
    class Program : CommonDriver
    {
    
        [OneTimeSetUp]
        public void Login()
        {
            Login loginObj = new Login();
            loginObj.loginpage(driver);
            HomePage homeObj = new HomePage();
            homeObj.navigatehome(driver);

        }

        [Test]
        public void CreateTime()
        {
            TnM tmObj = new TnM();
            tmObj.CreateTM(driver);

        }

        [Test]
        public void EditTime()
        {
            TnM tmObj1 = new TnM();
            tmObj1.EditTM(driver);
        }

        [Test]
        public void DeleteTime()
        {

            TnM tmObj2 = new TnM();
            tmObj2.DeleteTM(driver);
        }

        [OneTimeTearDown]
        public void FinalSteps()

        {
         //   driver.Quit();
        }
    }
}
