Feature: ShoppingBasket
	In order to place an order
	As a customer
	I want to be able to add multiple item to my basket

@checkout @shoppingbag
Scenario Outline: The shopping basket contains the correct number of items 
Given I am on the product description page
When I add <numberOfProducts> products
Then The checkout page contains <numberOfProducts> products 
Examples:
| numberOfProducts |
| 1                |
| 2                |
| 3                |

@checkout @shoppingbag @uk
Scenario Outline: The basket has the correct value for the selected gift card for UK market
Given I have a <cardValue> UK gift card in the basket
When I go to the checkout page
Then The basket sub total value is <cardValue>
Examples: 
| cardValue |
| 10        |
| 20        |
| 50        |
| 100       |

@checkout @shoppingbag @us
Scenario Outline: The basket has the correct value for the selected gift card for US market
Given I have a <cardValue> US gift card in the basket
When I go to the checkout page
Then The basket sub total value is <cardValue>
Examples: 
| cardValue |
| 25        |
| 50        |
| 75        |
| 100       |
| 250       |

@checkout @shoppingbag @au
Scenario Outline: The basket has the correct value for the selected gift card for AU market
Given I have a <cardValue> AU gift card in the basket
When I go to the checkout page
Then The basket sub total value is <cardValue>
Examples: 
| cardValue |
| 25        |
| 50        |
| 75        |
| 100       |
| 250       |

#THIS ONE HAS NOT BEEN CODED FOR IN EITHER PROJECT!
#@checkout @shoppingbag
#Scenario Outline: Example
#Given I am on the <market> checkout page and have 1 or more items in my basket
#When I place an order with <offercode>
#Then dmnsmndmnsd  test
#Examples: 
#| market | offercode           |
#| UK     | 10pc                |
#| UK     | 30pc                |
#| UK     | 15PCFREERET         |
#| UK     | 10PCFREESHIPFREERET |
#| UK     | 15pcFreeShipFreeRet |
#| US     | dfksdfjklsdf        |
#| FR     | dfdfd               | 

@checkout @shoppingbag
Scenario: I want to remove all products from the shopping basket
Given I am on the checkout page with a product in my basket
When I remove all products from the basket
Then The basket is empty

@checkout @shoppingbag
Scenario: I want to remove a product from the shopping basket
Given I am on the checkout page and have 2 product(s) in the basket
When I remove 1 product(s)
Then I have 1 product(s) in the basket

@checkout @us
Scenario: As a customer with an Alabama delivery address the provisional tax label is displayed on checkout for US Market
Given I am on the checkout page with a product in my basket
When I enter Alabama as a delivery address
And I click to expand the shipping options
Then The provisional tax panel is displayed on checkout

@checkout @us
Scenario: As a customer with an Alabama delivery address the provisional tax label is displayed on the confirmation page for US Market
Given I am on the checkout page with a product in my basket
When I enter Alabama as a delivery address
And I place an order here
Then The provisional tax panel is displayed on the confirmation page

@checkout @uk
Scenario: As a customer with a Jersey delivery address there is no tax on checkout for UK market
Given I am on the checkout page with a product in my basket
When I enter Jersey as a delivery address
Then The provisional tax panel is not displayed on checkout

#@checkout @uk
#Scenario: As a customer with a Jersey delivery address there is no tax on the confirmation page for UK market
#Given I am on the checkout page with a product in my basket
#When I enter Jersey as a delivery address
#And I place an order here
#Then The provisional tax panel is not displayed on the confirmation page
#
#@checkout @uk
#Scenario: As a customer with an international delivery address the european delivery charge is displayed for UK market
#Given I am on the checkout page with a product in my basket
#When I enter an Italian delivery address
#And I place an order here
#Then The European delivery charge is displayed on the confirmation page
#
#@checkout @uk
#Scenario: As a customer with a Dutch delivery address the tax is added on for child items on checkout for UK market
#Given I am on the checkout page with a child product in my basket
#When I enter a Netherlands delivery address
#Then The child item final price is more expensive than the original price on checkout
#
#@checkout @uk
#Scenario: As a customer with a Dutch delivery address the tax is added on for child items on the confirmation page for UK market
#Given I am on the checkout page with a child product in my basket
#When I enter a Netherlands delivery address
#And I complete an order
#Then The child item final price is more expensive than the original price on the confirmation page