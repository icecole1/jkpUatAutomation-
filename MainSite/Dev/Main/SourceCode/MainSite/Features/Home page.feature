Feature: Home page

Scenario: As a customer I can go to the join the mailing list page
Given I am on the home page
When I select join mailing list
Then you are taken to the join mailing list page

#Scenario: As a customer I can click the donate button to go to the donation page
#Given I am on the home page
#When I select the donate button 

Scenario: As a customer I can tell a friend about jkp films via facebook
Given I am on the home page
When I select the facebook tell a friend button

Scenario: As a customer I can tell a friend about jkp films via twitter
Given I am on the home page
When I select the twitter tell a friend button
Then a new window is opened for twitter sign in

Scenario: As a customer I can press about on the menu to go to the about page
Given I am on the home page
When i select the about button
Then i am taken to the about us page

Scenario: As a customer I can press the buy this UDOMNG ebook button, then i'm taken to its pdp page
Given I am on the home page
When I select the buy this ebook button
Then I am taken to the UDOMNG pdp page
#And the buy now button is displayed

Scenario: As a customer i can select our work on the menu bar and be taken to the our work page
Given I am on the home page
When i select the our work button on the menu bar
Then i am taken to the our work page


Scenario: As a customer i can select shop on the menu bar and be taken to the shop page
Given I am on the home page
When I select the shop button on the menu bar
Then I am taken to the Shoping Bag page

Scenario: As a customer i can select blog on the menu bar and be taken to the blob page
Given I am on the home page
When I select the blog button on the menu bar
Then I am taken to the blog page

Scenario: As a customer i can select free stuff on the menu bar and be taken to the free stuff page
Given I am on the home page
When i select the free stuff button on the menu bar
Then i am taken to the free stuff page

Scenario: As a customer i can select contact us on the menu bar and be taken to the contact page
Given I am on the home page
When i select the contact us button
Then i am taken to the contact us page
