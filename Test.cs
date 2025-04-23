using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using qa_automation_mars.Pages;
using qa_automation_mars.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace qa_automation_mars
{
    [TestFixture]
    public class Test : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            // Open Chrome Browser
            //driver = new ChromeDriver();
         }
        [Test]
        public void Login_Test()
        {
            // Login page object initialization
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver, "", "");
        }
    }
}
