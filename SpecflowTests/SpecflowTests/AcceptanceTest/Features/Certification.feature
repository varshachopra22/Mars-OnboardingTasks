Feature: Certification
	In order to update my profile 
	As a skill trader
	I want to add my certification that I have

@mytag
Scenario: Check if user could able to add his certification 
	Given I clicked on the Certification tab under Profile page
	When I add a new certification
	Then that certification should be displayed on my listings
