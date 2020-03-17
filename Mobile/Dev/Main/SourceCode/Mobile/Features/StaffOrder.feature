Feature: StaffOrder
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

#Staff Scenarios to be run on UK & US only
#Not to run on PreProd due to Environment Issues

@staff 
Scenario: The staff toolbar is displayed on the top left for UK and US markets
Given I am on the checkout page with a product in my basket
When I log in using staff details
Then The staff toolbar is displayed

@staff 
Scenario: As a staff user Staff Credit the Credit panel is displayed for UK, US, markets
Given I am on the checkout page with a product in my basket
When I log in using staff details
Then The account credit panel is displayed

@staff 
Scenario: As a staff user I can place an order on UK and US markets
Given I am on the checkout page with a product in my basket
When I log in using staff details
And Place a staff order
Then The confirmation page is displayed 