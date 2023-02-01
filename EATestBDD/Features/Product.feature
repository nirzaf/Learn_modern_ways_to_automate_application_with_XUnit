Feature: Product
	Test the product page functionalities

Background:
	Given I cleanup following data
		| Name       | Description        | Price | ProductType |
		| Monitor    | HD monitor         | 400   | MONITOR     |
		| Headphones | Noise cancellation | 300   | PERIPHARALS |

@mytag @retry(4)
Scenario: Create product and verify the details
	Given I click the Product menu
	And I click the "Create" link
	And I create product with following details
		| Name       | Description        | Price | ProductType |
		| Headphones | Noise cancellation | 300   | PERIPHARALS |
	When I click the Details link of the newly created product
	Then I see all the product details are created as expected
	And I delete the product Headphones for cleanup


@mytag
Scenario: Edit Product and verify if its updated
	Given I ensure the following product is created
		| Name    | Description | Price | ProductType |
		| Monitor | HD monitor  | 400   | MONITOR     |
	Given I click the Product menu
	When I click the Edit link of the newly created product
	And I Edit the product details with following
		| Name    | Description           | Price | ProductType |
		| Monitor | HD Resolution monitor | 500   | MONITOR     |
	And I click the Details link of the newly created product
	Then I see all the product details are created as expected
	And I delete the product Monitor for cleanup