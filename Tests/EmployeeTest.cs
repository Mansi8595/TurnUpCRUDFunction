using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography.X509Certificates;

namespace TurnUpCRUDFunctiontest.Test
{
    internal class EmployeeTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            login();
            homePage();
        }
        public void login()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("hari");
            driver.FindElement(By.Name("Password")).SendKeys("123123");
            driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]")).Click();
        }

        public void homePage()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")).Click();
        }
        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }
        [Test, Order(1)]
        public void createEmployeetest()
        {

            // Actions
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            driver.FindElement(By.Id("Name")).SendKeys("MayUser");
            driver.FindElement(By.Id("Username")).SendKeys("May2024User");
            driver.FindElement(By.Id("ContactDisplay")).SendKeys("user2");
            driver.FindElement(By.Id("Password")).SendKeys("Abcdqwer1@");
            driver.FindElement(By.Id("RetypePassword")).SendKeys("Abcdqwer1@");
            driver.FindElement(By.Id("SaveButton")).Click();
            driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")).Click();

            //Assertion
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")));
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            String Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[1]")).Text;
            String UserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[2]")).Text;


            Assert.That(Name == "MayUser", "Code value does not match");
            Assert.That(UserName == "May2024User", "typeCode value does not match");
        }

        [Test, Order(2)]
        public void editEmployeeTest()
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
        [Test, Order(3)]
        public void deleteEmployeeTest()
        {
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[6]/td[3]/a[2]")).Click();
            driver.SwitchTo().Alert().Accept();
            
            // Assertion
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")).Click();
            String Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[1]")).Text;
            String UserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[2]")).Text;


            Assert.That(Name != "MayUserData", "Code value does not match");
            Assert.That(UserName != "May2024UserData", "typeCode value does not match");
        }



        }
    
}
