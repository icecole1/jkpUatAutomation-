Feature: Delivery
	In order place orders using different delivery options
	As a customer
	I want to place an order using different delivery options available

@heartbeat @checkout @delivery @uk
Scenario Outline: customer delivery selection is displayed on the confirmation page for UK market
Given I am on the checkout page with a product in my basket
When I click on a UK <deliveryOption> delivery 
And I place an order
Then The confirmation page is displayed
Examples: 
| deliveryOption   |
| Standard         |
| Royal Mail       |
| Express          |
| Express Noon     |

@heartbeat @checkout @delivery @us
Scenario Outline: customer delivery selection is displayed on the confirmation page for US market
Given I am on the checkout page with a product in my basket
When I click on a US <deliveryOption> delivery 
And I place an order
Then The confirmation page is displayed
Examples: 
| deliveryOption |
| Standard       |
| Premium        |
| Express        |

@heartbeat @checkout @delivery @de
Scenario Outline: customer delivery selection is displayed on the confirmation page for DE market
Given I am on the checkout page with a product in my basket
When I click on a DE <deliveryOption> delivery 
And I place an order
Then The confirmation page is displayed
Examples: 
| deliveryOption |
| Standard       |
| Express        |

@heartbeat @checkout @delivery @fr
Scenario Outline: customer delivery selection is displayed on the confirmation page for FR market
Given I am on the checkout page with a product in my basket
When I click on a FR <deliveryOption> delivery 
And I place an order
Then The confirmation page is displayed
Examples: 
| deliveryOption |
| Standard       |
| Premium        |

@heartbeat @checkout @delivery @au
Scenario Outline: customer delivery selection is displayed on the confirmation page for AU market
Given I am on the checkout page with a product in my basket
When I click on a AU <deliveryOption> delivery 
And I place an order
Then The confirmation page is displayed
Examples: 
| deliveryOption |
| Standard       |

@checkout @delivery @uk
Scenario Outline: I am able to view a list of locations using click and collect delivery option for UK market
Given I have selected UK click and collect as a delivery method
When I enter a <postcode> postcode
Then the pickup locations are displayed
And the <postcode> is shown on the location result panel
Examples:
| postcode |
| NW10 6NY |

@checkout @delivery @de
Scenario Outline: I am able to view a list of locations using click and collect delivery option for DE market
Given I have selected DE click and collect as a delivery method
When I enter a <postcode> postcode
Then the pickup locations are displayed
And the <postcode> is shown on the location result panel
Examples:
| postcode |
| 13435    |

@checkout @delivery @fr
Scenario Outline: I am able to view a list of locations using click and collect delivery option for FR market
Given I have selected FR click and collect as a delivery method
When I enter a <postcode> postcode
Then the pickup locations are displayed
And the <postcode> is shown on the location result panel
Examples:
| postcode |
| 75016    |

@checkout @delivery @uk
Scenario Outline: validate the click and collect shows on the collection and delivery option panel for UK market
Given I have selected UK click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
Then the location is shown on the delivery options panel
And the location is displayed on the collection address panel
Examples:
| postcode |
| NW10 6NY |

@checkout @delivery @de
Scenario Outline: validate the click and collect shows on the collection and delivery option panel for DE market
Given I have selected DE click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
Then the location is shown on the delivery options panel
And the location is displayed on the collection address panel
Examples:
| postcode |
| 13435    |

@checkout @delivery @fr
Scenario Outline: validate the click and collect shows on the collection and delivery option panel for FR market
Given I have selected FR click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
Then the location is shown on the delivery options panel
And the location is displayed on the collection address panel
Examples:
| postcode |
| 75016    |

@checkout @delivery @uk
Scenario Outline: Place a Click and Collect order without entering delivery contact number for UK market
Given I have selected UK click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
And I continue on address panel and place order with <contactNumber> number
Then The confirmation page is displayed
Examples:
| postcode | contactNumber |
| NW10 6NY |               |
| NW10 6NY | 07953234253   |

@checkout @delivery @de
Scenario Outline: Place a Click and Collect order without entering delivery contact number for DE market
Given I have selected DE click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
And I continue on address panel and place order with <postNumber> number
Then The confirmation page is displayed
Examples:
| postcode | postNumber  |
| 13435    | 07953234253 |

@checkout @delivery @fr
Scenario Outline: Place a Click and Collect order without entering delivery contact number for FR market
Given I have selected FR click and collect as a delivery method
When I enter a <postcode> postcode
And I select a location
And I continue on address panel and place order with <contactNumber> number
Then The confirmation page is displayed
Examples:
| postcode | contactNumber  |
| 75016    | 07953234253 |