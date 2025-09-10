Feature: Launch Git portal

Simple calculator for adding two numbers

@mytag
Scenario: Login to git portal
	Given Launch Git URL 
	And the second number is 70
	When the two numbers are added
	Then the result should be 120