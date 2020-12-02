using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace OnlinerAutomationTests
{
    public class MainPage
    {
        private readonly By searchInput;
        private readonly IWebDriver driver;

        readonly CommonActions commonActions;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            searchInput = By.ClassName("fast-search__input");
            commonActions = new CommonActions(driver);
        }

        public void EnterTextInSearchbox(string text)
        {
            driver.FindElement(searchInput).SendKeys(text);
        }

        

    }
}
