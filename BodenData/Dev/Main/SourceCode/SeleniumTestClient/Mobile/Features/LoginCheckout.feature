Feature: Login Checkout
	In order to place an order
	As as a registered or guest customer
	I want to be able to login with my credentials

@checkout @login
Scenario: As a guest customer the checkout contact details are empty 
Given I am on the guest checkout page with a product in my basket
When I click next to continue to contact details
Then The contact details are empty

@checkout @login @address
Scenario: As a guest customer the checkout billing details are empty
Given I am on the guest checkout page with a product in my basket
When I continue onto the checkout billing details section
Then The billing details are empty

@checkout @login @payment
Scenario: As a guest customer the checkout payments details are empty
Given I am on the guest checkout page with a product in my basket
When I continue onto the checkout payment details section
Then The payment details are empty


