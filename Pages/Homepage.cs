using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpCRUDFunctiontest.Utils;

namespace TurnUpCRUDFunctiontest.Pages
{
    internal class Homepage : CommonDriver
    {
        
        public void homepage()
        {
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();

        }

    }
}
