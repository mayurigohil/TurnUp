using ClassLibrary1.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassLibrary1.Pages
{
    class HomePage
    {
        private IWebDriver driver;
        //public void NavigateCustomer(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}
        public  IWebElement admin => driver.FindElement(By.XPath("//a[normalize-space()='Administration']"));

        public IWebElement time => driver.FindElement(By.XPath("//*[@class='nav navbar-nav']//a[text()='Time & Materials']"));

        public IWebElement Customer => driver.FindElement(By.XPath("//a[normalize-space()='Customers']"));

        public void NavigateTnM(IWebDriver driver)
        {
            this.driver = driver;
            admin.Click();
            time.Click();
            WaitClass.ElementPresent(driver, "XPath", "//a[normalize-space()='Create New']");
        }

        public void NavigateCustomer(IWebDriver driver)
        {
            this.driver = driver;
            admin.Click();
            Thread.Sleep(1000);
            Customer.Click();
            WaitClass.ElementPresent(driver, "XPath", "//a[normalize-space()='Create New']");
        }

    }
}
