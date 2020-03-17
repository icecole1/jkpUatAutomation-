Feature: PDP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@pdp
Scenario: Selecting an item displays the add to bag button
Given I am on the product description page
When I select a product
Then The add to basket button is enabled

@pdp
Scenario: Adding an item to bag displays the bag overlay
Given I am on the product description page
When I select a product
And I click the add to bag button
Then The the bag overlay is displayed

@pdp @uk
Scenario: As a customer the trouser hemming modal is displayed in the UK market
Given I am on a hemming item product page
When I click the add to bag button
Then The trouser hemming modal is displayed

@pdp @uk
Scenario: As a customer I want to add a hemming item to the basket
Given I am on a hemming item product page
When I click the add to bag button
And I select a hemming option
Then the selected hemming item is added to the basket 