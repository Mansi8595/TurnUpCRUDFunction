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
using TurnUpCRUDFunctiontest.Pages;
using TurnUpCRUDFunctiontest.Utils;

namespace TurnUpCRUDFunctiontest.Test
{
    internal class EmployeeTest : CommonDriver
    {   
        WebDriverWait wait;
        LoginPage LoginPageObj = new LoginPage();
        Homepage HomepageObj = new Homepage();
        EmployeePage EmployeePageObj = new EmployeePage();

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            LoginPageObj.login();
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

            EmployeePageObj.createEmployeetest();
        }

        [Test, Order(2)]
        public void editEmployeetest()
        {
            EmployeePageObj.editEmployeetest();
            
        }

        [Test, Order(3)]
        public void deleteEmployeetest()
        {
            EmployeePageObj.deleteEmployeetest();

        }



    }
    
        }
