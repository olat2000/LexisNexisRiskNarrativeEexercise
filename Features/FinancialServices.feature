Feature: Financial Services

@Lexisnexis
Scenario:  Verify Financial Service page 
	Given Given user navigates to Lexisnexis website
 	Then user will arrive on the Lexisnexis home page
	When user click choose your industry tab
	And user select one of the industry links
	And user click on view financial services home
	Then user should see financial services home page displayed
	And user verify Financial Services header is displayed