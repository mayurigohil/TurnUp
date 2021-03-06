using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using ClassLibrary1.Utility;
using Telerik.JustMock;
using System.Threading;

namespace ClassLibrary1.Pages
{
    class TnM
    {

        public void CreateTM(IWebDriver driver)
        {


            //Click on Create New
            IWebElement createnew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnew.Click();

            //Fill the details
            IWebElement typecode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typecode.Click();


            IWebElement code = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            code.Click();

            IWebElement codetext = driver.FindElement(By.Id("Code"));
            codetext.SendKeys("First code2");

            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("First code description2");

           
            IWebElement text;
            text = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            text.Click();

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("15");

            IWebElement element = driver.FindElement(By.Id("files"));
            element.SendKeys("C:\\Users\\Dell\\Downloads\\PPT\\Test.txt");

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

           
            //Go to last page
           WaitClass.ElementPresent(driver, "Xpath", "//*[@id='tmsGrid']/div[4]/a[4]/span");
         // driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click;
        IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
         LastPage.Click();

            //WaitClass.ElementDisable(driver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");
            Thread.Sleep(500);

            //Validate Saved data and print result
            Assert.Multiple(() =>
           {
               Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text == "First code2");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]")).Text == "T");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]")).Text == "First code description2");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]")).Text == "$15.00");
           });

            
        }

        /////////////////// Edit time and material test ////////////////////////////

        public void EditTM(IWebDriver driver)
        {
            try
            {
                IWebElement FirstPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[1]/span"));
                FirstPage.Click();

                // Edit Time and Material test --Todo
                IWebElement edit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
                edit.Click();
            }
            catch
            {
                Assert.Fail("Link not found");
            }
            IWebElement updatecodetext = driver.FindElement(By.Id("Code"));
            updatecodetext.Clear();
            updatecodetext.SendKeys("updated code");

            IWebElement editdescription = driver.FindElement(By.Id("Description"));
            editdescription.Clear();
            editdescription.SendKeys("updated code description");

            IWebElement edittext;
            edittext = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            edittext.Click();

            IWebElement pricee = driver.FindElement(By.Id("Price"));
            pricee.Clear();
            pricee.SendKeys("12");

            IWebElement update = driver.FindElement(By.Id("SaveButton"));
            update.Click();

            Thread.Sleep(800);
            //WaitClass.ElementPresent(driver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");
            //Validate Edited Text
            Assert.Multiple(() =>
            {
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "updated code");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[2]")).Text == "T");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[3]")).Text == "updated code description");
                Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[4]")).Text == "$12.00");
           });


        }

        public void DeleteTM(IWebDriver driver)
        {
            IWebElement LastPage1= driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            LastPage1.Click();


            Thread.Sleep(1000);
            IWebElement TogetRows = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody"));
            IList<IWebElement> TotalRowsList = TogetRows.FindElements(By.TagName("tr"));
            int RowsCount = TotalRowsList.Count;

          
            //WaitClass.ElementPresent(driver, "Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");

            //Find the last Record and delete the record
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
            delete.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            IWebElement Refresh = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[5]/span"));
            Refresh.Click();

            IWebElement TogetRows1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody"));
            IList<IWebElement> TotalRowsList1= TogetRows1.FindElements(By.TagName("tr"));
            int RowsCount1= TotalRowsList1.Count;


            Assert.Less(RowsCount1, RowsCount);
    }   }
}
