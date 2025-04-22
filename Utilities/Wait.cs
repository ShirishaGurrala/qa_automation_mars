using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace qa_automation_mars.Utilities
{
    public class Wait
    {
        public static string waitToBeVisible(IWebDriver driver, int waitTimeMs, string elementXpathValue) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeMs));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath(elementXpathValue)
            ));
            return element.Text;
        }
    }
}
