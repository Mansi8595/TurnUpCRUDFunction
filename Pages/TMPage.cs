using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpCRUDFunctiontest.Utils;

namespace TurnUpCRUDFunctiontest.Pages
{
    internal class TMPage : CommonDriver
    {
        public void createTMRecordTest()

        {

            // Actions
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"Code\"]")).SendKeys("May2024");
            driver.FindElement(By.XPath("//*[@id=\"Description\"]")).SendKeys("This is test");
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.Id("Price")).SendKeys("101");
            driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();

            //Assertion

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            String code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[1]")).Text;
            String typeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[2]")).Text;
            String description = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[3]")).Text;
            String price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[4]")).Text;

            Assert.That(code == "May2024", "Code value does not match");
            Assert.That(typeCode == "M", "typeCode value does not match");
            Assert.That(description == "This is test", "description value does not match");
            Assert.That(price.Contains("101"), "price value does not match");

        }
        public void editTMRecordTest()
        {
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[5]/a[1]")).Click();
            driver.FindElement(By.Id("Code")).SendKeys("24");
            driver.FindElement(By.Id("Description")).SendKeys(" Data");
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.Id("Price")).SendKeys("2");
            driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]")).Click();

            //Assertion
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            String code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[1]")).Text;
            String typeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[2]")).Text;
            String description = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[3]")).Text;
            String price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[4]")).Text;

            Assert.That(code == "May202424", "Code value does not match");
            Assert.That(typeCode == "M", "typeCode value does not match");
            Assert.That(description == "This is test Data", "description value does not match");
            Assert.That(price.Contains("1,012"), "price value does not match");


        }

        public void deleteTMRecordTest()
        {

            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[5]/a[2]")).Click();
            driver.SwitchTo().Alert().Accept();

            // Assertion
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            String code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr/td[1]")).Text;
            String typeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr/td[2]")).Text;
            String description = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr/td[3]")).Text;
            String price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr/td[4]")).Text;


            Assert.That(code != "May202424", "Code value does not match");
            Assert.That(typeCode != "M", "TypeCode value does not match");
            Assert.That(description != "This is test Data", "Description value does not match");
            Assert.That(!price.Contains("1,012"), "Price value does not match");



        }
    }
}
