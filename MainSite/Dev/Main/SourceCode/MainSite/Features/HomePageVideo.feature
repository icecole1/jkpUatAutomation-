Feature: HomePageVideo

Scenario: As a customer i can watch the home page video
Given I am on the home page
When I play the home page video
Then the progress bar time is greater than 0

Scenario: As a customer I can share the home page video
Given I am on the home page
When I select the share video button
Then The share content panel is displayed 

Scenario: As a customer I can watch the home page video in full screen mode
Given I am on the home page
When I play the home page video
And I select full screen
Then the exit full screen  button is displayed

