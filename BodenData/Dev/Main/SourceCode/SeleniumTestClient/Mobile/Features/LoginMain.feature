Feature: Login Main
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@heartbeat
Scenario: As a customer I can create an account
Given I am on the customer registration page
When I complete customer registration
Then The customer account is created

@heartbeat
Scenario: Login as a registered user
Given I am on the login page
When I enter my credentials to sign in
Then the logout option is displayed