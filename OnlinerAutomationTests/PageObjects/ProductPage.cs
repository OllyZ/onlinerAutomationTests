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
    public class ProductPage
    {
        private readonly By productTitle;
        private readonly IWebDriver driver;
        private readonly CommonActions commonActions;

        public ProductPage(IWebDriver driver) 
        {
            this.driver = driver;
            commonActions = new CommonActions(driver);
            productTitle = By.ClassName("catalog-masthead__title");
        }

        public void CheckProductTitle()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(productTitle)));
        }
    }
}
