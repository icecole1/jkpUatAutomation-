Feature: PayPalExpress
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	#This will currently only work on Test Environment due to live account and we do not wish to place orders !!!!

#@paypal @WIP
#Scenario: validate price on checkout matches the price on paypal login page
#Given I am on the checkout page with a product in the basket 
#When I click on PayPal Express
#Then the price on the checkout page matches the price on the Paylap Login Screen
#
#@paypal @WIP
#Scenario: validate price on login screen matches once logged in
#Given I am on PayPal login page
#When I log into PayPal
#Then the Price on the login page matches the price on the PayPal checkout page

## This scenario can only be test on a test environment so that orders are placed against the paypal sandbox environment.
#@paypal
#Scenario: validate paypal redirects back to checkout page when order is complete
#Given I am on Paypal payment page with a product in the basket
#When I click on pay now on paypal
#Then the price on the paypal page matches the price on the

## This scenario can only be test on a test environment so that orders are placed against the paypal sandbox environment.
#@paypal
#Scenario: validate total price matches on confirmation page
#Given I am on the checkout page with paypal payment added
#When I click on pay now on paypal
#Then the total price on the checkout page matches the total price on the order confirmation page
