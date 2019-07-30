Feature: ContactUs
	Test Contact Us by generating random 
	test data and filling up the form.

@mytag
Scenario: Test Secure Pay Contact US
	Given I Search for "SecurePay" on Google
	And Click on the link with the search link "https://www.securepay.com.au/" from the search results
	When Navigate to "ContactUs" page in the SecurePay website	
	Then Contact Us Page is loaded
	Given I generate random Contact test data 
	And Fill the Contact Details in the Contact Us form 
