Feature: Customer Authentication

  Background:
    Given the customer is on the shopping website

  @negative @regression
  Scenario: Customer attempts to login with invalid credentials
    When the customer opens the login page
    And the customer logs in with an invalid email and password
    Then an invalid login message should be displayed

@smoke @regression
Scenario: Registered customer logs in successfully
    When the customer opens the login page
    And the customer logs in with valid credentials
    Then the customer should be logged in successfully

Scenario: New customer registers successfully
    When the customer opens the signup page
    And the customer registers with valid details
    Then the customer account should be created successfully