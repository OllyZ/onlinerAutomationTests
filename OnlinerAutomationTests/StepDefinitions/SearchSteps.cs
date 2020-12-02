using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace OnlinerAutomationTests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly MainPage mainPage;
        private readonly SearchPopup searchPopup;
        private readonly CommonActions commonActions;
        private readonly ProductPage productPage;

        public SearchSteps(IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            searchPopup = new SearchPopup(driver);
            productPage = new ProductPage(driver);
            commonActions = new CommonActions(driver);
        }
        
        [When(@"I enter ""(.*)"" in the search field")]
        public void EnterTextInSearchField(string text)
        {
            mainPage.EnterTextInSearchbox(text);
        }

        [Given(@"I am on the Main page")]
        public void NavigateToMainPage()
        {
            commonActions.OpenMainPage(TestData.siteUrl, TestData.siteTitle);
        }

        [Then(@"I am able to see the search result popup")]
        public void CheckSearchResultPopup()
        {
            searchPopup.CheckAndSwitchToSearchFrame();
        }

        [When(@"I click on the first item in the search result popup")]
        public void ClickOnFirstItemInResultPopup()
        {
            searchPopup.ClickOnFirstItem();
        }

        [Then(@"I am able to see opened product on the Product Page")]
        public void CheckTheProduct()
        {
            productPage.CheckProductTitle();
        }

        [Then(@"I am able to see ""(.*)"" tab")]
        public void ThenIAmAbleToSeeSpecificTab(string tabName)
        {
            searchPopup.CheckTheTab(tabName);
        }

        [Then(@"I am able to see image of the product")]
        public void ThenIAmAbleToSeeImageOfTheProduct()
        {
            searchPopup.CheckIsProductImageVisible();
        }

        [When(@"I hover mouse over to the image")]
        public void WhenIHoverOverTheImage()
        {
            searchPopup.HoverMouseOverToImage();
        }

        [When(@"I switch to ""(.*)"" tab")]
        public void WhenISwitchToTab(string tabName)
        {
            searchPopup.SwitchOnTab(tabName);
        }


        [Then(@"I am able to see product image widget")]
        public void ThenIAmAbleToSeeProductImageWidget()
        {
            searchPopup.CheckIsImageWidgetVisible();
        }

        [Then(@"Title is visible on the widget")]
        public void ThenTitleIsVisibleOnTheWidget()
        {
            searchPopup.CheckIsProductTitleVisibleOnWidget();
        }

        [Then(@"Rate is visible on the widget")]
        public void ThenRateIsVisibleOnTheWidget()
        {
            searchPopup.CheckIsProductRateVisibleOnWidget();
        }

        [Then(@"Price is visible on the widget")]
        public void ThenPriceIsVisibleOnTheWidget()
        {
            searchPopup.CheckIsProductPriceVisibleOnWidget();
        }

        [Then(@"""(.*)"" message is present in search input")]
        public void ThenMessageIsPresentInSearchInput(string message)
        {
            searchPopup.CheckMessageInsideSearchInput(message);
        }

        [Then(@"Search result list is empty")]
        public void ThenSearchResultListIsEmpty()
        {
            searchPopup.CheckIsSearhResultListIsNotPresent();
        }

        [Then(@"I am able to see ""(.*)"" filter")]
        public void ThenIAmAbleToSeeFilter(string filterName)
        {
            searchPopup.CheckTheFilter(filterName);
        }

        [Then(@"I am able to see Video only checkbox")]
        public void ThenIAmAbleToSeeVideoOnlyCheckbox()
        {
            searchPopup.CheckIsVideoOnlyCheckboxVisible();
        }

    }
}
