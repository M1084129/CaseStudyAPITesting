Feature: SpecFlowFeature1
	To test Case Study API

@mytag
Scenario: GET list of users
	When user send get request
	Then user should able to verify result

Scenario:  Post users
	When user send Post requests
	Then user should able to verify 

Scenario:  Delete users
	When user send Delete request
	Then user should able to delete the details and see success