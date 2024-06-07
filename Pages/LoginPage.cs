using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpCRUDFunctiontest.Utils;

namespace TurnUpCRUDFunctiontest.Pages
{
    internal class LoginPage : CommonDriver
    {    
        
        public void login()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("hari");
            driver.FindElement(By.Name("Password")).SendKeys("123123");
            driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]")).Click();
        }
    }
}
