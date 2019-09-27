Feature: Education
	In order to update my profile 
	As a skill trader
	I want to add my education 

@mytag
Scenario: Check if user could able to add his education 
	Given I clicked on the Education tab under Profile page
	When I add a new education
	Then that education should be displayed on my listings
