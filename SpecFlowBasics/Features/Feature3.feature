Feature: Feature3

A short summary of the feature

@tag1
Scenario: Select 'Sign in' and enter as many negative scenarios as possible
    Given I navigate to the login page
    When I attempt to sign in with invalid credentials
    Then I verify that an error message is displayed with the expected text
