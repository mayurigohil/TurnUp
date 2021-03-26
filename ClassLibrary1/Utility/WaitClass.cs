using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Utility
{
    class WaitClass
    {  //Explicit Wait
        public static void ElementPresent(IWebDriver driver, String Locator, String LocatorValue)
        {
            try
            {
                if (Locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LocatorValue)));
                }

                if (Locator == "Xpath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(LocatorValue)));
                }
            }
           
            catch (WebDriverTimeoutException)
            { 
                Assert.Fail("Time out Exception");
            }
            catch (StaleElementReferenceException)
            {
                Assert.Fail("Stale element"); 
            }
            catch (Exception Ex)
            {
                Assert.Fail("test case failed", Ex);
            }
           
        }

        public static void ElementDisable(IWebDriver driver, String Locator, String LocatorValue)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LocatorValue)));
        }

    }
}
