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
    internal class EmployeePage : CommonDriver
    {
        public void createEmployeetest()
        {

            // Actions
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("Name")).SendKeys("MayUser");
            driver.FindElement(By.Id("Username")).SendKeys("May2024User");
            driver.FindElement(By.Id("ContactDisplay")).SendKeys("user2");
            driver.FindElement(By.Id("Password")).SendKeys("Abcdqwer1@");
            driver.FindElement(By.Id("RetypePassword")).SendKeys("Abcdqwer1@");
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")).Click();

            //Assertion
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            String Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[1]")).Text;
            String UserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[2]")).Text;


            Assert.That(Name == "MayUser", "Code value does not match");
            Assert.That(UserName == "May2024User", "typeCode value does not match");
        }
        public void editEmployeetest()
        {
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[3]/a[1]")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("Data");

            driver.FindElement(By.Id("Username")).SendKeys("Data");
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")).Click();

            //Assertion
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            String Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[1]")).Text;
            String UserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[2]")).Text;


            Assert.That(Name == "MayUserData", "Code value does not match");
            Assert.That(UserName == "May2024UserData", "typeCode value does not match");
        }
        public void deleteEmployeetest()
        {
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[3]/a[2]")).Click();
            driver.SwitchTo().Alert().Accept();

            // Assertion
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(3000);
            String Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[1]")).Text;
            String UserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[2]")).Text;


            Assert.That(Name != "MayUserData", "Code value does not match");
            Assert.That(UserName != "May2024UserData", "typeCode value does not match");
        }

       
    }
}
