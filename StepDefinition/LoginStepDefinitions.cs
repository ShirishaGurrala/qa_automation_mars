using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using qa_automation_mars.Pages;
using qa_automation_mars.Utilities;
using Reqnroll;

namespace qa_automation_mars.StepDefinition
{
    [Binding]
    public class LoginStepDefinitions : CommonDriver
    {

        [Given("I am on the application main page, click on sign in to navigate to login page")]
        public void NavigateToLoginPage()
        {
            AppHomePage appHomePage = new AppHomePage();
            appHomePage.naviagetToLoginPage(driver);

        }

        [When("I enter valid credentials {string} and {string}")]
        public void WhenIEnterValidCredentialsAnd(string email, string password)
        {
            LoginPage loginPage = new LoginPage();  
            loginPage.LoginActions(driver, email, password);
            Thread.Sleep(1000);
                     
        }

        [Then("I should see the profile page")]
        public void ThenIShouldSeeTheProfilePage()
        {
            
            Console.WriteLine(driver.Title);
            Assert.That(driver.Title.Equals("Profile"), "Logged on to Profile page");
                    }

        [When("I enter an invalid email and valid password {string} and {string}")]
        public void WhenIEnterAnInvalidEmailAndValidPasswordAnd(string email, string password)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver, email, password);
            Thread.Sleep(1000);
        }

        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
          
            Assert.That(!driver.Title.Equals("Profile"), "User login failed");
        }

        [When("I enter a valid email and invalid password {string} and {string}")]
        public void WhenIEnterAValidEmailAndInvalidPasswordAnd(string email, string password)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver, email, password);
            Thread.Sleep(1000);
        }
       
    }
}
