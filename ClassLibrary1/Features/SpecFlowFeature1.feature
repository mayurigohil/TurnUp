Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@mytag
Scenario: Add new Time record
	Given User has logged in
	And on Time and Material page
	Then User should be able to add new time record with valid data

Scenario: Edit Time record
	Given User has logged in
	And on Time and Material page
	Then User should be able to edit time record

Scenario: Delete Time record
	Given User has logged in
	And on Time and Material page
	Then User should be able to Delete time record 

Scenario: Add new Customer record
	Given User has logged in
	And Customer page
	Then User should be able to Create new Customer record with valid data