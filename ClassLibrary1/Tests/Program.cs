using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using ClassLibrary1.Utility;
using System.Threading;
using ClassLibrary1.Models;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Collections;

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
           

            string filePath = "Models\\Data.csv";
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    TestData Data = new TestData(csv[0], csv["Lastname"], "fdssd", "1234567896", "2525252552", "ette@ggg.com", "123456", "Test address", "52", "auckland", "123122", "New Zealand");
                    CustObj.EditContact(driver, Data);
                }
            }
            
            
            
           
        }


        //[TestCaseSource("TestDataCSV")]
        //public void CreateCustomer1(TestData data)
        //{
        //    TestContext.WriteLine(data.Fname);

        //}



         [TestCaseSource("CreateCustomerTestDataCSV")]
        public void CreateCustomer(TestData data)
        {
            HomePage homeObj1 = new HomePage();
            homeObj1.NavigateCustomer(driver);
            Customer CustObj = new Customer();
            CustObj.CustomerPage(driver);
            // ExcelHelper.TestDataCSV(TestData data);
            //  ReadData.TestDataCSV(data);

            CustObj.EditContact(driver, data);
        }

        public static IEnumerable CreateCustomerTestDataCSV()
        {
            //Provide path of file and also change property to Copy always
            string filePath = "Models\\Data.csv"; // C: \Users\Dell\Documents\VB Feb 2021\FirstTests\ClassLibrary1\Models\

            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData( new TestData(csv["firstname"], csv[1], csv[2], csv[3], csv[4], csv[5], csv[6], csv[7], csv[8], csv[9], csv[10], csv[11])).SetName(csv["testname"]);
                }
            }
        }




        [OneTimeTearDown]
        public void FinalSteps()

        {
          Thread.Sleep(1000);
          driver.Quit();
        }
    }
}
