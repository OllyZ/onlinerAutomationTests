using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GmailAutomationTests
{
    [Binding]
    public class Core
    {
        public static IWebDriver driver;

        private readonly IObjectContainer objectContainer;

        public Core(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        { 
            driver.Close();
            driver.Dispose();
        }
    }
}
