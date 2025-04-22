using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using qa_automation_mars.Pages;
using qa_automation_mars.Utilities;
using Reqnroll;

namespace qa_automation_mars.StepDefinition
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
                  
        [Given("I logged into mars application successfully {string} and {string}")]
        public void GivenILoggedIntoMarsApplicationSuccessfullyAnd(string email, string password)
        {
            AppHomePage appHomePage = new AppHomePage();
            appHomePage.naviagetToLoginPage(driver);
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver, email, password);
        }


        [When("I add a new language {string} and {string}")]
        public void WhenIAddANewLanguageAnd(string languageValue, string levelValue)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValue, levelValue);

        }

        [Then("New language should be successfully created {string}")]
        public void ThenNewLanguageShouldBeSuccessfullyCreated(string languageValue)
        {
            Languages languages = new Languages();
            string lastValue = languages.lastLanguage(driver);
            Console.WriteLine(lastValue);
            Assert.That(lastValue == languageValue, "Actual and excepted language doesn't match");
        }


        [When("I update an existing language {string} and {string} and {string}")]
        public void WhenIUpdateAnExistingLanguageAnd(string languageValue, string levelValue, string languageValueOne)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValueOne, levelValue);
            languages.editLanguage(driver, languageValue, levelValue);
        }

        [Then("The updated language with modified data should be successfully updated {string}")]
        public void ThenTheUpdatedLanguageWithModifiedDataShouldBeSuccessfullyUpdated(string languageValue)
        {
            Languages languages = new Languages();
            string lastValue = languages.lastLanguage(driver);
          
            Console.WriteLine(lastValue);
            Assert.That(lastValue == languageValue, "Actual and excepted language doesn't match");

        }

        [When("I delete an existing language")]
        public void WhenIDeleteAnExistingLanguage()
        {
            Languages languages = new Languages();
            languages.deleteLanguage(driver);
        }

        [Then("The existing language should be successfully removed")]
        public void ThenTheExistingLanguageShouldBeSuccessfullyRemoved()
        {
            Languages languages = new Languages();
            string removeErrorMsg = languages.removeSuccessMsg(driver);
            Console.WriteLine(removeErrorMsg);
            Assert.That(removeErrorMsg.Contains("has been deleted from your languages"), "Actual and excepted language doesn't match");
        }

        [When("I add same language with different language levels {string} and {string} and {string}")]
        public void WhenIAddSameLanguageWithDifferentLanguageLevelsAndAnd(string languageValue, string levelValue, string levelValuetwo)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValue, levelValue);
            languages.addLanguages(driver, languageValue, levelValuetwo);
        }
        [Then("An error message should be shown")]
        public void ThenAnErrorMessageShouldBeShown()
        {
            Languages languages = new Languages();
            string duplicateDataMsg = languages.duplicateDataMsg(driver);
            Console.WriteLine(duplicateDataMsg);
            Assert.That(duplicateDataMsg.Equals("Duplicated data"), "Actual and excepted language doesn't match");

        }

        [When("I add same language twice with same language level {string} and {string}")]
        public void WhenIAddSameLanguageTwiceWithSameLanguageLevelAnd(string languageValue, string levelValue)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValue, levelValue);
            languages.addLanguages(driver, languageValue, levelValue);
        }

        [Then("An error message language is already exist in your language list should be shown")]
        public void ThenAnErrorMessageLanguageIsAlreadyExistInYourLanguageListShouldBeShown()
        {
            Languages languages = new Languages();
            string languageExistErrorMsg = languages.languageExistErrorMsg(driver);
            Console.WriteLine(languageExistErrorMsg);
            Assert.That(languageExistErrorMsg.Equals("This language is already exist in your language list."), "Actual and excepted language doesn't match");
        }

        [When("I add an empty language {string} and {string}")]
        public void WhenIAddAnEmptyLanguageAnd(string languageValue, string levelValue)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValue, levelValue);
        }


        [Then("An error message Please enter language and level should be shown")]
        public void ThenAnErrorMessagePleaseEnterLanguageAndLevelShouldBeShown()
        {
            Languages languages = new Languages();
            string emptyLanguageErrorMsg = languages.emptyLanguageErrorMsg(driver);
            Console.WriteLine(emptyLanguageErrorMsg);
            Assert.That(emptyLanguageErrorMsg.Equals("Please enter language and level"), "Actual and excepted language doesn't match");

        }

        [When("I add a new language {string} and  empty language level {string}")]
        public void WhenIAddANewLanguageAndEmptyLanguageLevel(string languageValue, string levelValue)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            languages.addLanguages(driver, languageValue, levelValue);
        }

        [Then("An error message Please enter language and level should be displayed")]
        public void ThenAnErrorMessagePleaseEnterLanguageAndLevelShouldBeDisplayed()
        {
            Languages languages = new Languages();
            string emptyLanguageLevelErrorMsg = languages.emptyLanguageLevelErrorMsg(driver);
            Console.WriteLine(emptyLanguageLevelErrorMsg);
            Assert.That(emptyLanguageLevelErrorMsg.Equals("Please enter language and level"), "Actual and excepted language doesn't match");

        }

        [When("I add four languages {string} and  {string}")]
        public void WhenIAddFourLanguagesAnd(string languageValue, string levelValue)
        {
            Languages languages = new Languages();
            languages.clearData(driver);
            for (int i = 0; i < 4; i++)
            {
                languages.addLanguages(driver, languageValue + i, levelValue);
            }
                    }

        [Then("I should not add fifth language")]
        public void ThenIShouldNotAddFifthLanguage()
        {
            Languages languages = new Languages();
            int addNewButtonPresent = languages.addNewButtonPresent(driver);
            Console.WriteLine(addNewButtonPresent);
            Assert.That(addNewButtonPresent == 0, "user can add more than four kanguages");

        }

    }
}
