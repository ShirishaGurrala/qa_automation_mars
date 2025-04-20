using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace qa_automation_mars.Pages
{
    public class Skills
    {
        public void addSkills(IWebDriver driver, String languageValue, String levelValue)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//div[text()='Add New']"));
            addNew.Click();
            IWebElement addSkillText = driver.FindElement(By.XPath("//div/input[@placeholder='Add Skill']"));
            addSkillText.SendKeys(languageValue);
            SelectElement chooseSkillLevel = new SelectElement(driver.FindElement(By.XPath("//option[text()=\"Choose Skill Level\"]/ancestor::select")));
            chooseSkillLevel.SelectByText(levelValue);
            IWebElement add = driver.FindElement(By.XPath("//div/input[@placeholder='Add Skill']/ancestor::div//input[@value='Add']"));
            add.Click();
            Thread.Sleep(2000);
        }
        public void editSkill(IWebDriver driver, string languageValue, string levelValue)
        {

            // //th[text()='Language']/ancestor::table//tbody[last()]//tr/td
            IWebElement lastSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//tr/td"));
            String lastSkillValue = lastSkill.Text;


            IWebElement editLastSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//i[@class=\"outline write icon\"]"));
            editLastSkill.Click();

            IWebElement addSkillText = driver.FindElement(By.XPath($"//div/input[@placeholder='Add Skill' and @value='{lastSkillValue}']"));
            addSkillText.Clear();
            addSkillText.SendKeys(languageValue);
            SelectElement chooseSkillLeveltwo = new SelectElement(driver.FindElement(By.XPath($"//input[@placeholder=\"Add Skill\" and @value=\"{lastSkillValue}\"]/ancestor::td//select")));
            chooseSkillLeveltwo.SelectByText(levelValue);
            IWebElement update = driver.FindElement(By.XPath("//input[@placeholder=\"Add Skill\"]/ancestor::table//input[@value=\"Update\"]"));
            update.Click();
            Thread.Sleep(2000);
        }

        public void deleteSkill(IWebDriver driver)
        {
            Thread.Sleep(3000);

            var removeSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//i[@class=\"remove icon\"]"));
            removeSkill.Click();
            Thread.Sleep(2000);
        }

        public void clearData(IWebDriver driver)
        {
            // IReadOnlyCollection<IWebElement> numberOfSkills = driver.FindElements(By.XPath("//th[text()='Language']/ancestor::table//tbody"));
            var numberOfSkills = driver.FindElements(By.XPath("//th[text()='Skill']/ancestor::table//tbody"));
            Console.WriteLine(numberOfSkills.Count);
            for (int i = 0; i < numberOfSkills.Count; i++)
            {
                deleteSkill(driver);
            }
        }


        public string lastSkill(IWebDriver driver)
        {
            IWebElement lastSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//tr/td"));
            return lastSkill.Text;

        }

        public string removeSuccessMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'has been deleted')]")
            ));
            return errorMessage.Text;
        }

        public string duplicateDataMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement duplicateDataMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'Duplicated data')]")
            ));
            return duplicateDataMsg.Text;
        }

        public string skillExistErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement skillExistErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'This skill is already exist in your skill list.')]")
            ));
            return skillExistErrorMsg.Text;
        }

        public string emptySkillErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement emptySkillErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'Please enter skill and experience level')]")
            ));
            return emptySkillErrorMsg.Text;
        }

        public string emptySkillLevelErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement emptySkillLevelErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'Please enter skill and experience level')]")
            ));
            return emptySkillLevelErrorMsg.Text;
        }

        //public int addNewButtonPresent(IWebDriver driver)
        //{
            //var addNewButtonPresent = driver.FindElements(By.XPath("//th[text()='Language']/ancestor::table//div[text()='Add New']"));
           // return addNewButtonPresent.Count;
        //}
    
    }
}
