Feature: MenuBar

@heartbeat
Scenario Outline: As a customer I can use the menu bar to go to the different pages
Given I am on the <page>
When I select the about us menu tab
Examples: 
| Home    |  
| A |