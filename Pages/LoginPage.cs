using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace qa_automation_mars.Pages
{
    public class LoginPage
    {

        public void LoginActions(IWebDriver driver, string email, string password)
        {

            //// Launch Turnup Portal
            //driver.Navigate().GoToUrl("http://localhost:5003/");
            //driver.Manage().Window.Maximize();

            ////Identify Sign In button and perform click
            //IWebElement signInTextbox = driver.FindElement(By.XPath("//a[text()=\"Sign In\"]"));
            //signInTextbox.Click();

            // Identify Email address textbox and enter valid Email Id
            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("//input[@name=\"email\"]"));
            //emailAddressTextbox.SendKeys("shirishareddy.gurrala@gmail.com");
            emailAddressTextbox.SendKeys(email);

            // Identify password textbox and enter valid password;
            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[@name=\"password\"]"));
            //passwordTextbox.SendKeys("123456");
            passwordTextbox.SendKeys(password);

            // Identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//button[text()=\"Login\"]"));
            loginButton.Click();
            Thread.Sleep(2000);

        }

    }
}
