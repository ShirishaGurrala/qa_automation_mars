using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace qa_automation_mars.Pages
{
    public class Languages
    {
        public void addLanguages(IWebDriver driver, String languageValue, String levelValue)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//div[text()='Add New']"));
            addNew.Click();
            IWebElement addLanguageText = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']"));
            addLanguageText.SendKeys(languageValue);
            SelectElement chooseLangLevel = new SelectElement(driver.FindElement(By.XPath("//option[text()=\"Choose Language Level\"]/ancestor::select")));
            chooseLangLevel.SelectByText(levelValue);
            IWebElement add = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']/ancestor::div//input[@value='Add']"));
            add.Click();
            Thread.Sleep(2000);
        }
        public void editLanguage(IWebDriver driver, string languageValue, string levelValue)
        {

            // //th[text()='Language']/ancestor::table//tbody[last()]//tr/td
            IWebElement lastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//tr/td"));
            String lastLanguageValue = lastLanguage.Text;


            IWebElement editLastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"outline write icon\"]"));
            editLastLanguage.Click();

            IWebElement addLanguageText = driver.FindElement(By.XPath($"//div/input[@placeholder='Add Language' and @value='{lastLanguageValue}']"));
            addLanguageText.Clear();
            addLanguageText.SendKeys(languageValue);
            SelectElement chooseLangLeveltwo = new SelectElement(driver.FindElement(By.XPath($"//input[@placeholder=\"Add Language\" and @value=\"{lastLanguageValue}\"]/ancestor::td//select")));
            chooseLangLeveltwo.SelectByText(levelValue);
            IWebElement update = driver.FindElement(By.XPath("//input[@placeholder=\"Add Language\"]/ancestor::table//input[@value=\"Update\"]"));
            update.Click();
            Thread.Sleep(2000);
        }

        public void deleteLanguage(IWebDriver driver)
        {
            Thread.Sleep(3000);

            var removeLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"remove icon\"]"));
            removeLanguage.Click();
            Thread.Sleep(2000);
        }

        public void clearData(IWebDriver driver)
        {
            // IReadOnlyCollection<IWebElement> numberOfLanguages = driver.FindElements(By.XPath("//th[text()='Language']/ancestor::table//tbody"));
            var numberOfLanguages = driver.FindElements(By.XPath("//th[text()='Language']/ancestor::table//tbody"));
            Console.WriteLine(numberOfLanguages.Count);
            for (int i = 0; i < numberOfLanguages.Count; i++)
            {
                deleteLanguage(driver);
            }
        }


        public string lastLanguage(IWebDriver driver)
        {
            IWebElement lastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//tr/td"));
            return lastLanguage.Text;

        }

        public string removeSuccessMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'has been deleted from your languages')]")
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

        public string languageExistErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement languageExistErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'This language is already exist in your language list.')]")
            ));
            return languageExistErrorMsg.Text;
        }

        public string emptyLanguageErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement emptyLanguageErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'Please enter language and level')]")
            ));
            return emptyLanguageErrorMsg.Text;
        }

        public string emptyLanguageLevelErrorMsg(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement emptyLanguageLevelErrorMsg = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(text(), 'Please enter language and level')]")
            ));
            return emptyLanguageLevelErrorMsg.Text;
        }

        public int addNewButtonPresent(IWebDriver driver)
        {
            var addNewButtonPresent = driver.FindElements(By.XPath("//th[text()='Language']/ancestor::table//div[text()='Add New']"));
            return addNewButtonPresent.Count;
        }
    
              
    }
}
