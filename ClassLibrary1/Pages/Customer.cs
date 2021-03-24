using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1.Utility;
using ClassLibrary1.Models;

namespace ClassLibrary1.Pages
{
    class Customer
    {
        private IWebDriver driver;

        //public Customer(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

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
        public IWebElement CheckBox => driver.FindElement(By.Id("BillingContactId"));

        public void CustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            CreateNew.Click();
            WaitClass.ElementPresent(driver, "Id", "Name");
            Name.SendKeys("Mayuri");
            Edit.Click();
            driver.SwitchTo().Frame(0);
        }


        public void EditContact(IWebDriver driver, TestData data)
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
            //WaitClass.ElementPresent(driver, "Id", "BillingContactId");
            CheckBox.Click();
            SubmitButton.Click();
        }
    }
}
