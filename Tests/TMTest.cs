using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpCRUDFunctiontest.Pages;

namespace TurnUpCRUDFunctiontest.Tests
{
    internal class TMTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        LoginPage LoginPageObj = new LoginPage();
        Homepage HomepageObj = new Homepage();
        TMPage TMPageObj = new TMPage();

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            LoginPageObj.login(driver);
            HomepageObj.homepage(driver);
        }
           
              
        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }


        [Test, Order(1)]
        public void createTMRecordTest()

        {
            TMPageObj.createTMRecordTest(driver);
            
        
        }
        [Test, Order(2)]
        public void editTMRecordTest()
        {
             TMPageObj.editTMRecordTest(driver);
        }
        
        [Test, Order(3)]
        public void deleteTMRecordTest()
        {
            TMPageObj.deleteTMRecordTest(driver);

        }
    }
}
