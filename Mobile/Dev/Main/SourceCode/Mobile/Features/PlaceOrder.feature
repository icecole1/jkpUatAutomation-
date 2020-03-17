Feature: PlaceOrder
	In order to place an Order
	As a customer
	I want to Login and place and Order and goto checkout and place an Order

@heartbeat
Scenario: Login and then place an order
Given I am on the login page
When I enter my credentials to sign in
And I place a pre-logged in order
Then The confirmation page is displayed

@heartbeat
Scenario: Go to checkout login and place an order
Given I am on the checkout page with a product in my basket
When I place an order
Then The confirmation page is displayed

@heartbeat @checkout
Scenario: As a registered customer I can place an order
Given I have a product in my shopping basket
When I place an order as a registered customer
Then The confirmation page is displayed

@heartbeat @payment
Scenario: As a guest customer I can place an order
Given I have a product in my shopping basket
When I place an order as a guest customer
Then The confirmation page is displayed

@checkout
Scenario: I want to place a guest order as a new guest customer and register
Given I have a product in my shopping basket
When I place an order as a new guest customer
And I register on the order complete register page
Then The confirmation page is displayed

@checkout
Scenario: I want to place a guest order as a new guest customer and go to order summary
Given I have a product in my shopping basket
When I place an order as a new guest customer
Then The confirmation page is displayed
