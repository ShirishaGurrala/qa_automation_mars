using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using qa_automation_mars.Utilities;

namespace qa_automation_mars.Pages
{
    public class Skills
    {
        public void addSkills(IWebDriver driver, String skillValue, String skilllLevelValue)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//div[text()='Add New']"));
            addNew.Click();
            IWebElement addSkillText = driver.FindElement(By.XPath("//div/input[@placeholder='Add Skill']"));
            addSkillText.SendKeys(skillValue);
            SelectElement chooseSkillLevel = new SelectElement(driver.FindElement(By.XPath("//option[text()=\"Choose Skill Level\"]/ancestor::select")));
            chooseSkillLevel.SelectByText(skilllLevelValue);
            IWebElement add = driver.FindElement(By.XPath("//div/input[@placeholder='Add Skill']/ancestor::div//input[@value='Add']"));
            add.Click();
            Thread.Sleep(2000);
        }
        public void editSkill(IWebDriver driver, string skillValue, string skilllLevelValue)
        {

            // //th[text()='Language']/ancestor::table//tbody[last()]//tr/td
            IWebElement lastSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//tr/td"));
            String lastSkillValue = lastSkill.Text;


            IWebElement editLastSkill = driver.FindElement(By.XPath("//th[text()='Skill']/ancestor::table//tbody[last()]//i[@class=\"outline write icon\"]"));
            editLastSkill.Click();

            IWebElement addSkillText = driver.FindElement(By.XPath($"//div/input[@placeholder='Add Skill' and @value='{lastSkillValue}']"));
            addSkillText.Clear();
            addSkillText.SendKeys(skillValue);
            SelectElement chooseSkillLeveltwo = new SelectElement(driver.FindElement(By.XPath($"//input[@placeholder=\"Add Skill\" and @value=\"{lastSkillValue}\"]/ancestor::td//select")));
            chooseSkillLeveltwo.SelectByText(skilllLevelValue);
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
            string errorMessage = Wait.waitToBeVisible(driver, 5, "//div[contains(text(), 'has been deleted')]");
            return errorMessage;
        }

        public string duplicateDataMsg(IWebDriver driver)
        {
            string duplicateDataMsg = Wait.waitToBeVisible(driver, 5, "//div[contains(text(), 'Duplicated data')]");
            return duplicateDataMsg;
        }

        public string skillExistErrorMsg(IWebDriver driver)
        {
            string skillExistErrorMsg = Wait.waitToBeVisible(driver, 5, "//div[contains(text(), 'This skill is already exist in your skill list.')]");
            return skillExistErrorMsg;
        }

        public string emptySkillErrorMsg(IWebDriver driver)
        {
            string emptySkillErrorMsg = Wait.waitToBeVisible(driver, 5, "//div[contains(text(), 'Please enter skill and experience level')]");
            return emptySkillErrorMsg;
        }

        public string emptySkillLevelErrorMsg(IWebDriver driver)
        {
            string emptySkillLevelErrorMsg = Wait.waitToBeVisible(driver, 5, "//div[contains(text(), 'Please enter skill and experience level')]");
            return emptySkillLevelErrorMsg;
        }
                 
    }
}
