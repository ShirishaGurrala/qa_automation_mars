using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace qa_automation_mars.Pages
{
    public class AppHomePage
    {
        public void naviagetToLoginPage(IWebDriver driver)
        {
            // Launch Turnup Portal
            driver.Navigate().GoToUrl("http://localhost:5003/");
            driver.Manage().Window.Maximize();

            //Identify Sign In button and perform click
            IWebElement signInTextbox = driver.FindElement(By.XPath("//a[text()=\"Sign In\"]"));
            signInTextbox.Click();

        }
    }
}
