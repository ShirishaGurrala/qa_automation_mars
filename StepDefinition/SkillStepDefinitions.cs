using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using qa_automation_mars.Pages;
using qa_automation_mars.Utilities;
using Reqnroll;

namespace qa_automation_mars.StepDefinition
{
    [Binding]
    public class SkillStepDefinitions : CommonDriver
    {
        
        [Given("I logged into mars application successfully {string} and {string} and navigated to Skills page")]
        public void GivenILoggedIntoMarsApplicationSuccessfullyAndAndNavigatedToSkillsPage(string email, string password)
        {
            AppHomePage appHomePage = new AppHomePage();
            appHomePage.naviagetToLoginPage(driver);
            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver, email, password);
            loginPage.navigateToSkillsTab(driver);
        }

        [When("I add a new skill {string} and {string}")]
        public void WhenIAddANewSkillAnd(string skillValue, string skilllLevelValue)
        {
            Skills skills = new Skills();
            skills.addSkills(driver, skillValue, skilllLevelValue);
        }

        [Then("New skill should be successfully created {string}")]
        public void ThenNewSkillShouldBeSuccessfullyCreated(string skillValue)
        {
            Skills skills = new Skills();
            string lastSkillValue = skills.lastSkill(driver);
            Console.WriteLine(lastSkillValue);
            Assert.That(lastSkillValue == skillValue, "Actual and excepted skill doesn't match");
        }

        [When("I update an existing skill {string} and {string}")]
        public void WhenIUpdateAnExistingSkillAnd(string skillValue, string skilllLevelValue)
        {
            Skills skills = new Skills();
            skills.editSkill(driver, skillValue, skilllLevelValue);
        }

        [Then("The updated skill with modified data should be successfully updated {string}")]
        public void ThenTheUpdatedSkillWithModifiedDataShouldBeSuccessfullyUpdated(string skillValue)
        {
            Skills skills = new Skills();
            string lastSkillValue = skills.lastSkill(driver);
            Console.WriteLine(lastSkillValue);
            Assert.That(lastSkillValue == skillValue, "Actual and excepted skill doesn't match");
        }

        [When("I delete an existing skill")]
        public void WhenIDeleteAnExistingSkill()
        {
            Skills skills = new Skills();
            skills.deleteSkill(driver);

        }

        [Then("The existing skill should be successfully removed")]
        public void ThenTheExistingSkillShouldBeSuccessfullyRemoved()
        {
            Skills skills = new Skills();
            string removeErrorMsg = skills.removeSuccessMsg(driver);
            Console.WriteLine(removeErrorMsg);
            Assert.That(removeErrorMsg.Contains("has been deleted"), "Actual and excepted skill doesn't match");
        }

        [When("I add same skill with different skill levels {string} and {string} and {string}")]
        public void WhenIAddSameSkillWithDifferentSkillLevelsAndAnd(string skillValue, string skilllLevelValue, string skilllevelValuetwo)
        {
            Skills skills = new Skills();
            skills.clearData(driver);
            skills.addSkills(driver, skillValue, skilllLevelValue);
            skills.addSkills(driver, skillValue, skilllevelValuetwo);
        }

        [Then("An error message Duplicated data should be shown")]
        public void ThenAnErrorMessageDuplicatedDataShouldBeShown()
        {
            Skills skills = new Skills();
            string duplicateDataMsg = skills.duplicateDataMsg(driver);
            Console.WriteLine(duplicateDataMsg);
            Assert.That(duplicateDataMsg.Equals("Duplicated data"), "Actual and excepted skill doesn't match");
        }

        [When("I add same skill twice with same skill level {string} and {string}")]
        public void WhenIAddSameSkillTwiceWithSameSkillLevelAnd(string skillValue, string skilllLevelValue)
        {
            Skills skills = new Skills();
            skills.clearData(driver);
            skills.addSkills(driver, skillValue, skilllLevelValue);
            skills.addSkills(driver, skillValue, skilllLevelValue);
        }

        [Then("An error message skill is already exist in your skill list should be shown")]
        public void ThenAnErrorMessageSkillIsAlreadyExistInYourSkillListShouldBeShown()
        {
            Skills skills = new Skills();
            string skillExistErrorMsg = skills.skillExistErrorMsg(driver);
            Console.WriteLine(skillExistErrorMsg);
            Assert.That(skillExistErrorMsg.Equals("This skill is already exist in your skill list."), "Actual and excepted language doesn't match");

        }

        [When("I add an empty skill {string} and {string}")]
        public void WhenIAddAnEmptySkillAnd(string skillValue, string skilllLevelValue)
        {
            Skills skills = new Skills();
            skills.clearData(driver);
            skills.addSkills(driver, skillValue, skilllLevelValue);
        }

        [Then("An error message Please enter skill and level should be shown")]
        public void ThenAnErrorMessagePleaseEnterSkillAndLevelShouldBeShown()
        {
            Skills skills = new Skills();
            string emptySkillErrorMsg = skills.emptySkillErrorMsg(driver);
            Console.WriteLine(emptySkillErrorMsg);
            Assert.That(emptySkillErrorMsg.Equals("Please enter skill and experience level"), "Actual and excepted skill doesn't match");

        }

        [When("I add a new skill {string} and  empty skill level {string}")]
        public void WhenIAddANewSkillAndEmptySkillLevel(string skillValue, string skilllLevelValue)
        {
            Skills skills = new Skills();
            skills.clearData(driver);
            skills.addSkills(driver, skillValue, skilllLevelValue);
        }

        [Then("An error message Please enter skill and level should be displayed")]
        public void ThenAnErrorMessagePleaseEnterSkillAndLevelShouldBeDisplayed()
        {
            Skills skills = new Skills();
            string emptySkillLevelErrorMsg = skills.emptySkillLevelErrorMsg(driver);
            Console.WriteLine(emptySkillLevelErrorMsg);
            Assert.That(emptySkillLevelErrorMsg.Equals("Please enter skill and experience level"), "Actual and excepted language doesn't match");

        }
    }
}
