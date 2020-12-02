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
using GmailAutomationTests.Other;

namespace OnlinerAutomationTests
{
    public class SearchPopup
    {
        private readonly IWebDriver driver;

        private readonly By searchFrame;

        private readonly By searchResultSection;

        private readonly By productPriceLink;

        private readonly By productImage;

        private readonly By imageWidget;

        private readonly By productTitleOnWidget;

        private readonly By productRateOnWidget;

        private readonly By productPriceOnWidget;
        
        private readonly By searchInputMessage;

        private readonly By searchResultList;

        private readonly By videoOnlyCheckBox;


        private string tabWithName = "//*[contains(text(),'{0}')]";


        readonly CommonActions commonActions;

        public SearchPopup(IWebDriver driver)
        {
            this.driver = driver;
            commonActions = new CommonActions(driver);

            searchFrame = By.ClassName("modal-iframe");
            searchResultSection = By.Id("search-page");
            productPriceLink = By.ClassName("product__price-value");
            productImage = By.ClassName("search__widget-image");
            imageWidget = By.ClassName("search__widget-information");
            productTitleOnWidget = By.ClassName("search__widget-title-link");
            productRateOnWidget = By.ClassName("rating");
            productPriceOnWidget = By.ClassName("search__widget-price-value");
            searchInputMessage = By.ClassName("search__suggest-addon_active");
            searchResultList = By.CssSelector(".search__results li");
            videoOnlyCheckBox = By.CssSelector(".search__filter-checkbox .i-checkbox__faux");
        }

        public void CheckAndSwitchToSearchFrame()
        {
            commonActions.SwitchToFrame(driver.FindElement(searchFrame));
            commonActions.IsElementVisible(driver.FindElement(searchResultSection));
        }

        public void ClickOnFirstItem()
        {
            driver.FindElement(productPriceLink).Click();
        }

        public void CheckTheTab(string tabName)
        {
            Assert.IsTrue(commonActions.IsElementWithNameVisible(tabName),
                String.Format(ErrorMessages.ElementWithNameIsNotVisible, tabName));
        }

        public void CheckIsProductImageVisible()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(productImage)),
                String.Format(ErrorMessages.ElementIsNotVisible, "Product image"));
        }

        public void HoverMouseOverToImage()
        {
            commonActions.HoverMouseOverToElement(driver.FindElement(productImage));
        }

        public void CheckIsImageWidgetVisible()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(imageWidget)),
                String.Format(ErrorMessages.ElementIsNotVisible, "Image widget"));
        }

        public void CheckIsProductTitleVisibleOnWidget()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(productTitleOnWidget)),
                String.Format(ErrorMessages.ElementIsNotVisible, "Product title"));
        }

        public void CheckIsProductRateVisibleOnWidget()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(productRateOnWidget)),
                String.Format(ErrorMessages.ElementIsNotVisible, "Product rate"));
        }

        public void CheckIsProductPriceVisibleOnWidget()
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(productPriceOnWidget)),
                String.Format(ErrorMessages.ElementIsNotVisible, "Product price"));
        }

        public void SwitchOnTab(string tabName)
        {
            string currentTab = String.Format(tabWithName, tabName);
            driver.FindElement(By.XPath(currentTab)).Click();
        }

        public void CheckMessageInsideSearchInput(string expectedMessage)
        {
            string actualMessage = driver.FindElement(searchInputMessage).Text;
            Assert.AreEqual(actualMessage, expectedMessage, 
                String.Format(ErrorMessages.IncorrectMessage, expectedMessage, actualMessage));
        }

        public void CheckIsSearhResultListIsNotPresent() 
        {
            Assert.IsFalse(commonActions.IsElementPresent(searchResultList), 
                String.Format(ErrorMessages.ElementPresent, "Search result list"));
        }

        public void CheckTheFilter(string filterName)
        {
            Assert.IsTrue(commonActions.IsElementWithNameVisible(filterName),
                String.Format(ErrorMessages.ElementWithNameIsNotVisible, filterName));
        }

        public void CheckIsVideoOnlyCheckboxVisible() 
        {
            Assert.IsTrue(commonActions.IsElementVisible(driver.FindElement(videoOnlyCheckBox)),   
                String.Format(ErrorMessages.ElementIsNotVisible, "Video only checkbox"));
        }
    }
}
