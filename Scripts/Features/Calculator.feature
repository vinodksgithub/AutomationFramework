Feature: Launch Git portal

Simple calculator for adding two numbers

@mytag
Scenario: Login to git portal
	Given Launch Git URL 
	When User Inputs Username
	And User Inputs Password
	And User Clicks Login Button