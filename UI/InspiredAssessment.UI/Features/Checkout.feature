Feature: Checkout

  Background:
    Given the customer is on the shopping website

  Scenario: Unauthenticated customer attempts to checkout
    Given the customer has "Blue Top" in the shopping cart
    When the customer proceeds to checkout
    Then the customer should be prompted to register or login