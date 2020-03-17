Feature: CalculateBasket
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@checkout
Scenario: As a customer I want to ensure the total value of the items added match the value on the checkout
Given I have added an item to the bag on the PDP page
When I go to the checkout page
Then The Add to Bag value matched the checkout page value


@checkout @uk
Scenario Outline: As a customer I want to ensure that the delivery is added on correctly to the basket total for UK market
Given I am on the checkout page with a product in my basket
When I click on a UK <deliveryOption> delivery 
Then The sub total plus the delivery equals the total price
Examples: 
| deliveryOption   |
| Standard         |
| Royal Mail       |
| Express          |
| Express Noon     |

@checkout @us
Scenario Outline: As a customer I want to ensure that the delivery is added on correctly to the basket total for US market
Given I am on the checkout page with a product in my basket
When I click on a US <deliveryOption> delivery 
Then The sub total plus the delivery equals the total price
Examples: 
| deliveryOption   |
| Standard         |
| Premium          |
| Express          |

@checkout @de
Scenario Outline: As a customer I want to ensure that the delivery is added on correctly to the basket total for DE market
Given I am on the checkout page with a product in my basket
When I click on a DE <deliveryOption> delivery 
Then The sub total plus the delivery equals the total price
Examples: 
| deliveryOption   |
| Standard         |
| Express          |

@checkout @fr
Scenario Outline: As a customer I want to ensure that the delivery is added on correctly to the basket total for FR market
Given I am on the checkout page with a product in my basket
When I click on a FR <deliveryOption> delivery 
Then The sub total plus the delivery equals the total price
Examples: 
| deliveryOption   |
| Standard         |
| Premium          |

@checkout @au
Scenario Outline: As a customer I want to ensure that the delivery is added on correctly to the basket total for AU market
Given I am on the checkout page with a product in my basket
When I click on a AU <deliveryOption> delivery 
Then The sub total plus the delivery equals the total price
Examples: 
| deliveryOption   |
| Standard         |


@checkout
Scenario:  As a customer I want to ensure the value on the checkout page matches the confirmation page
Given I am on the checkout page with a product in my basket
When I place an order
Then the total value on the checkout page matches the total value on the confirmation page

