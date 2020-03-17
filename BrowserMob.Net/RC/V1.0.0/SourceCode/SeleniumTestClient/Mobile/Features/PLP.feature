Feature: PLP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@plp
Scenario: The product listing page displays products
Given I am on the default product listing page
Then The page displays products

@plp
Scenario: The product listing page has the model view selected by default
Given I am on the default product listing page
Then The model view is selected by default

@plp
Scenario: The product listing page has the our favourites selected by default
Given I am on the default product listing page
Then The sort by has the our favourites selected by default