Feature: Payment
	In order to place an order
	As a customer
	I want to be pay using multiple mehtods of payments

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

@checkout @payment
Scenario: As a registered customer with Account Credit the Account Credit panel is displayed 
Given I am on the checkout page with a product in my basket
When I enter my account credit credentials to sign in
Then The account credit panel is displayed

@checkout @payment
Scenario: As a registered customer I can place an order using Account Credit
Given I am on the checkout page with a product in my basket
When I enter my account credit credentials to sign in
And I click apply account credit to this order
And I click place order using account credit
Then The confirmation page is displayed

@checkout @payment
Scenario: I want to place an order with an offer code
Given I am on the checkout page with 1 or more product(s) in my basket
When I place an order with valid offer code
Then The confirmation page is displayed

## Need to find a product that is not already on sale and long expiry offer code
#@checkout @payment @uk
#Scenario Outline: I want to place an order with an offer code and make sure it is applied correctly for UK market
#Given I am on the checkout page with 1 or more product(s) in my basket
#When I place an order with <offerCode> offer code
#Then The checkout page is displayed with the <percent> applied to the total
#Examples: 
#|percent | offerCode |
#| 20     | ETXC      |

## Need to find a product that is not already on sale and long expiry offer code
#@checkout @payment @us
#Scenario Outline: I want to place an order with an offer code and make sure it is applied correctly for US market
#Given I am on the checkout page with 1 or more product(s) in my basket
#When I place an order with <offerCode> offer code
#Then The checkout page is displayed with the <percent> applied to the total
#Examples: 
#|percent | offerCode |
#| 20     | 9HCX      |

## Need to find a product that is not already on sale and long expiry offer code
#@checkout @payment @de
#Scenario Outline: I want to place an order with an offer code and make sure it is applied correctly for DE market
#Given I am on the checkout page with 1 or more product(s) in my basket
#When I place an order with <offerCode> offer code
#Then The checkout page is displayed with the <percent> applied to the total
#Examples: 
#|percent | offerCode |
#| 20     | PREM      |

## Need to find a product that is not already on sale and long expiry offer code
#@checkout @payment @de
#Scenario Outline: I want to place an order with an offer code and make sure it is applied correctly for FR market
#Given I am on the checkout page with 1 or more product(s) in my basket
#When I place an order with <offerCode> offer code
#Then The checkout page is displayed with the <percent> applied to the total
#Examples: 
#|percent | offerCode |
#| 20     | FRPR      |

## Waiting for AWS environment to be setup before completing this test as a sql script needs to be run to reset the vouchers for re-use.
#@payment @WIP 
#Scenario Outline: I want to place an order with a gift voucher
#Given I am on the checkout page and have 1 or more items in my basket
#When I place an order with <giftVoucher> gift voucher
#Then I am taken to the order confirmation page
#Examples:
#| giftVoucher	|
#| Q0TTFMGBVDJX	|

# Waiting for AWS environment to be setup before completing this test as a sql script needs to be run to reset the vouchers for re-use.
#@payment @WIP
#Scenario Outline: I want to place an order with mix payment
#Given I am on the checkout page and have 1 or more items in my basket
#When I add a <giftVoucher>
#And place an order with a valid credit card
#Then I am taken to the order confirmation page
#Examples:
#| giftVoucher	|
#| VQETGQ6F3B6U	|

#@payment
#Scenario Outline: I want to place an order with mix payment
#Given I am on the checkout page and have 1 or more items in my basket over the 100 in value
#When I place an order with <giftVoucher>
#And pay with PayPal
#Then I am taken to the order confirmation page
#Examples:
#| giftVoucher	|
#| VQETGQ6F3B6U	|

