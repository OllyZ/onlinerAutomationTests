using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OnlinerAutomationTests
{
    public class CommonActions
    {
        private readonly IWebDriver driver;

        private string elementWithName = "//*[contains(text(),'{0}')]";

        public CommonActions(IWebDriver driver) {
            this.driver = driver;
        }

        public void MaximazeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public bool CheckPage(string title)
        {
            return driver.Title.Equals(title);
        }

        public void OpenMainPage(string url, string title) {
            driver.Url = url;
            CheckPage(title);
        }

        public void NavigateToPage(string url, string title) {
            driver.Url = url;
            CheckPage(title);
        }

        public void ManageDriver() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        public void WaitForElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => element);
        }

        public void SwitchToFrame(IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        public void WaitForPageToLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void HoverMouseOverToElement(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementWithNameVisible(string elementName)
        {
            string currentFilter = String.Format(elementWithName, elementName);
            return IsElementVisible(driver.FindElement(By.XPath(currentFilter)));
        }
    } 
}
    

