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
              public void addLanguages(IWebDriver driver) 
        {
            IWebElement addNew = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//div[text()='Add New']"));
            addNew.Click();
            IWebElement addLanguageText = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']"));
            addLanguageText.SendKeys("English");
            SelectElement chooseLangLevel = new SelectElement(driver.FindElement(By.XPath("//option[text()=\"Choose Language Level\"]/ancestor::select")));
            chooseLangLevel.SelectByText("Basic");
            IWebElement add = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']/ancestor::div//input[@value='Add']"));
            add.Click();
        }
        public void editLanguage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // //th[text()='Language']/ancestor::table//tbody[last()]//tr/td
            IWebElement lastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//tr/td"));
            String lastLanguageValue = lastLanguage.Text;
            

            IWebElement editLastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"outline write icon\"]"));
            editLastLanguage.Click();

            IWebElement addLanguageText = driver.FindElement(By.XPath($"//div/input[@placeholder='Add Language' and @value='{lastLanguageValue}']"));
            addLanguageText.Clear();
            addLanguageText.SendKeys("Spanish");
            SelectElement chooseLangLeveltwo = new SelectElement(driver.FindElement(By.XPath($"//input[@placeholder=\"Add Language\" and @value=\"{lastLanguageValue}\"]/ancestor::td//select")));
            chooseLangLeveltwo.SelectByText("Fluent");
            IWebElement update = driver.FindElement(By.XPath("//input[@placeholder=\"Add Language\"]/ancestor::table//input[@value=\"Update\"]"));
            update.Click();
        }



        public void deleteLanguage(IWebDriver driver)
        {
            IWebElement lastLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//tr/td"));
            String lastLanguageValue = lastLanguage.Text;
            Thread.Sleep(2000);
            IWebElement removeLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"remove icon\"]"));
            removeLanguage.Click();
        }
        public void createEntries(IWebDriver driver)
        {
            IWebElement addNew = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//div[text()='Add New']"));
            IWebElement editLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"outline write icon\"]"));
            IWebElement removeLanguage = driver.FindElement(By.XPath("//th[text()='Language']/ancestor::table//tbody[last()]//i[@class=\"remove icon\"]"));
            IWebElement addLanguage = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']/ancestor::div//input[@value='Add']"));
            IWebElement cancel = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']/ancestor::div//input[@value='Cancel']"));
            ////input[@placeholder="Add Language"]/ancestor::table//input[@value="Update"]
            
            // fields

            IWebElement addLanguageText = driver.FindElement(By.XPath("//div/input[@placeholder='Add Language']"));
            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//option[text()=\"Choose Language Level\"]/ancestor::select")));
            select.SelectByText("shirisha");


            //error message
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Wait for the error message to be visible
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[text()='Please enter language and level']")
            ));

            // Assert the text (if you're using NUnit/xUnit/MSTest)
            if (errorMessage.Text == "Please enter language and level")
            {
                Console.WriteLine("Error message appeared correctly.");
            }

            IWebElement errorMessage2 = wait.Until(ExpectedConditions.ElementIsVisible(
               By.XPath("//div[text()='Duplicate Data']")
           ));

            // Assert the text (if you're using NUnit/xUnit/MSTest)
            if (errorMessage.Text == "Please enter language and level")
            {
                Console.WriteLine("Error message appeared correctly.");
            }

        }
    }
}
