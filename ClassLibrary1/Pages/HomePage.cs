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
        public void navigatehome(IWebDriver driver)
        {
            IWebElement admin = driver.FindElement(By.XPath("//*[@class='nav navbar-nav']//a[text()='Administration ']"));
            admin.Click();
            IWebElement time = driver.FindElement(By.XPath("//*[@class='nav navbar-nav']//a[text()='Time & Materials']"));
            time.Click();

            WaitClass.ElementPresent(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span");
         
        }
    }
}
