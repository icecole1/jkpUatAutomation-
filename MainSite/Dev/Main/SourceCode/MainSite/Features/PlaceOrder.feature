Feature: PlaceOrder
	In order to place an Order
	As a customer
	I want to Login and place and Order and goto checkout and place an Order

@heartbeat @checkout @payment
Scenario: As a registered customer I can place an order
Given I have a product in my shopping basket
#When I place an order as a registered customer
#Then The confirmation page is displayed
#
#@heartbeat @payment
#Scenario: As a guest customer I can place an order
#Given I have a product in my shopping basket
#When I place an order as a guest customer
#Then The confirmation page is displayed
#
#@heartbeat @mainsite
#Scenario: Login and then place an order
#Given I am on the login page
#When I enter my credentials to sign in
#And I place a pre-logged in order
#Then The confirmation page is displayed
#
#@heartbeat @mainsite
#Scenario: Go to checkout login and place an order
#Given I am on the checkout page with a product in my basket
#When I place an order
#Then The confirmation page is displayed
#
#@checkout
#Scenario: I want to place a guest order as a new guest customer and go to order summary
#Given I am on the checkout page with a product in my basket
#When I place an order as a new guest customer
#And I select order summary on the guest registration page
#Then The confirmation page is displayed
#
#@checkout
#Scenario: as a customer I want the last four digits of my credit card on the checkout to be the same as the Order confirmation
#Given I am on the checkout page with a product in my basket
#When I place an order
#Then The last four digits of my credit card is displayed on the confirmation page
#
#@heartbeat @checkout @payment
#Scenario Outline: As a registered customer after I place an order my shopping bag is empty
#Given I have a product in my shopping basket
#When I place an order as a registered customer
#And I select continue shopping
#Then The product detail page contains <numberOfProducts> products 
#Examples:
#| numberOfProducts |
#| 0                |
# 
# @heartbeat @checkout @payment
#Scenario: Go to security FAQ from checkout page link
#Given I am on the checkout page with a product in my basket
#When I select more about your security
#Then the security Faq page is displayed
#
#@heartbeat @checkout @payment
#Scenario: Open terms and conditions popup via checkout page link
#Given I am on the checkout page with a product in my basket
#When I select terms and conditions
#Then the terms and conditions are displayed in a popup window.
#
#
#
#
