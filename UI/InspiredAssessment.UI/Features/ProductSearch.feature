Feature: Product Search

  Background:
    Given the customer is on the shopping website

  @smoke @regression
  Scenario: Customer searches for an existing product
    When the customer navigates to the products page
    And the customer searches for "Blue Top"
    Then products matching "Blue Top" should be displayed

    Scenario: Customer searches for a product that does not exist
    When the customer navigates to the products page
    And the customer searches for "PlayStation 20"
    Then no matching products should be displayed