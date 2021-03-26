using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Utility;
using ClassLibrary1.Models;
using System.Threading;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ClassLibrary1.Pages
{
    class Customer
    {
        private IWebDriver driver;
        public IWebElement CreateNew => driver.FindElement(By.XPath("//a[normalize-space()='Create New']"));
        public IWebElement Name => driver.FindElement(By.Id("Name"));
        public IWebElement Edit => driver.FindElement(By.Id("EditContactButton"));
        public IWebElement EditContactFrame => driver.FindElement(By.XPath("//iframe[@title='Edit Contact']"));
        public IWebElement Fname => driver.FindElement(By.Id("FirstName"));
        public IWebElement Lname => driver.FindElement(By.Id("LastName"));
        public IWebElement Pname => driver.FindElement(By.Id("PreferedName"));
        public IWebElement Phone => driver.FindElement(By.Id("Phone"));
        public IWebElement Mobile => driver.FindElement(By.Id("Mobile"));
        public IWebElement Email => driver.FindElement(By.Id("email"));
        public IWebElement Fax => driver.FindElement(By.Id("Fax"));
        public IWebElement Address => driver.FindElement(By.Id("autocomplete"));
        public IWebElement Street => driver.FindElement(By.Id("Street"));
        public IWebElement City => driver.FindElement(By.Id("City"));
        public IWebElement PostCode => driver.FindElement(By.Id("Postcode"));
        public IWebElement Country => driver.FindElement(By.Id("Country"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submitButton"));
        public IWebElement CheckBox => driver.FindElement(By.Id("IsSameContact"));
        public IWebElement Delete => driver.FindElement(By.XPath("//tbody/tr[6]/td[4]/a[2]"));
        public IWebElement PagerCount => driver.FindElement(By.XPath("//span[@class='k-pager-info k-label']"));
        public IWebElement EditCustomer => driver.FindElement(By.XPath("//tbody/tr[6]/td[4]/a[1]"));

        //public IWebElement CheckBox => driver.FindElement(By.Id("IsSameContact"));


        public void CustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            CreateNew.Click();
            WaitClass.ElementPresent(driver, "Id", "Name");
            Name.SendKeys("Automated");
            Edit.Click();
            driver.SwitchTo().Frame(0);
        }


        public void EditContactDetails(IWebDriver driver, TestData data)
        {
            this.driver = driver;
            Fname.SendKeys(data.Fname);
            Lname.SendKeys(data.Lname);
            Pname.SendKeys(data.Pname);
            Phone.SendKeys(data.Phone);
            Mobile.SendKeys(data.Mobile);
            Email.SendKeys(data.Email);
            Fax.SendKeys(data.Fax);
            Address.SendKeys(data.Address);
            Street.SendKeys(data.Street);
            City.SendKeys(data.City);
            PostCode.SendKeys(data.Postcode);
            Country.SendKeys(data.Country);
            SubmitButton.Click();
            driver.SwitchTo().DefaultContent();
            CheckBox.Click();
            SubmitButton.Click();
            driver.Navigate().Back();
            WaitClass.ElementPresent(driver, "Xpath", "//tbody/tr[3]/td[4]/a[2]");
        }

        public void DeleteCustomer(IWebDriver driver)
        {
            this.driver = driver;
            //Wait till table is loaded
            WaitClass.ElementPresent(driver, "Xpath", "//tbody/tr[3]/td[4]/a[2]");

            //Trim and record the count of the records before delete
            string count = PagerCount.Text;
            string FinalCount = count.Substring(10, 4);
            Regex.Replace(FinalCount, "[^0-9]+", string.Empty);
            TestContext.WriteLine(FinalCount);

            //Delete Customer
            Delete.Click();
            driver.SwitchTo().Alert().Accept();

            //Wait till Table is loaded
            WaitClass.ElementPresent(driver, "Xpath", "//tbody/tr[3]/td[4]/a[2]");

            //Trim and record the count of the records after delete
            string count1 =PagerCount.Text;
            string FinalCount1= count1.Substring(10,4);
            Regex.Replace(FinalCount1, "[^0-9]+", string.Empty);
            TestContext.WriteLine(FinalCount1);

            //Validate before and after count
            Assert.Less(FinalCount1, FinalCount);
        }
    }
}
