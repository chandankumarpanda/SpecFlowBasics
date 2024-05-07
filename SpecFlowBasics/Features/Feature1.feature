Feature: Feature1

A short summary of the feature

@tag1
Scenario: Output all team names with a match today
    Given I navigate to the BBC website
    When I navigate to Scores & Fixtures - Football
    Then I record all team names playing today
