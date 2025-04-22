using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using qa_automation_mars.Utilities;
using Reqnroll;

namespace qa_automation_mars
{
    [Binding]
    public class Hooks : CommonDriver
    {
        [BeforeScenario]
        public void Setup()
        {
            Console.WriteLine("Setup: Opening a new Chrome browser");
            driver = new ChromeDriver();
        }


        [AfterScenario]
        public void CloseTestRun()
        {
            Console.WriteLine("Teardown: Closing browser");
            driver.Quit();

        }
    }
}
