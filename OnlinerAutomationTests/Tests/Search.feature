Feature: Search
	In order to avoid defects
	As a user
	I want to be able to use search functionality on the Main page

Background:
	Given I am on the Main page

Scenario: Open Product Page from the Search
	When I enter "iphone" in the search field
	Then I am able to see the search result popup
	When I click on the first item in the search result popup
	Then I am able to see opened product on the Product Page

Scenario Outline: Check tabs in Search result popup
	When I enter "iphone" in the search field
	Then I am able to see the search result popup
	And I am able to see "<tabName>" tab
	Examples:
    | tabName      |
    | в каталоге   |
    | в новостях   |
    | на барахолке |
    | на форуме    |

Scenario: Check image widget in search result popup
	When I enter "iphone" in the search field
	Then I am able to see the search result popup
	When I switch to "на барахолке" tab
	Then I am able to see image of the product
	When I hover mouse over to the image
	Then I am able to see product image widget
	And Title is visible on the widget
	And Rate is visible on the widget
	And Price is visible on the widget

Scenario: Try to find non existing product
	When I enter "non existing product" in the search field
	Then I am able to see the search result popup
	And "Ничего не найдено" message is present in search input
	And I am able to see "в каталоге" tab
	And I am able to see "в новостях" tab
	And I am able to see "на барахолке" tab
	And I am able to see "на форуме" tab
	And Search result list is empty

Scenario Outline: Check filters in news section
	When I enter "iphone" in the search field
	Then I am able to see the search result popup
	When I switch to "в новостях" tab
	Then I am able to see "<filterName>" filter
	Examples:
	| filterName            |
	| В любом разделе     |
	| За полгода          |
	| Сначала релевантные |
		
Scenario: Check VideoOnly checkbox
	When I enter "iphone" in the search field
	Then I am able to see the search result popup
	When I switch to "в новостях" tab
	Then I am able to see Video only checkbox