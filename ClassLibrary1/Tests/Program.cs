using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using ClassLibrary1.Utility;
using System.Threading;
using ClassLibrary1.Models;

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
            

        }

        [Test]
        public void CreateTime()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateTnM(driver);
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

        [Test]
        public void CreateCustomer()
        {
            HomePage homeObj1 = new HomePage();
            homeObj1.NavigateCustomer(driver);
            Customer CustObj = new Customer();
            CustObj.CustomerPage(driver);
            TestData Data = new TestData("Test", "Lastname", "fdssd", "1234567896", "2525252552", "ette@ggg.com", "123456", "Test address", "52", "auckland", "123122", "New Zealand");
            Customer Edit = new Customer();
            Edit.EditContact(driver,Data);
        }

        [OneTimeTearDown]
        public void FinalSteps()

        {
          Thread.Sleep(10000);
          driver.Quit();
        }
    }
}
