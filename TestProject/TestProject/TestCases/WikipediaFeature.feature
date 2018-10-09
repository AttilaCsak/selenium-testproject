Feature: Wikipedia page test
	In order to test the Wikipedia page

Background: 
 Given I Navigate to the Wikipedia page

@Wikipedia
Scenario: WikipediaPageTest
When The 'Wikipedia' page is opened
	Then I set English language
	And I search for 'Test Automation' on main page
When The 'Test automation - Wikipedia' page is opened
	Then I check the 'Unit Testing' content on the page
	And I check the interface modul image on the page
	And I open the 'Behavior driven development' page
	And The 'Behavior-driven development - Wikipedia' page is opened
