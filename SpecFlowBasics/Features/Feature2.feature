Feature: Feature2

A short summary of the feature

@tag1
Scenario: Use the search option to find all articles related to ‘sports’
    Given I navigate to the BBC Sport website
    When I search for articles related to 'sports'
    Then I output the first and last headings returned on the page