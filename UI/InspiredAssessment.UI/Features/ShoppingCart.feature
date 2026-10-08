@ui
Feature: Online Shopping Journey

  As an online customer
  I want to access the shopping website
  So that I can purchase products

  Background:
    Given the customer is on the shopping website

  @smoke
  Scenario: Customer can access the online shopping website
    Then the shopping website should be displayed


 Scenario: Customer adds a product to the shopping cart
    When the customer navigates to the products page
    And the customer adds "Blue Top" to the cart
    And the customer opens the shopping cart
    Then "Blue Top" should be displayed in the cart

  Scenario: Customer adds multiple products to the shopping cart
    When the customer navigates to the products page
    And the customer adds "Blue Top" to the cart
    And the customer continues shopping
    And the customer adds "Men Tshirt" to the cart
    And the customer opens the shopping cart
    Then "Blue Top" should be displayed in the cart
    And "Men Tshirt" should be displayed in the cart

Scenario: Customer removes a product from the shopping cart
    Given the customer has "Blue Top" in the shopping cart
    When the customer removes "Blue Top" from the cart
    Then "Blue Top" should not be displayed in the cart

Scenario: Customer adds multiple quantities of a product
    Given the customer is viewing the details for "Blue Top"
    When the customer changes the quantity to 4
    And the customer adds the product to the cart
    And the customer opens the shopping cart
    Then the quantity for "Blue Top" should be 4