Feature: Address
	In order to enter different address for delivery and billing
	As customer
	I want the option to enter different addresses

@payment @address
Scenario: As a guest customer I can place an order by populating the delivery address manually
Given I am on the checkout page with a product in my basket
When I manually populate the checkout delivery details
And I continue through checkout and place the order
Then The confirmation page is displayed

@address @uk
Scenario: As a customer I want to lookup an address
Given I am on the address panel
When I enter a postcode lookup and select an address 
Then the address details are auto populated 

## TODO: remove @WIP once the address removal from customer account solution is implemented.
## as current test run are failing intermitently.
@ignore @checkout @address @WIP
Scenario: As a customer I want to change my billing address
Given I am on the checkout page with a product in my basket
When I log into my existing customer account
And I change my billing address
Then The new billing address shows in the collapsed Address box

## TODO: remove @WIP once the address removal from customer account solution is implemented.
## as current test run are failing intermitently.
@ignore @checkout @address @WIP
Scenario: As a customer I want to change my delivery address
Given I am on the checkout page with a product in my basket
When I log into my existing customer account
And I change my delivery Address
Then The new delivery address shows in the collapsed address box

#@WIP
#Scenario Outline: As a customer my delivery address can be changed in the checkout address panel
#Given I am on the checkout page with a product in my basket
#When I log into checkout with <email> and <password>
#And I click to expand the checkout address panel 
#And I add a new delivery address
#Then The collapsed delivery address panel displays the newly added address
#Examples: 
#| email                     | password   |
#| changeaddress@boden.co.uk | password1  |
#
#@WIP
#Scenario Outline: As a customer my billing address can be changed in the checkout address panel
#Given I am on the checkout page with a product in my basket
#When I log into checkout with <email> and <password>
#And I click to expand the checkout address panel 
#And I add a new billing address
#Then The collapsed billing address panel displays the newly added address
#Examples: 
#| email                     | password   |
#| changeaddress@boden.co.uk | password1  |