Feature: CheckOutTests
	In order to avoid overcharging our customers
	As a sales representative
	I want to be sure that the checkout screen calculates the right price

Scenario: Checkout a cart full of oranges and apples
	Given I have the following cart
		| Product | Quantity |
		| Oranges | 50       |
		| Apples  | 20       |
	When I checkout
	Then the price should be £24.50

Scenario Outline: Checkout random carts
	Given I have the following cart
		| Product     | Quantity     |
		| <Product 1> | <Quantity 1> |
		| <Product 2> | <Quantity 2> |
	When I checkout
	Then the price should be £<Final Price>
		Examples:
			| Test Type     | Product 1 | Quantity 1 | Product 2 | Quantity 2 | Final Price |
			| Both Products | Oranges   | 23         | Apples    | 54         | 38.15       |
			| Only Apples   | Oranges   | 0          | Apples    | 17         | 10.20       |
			| Only Oranges  | Oranges   | 33         | Apples    | 0          | 8.25        |

Scenario: Checkout using a predefined cart
	Given I am using a random cart
	When I checkout
	Then the price should be calculated

Scenario: Checkout an empty cart
	Given my cart is empty
	When I checkout
	Then the price should be £0